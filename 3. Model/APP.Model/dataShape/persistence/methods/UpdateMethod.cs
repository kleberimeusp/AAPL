using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace APP.Model.dataShape.persistence.methods
{
    public class UpdateMethod : TemplateMethod
    {
        private DbDao _dbDao;
        private DbCommand _command;
        private List<string> _list;

        public UpdateMethod(DbDao dbDao)
        {
            this._dbDao = dbDao;
            this._list = new List<string>();
        }

        public override void BuildDictionary(IDataShape model)
        {
            foreach (PropertyInfo property in model.GetProperties())
            {
                this._list.Add(String.Format("[{0}] = @{0}", property.Name));
            }
        }

        public override void MountQuery(IDataShape model)
        {
            string query = String.Format("UPDATE [{0}] SET {1} WHERE [Id] = @Id",
                                        model.GetType().Name,
                                        String.Join(", ", this._list.ToArray()));

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
            catch
            {
                return false;
            }
        }
    }
}
