using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwePay_Service
{
    public class CacheKeys
    {
        public static string Users { get { return "Users_"; } }
    }

    public class CacheTime
    {
        public static int Hours_1 { get { return 1; } }
    }

    //Can manage enable or disable from here (usually in a config file)
    public class Caching
    {
        public static bool Enable { get { return true; } }
    }
}
