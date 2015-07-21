using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Data;
using System.Reflection;
using STIS.Framework.V4;
using System.Collections;

namespace WA.Standard.IF.Biz.Util
{
    public class DataHelper
    {
        public static string ObjectToXml(object obj)
        {
            if (obj != null)
            {
                string xmlString = null;
                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(memoryStream, obj);
                    memoryStream.Position = 0;
                    xmlString = new StreamReader(memoryStream).ReadToEnd();
                }

                return Sort(xmlString).ToString();
            }
            else
            {
                return null;
            }
        }

        private static XElement Sort(XElement element)
        {

            return new XElement(element.Name,
                    element.Attributes(),
                    from child in element.Nodes()
                    where child.NodeType != XmlNodeType.Element
                    select child,
                    from child in element.Elements()
                    orderby child.Name.ToString()
                    select Sort(child));
        }

        private static XDocument Sort(string xml)
        {
            XDocument doc = XDocument.Parse(xml);

            return new XDocument(
                    doc.Declaration,
                    from child in doc.Nodes()
                    where child.NodeType != XmlNodeType.Element
                    select child,
                    Sort(doc.Root));
        }

        public static List<T> ConvertToList<T>(DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }

        private static T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();

            string columnname = "";
            string value = "";
            PropertyInfo[] Properties;
            Properties = typeof(T).GetProperties();
            foreach (PropertyInfo objProperty in Properties)
            {
                columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                if (!string.IsNullOrEmpty(columnname))
                {
                    value = row[columnname].ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                        {
                            try
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");

                                if (objProperty.PropertyType.Name == "Boolean" || objProperty.PropertyType.Name == "bool")
                                {
                                    bool changeValue = CommonLib.IsNullBool(CommonLib.IsNullInt32(value));
                                    objProperty.SetValue(obj, Convert.ChangeType(changeValue, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                                }
                                else
                                {
                                    if (row[columnname].GetType().Name == "DateTime")
                                    {
                                        objProperty.SetValue(obj, TimeZone.CurrentTimeZone.ToUniversalTime(CommonLib.IsNullDateTime(value)), null);
                                        //objProperty.SetValue(obj, CommonLib.IsNullDateTime(value), null);
                                        //objProperty.SetValue(obj, CommonLib.IsNullDateTime(value).ToString("yyyy-MM-dd"), null);
                                    }
                                    else
                                    {
                                        objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            try
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                if (objProperty.PropertyType.Name == "Boolean")
                                {
                                    bool changeValue = CommonLib.IsNullBool(CommonLib.IsNullInt32(value));
                                    objProperty.SetValue(obj, Convert.ChangeType(changeValue, Type.GetType(objProperty.PropertyType.ToString())), null);
                                }
                                else
                                {
                                    if (row[columnname].GetType().Name == "DateTime")
                                    {
                                        objProperty.SetValue(obj, TimeZone.CurrentTimeZone.ToUniversalTime(CommonLib.IsNullDateTime(value)), null);
                                        //objProperty.SetValue(obj, CommonLib.IsNullDateTime(value), null);
                                        //objProperty.SetValue(obj, CommonLib.IsNullDateTime(value).ToString("yyyy-MM-dd"), null);
                                    }
                                    else
                                    {
                                        objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
            return obj;
        }

        public static void AppendNewNode(ref XmlDocument xml, ref XmlNodeList targetnodelist, string value, string nodename)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, nodename, null);
            node.InnerText = value;
            targetnodelist[0].AppendChild(node);
        }

        public static string GetDescendantsNodeByNameSpace(string xml, string xmlnamespace, string xmlnamespacename)
        {
            string descendantsxml = string.Empty;
            foreach (var node in XDocument.Parse(xml).Descendants((XNamespace)xmlnamespace + xmlnamespacename))
                descendantsxml += node.ToString();

            return descendantsxml;
        }

        public static string GetDescendantsNodeByElementName(string xml, string elementname)
        {
            string descendantsxml = string.Empty;
            foreach (var node in XDocument.Parse(xml).Descendants(elementname))
                descendantsxml += node.ToString();

            return descendantsxml;
        }

        public static string GetChild(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            return doc.DocumentElement.InnerXml;
        }

        public static Dictionary<string, string> ConvertXDoctoDic(XDocument xml)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (XElement element in xml.Descendants().Where(p => p.HasElements == false))
            {
                int keyInt = 0;
                string keyName = element.Name.LocalName;

                while (dic.ContainsKey(keyName))
                    keyName = element.Name.LocalName + "_" + keyInt++;

                dic.Add(keyName, element.Value);
            }

            return dic;
        }

        public static string GetValueByElementName(string xml, string elementName)
        {
            XDocument doc = XDocument.Parse(xml);

            foreach (XNode node in doc.DescendantNodes())
            {
                if (node is XElement)
                {
                    XElement element = (XElement)node;
                    if (element.Name.LocalName == (elementName))
                        return element.Value;
                }
            }
            return null;
        }

        public static List<T> GetListByElementName<T>(string fileName, string rootName)
        {
            List<T> rtnList = new List<T>();
            XDocument doc = XDocument.Load(fileName);

            foreach (XNode node in doc.DescendantNodes())
            {
                if (node is XElement)
                {
                    XElement element = (XElement)node;
                    if (element.Name.LocalName == (rootName))
                    {
                        T rtnClass = XMLParseToClass<T>(element.ToString());
                        rtnList.Add(rtnClass);
                    }
                }
            }
            return rtnList;
        }

        public static T XMLParseToClass<T>(string xml)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(xml);
            MemoryStream stream = new MemoryStream(byteArray);
            StreamReader reader = new StreamReader(stream);
            XmlSerializer serializer;
            serializer = new XmlSerializer(typeof(T));
            T model = (T)serializer.Deserialize(reader);
            reader.Close();

            return model;
        }

        public static DateTime ConvertStrToDateTime(string dateTimeStr, string dateFormat)
        {
            try
            {
                return DateTime.ParseExact(dateTimeStr, dateFormat, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                return new DateTime();
            }
        }

        public static DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            if (dTable.Rows.Count > 0)
            {
                //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
                //And add duplicate item value in arraylist.
                foreach (DataRow drow in dTable.Rows)
                {
                    if (hTable.Contains(drow[colName]))
                        duplicateList.Add(drow);
                    else
                        hTable.Add(drow[colName], string.Empty);
                }

                //Removing a list of duplicate items from datatable.
                foreach (DataRow dRow in duplicateList)
                    dTable.Rows.Remove(dRow);
            }

            //Datatable which contains unique records will be return as output.
            return dTable;
        }

        public static DateTime ConvertObjectToDateTime(object obj)
        {
            DateTime rtn;
            try
            {
                rtn = Convert.ToDateTime(obj);
            }
            catch
            {
                rtn = new DateTime();
            }

            return rtn;
        }

        public static string ConvertObjectToString(object obj, string defaultvalue)
        {
            string rtn;
            try
            {
                rtn = Convert.ToString(obj);
            }
            catch
            {
                rtn = defaultvalue;
            }

            return rtn;
        }

        public static string ConvertObjectToString(object obj)
        {
            string rtn;
            try
            {
                rtn = Convert.ToString(obj);
            }
            catch
            {
                rtn = string.Empty;
            }

            return rtn;
        }

        public static int ConvertObjectToInt(object obj)
        {
            int rtn;
            try
            {
                rtn = Convert.ToInt32(obj);
            }
            catch
            {
                rtn = 0;
            }

            return rtn;
        }

        public static double ConvertObjectToDouble(object obj)
        {
            double rtn;
            try
            {
                rtn = Convert.ToDouble(obj);
            }
            catch
            {
                rtn = 0;
            }

            return rtn;
        }

    }
}