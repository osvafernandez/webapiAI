using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapiAI.Common
{
    public class ResponseStringParser
    {
        public static string ParseResponse(string response)
        {
            return response
            .Replace("\\r\\n", "\n")
            .Replace("\\n", "\n");
        }
    }
}