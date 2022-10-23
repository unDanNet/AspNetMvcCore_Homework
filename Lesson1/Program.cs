namespace Lesson1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var concurrentList = new ConcurrentList<int>();

            var t1 = new Thread((object? o) => {
                if (o is null or not ConcurrentList<int>)
                {
                    return;
                }

                var list = o as ConcurrentList<int>;

                for (var i = 0; i < 5; i++)
                {
                    list!.AddAsync(i);
                    Thread.Sleep(1000);
                }
            });

            var t2 = new Thread((object? o) => {
                if (o is null or not ConcurrentList<int>)
                {
                    return;
                }

                var list = o as ConcurrentList<int>;

                for (var i = 5; i < 10; i++)
                {
                    list!.AddAsync(i);
                    Thread.Sleep(500);
                }
            });

            var t3 = new Thread((object? o) => {
                if (o is null or not ConcurrentList<int>)
                {
                    return;
                }

                var list = o as ConcurrentList<int>;

                for (var i = 0; i < 10; i++)
                {
                    list!.RemoveAsync(i);
                    Thread.Sleep(1500);
                }
            });
            
            t1.Start(concurrentList);
            t2.Start(concurrentList);
            t3.Start(concurrentList);
        }
    }
}
