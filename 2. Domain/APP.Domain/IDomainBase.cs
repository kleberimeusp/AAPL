using System;

namespace APP.Domain
{
    public interface IDomainBase
    {
        Object GetSingle(Object model);
        Object GetList(Object model);
        Object Insert(Object model);
        Object Update(Object model);
        Object Delete(Object model);
    }
}