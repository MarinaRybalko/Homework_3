using System;
using System.Threading.Tasks;
using Module4task3.Services;

namespace Module4task3
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //await using (var context = new SampleContextFactory().CreateDbContext(args))
            //{
            //    await new LinqQueries(context).Task1();
            //}

            //await using (var context = new SampleContextFactory().CreateDbContext(args))
            //{
            //    await new LinqQueries(context).Task2();
            //}

            //await using (var context = new SampleContextFactory().CreateDbContext(args))
            //{
            //    await new LinqQueries(context).Task3();
            //}

            //await using (var context = new SampleContextFactory().CreateDbContext(args))
            //{
            //    await new LinqQueries(context).Task4();
            //}

            //await using (var context = new SampleContextFactory().CreateDbContext(args))
            //{
            //    await new LinqQueries(context).Task5();
            //}

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new LinqQueries(context).Task6();
            }

            Console.Read();
        }
    }
}
