using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Schemas.Orders
{
    public static class ResolveFieldContextExtensions
    {
        public static async Task<object> TryAsyncResolve<TSource>(this ResolveFieldContext<TSource> context, Func<ResolveFieldContext<TSource>, Task<object>> resolve, Func<ExecutionErrors, Task<object>> error = null)
        {
            try
            {
                return await resolve(context);
            }
            catch (Exception ex)
            {
                if (error == null)
                {
                    context.Errors.Add(new ExecutionError(ex.Message));
                    return null;
                }
                else
                {
                    return error(context.Errors);
                }
            }
        }
    }
}
