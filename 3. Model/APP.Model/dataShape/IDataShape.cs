using System;
using System.Collections.Generic;
using System.Reflection;

namespace APP.Model.dataShape
{
    public interface IDataShape
    {
        object this[string index] { get; set; }

        PropertyInfo[] GetProperties();

        Object Insert();
        Object Update();
        Object Delete();

        Object GetSingle();
        Object GetList();

        List<String> Validate();
    }
}
