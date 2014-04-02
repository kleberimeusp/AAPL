using System;

namespace APP.Model.dataShape.persistence.mappers
{
    public class DataMapperCreator : IDataMapperCreator
    {
        public IDataMapper Create(Type dto)
        {
            switch (dto.Name)
            {
                default:
                    return new DataMapper(dto);
            }
        }
    }
}
