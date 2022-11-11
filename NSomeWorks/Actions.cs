using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class Actions
    {
        public Result StartMethod()
        {
            Result result = new Result("Start method: StartMethod()", TypeLog.Info, true);

            return result;
        }

        public BusinessException SkipedMethod()
        {
            BusinessException businessException = new BusinessException("Skipped logic in method");

            // Result result = new Result("Skipped logic in method: SkipedMethod()", TypeLog.Warning, true);
            return businessException;
        }

        public Result ErrorMethod()
        {
            Result result = new Result("I broke a logic", TypeLog.Error, false);
            throw new Exception("I broke a logic");
        }
    }
}
