using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// https://github.com/akazemis/TestableDateTimeProvider
/// </summary>
namespace Infraestrutura.Transversal
{
    public class DateTimeProviderContext : IDisposable
    {
        private static readonly ThreadLocal<Stack<DateTimeProviderContext>> ThreadScopeStack = new ThreadLocal<Stack<DateTimeProviderContext>>(() => new Stack<DateTimeProviderContext>());
        public DateTime Context;

        public DateTimeProviderContext(DateTime context)
        {
            Context = context;
            ThreadScopeStack.Value.Push(this);
        }

        public static DateTimeProviderContext Current { get { return ThreadScopeStack.Value.Count == 0 ? null : ThreadScopeStack.Value.Peek(); } }

        public void Dispose()
        {
            ThreadScopeStack.Value.Pop();
        }
    }
}
