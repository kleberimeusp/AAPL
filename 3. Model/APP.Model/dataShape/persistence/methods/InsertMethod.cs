using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace APP.Model.dataShape.persistence.methods
{
    public class InsertMethod : TemplateMethod
    {
        private DbDao _dbDao;
        private DbCommand _command;
        private Dictionary<string, string> _dictionary;

        public InsertMethod(DbDao dbDao)
        {
            this._dbDao = dbDao;
            this._dictionary = new Dictionary<string, string>();
        }

        public override void BuildDictionary(IDataShape model)
        {
            foreach (PropertyInfo property in model.GetProperties())
            {
                this._dictionary.Add(String.Format("[{0}]", property.Name), String.Format("@{0}", property.Name));
            }
        }

        public override void MountQuery(IDataShape model)
        {
            string query = String.Format("INSERT INTO [{0}] ( {1} ) VALUES ( {2} )",
                                        model.GetType().Name,
                                        String.Join(", ", this._dictionary.Keys),
                                        String.Join(", ", this._dictionary.Values));

            this._command = this._dbDao.GetSqlCommand(query);
        }

        public override void AddParameter(IDataShape model)
        {
            foreach (PropertyInfo property in model.GetProperties())
            {
                this._command.Parameters.Add(this._dbDao.CreateParameter(String.Format("@{0}", property.Name), model[property.Name]));
            }
        }

        public override Object Execute()
        {
            try
            {
                this._dbDao.ExecuteNonQuery(this._command);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
