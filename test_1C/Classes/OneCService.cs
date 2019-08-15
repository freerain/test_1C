using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using test_1C.ServiceReference1;

namespace test_1C.Classes
{
    public class OneCService
    {


        public static string GetTableOneCData(string funcName, ref Dictionary<string, string> spars, ref List<List<Dictionary<string, string>>> tpars)
        {
            //добавление строк
            ОписаниеСтроки strDesc = new ОписаниеСтроки();
            ОписаниеЗначения valDesc;

            foreach (var item in spars)
            {
                valDesc = new ОписаниеЗначения();
                valDesc.Наименование = item.Key;
                valDesc.Значение = item.Value;
                strDesc.Add(valDesc);
            }
            Dictionary<string, string> result = new Dictionary<string, string>();

            //добавление таблиц
            СписокТаблиц tables = new СписокТаблиц();
            ОписаниеТаблицы tablDesc;
            ОписаниеСтроки strDescT;
            foreach (var table in tpars)
            {
                tablDesc = new ОписаниеТаблицы();
                foreach (var str in table)
                {
                    strDescT = new ОписаниеСтроки();
                    foreach (var item in str)
                    {
                        valDesc = new ОписаниеЗначения();
                        valDesc.Наименование = item.Key;
                        valDesc.Значение = item.Value;
                        strDescT.Add(valDesc);
                    }
                    tablDesc.Add(strDescT);
                }
                tables.Add(tablDesc);
            }

            spars.Clear();
            tpars.Clear();

            //возврат строк
            string returnString = GetOneCData(funcName, ref strDesc, ref tables);
            foreach (ОписаниеЗначения val in strDesc)
            {
                spars.Add(val.Наименование, val.Значение);
            }

            //возврат таблиц
            foreach (ОписаниеТаблицы table in tables)
            {
                List<Dictionary<string, string>> ld = new List<Dictionary<string, string>>();
                foreach (ОписаниеСтроки str in table)
                {
                    Dictionary<string, string> d = new Dictionary<string, string>();
                    foreach (ОписаниеЗначения item in str)
                    {
                        d.Add(item.Наименование, item.Значение);
                    }
                    ld.Add(d);
                }
                tpars.Add(ld);
            }
            return returnString;
        }


        public static string GetOneCData(string funcName, ref ОписаниеСтроки strDesc, ref СписокТаблиц tables)
        {
            WebServiceCommonPortTypeClient client = new WebServiceCommonPortTypeClient();
            var login = "";
            var res = client.WebServiceCommonFunction(login, funcName, ref strDesc, ref tables);


            //StringBuilder sb = new StringBuilder();
            //StringWriter w = new StringWriter(sb, System.Globalization.CultureInfo.InvariantCulture);
            //new XmlSerializer(typeof(СписокТаблиц))
            //    .Serialize(w, tables);
            //string xml_request = sb.ToString();


            //XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfArrayOfArrayOfОписаниеЗначения));
            //StreamReader reader = new StreamReader(xml_request);
            //ArrayOfArrayOfArrayOfОписаниеЗначения cars = (ArrayOfArrayOfArrayOfОписаниеЗначения)serializer.Deserialize(reader);
            //reader.Close();


            return res;
        }

    }
}