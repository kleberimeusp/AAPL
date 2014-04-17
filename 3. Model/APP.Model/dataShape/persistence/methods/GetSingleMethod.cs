using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace APP.Model.dataShape.persistence.methods
{
    public class GetSingleMethod<T> : TemplateMethod where T : class
    {
        private DbDao _dbDao;
        private DbCommand _command;
        private NullValue _nullValue;
        private List<string> _list;

        public GetSingleMethod(DbDao dbDao)
        {
            this._dbDao = dbDao;
            this._list = new List<string>();
            this._nullValue = new NullValue();
        }

        public override void BuildDictionary(IDataShape model)
        {
            foreach (PropertyInfo property in model.GetProperties())
            {
                if (!this._nullValue.IsNull(model[property.Name]))
                {
                    this._list.Add(String.Format("[{0}] = @{0}", property.Name));
                }
            }
        }

        public override void MountQuery(IDataShape model)
        {
            string query = String.Format("SELECT * FROM [{0}] WHERE {1}",
                                        model.GetType().Name,
                                        String.Join(" AND ", this._list.ToArray()));

            this._command = this._dbDao.GetSqlCommand(query);
        }

        public override void AddParameter(IDataShape model)
        {
            foreach (PropertyInfo property in model.GetProperties())
            {
                if (!this._nullValue.IsNull(model[property.Name]))
                {
                    this._command.Parameters.Add(this._dbDao.CreateParameter(String.Format("@{0}", property.Name), model[property.Name]));
                }
            }
        }

        public override Object Execute()
        {
            try
            {
                return this._dbDao.GetSingle<T>(this._command);
            }
            catch
            {
                return Activator.CreateInstance<T>();
            }
        }
    }
}
