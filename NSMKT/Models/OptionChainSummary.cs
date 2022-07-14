namespace NSMkt.Models
{
    public class OptionChainSummary : BaseModel
    {
        public string group { get; set; }
        public DateTime analysisTime { get; set; }
        public string script { get; set; }
        public string expiry { get; set; }
        public string expiryType { get; set; }

        public decimal openPrice { get; set; }
        public decimal highPrice { get; set; }
        public decimal lowPrice { get; set; }
    
        public bool isSpot { get; set; } = false;
        public string strike_reflabel { get; set; }

        #region OCdata
        public decimal futureprice { get; set; }
        public decimal indexprice { get; set; }
        public decimal ceoi { get; set; }
        public decimal cecoi { get; set; }
        public decimal cevolume { get; set; }
        public decimal ceiv { get; set; }
        public decimal celtp { get; set; }
        public decimal celtpchange { get; set; }
        public decimal strike { get; set; }
        public decimal peltpchange { get; set; }
        public decimal peltp { get; set; }
        public decimal peiv { get; set; }
        public decimal pevolume { get; set; }
        public decimal pecoi { get; set; }
        public decimal peoi { get; set; }
        #endregion

        public decimal Res1 { get; set; }
        public decimal Sup1 { get; set; }
        public decimal Res2 { get; set; }
        public decimal Sup2 { get; set; }       

        public bool isResVolStrong { get; set; }
        public bool isResOIStrong { get; set; }
        public bool isSupVolStrong { get; set; }
        public bool isSupOIStrong { get; set; }
        public decimal PECOIDiffPer { get; set; } // -2%
        public decimal CECOIDiffPer { get; set; }  //-1%
        public string SummaryJson { get; set; }


        #region stocks
        public int CECount { get; set; }
        public int PECount { get; set; }
        public decimal IsDoji { get; set; }
        public decimal prev1Support { get; set; }
        public decimal prev1Resistance { get; set; }
        public decimal prev1Support1 { get; set; }
        public decimal prev1Resistance1 { get; set; }
        public decimal prev2Support { get; set; }
        public decimal prev2Resistance { get; set; }
        public decimal prev2Support1 { get; set; }
        public decimal prev2Resistance1 { get; set; }
        #endregion

        // Advanced Analysis
        //public decimal intrinsicCEvalue { get; set; }
        //public decimal extrensicCEvalue { get; set; }
        //public decimal intrinsicPEvalue { get; set; }
        //public decimal extrensicPEvalue { get; set; }
        //public double PEdelta { get; set; }
        //public double PEgamma { get; set; }
        //public double PEvega { get; set; }
        //public double PErho { get; set; }
        //public double PEtheta { get; set; }
        //public double CEdelta { get; set; }
        //public double CEgamma { get; set; }
        //public double CEvega { get; set; }
        //public double CErho { get; set; }
        //public double CEtheta { get; set; }
        //public double blackSholesPricePE { get; set; }
        //public double blackSholesPriceCE { get; set; }
    }
}
