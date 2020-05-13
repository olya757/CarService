using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace WebAPI.Models
{
    public class BinaryFileDataAccess
    {
        public static string Path = @"~/App_Data/AutoServiceData.dat";
        public static AutoServiceModel GetModel()
        {
            var res = System.Web.Hosting.HostingEnvironment.MapPath(Path);
            FileStream fs = new FileStream(res, FileMode.OpenOrCreate);
            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            AutoServiceModel result;
            try
            {
                result = (AutoServiceModel)formatter.Deserialize(fs);
                
            }
            catch (Exception e)
            {
                result = new AutoServiceModel();
            }
            return result;
        }
        public static void SetModel(AutoServiceModel autoServiceModel)
        {
            var res = System.Web.Hosting.HostingEnvironment.MapPath(Path);
            FileStream fs = new FileStream(res, FileMode.OpenOrCreate);
            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, autoServiceModel);
        }

    }
}