using IdGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Util
{
    class IDGenerator
    {
        static IdGenerator generator = new IdGenerator(100);
        public static long CrateId()
        {
            long result = generator.CreateId();
            string aa = result.ToString();
            return Convert.ToInt64(aa.Substring(6));
        }

        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds * 1000);
        }
    }
}
