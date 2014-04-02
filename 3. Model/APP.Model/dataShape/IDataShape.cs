using System.Reflection;

namespace APP.Model.dataShape
{
    public interface IDataShape
    {
        object this[string index] { get; set; }

        PropertyInfo[] GetProperties();

        Response Insert();
        Response Update();
        Response Delete();

        Response GetSingle();
        Response GetList();
    }
}
