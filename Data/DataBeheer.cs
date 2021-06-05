using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Data
{
    public class DataBeheer
    {
        internal class XmlField { public string Db { get; set; } public Type Type { get; set; } }

        // We leggen een overzichtstabel aan: xml tag, databank veldnaam, type:
        private static Dictionary<string, XmlField> _typeMap = new()
        {
            { "agiv:ID", new XmlField { Db = "ID", Type = typeof(UInt64) } },
            { "agiv:STRAATNMID", new XmlField { Db = "STRAATNMID", Type = typeof(UInt64) } },
            { "agiv:STRAATNM", new XmlField { Db = "STRAATNM", Type = typeof(string) } },
            { "agiv:HUISNR", new XmlField { Db = "HUISNR", Type = typeof(string) } },
            { "agiv:APPTNR", new XmlField { Db = "APPTNR", Type = typeof(string) } },
            { "agiv:BUSNR", new XmlField { Db = "BUSNR", Type = typeof(string) } },
            { "agiv:HNRLABEL", new XmlField { Db = "HNRLABEL", Type = typeof(string) } },
            { "agiv:NISCODE", new XmlField { Db = "NISCODE", Type = typeof(UInt64) } },
            { "agiv:GEMEENTE", new XmlField { Db = "GEMEENTE", Type = typeof(string) } },
            { "agiv:POSTCODE", new XmlField { Db = "POSTCODE", Type = typeof(UInt64) } },
            { "agiv:HERKOMST", new XmlField { Db = "HERKOMST", Type = typeof(string) } }
        };

        // We specificeren hoe een type afgeleid wordt van string naar het gevraagde type:
        private static Dictionary<Type, Func<string, object>> _conversionMap = new()
        {
            { typeof(string), (x => x) },
            { typeof(int), (x => Convert.ToInt32(x)) },
            { typeof(UInt64), (x => Convert.ToUInt64(x)) },
            { typeof(double), (x => Convert.ToDouble(x)) },
            { typeof(DateTime), (x => Convert.ToDateTime(x)) }
        };


        public void Inlezen()
        {
            SqlConnection conn = null;
            try
            {
                string connectionString = @"Data Source =.\SQLEXPRESS;Initial Catalog = eindWerk; Integrated Security = True";
                conn = new(connectionString);
                conn.Open();

                int addressCount = 0;
                var AddressTable = new DataTable("adres");
                var GemeenteTable = new DataTable("gemeente");
                var StraatTable = new DataTable("straat");
                var AdreslocatieTable = new DataTable("adreslocatie");
                foreach (var dbItem in _typeMap.Values)
                {
                    AddressTable.Columns.Add(dbItem.Db, dbItem.Type);
                    GemeenteTable.Columns.Add(dbItem.Db, dbItem.Type);
                    StraatTable.Columns.Add(dbItem.Db, dbItem.Type);
                    AdreslocatieTable.Columns.Add(dbItem.Db, dbItem.Type);
                }

                var myXmlReader = new XmlTextReader("gml/CrabAdr.gml");
                while (myXmlReader.ReadToFollowing("agiv:CrabAdr"))
                {
                    var fieldName = "?";
                    var v = "?";
                    try
                    {
                        var dradres = AddressTable.NewRow();
                        var drgemeente = GemeenteTable.NewRow();
                        var drstraat = StraatTable.NewRow();
                        var dradreslocatie = AdreslocatieTable.NewRow();

                        for (int i = 0; i < _typeMap.Keys.Count; i++)
                        {
                            fieldName = _typeMap.Keys.ElementAt(i);
                            bool elementFound;
                            if (i == 0)
                                elementFound = myXmlReader.ReadToDescendant(fieldName);
                            else
                                elementFound = myXmlReader.ReadToFollowing(fieldName);
                            if (elementFound)
                            {
                                v = myXmlReader.ReadInnerXml().Trim();
                                if (!string.IsNullOrEmpty(v))
                                {
                                    drgemeente[_typeMap.Values.ElementAt(i).Db] = _conversionMap[_typeMap.Values.ElementAt(i).Type](v);
                                    dradres[_typeMap.Values.ElementAt(i).Db] = _conversionMap[_typeMap.Values.ElementAt(i).Type](v);
                                    drstraat[_typeMap.Values.ElementAt(i).Db] = _conversionMap[_typeMap.Values.ElementAt(i).Type](v);
                                    dradreslocatie[_typeMap.Values.ElementAt(i).Db] = _conversionMap[_typeMap.Values.ElementAt(i).Type](v);
                                }
                            }
                        }
                        AddressTable.Rows.Add(dradres);
                        GemeenteTable.Rows.Add(drgemeente);
                        StraatTable.Rows.Add(drstraat);
                        AdreslocatieTable.Rows.Add(dradreslocatie);
                        addressCount++;
                    }

                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("Address " + addressCount + ", field " + fieldName + ", value " + v + ": " + e.Message);
                    }
                    System.Diagnostics.Debug.WriteLine(addressCount);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn?.Dispose();
                conn = null;
            }
        }
    }
}