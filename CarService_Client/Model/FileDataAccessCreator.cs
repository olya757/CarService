using System.IO;

namespace CarService_Client.Model
{
    public static class FileDataAccessCreator
    {
        public static IFileDataAccess GetFileDataAccess(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Extension == ".xml")
            {
                return new XMLFileDataAccess(path);
            }
            else
            {
                return new BinaryFileDataAccess(path);
            }
        }
    }
}
