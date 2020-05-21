using System;
using System.IO;
using System.Web.Hosting;
using System.Xml.Serialization;

namespace CarService.DataAccess.Source
{
    [Serializable]
    public class XMLFileDataAccess : IFileDataAccess
    {

        public string Path {get;set;}
        public XMLFileDataAccess()
        {
            Path= System.Web.Hosting.HostingEnvironment.MapPath( @"~/App_Data/AutoServiceData.xml");
        }
        public AutoServiceModel GetModel()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AutoServiceModel));
            AutoServiceModel result;
            try
            {
                
                using (Stream reader = new FileStream(Path, FileMode.OpenOrCreate))
                {
                    // Call the Deserialize method to restore the object's state.
                    result = (AutoServiceModel)xmlSerializer.Deserialize(reader);
                    result.fileDataAccess = this;
                }
            }
            catch (Exception e)
            {
                result = new AutoServiceModel(this);
                SetModel(result);
            }
            return result;
        }

        public void SetModel(AutoServiceModel autoServiceModel)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AutoServiceModel));
            using (Stream writer = new FileStream(Path, FileMode.Create))
            {
                // Call the Deserialize method to restore the object's state.
                xmlSerializer.Serialize(writer, autoServiceModel);
            }
        }

    }
}
