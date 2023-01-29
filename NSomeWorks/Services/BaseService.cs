using System;
using System.Threading.Tasks;
using NSomeWorks.Helpers;
using NSomeWorks.Model;

namespace NSomeWorks.Services;

public abstract class BaseService
{
    protected async Task<TResult> ExecuteSafeAsync<TResult>(Func<Task<TResult>> action)
        where TResult : Validation, new()
    {
        try
        {
           return await action();
        }
        catch (BusinessException e)
        {
            return new TResult
            {
                Error = e.Message,
                ErrorCode = e.ErrorCode
            };
        }
    }
}