using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NBU.EmpWebService.ServiceObjects
{
    [Serializable]
    public abstract class BaseSTO
    {
        private string updateUserID;

        public string UpdateUserID
        {
            get { return updateUserID; }
            set { updateUserID = value; }
        }

        private string bussinessErrorMsg;

        public string BussinessErrorMsg
        {
            get { return bussinessErrorMsg; }
            set { bussinessErrorMsg = value; }
        }
        
        public string ToXML(Type objectType)
        {
            XmlDocument xmlDocumentObject = new XmlDocument();
            XmlSerializer xmlSerializerObject = new XmlSerializer(objectType);
            MemoryStream memoryStreamObject = new MemoryStream();
            try
            {
                xmlSerializerObject.Serialize(memoryStreamObject, this);
                memoryStreamObject.Position = 0;
                xmlDocumentObject.Load(memoryStreamObject);
                memoryStreamObject.Close();
                memoryStreamObject.Dispose();
                return xmlDocumentObject.InnerXml;
            }
            catch
            {
                throw;
            }
        }
    }
}
