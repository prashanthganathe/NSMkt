namespace NSMkt.Services
{
    using Hangfire;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Jobs:IJobs
    {
        #region Property  
        private readonly INSEOCService _NSEOCService;
        private readonly IEmailService _emailService;
        #endregion

        #region Constructor  
        public Jobs(INSEOCService NSEOCService, IEmailService  emailService)
        {
            _NSEOCService = NSEOCService;
            _emailService=emailService;
        }
        #endregion

        #region Job Scheduler  
        public async Task<List<OCIndexData>> OCDetailAsync(List<string> scripts,int neighbours, bool? nextmonth = false)
        {
            var jobid = BackgroundJob.Enqueue<INSEOCService>(x => x.GetOCDataAsyncFiltered(scripts, neighbours, nextmonth));
            BackgroundJob.ContinueJobWith(jobid, () => _emailService.SendEmail());
            return null;

        }
        #endregion
    }
}
