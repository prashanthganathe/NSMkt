using Hangfire;
using Hangfire.Storage;

namespace NSMkt
{
    public class HFJobs
    {
        public async Task CleanHangFireJobs()
        {
            try
            {

                using (var connection = JobStorage.Current.GetConnection())
                {
                    foreach (var recurringJob in StorageConnectionExtensions.GetRecurringJobs(connection))
                    {
                        RecurringJob.RemoveIfExists(recurringJob.Id);
                    }
                    BackgroundJob.Enqueue<GlobalVariableService>(x => x.SetNSECookie());
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
