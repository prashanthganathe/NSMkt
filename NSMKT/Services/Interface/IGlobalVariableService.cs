namespace NSMkt.Services.Interface
{
    public interface IGlobalVariableService
    {
        Task SetNSECookie();
        Task CleanHangFireJobs();
    }
}
