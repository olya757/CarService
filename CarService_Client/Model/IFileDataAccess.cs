using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService_Client.Model
{
    public interface IFileDataAccess
    {
        string Path { get; set; }
        AutoServiceModel GetModel();
        void SetModel(AutoServiceModel autoServiceModel);
    }
}
