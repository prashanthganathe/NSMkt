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
        private readonly IConfiguration _config;
        #endregion

        #region Constructor  
        public Jobs(IConfiguration config,INSEOCService NSEOCService, IEmailService  emailService)
        {
            _config = config;
            _NSEOCService = NSEOCService;
            _emailService=emailService;
        }
        #endregion

        #region Job Scheduler  
        public async Task<List<OCIndexData>> OCIndexAsync(List<string> scripts,int neighbours, bool? nextmonth = false)
        {
            var jobid = BackgroundJob.Enqueue<INSEOCService>(x => x.GetOCIndexDataAsyncFiltered(scripts, neighbours, nextmonth));
            BackgroundJob.ContinueJobWith(jobid, () => _emailService.SendEmail_IndexOC("Index","", _config.GetSection("EmailList").GetSection("IndexEmails").Value));
            return null;

        }


        public async Task<List<OCIndexData>> OCStockAsync()
        {
            //var jobid = BackgroundJob.Enqueue<INSEOCService>(x => x.StocksOC());
            //BackgroundJob.ContinueJobWith(jobid, () => _emailService.SendEmail());
            return null;

        }
        #endregion
    }
}
