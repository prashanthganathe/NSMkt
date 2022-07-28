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
        private readonly INSEIndexOCService _nseOCService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;
        #endregion

        #region Constructor  
        public Jobs(IConfiguration config,INSEIndexOCService nseOCService, IEmailService  emailService)
        {
            _config = config;
            _nseOCService = nseOCService;
            _emailService=emailService;
        }
        #endregion

        #region Job Scheduler  
        public async Task<List<OCIndexData>> OCIndexAsync(List<string> scripts,int neighbours, bool? nextmonth = false)
        {
            var jobid = BackgroundJob.Enqueue<INSEIndexOCService>(x => x.GetOCIndexDataAsyncFiltered(scripts, neighbours, nextmonth));
          
            var emailSection = _config.GetSection("EmailList");
            var indexMsgBody = await _nseOCService.GetIndexBodyHTML();
            var indexSubject =await _nseOCService.GetIndexSubject();
            BackgroundJob.ContinueJobWith(jobid, () => _emailService.SendEmail(indexSubject, indexMsgBody, emailSection.GetSection("PremiumEmails").Value, emailSection.GetSection("").Value,emailSection.GetSection("IndexEmails").Value));
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
