using System.Reactive.Subjects;

namespace TryComplexRx
{
    public static class Env
    {
        public static readonly Subject<dynamic> Events = new Subject<dynamic>();        
    }
}
