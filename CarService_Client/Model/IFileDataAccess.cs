
namespace CarService_Client.Model
{
    public interface IFileDataAccess
    {
        string Path { get; set; }
        AutoServiceModel GetModel();
        void SetModel(AutoServiceModel autoServiceModel);
    }
}
