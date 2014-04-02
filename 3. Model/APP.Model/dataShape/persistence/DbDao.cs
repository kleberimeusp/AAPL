using APP.Model.dataShape.persistence.mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace APP.Model.dataShape.persistence
{
    public class DbDao
    {
        private ConnectionStringSettings _connectionString;
        private DbConnection _sharedConnection;

        private NullValue _nullValue = new NullValue();
        private DbValue _dbValue = new DbValue();

        private DbConnection SharedConnection
        {
            get
            {
                if (this._sharedConnection == null)
                {
                    this._sharedConnection = Factory.CreateConnection();
                    this._sharedConnection.ConnectionString = this._connectionString.ConnectionString;
                }

                return this._sharedConnection;
            }
            set
            {
                this._sharedConnection = value;
            }
        }

        private DbProviderFactory Factory
        {
            get
            {
                return DbProviderFactories.GetFactory(_connectionString.ProviderName);
            }
        }

        public DbDao()
            : this("ConnectionString")
        {
        }

        public DbDao(string nameConnection)
        {
            this._connectionString = ConfigurationManager.ConnectionStrings[nameConnection];
        }

        public DbCommand GetSqlCommand(string sqlQuery)
        {
            DbCommand command = Factory.CreateCommand();

            command.Connection = SharedConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = sqlQuery;

            return command;
        }

        public DbCommand GetSprocCommand(string sprocName)
        {
            DbCommand command = Factory.CreateCommand();

            command.Connection = SharedConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = sprocName;

            return command;
        }

        DbParameter CreateNullParameter(string name, DbType paramType)
        {
            DbParameter parameter = Factory.CreateParameter();

            parameter.DbType = paramType;
            parameter.ParameterName = name;
            parameter.Value = DBNull.Value;
            parameter.Direction = ParameterDirection.Input;

            return parameter;
        }

        DbParameter CreateOutputParameter(string name, DbType paramType)
        {
            DbParameter parameter = Factory.CreateParameter();

            parameter.DbType = paramType;
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;

            return parameter;
        }

        public DbParameter CreateParameter(string name, object value)
        {
            if (this._nullValue.IsNull(value))
            {
                return CreateNullParameter(name, this._dbValue[value.GetType()]);
            }
            else
            {
                DbParameter parameter = Factory.CreateParameter();

                parameter.DbType = this._dbValue[value.GetType()];
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;

                return parameter;
            }
        }

        public void ExecuteNonQuery(DbCommand command)
        {
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error executing query", e);
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public Object ExecuteScalar(DbCommand command)
        {
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                return command.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception("Error executing query", e);
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public T GetSingle<T>(DbCommand command) where T : class
        {
            T dto = null;

            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    IDataMapper mapper = new DataMapperCreator().Create(typeof(T));
                    dto = (T)mapper.GetData(reader);
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
            }

            return dto;
        }

        public List<T> GetList<T>(DbCommand command) where T : class
        {
            List<T> dtoList = new List<T>();

            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                DbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    IDataMapper mapper = new DataMapperCreator().Create(typeof(T));

                    while (reader.Read())
                    {
                        T dto = null;
                        dto = (T)mapper.GetData(reader);
                        dtoList.Add(dto);
                    }

                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
            }

            return dtoList;
        }
    }
}
