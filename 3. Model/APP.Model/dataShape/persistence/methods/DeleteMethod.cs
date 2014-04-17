using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace APP.Model.dataShape.persistence.methods
{
    public class DeleteMethod : TemplateMethod
    {
        private DbDao _dbDao;
        private DbCommand _command;
        private NullValue _nullValue;
        private List<string> _list;

        public DeleteMethod(DbDao dbDao)
        {
            this._dbDao = dbDao;
            this._list = new List<string>();
            this._nullValue = new NullValue();
        }

        public override void BuildDictionary(IDataShape model)
        {
            this._list.Add("[Id] = @Id");
        }

        public override void MountQuery(IDataShape model)
        {
            string query = String.Format("DELETE FROM [{0}] WHERE {1}",
                                        model.GetType().Name,
                                        String.Join(", ", this._list.ToArray()));

            this._command = this._dbDao.GetSqlCommand(query);
        }

        public override void AddParameter(IDataShape model)
        {
            this._command.Parameters.Add(this._dbDao.CreateParameter("@Id", model["Id"]));
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
