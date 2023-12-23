using Microsoft.Extensions.Hosting;
using SAS.Manage.Databases;

namespace SAS.Manage.Scheduler.ServiceJobs
{
    internal class UpdateTimeAnalyst : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(10));
            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                var completedOrder = MDatabases.Instance.Status
                    .Where(record => record.IsCompleted)
                    .OrderByDescending(record => record.TimeCreated)
                    .Take(20);

                IEnumerable<(Guid TypeId, TimeSpan Duration)> data = completedOrder.Select(order => (
                    MDatabases.Instance.Orders[order.Id].TypeId,
                    order.TimeUpdated - order.TimeCreated
                    ));

                IEnumerable<(Guid TypeId, int Count, double DurationAverage)> avg = data.GroupBy(
                    record => record.TypeId,
                    record => record.Duration,
                    (id, timespans) => (
                        id,
                        timespans.Count(),
                        timespans.Average(time => time.TotalSeconds)
                    ));

                foreach (var item in avg)
                {
                    var ordertype = MDatabases.Instance.Ordertypes[item.TypeId];
                    var newAvg = (ordertype.SampleAvgTimeInMinisecond + item.DurationAverage) / 2;

                    ordertype.SampleTypecount = item.Count;
                    ordertype.SampleAvgTimeInMinisecond = Convert.ToInt32(Math.Floor(newAvg));
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
