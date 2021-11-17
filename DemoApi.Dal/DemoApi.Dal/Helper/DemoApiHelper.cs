using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Dal
{
    public class DemoApiHelper
    {
        public static string GetValueFromEnv(string envName)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Environment.GetEnvironmentVariable(envName, EnvironmentVariableTarget.User);
            }
            return Environment.GetEnvironmentVariable(envName); //Linux & Mac
        }
    }
}
