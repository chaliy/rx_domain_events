using System;
using System.Reactive;

public static class _
{
    public interface IMatcher
    {
        bool Match(object value);
        object Exec(object value);
    }
    
    private class IsMatcher<T, TRes> : IMatcher
    {
        private readonly Func<T, TRes> _exe;

        public IsMatcher(Func<T, TRes> exe)
        {
            _exe = exe;
        }

        public bool Match(object value)
        {
            // 
            return (value.GetType() == typeof (T));
        }

        public object Exec(object t)
        {
            return _exe((T)t);            
        }
    }

    public static IMatcher Is<T>(Action<T> exe)
    {
        return new IsMatcher<T, Unit>(x => {
            exe(x);
            return Unit.Default;
        });
    }

    public static void Match(object input, params IMatcher[] matchers)
    {
        foreach (var matcher in matchers)
        {
            if (matcher.Match(input))
            {
                matcher.Exec(input);
            }
        }
    }
    
}