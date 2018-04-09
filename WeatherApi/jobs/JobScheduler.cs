using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace WeatherApi.jobs
{
    public class JobScheduler
    {
        public static async Task Start()
        {

            // Grab the Scheduler instance from the Factory
            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            IScheduler scheduler = await factory.GetScheduler();

            // and start it off
            await scheduler.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<EmailJob>()
                .WithIdentity("job1", "group1")
                .Build();


            IJobDetail job2 = JobBuilder.Create<WeatherDataJob>()
                .WithIdentity("job2", "group1")
                .Build();




            ITrigger trigger2 = TriggerBuilder.Create()
                .WithIdentity("trigger2", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(1)
                    .RepeatForever())
                .Build();


            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();

            // Tell quartz to schedule the job using our trigger
            await scheduler.ScheduleJob(job, trigger);
            await scheduler.ScheduleJob(job2, trigger2);

        }
    }
}