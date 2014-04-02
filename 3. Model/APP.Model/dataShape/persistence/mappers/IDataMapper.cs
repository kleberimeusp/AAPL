using System.Data;

namespace APP.Model.dataShape.persistence.mappers
{
    public interface IDataMapper
    {
        object GetData(IDataReader reader);
    }
}
