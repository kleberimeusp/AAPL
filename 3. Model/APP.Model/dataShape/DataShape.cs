using APP.Model.dataShape.persistence;
using APP.Model.dataShape.persistence.methods;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace APP.Model.dataShape
{
    public class DataShape<T> : IDataShape where T : class
    {
        private DbDao _dbDao = new DbDao();
        private NullValue _nullValue = new NullValue();

        private TemplateMethod _templateMethod;

        public object this[string index]
        {
            get
            {
                return this.GetType().GetProperty(index).GetValue(this, null);
            }
            set
            {
                this.GetType().GetProperty(index).SetValue(this, value);
            }
        }

        public DataShape()
        {
            foreach (PropertyInfo property in this.GetProperties())
            {
                this[property.Name] = this._nullValue[property.PropertyType];
            }
        }

        public PropertyInfo[] GetProperties()
        {
            return Array.FindAll(this.GetType().GetProperties(), element =>

                    element.Name != "Item"

                && element.PropertyType.Namespace != this.GetType().Namespace
                && element.PropertyType.Namespace != "System.Collections.Generic"
                && element.PropertyType.Namespace != "System.Enum");
        }

        public virtual Object Insert()
        {
            this._templateMethod = new InsertMethod(this._dbDao);
            return this._templateMethod.Run(this);
        }

        public virtual Object Update()
        {
            this._templateMethod = new UpdateMethod(this._dbDao);
            return this._templateMethod.Run(this);
        }

        public virtual Object Delete()
        {
            this._templateMethod = new DeleteMethod(this._dbDao);
            return this._templateMethod.Run(this);
        }

        public virtual Object GetSingle()
        {
            this._templateMethod = new GetSingleMethod<T>(this._dbDao);
            return this._templateMethod.Run(this);
        }

        public virtual Object GetList()
        {
            this._templateMethod = new GetListMethod<T>(this._dbDao);
            return this._templateMethod.Run(this);
        }

        public virtual List<string> Validate()
        {
            return new List<String>();
        }
    }
}
