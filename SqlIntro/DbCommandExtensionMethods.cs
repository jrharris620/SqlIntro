using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlIntro
{
    class DbCommandExtensionMethods
    {
        public static class DbCommandExtensionMethods
        {
            public static void AddParam(this IDbCommand command, string name, object value)
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = name;
                parameter.Value = value;
                command.Parameters.Add(parameter);
            }
        }
    }
}
