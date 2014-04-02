using System;

namespace APP.Model.dataShape.persistence.mappers
{
    public interface IDataMapperCreator
    {
        IDataMapper Create(Type dto);
    }
}
