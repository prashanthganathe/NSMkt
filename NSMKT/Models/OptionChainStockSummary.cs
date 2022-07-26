namespace NSMkt.Models
{
    public class OptionChainStockSummary : BaseModel
    {
        public string group { get; set; }
        public DateTime analysisTime { get; set; }
        public string script { get; set; }
        public string expiry { get; set; }
        public string expiryType { get; set; }

        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal ltp { get; set; }


        public decimal yearHigh { get; set; }
        public decimal yearLow { get; set; }
        public decimal prevClose { get; set; }
        public decimal TurnOver { get; set; }
        public bool IsTop50 { get; set; } = false;


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
    


        public string Label { get; set; }


        public int CECount { get; set; }
        public int PECount { get; set; }
        public decimal IsDoji { get; set; }

        public DateTime prev1 { get; set; }
        public decimal prev1Support { get; set; }
        public decimal prev1Resistance { get; set; }
        public decimal prev1Support1 { get; set; }
        public decimal prev1Resistance1 { get; set; }

        public DateTime prev2 { get; set; }
        public decimal prev2Support { get; set; }
        public decimal prev2Resistance { get; set; }
        public decimal prev2Support1 { get; set; }
        public decimal prev2Resistance1 { get; set; }


        public string SummaryJson { get; set; }
        //Entry,Target,LTP
        //S,S1,R,R1
        //CC/PC
        //Top50


    }
}
