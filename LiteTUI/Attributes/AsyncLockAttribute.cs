using System.Collections.Concurrent;
using System.Reflection;
using MethodBoundaryAspect.Fody.Attributes;

namespace LiteTUI.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class AsyncLockAttribute : OnMethodBoundaryAspect
    {
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> Semaphores = new();

        public override void OnEntry(MethodExecutionArgs args)
        {
            var lockKey = GetPropertyLockKey(args.Method);
            var semaphore = Semaphores.GetOrAdd(lockKey, _ => new SemaphoreSlim(1, 1));
            
            args.MethodExecutionTag = semaphore;
            semaphore.Wait();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((SemaphoreSlim)args.MethodExecutionTag).Release();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            ((SemaphoreSlim)args.MethodExecutionTag).Release();
        }

        private static string GetPropertyLockKey(MethodBase method)
        {
            var type = method.DeclaringType?.FullName ?? "Unknown";
            var propertyName = method.Name.Substring(4); // Remove "get_" or "set_"
            return $"{type}.{propertyName}";
        }
    }
}