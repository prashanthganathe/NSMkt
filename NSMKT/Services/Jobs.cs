namespace NSMkt.Services
{

   
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Jobs:IJobs
    {
        #region Property  
        private readonly INSEOCService _NSEOCService;
        #endregion

        #region Constructor  
        public Jobs(INSEOCService NSEOCService)
        {
            _NSEOCService = NSEOCService;
        }
        #endregion

        #region Job Scheduler  
        public async Task<List<OCIndexData>> OCDetailAsync(List<string> scripts,int neighbours, bool? nextmonth = false)
        {
            var result = await _NSEOCService.GetOCDataAsyncFiltered(scripts, neighbours, nextmonth);
            if(result!=null)
            {
            }
            return null;
        }
        #endregion
    }
}
