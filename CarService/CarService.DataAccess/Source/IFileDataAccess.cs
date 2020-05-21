
namespace CarService.DataAccess.Source
{
    public interface IFileDataAccess
    {
        string Path { get; set; }
        AutoServiceModel GetModel();
        void SetModel(AutoServiceModel autoServiceModel);
    }
}
