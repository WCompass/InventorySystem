
namespace IDataAccess
{
    public interface IBaseAccess<T> where T : DataObjects.BaseDataObject, new()
    {
        bool Create(T model);
        bool Update(T model);
        bool Delete(int id);
        bool Disable(int id);
        T GetDataObject(int id);
    }
}
