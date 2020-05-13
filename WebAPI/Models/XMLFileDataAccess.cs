using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebAPI.Models
{
    public class XMLFileDataAccess
    {
        public static string Path = @"~/App_Data/AutoServiceData.xml";
        public static AutoServiceModel GetModel()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AutoServiceModel));
            AutoServiceModel result;
            try
            {
                var res = System.Web.Hosting.HostingEnvironment.MapPath(Path);
                using (Stream reader = new FileStream(res, FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                    result = (AutoServiceModel)xmlSerializer.Deserialize(reader);
                }
            }
            catch(Exception e)
            {
                result = new AutoServiceModel();
            }
            return result;
        }

        public static void SetModel(AutoServiceModel autoServiceModel)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AutoServiceModel));
            var res = System.Web.Hosting.HostingEnvironment.MapPath(Path);
            using (Stream writer = new FileStream(res, FileMode.OpenOrCreate))
            {
                // Call the Deserialize method to restore the object's state.
                xmlSerializer.Serialize(writer, autoServiceModel);
            }
        }

    }
}