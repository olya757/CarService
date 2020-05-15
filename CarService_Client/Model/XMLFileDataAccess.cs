using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarService_Client.Model
{
    [Serializable]
    public class XMLFileDataAccess:IFileDataAccess
    { 

        public string Path { get; set; }
        public XMLFileDataAccess(string path)
        {
            Path = path;
        }
        public AutoServiceModel GetModel()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AutoServiceModel));
            AutoServiceModel result;
            try
            {
                
                using (Stream reader = new FileStream(Path, FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                    result = (AutoServiceModel)xmlSerializer.Deserialize(reader);
                    result.fileDataAccess = this;
                }
            }
            catch (Exception e)
            {
                result = new AutoServiceModel(this);
                result.fileDataAccess = this;
            }
            return result;
        }

        public void SetModel(AutoServiceModel autoServiceModel)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AutoServiceModel));
            using (Stream writer = new FileStream(Path, FileMode.OpenOrCreate))
            {
                // Call the Deserialize method to restore the object's state.
                xmlSerializer.Serialize(writer, autoServiceModel);
            }
        }

    }
}
