using Microsoft.Extensions.Hosting;
using SAS.Manage.Databases;

namespace SAS.Manage.Scheduler.ServiceJobs
{
    internal class ScanLateIncome : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var timeRepeat = 10;
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(timeRepeat));
            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                var timenow = DateTime.Now;
                var top = timenow.Subtract(TimeSpan.FromMinutes(timeRepeat * 1.5));
                var floor = timenow.Subtract(TimeSpan.FromMinutes(timeRepeat * 3));

                var lateItems = MDatabases.Instance.Status
                    .Where(record => !record.IsCompleted && !record.IsCanceled)
                    .Where(record => record.TimeUpdated >= floor && record.TimeUpdated <= top);

                foreach (var item in lateItems)
                {
                    MDatabases.Instance.Orders[item.Id].Priority += 1;
                    MDatabases.Instance.Status[item.Id].ScanCount += 1;
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
