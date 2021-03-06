using System;
using SnapObjects.Data;
using SnapObjects.Data.Oracle;

namespace LargeNumberError
{
    public class DefaultDataContext : OracleDataContext
	{
        public DefaultDataContext(string connectionString)
            : this(new OracleDataContextOptions<DefaultDataContext>(connectionString))
        {
        }

        public DefaultDataContext(IDataContextOptions<DefaultDataContext> options)
            : base(options)
        {
        }
        
        public DefaultDataContext(IDataContextOptions options)
            : base(options)
        {
        }
    }
}
