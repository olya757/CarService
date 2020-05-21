using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Hosting;

namespace CarService.DataAccess.Source
{
    [Serializable]
    public class BinaryFileDataAccess:IFileDataAccess
    {
        public string Path { get; set; }
        public BinaryFileDataAccess()
        {
            Path = HostingEnvironment.MapPath(@"~/App_Data/AutoServiceData.dat");
        }
        public AutoServiceModel GetModel()
        {
            FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            AutoServiceModel result;
            try
            {
                result = (AutoServiceModel)formatter.Deserialize(fs);
                fs.Close();
            }
            catch (Exception e)
            {
                fs.Close();
                result = new AutoServiceModel(this);
                SetModel(result);
            }
            finally
            {
                //fs.Close();
            }
            return result;
        }
        public void SetModel(AutoServiceModel autoServiceModel)
        {
            FileStream fs = new FileStream(Path, FileMode.Create);
            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, autoServiceModel);
            fs.Close();
        }

    }
}
