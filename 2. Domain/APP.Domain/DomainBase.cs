using APP.Model.dataShape;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APP.Domain
{
    public class DomainBase : IDomainBase
    {
        public Object  GetSingle(Object model)
        {
            return ((IDataShape)model).GetSingle();
        }

        public Object  GetList(Object model)
        {
            return ((IDataShape)model).GetList();
        }

        public Object  Insert(Object model)
        {
            List<String> erros = ((IDataShape)model).Validate();

            if (!erros.Any())
            {
                ((IDataShape)model).Insert();
            }

            return erros;
        }

        public Object  Update(Object model)
        {
            List<String> erros = ((IDataShape)model).Validate();

            if (!erros.Any())
            {
                ((IDataShape)model).Update();
            }

            return erros;
        }

        public Object  Delete(Object model)
        {
            List<String> erros = ((IDataShape)model).Validate();

            if (!erros.Any())
            {
                ((IDataShape)model).Delete();
            }

            return erros;
        }
    }
}