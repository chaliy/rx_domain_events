using System;
using System.Collections.Generic;

namespace TryComplexRx.Infrastructure
{
    public class UnitOfWork : IObserver<object>
    {
        private readonly List<object> _registry = new List<object>();

        public void OnCompleted()
        {            
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(dynamic value)
        {
            _registry.Add(value);            
        }

        public void Commit()
        {
            Console.WriteLine("Commit {0} changes to database", _registry.Count);
            _registry.Clear();
        }        
    }
}
