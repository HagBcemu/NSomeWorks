using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class Actions
    {
        public Result StartMethod()
        {
            Result result = new Result("Start method: StartMethod()", TypeLog.Info, true, DateTime.Now);

            return result;
        }

        public Result SkipedMethod()
        {
            Result result = new Result("Skipped logic in method: SkipedMethod()", TypeLog.Warning, true, DateTime.Now);
            return result;
        }

        public Result ErrorMethod()
        {
            Result result = new Result("I broke a logic", TypeLog.Error, false, DateTime.Now);
            return result;
        }
    }
}
