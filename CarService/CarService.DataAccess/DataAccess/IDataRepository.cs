using System.Collections.Generic;

namespace CarService.DataAccess.DataAccess
{
    public interface IDataRepository<T>  where T: class
    {
        List<T> GetIndex(); // получение всех объектов
        T GetByID(int id); // получение одного объекта по id
        void Add(T item); // создание объекта
        void Update(T item, int id); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
