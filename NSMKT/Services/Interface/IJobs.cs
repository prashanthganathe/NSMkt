namespace NSMkt.Services.Interface
{
    public interface IJobs
    {
        Task<bool> OCDetailAsync(List<string> script);
    }
}
