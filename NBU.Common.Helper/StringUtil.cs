using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Security.Cryptography;
using System.Xml;
using System.IO;
using System.Text;

using Newtonsoft.Json;

namespace NBU.Common.Helper
{
    public static class StringUtil
    {
        public static string Encode(string plainText)
        {
            return System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(plainText));
        }

        public static string Decode(string cipherText)
        {
            return System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(cipherText));
        }

        public static string ToUpperFirst(string str)
        {
            string firstUpperString = string.Empty;

            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            string[] strArr = str.Split(' ');
            foreach (string s in strArr)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    char[] a = s.ToLower().ToCharArray();
                    a[0] = char.ToUpper(a[0]);
                    firstUpperString = firstUpperString + " " + new string(a);
                }
            }

            return firstUpperString;
        }

        public static Object DeserializeObjectFromXML(string strInputXML, Type objectType)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer;

            UTF8Encoding utfEncodingObject = new UTF8Encoding();
            Byte[] utfByteArray = utfEncodingObject.GetBytes(strInputXML);

            System.IO.MemoryStream ms = new System.IO.MemoryStream(utfByteArray);
            System.Xml.XmlTextWriter xmlTxtWriter = new System.Xml.XmlTextWriter(ms, Encoding.Unicode);
            xmlSerializer = new System.Xml.Serialization.XmlSerializer(objectType);

            return xmlSerializer.Deserialize(ms);
        }

        public static string SerializeObjectToXML(Object obj, Type objectType)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer;
            xmlSerializer = new System.Xml.Serialization.XmlSerializer(objectType);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(ms, System.Text.Encoding.UTF8);
            xmlTextWriter.Formatting = System.Xml.Formatting.Indented;
            xmlSerializer.Serialize(xmlTextWriter, obj);
            ms = (System.IO.MemoryStream)xmlTextWriter.BaseStream;
            string strOutputXML = System.Text.Encoding.UTF8.GetString(ms.ToArray());

            return strOutputXML;
        }

        public static string SerializeObjectToJSON(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeObjectFromJSON<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}