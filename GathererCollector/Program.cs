using System;
using System.Threading;
using Quartz;
using Quartz.Impl;

namespace GathererCollector
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Start();

                var job = JobBuilder.Create<GathererJob>().WithIdentity("TestJob", "GathererCollector").Build();

                var trigger = TriggerBuilder.Create()
                    .WithIdentity("Trigger", "GathererCollector")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInMinutes(10)
                        .RepeatForever())
                    .Build();

                scheduler.ScheduleJob(job, trigger);

            }
            catch (SchedulerException exception)
            {
                Console.WriteLine(exception);
                //handle exception, restart scheduler
            }

            Console.ReadKey();
        }
    }
}
