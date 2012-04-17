namespace TryComplexRx
{
    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.Reactive.Subjects;
    using Domain.Accounts;
    
    public class Execution
    {
        readonly Subject<dynamic> events = new Subject<dynamic>();
        readonly CompositionContainer container;
        
        public Execution()
        {
            // Registration
            container = new CompositionContainer();
            container.ComposeExportedValue(new AccountsModule(this));
            container.ComposeExportedValue(this);
        }

        public IObservable<dynamic> Events { get { return events; } }

        /// <summary>
        /// Wire source of events to main event stream.
        /// </summary>
        /// <param name="source"></param>
        public void Register(IObservable<dynamic> source)
        {
            source.Subscribe(events);
        }
        
        public T Resolve<T>() where T : class 
        {
            var export = container.GetExports<T>().FirstOrDefault();
            if (export == null)
            {
                // http://blogs.msdn.com/b/dsplaisted/archive/2010/07/13/how-to-debug-and-diagnose-mef-failures.aspx :)
                throw new InvalidOperationException("Failed to build " + typeof(T));              
            }
            return export.Value;

        }
    }
}
