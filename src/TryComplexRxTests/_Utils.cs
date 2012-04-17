using System;
using System.Collections.Generic;

namespace TryComplexRxTests
{
    internal static class EventRecorder
    {
        public static EventRecorder<T> Recorder<T>()
        {
            return new EventRecorder<T>();
        }        
    }

    internal class EventRecorder<T> : IObserver<T>
    {
        public readonly List<T> Messages = new List<T>();

        public void OnNext(T value)
        {
            Messages.Add(value);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }        
    }
}
