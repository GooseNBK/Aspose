using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;

[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace Poc
{
    public class Function
    {
        public static string FunctionHandler(string input, ILambdaContext context)
        {
            return input?.ToUpper() ?? string.Empty;
        }
    }
}