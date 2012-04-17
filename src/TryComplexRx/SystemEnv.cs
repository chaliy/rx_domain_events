namespace TryComplexRx
{
    using System.Reactive.Subjects;

    public static class SystemEnv
    {
        public static readonly Subject<dynamic> Events = new Subject<dynamic>();

        public static Execution Start()
        {
            return new Execution();
        }
    }    
}
