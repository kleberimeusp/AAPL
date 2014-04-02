using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace APP.Model.dataShape.persistence.mappers
{
    public class DataMapper : IDataMapper
    {
        private IDataShape Model { get; set; }

        private bool IsInitialized = false;
        private List<int> OrdinalMappings = new List<int>();

        public DataMapper(Type type)
        {
            this.Model = this.CreateInstance(type);
        }

        private IDataShape CreateInstance(Type type)
        {
            return Activator.CreateInstance(type) as IDataShape;
        }

        protected void InitializeMapper(IDataReader reader)
        {
            this.PopulatePropertyOrdinalMappings(reader);
            this.IsInitialized = true;
        }

        protected void PopulatePropertyOrdinalMappings(IDataReader reader)
        {
            foreach (PropertyInfo property in this.Model.GetProperties())
            {
                this.OrdinalMappings.Add(reader.GetOrdinal(property.Name));
            }
        }

        public object GetData(IDataReader reader)
        {
            if (this.IsInitialized.Equals(false))
            {
                this.InitializeMapper(reader);
            }

            IDataShape model = this.CreateInstance(this.Model.GetType());

            foreach (int map in this.OrdinalMappings)
            {
                if (!reader.IsDBNull(map))
                {
                    model[reader.GetName(map)] = reader.GetValue(map);
                }
            }

            return model;
        }
    }
}
