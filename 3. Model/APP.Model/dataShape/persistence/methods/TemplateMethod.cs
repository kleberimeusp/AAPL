
using System;
namespace APP.Model.dataShape.persistence.methods
{
    public abstract class TemplateMethod
    {
        public abstract void BuildDictionary(IDataShape model);
        public abstract void MountQuery(IDataShape model);
        public abstract void AddParameter(IDataShape model);
        public abstract Object Execute();

        public Object Run(IDataShape model)
        {
            this.BuildDictionary(model);
            this.MountQuery(model);
            this.AddParameter(model);
            
            return this.Execute();
        }
    }
}
