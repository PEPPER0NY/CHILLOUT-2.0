using System;

namespace Chillout.DataAccess.Context
{
    internal class MapperConfiguration
    {
        private Func<object, object> p;

        public MapperConfiguration(Func<object, object> p)
        {
            this.p = p;
        }
    }
}