﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CarService_Client.Model
{
    [Serializable]
    public class BinaryFileDataAccess:IFileDataAccess
    {
        public string Path { get; set; }
        public BinaryFileDataAccess(string path)
        {
            Path = path;
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
            }
            catch (Exception e)
            {
                result = new AutoServiceModel(this);
            }
            finally
            {
                fs.Close();
            }
            return result;
        }
        public void SetModel(AutoServiceModel autoServiceModel)
        {
            FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, autoServiceModel);
            fs.Close();
        }

    }
}
