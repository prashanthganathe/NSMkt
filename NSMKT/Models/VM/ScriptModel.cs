﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace NSMkt.Models.VM
{
    public class ModelScriptExpiry
    {
       public ScriptModel scriptModel { get; set; }
       public  ExpiryDropdownModel expiryDropdownModel { get; set; }
    }


    public class ScriptModel
    {
        public string Script { get; set; }
        public SelectList Scripts { get; set; }

        public ScriptModel()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text ="NIFTY", Value="NIFTY" });
            items.Add(new SelectListItem { Text ="BANKNIFTY", Value="BANKNIFTY" });
            items.Add(new SelectListItem { Text ="ABB", Value="ABB" });
            items.Add(new SelectListItem { Text ="ACC", Value="ACC" });
            items.Add(new SelectListItem { Text ="AUBANK", Value="AUBANK" });
            items.Add(new SelectListItem { Text ="ABBOTINDIA", Value="ABBOTINDIA" });
            items.Add(new SelectListItem { Text ="ADANIENT", Value="ADANIENT" });
            items.Add(new SelectListItem { Text ="ADANIGREEN", Value="ADANIGREEN" });
            items.Add(new SelectListItem { Text ="ADANIPORTS", Value="ADANIPORTS" });
            items.Add(new SelectListItem { Text ="ATGL", Value="ATGL" });
            items.Add(new SelectListItem { Text ="ADANITRANS", Value="ADANITRANS" });
            items.Add(new SelectListItem { Text ="ABCAPITAL", Value="ABCAPITAL" });
            items.Add(new SelectListItem { Text ="ABFRL", Value="ABFRL" });
            items.Add(new SelectListItem { Text ="APLLTD", Value="APLLTD" });
            items.Add(new SelectListItem { Text ="ALKEM", Value="ALKEM" });
            items.Add(new SelectListItem { Text ="AMBUJACEM", Value="AMBUJACEM" });
            items.Add(new SelectListItem { Text ="APOLLOHOSP", Value="APOLLOHOSP" });
            items.Add(new SelectListItem { Text ="APOLLOTYRE", Value="APOLLOTYRE" });
            items.Add(new SelectListItem { Text ="ASHOKLEY", Value="ASHOKLEY" });
            items.Add(new SelectListItem { Text ="ASIANPAINT", Value="ASIANPAINT" });
            items.Add(new SelectListItem { Text ="ASTRAL", Value="ASTRAL" });
            items.Add(new SelectListItem { Text ="AUROPHARMA", Value="AUROPHARMA" });
            items.Add(new SelectListItem { Text ="DMART", Value="DMART" });
            items.Add(new SelectListItem { Text ="AXISBANK", Value="AXISBANK" });
            items.Add(new SelectListItem { Text ="BAJAJ-AUTO", Value="BAJAJ-AUTO" });
            items.Add(new SelectListItem { Text ="BAJFINANCE", Value="BAJFINANCE" });
            items.Add(new SelectListItem { Text ="BAJAJFINSV", Value="BAJAJFINSV" });
            items.Add(new SelectListItem { Text ="BAJAJHLDNG", Value="BAJAJHLDNG" });
            items.Add(new SelectListItem { Text ="BALKRISIND", Value="BALKRISIND" });
            items.Add(new SelectListItem { Text ="BANDHANBNK", Value="BANDHANBNK" });
            items.Add(new SelectListItem { Text ="BANKBARODA", Value="BANKBARODA" });
            items.Add(new SelectListItem { Text ="BANKINDIA", Value="BANKINDIA" });
            items.Add(new SelectListItem { Text ="BATAINDIA", Value="BATAINDIA" });
            items.Add(new SelectListItem { Text ="BERGEPAINT", Value="BERGEPAINT" });
            items.Add(new SelectListItem { Text ="BEL", Value="BEL" });
            items.Add(new SelectListItem { Text ="BHARATFORG", Value="BHARATFORG" });
            items.Add(new SelectListItem { Text ="BHEL", Value="BHEL" });
            items.Add(new SelectListItem { Text ="BPCL", Value="BPCL" });
            items.Add(new SelectListItem { Text ="BHARTIARTL", Value="BHARTIARTL" });
            items.Add(new SelectListItem { Text ="BIOCON", Value="BIOCON" });
            items.Add(new SelectListItem { Text ="BOSCHLTD", Value="BOSCHLTD" });
            items.Add(new SelectListItem { Text ="BRITANNIA", Value="BRITANNIA" });
            items.Add(new SelectListItem { Text ="CANBK", Value="CANBK" });
            items.Add(new SelectListItem { Text ="CHOLAFIN", Value="CHOLAFIN" });
            items.Add(new SelectListItem { Text ="CIPLA", Value="CIPLA" });
            items.Add(new SelectListItem { Text ="CLEAN", Value="CLEAN" });
            items.Add(new SelectListItem { Text ="COALINDIA", Value="COALINDIA" });
            items.Add(new SelectListItem { Text ="COFORGE", Value="COFORGE" });
            items.Add(new SelectListItem { Text ="COLPAL", Value="COLPAL" });
            items.Add(new SelectListItem { Text ="CONCOR", Value="CONCOR" });
            items.Add(new SelectListItem { Text ="COROMANDEL", Value="COROMANDEL" });
            items.Add(new SelectListItem { Text ="CROMPTON", Value="CROMPTON" });
            items.Add(new SelectListItem { Text ="CUMMINSIND", Value="CUMMINSIND" });
            items.Add(new SelectListItem { Text ="DLF", Value="DLF" });
            items.Add(new SelectListItem { Text ="DABUR", Value="DABUR" });
            items.Add(new SelectListItem { Text ="DALBHARAT", Value="DALBHARAT" });
            items.Add(new SelectListItem { Text ="DEEPAKNTR", Value="DEEPAKNTR" });
            items.Add(new SelectListItem { Text ="DIVISLAB", Value="DIVISLAB" });
            items.Add(new SelectListItem { Text ="DIXON", Value="DIXON" });
            items.Add(new SelectListItem { Text ="LALPATHLAB", Value="LALPATHLAB" });
            items.Add(new SelectListItem { Text ="DRREDDY", Value="DRREDDY" });
            items.Add(new SelectListItem { Text ="EICHERMOT", Value="EICHERMOT" });
            items.Add(new SelectListItem { Text ="EMAMILTD", Value="EMAMILTD" });
            items.Add(new SelectListItem { Text ="ESCORTS", Value="ESCORTS" });
            items.Add(new SelectListItem { Text ="EXIDEIND", Value="EXIDEIND" });
            items.Add(new SelectListItem { Text ="NYKAA", Value="NYKAA" });
            items.Add(new SelectListItem { Text ="FEDERALBNK", Value="FEDERALBNK" });
            items.Add(new SelectListItem { Text ="FORTIS", Value="FORTIS" });
            items.Add(new SelectListItem { Text ="GAIL", Value="GAIL" });
            items.Add(new SelectListItem { Text ="GLAND", Value="GLAND" });
            items.Add(new SelectListItem { Text ="GLENMARK", Value="GLENMARK" });
            items.Add(new SelectListItem { Text ="GODREJCP", Value="GODREJCP" });
            items.Add(new SelectListItem { Text ="GODREJPROP", Value="GODREJPROP" });
            items.Add(new SelectListItem { Text ="GRASIM", Value="GRASIM" });
            items.Add(new SelectListItem { Text ="GUJGASLTD", Value="GUJGASLTD" });
            items.Add(new SelectListItem { Text ="GSPL", Value="GSPL" });
            items.Add(new SelectListItem { Text ="HCLTECH", Value="HCLTECH" });
            items.Add(new SelectListItem { Text ="HDFCAMC", Value="HDFCAMC" });
            items.Add(new SelectListItem { Text ="HDFCBANK", Value="HDFCBANK" });
            items.Add(new SelectListItem { Text ="HDFCLIFE", Value="HDFCLIFE" });
            items.Add(new SelectListItem { Text ="HAVELLS", Value="HAVELLS" });
            items.Add(new SelectListItem { Text ="HEROMOTOCO", Value="HEROMOTOCO" });
            items.Add(new SelectListItem { Text ="HINDALCO", Value="HINDALCO" });
            items.Add(new SelectListItem { Text ="HAL", Value="HAL" });
            items.Add(new SelectListItem { Text ="HINDPETRO", Value="HINDPETRO" });
            items.Add(new SelectListItem { Text ="HINDUNILVR", Value="HINDUNILVR" });
            items.Add(new SelectListItem { Text ="HINDZINC", Value="HINDZINC" });
            items.Add(new SelectListItem { Text ="HONAUT", Value="HONAUT" });
            items.Add(new SelectListItem { Text ="HDFC", Value="HDFC" });
            items.Add(new SelectListItem { Text ="ICICIBANK", Value="ICICIBANK" });
            items.Add(new SelectListItem { Text ="ICICIGI", Value="ICICIGI" });
            items.Add(new SelectListItem { Text ="ICICIPRULI", Value="ICICIPRULI" });
            items.Add(new SelectListItem { Text ="ISEC", Value="ISEC" });
            items.Add(new SelectListItem { Text ="IDBI", Value="IDBI" });
            items.Add(new SelectListItem { Text ="IDFCFIRSTB", Value="IDFCFIRSTB" });
            items.Add(new SelectListItem { Text ="ITC", Value="ITC" });
            items.Add(new SelectListItem { Text ="INDIAMART", Value="INDIAMART" });
            items.Add(new SelectListItem { Text ="INDIANB", Value="INDIANB" });
            items.Add(new SelectListItem { Text ="IEX", Value="IEX" });
            items.Add(new SelectListItem { Text ="INDHOTEL", Value="INDHOTEL" });
            items.Add(new SelectListItem { Text ="IOC", Value="IOC" });
            items.Add(new SelectListItem { Text ="IRCTC", Value="IRCTC" });
            items.Add(new SelectListItem { Text ="IGL", Value="IGL" });
            items.Add(new SelectListItem { Text ="INDUSTOWER", Value="INDUSTOWER" });
            items.Add(new SelectListItem { Text ="INDUSINDBK", Value="INDUSINDBK" });
            items.Add(new SelectListItem { Text ="NAUKRI", Value="NAUKRI" });
            items.Add(new SelectListItem { Text ="INFY", Value="INFY" });
            items.Add(new SelectListItem { Text ="INDIGO", Value="INDIGO" });
            items.Add(new SelectListItem { Text ="IPCALAB", Value="IPCALAB" });
            items.Add(new SelectListItem { Text ="JSWENERGY", Value="JSWENERGY" });
            items.Add(new SelectListItem { Text ="JSWSTEEL", Value="JSWSTEEL" });
            items.Add(new SelectListItem { Text ="JINDALSTEL", Value="JINDALSTEL" });
            items.Add(new SelectListItem { Text ="JUBLFOOD", Value="JUBLFOOD" });
            items.Add(new SelectListItem { Text ="KOTAKBANK", Value="KOTAKBANK" });
            items.Add(new SelectListItem { Text ="L&TFH", Value="L&TFH" });
            items.Add(new SelectListItem { Text ="LTTS", Value="LTTS" });
            items.Add(new SelectListItem { Text ="LICHSGFIN", Value="LICHSGFIN" });
            items.Add(new SelectListItem { Text ="LTI", Value="LTI" });
            items.Add(new SelectListItem { Text ="LT", Value="LT" });
            items.Add(new SelectListItem { Text ="LAURUSLABS", Value="LAURUSLABS" });
            items.Add(new SelectListItem { Text ="LUPIN", Value="LUPIN" });
            items.Add(new SelectListItem { Text ="MRF", Value="MRF" });
            items.Add(new SelectListItem { Text ="M&MFIN", Value="M&MFIN" });
            items.Add(new SelectListItem { Text ="M&M", Value="M&M" });
            items.Add(new SelectListItem { Text ="MANAPPURAM", Value="MANAPPURAM" });
            items.Add(new SelectListItem { Text ="MARICO", Value="MARICO" });
            items.Add(new SelectListItem { Text ="MARUTI", Value="MARUTI" });
            items.Add(new SelectListItem { Text ="MFSL", Value="MFSL" });
            items.Add(new SelectListItem { Text ="MAXHEALTH", Value="MAXHEALTH" });
            items.Add(new SelectListItem { Text ="METROPOLIS", Value="METROPOLIS" });
            items.Add(new SelectListItem { Text ="MINDTREE", Value="MINDTREE" });
            items.Add(new SelectListItem { Text ="MPHASIS", Value="MPHASIS" });
            items.Add(new SelectListItem { Text ="MUTHOOTFIN", Value="MUTHOOTFIN" });
            items.Add(new SelectListItem { Text ="NMDC", Value="NMDC" });
            items.Add(new SelectListItem { Text ="NTPC", Value="NTPC" });
            items.Add(new SelectListItem { Text ="NATIONALUM", Value="NATIONALUM" });
            items.Add(new SelectListItem { Text ="NAVINFLUOR", Value="NAVINFLUOR" });
            items.Add(new SelectListItem { Text ="NESTLEIND", Value="NESTLEIND" });
            items.Add(new SelectListItem { Text ="NAM-INDIA", Value="NAM-INDIA" });
            items.Add(new SelectListItem { Text ="OBEROIRLTY", Value="OBEROIRLTY" });
            items.Add(new SelectListItem { Text ="ONGC", Value="ONGC" });
            items.Add(new SelectListItem { Text ="OIL", Value="OIL" });
            items.Add(new SelectListItem { Text ="PAYTM", Value="PAYTM" });
            items.Add(new SelectListItem { Text ="OFSS", Value="OFSS" });
            items.Add(new SelectListItem { Text ="POLICYBZR", Value="POLICYBZR" });
            items.Add(new SelectListItem { Text ="PIIND", Value="PIIND" });
            items.Add(new SelectListItem { Text ="PAGEIND", Value="PAGEIND" });
            items.Add(new SelectListItem { Text ="PERSISTENT", Value="PERSISTENT" });
            items.Add(new SelectListItem { Text ="PETRONET", Value="PETRONET" });
            items.Add(new SelectListItem { Text ="PIDILITIND", Value="PIDILITIND" });
            items.Add(new SelectListItem { Text ="PEL", Value="PEL" });
            items.Add(new SelectListItem { Text ="POLYCAB", Value="POLYCAB" });
            items.Add(new SelectListItem { Text ="PFC", Value="PFC" });
            items.Add(new SelectListItem { Text ="POWERGRID", Value="POWERGRID" });
            items.Add(new SelectListItem { Text ="PRESTIGE", Value="PRESTIGE" });
            items.Add(new SelectListItem { Text ="PGHH", Value="PGHH" });
            items.Add(new SelectListItem { Text ="PNB", Value="PNB" });
            items.Add(new SelectListItem { Text ="RECLTD", Value="RECLTD" });
            items.Add(new SelectListItem { Text ="RELIANCE", Value="RELIANCE" });
            items.Add(new SelectListItem { Text ="SBICARD", Value="SBICARD" });
            items.Add(new SelectListItem { Text ="SBILIFE", Value="SBILIFE" });
            items.Add(new SelectListItem { Text ="SRF", Value="SRF" });
            items.Add(new SelectListItem { Text ="SHREECEM", Value="SHREECEM" });
            items.Add(new SelectListItem { Text ="SRTRANSFIN", Value="SRTRANSFIN" });
            items.Add(new SelectListItem { Text ="SIEMENS", Value="SIEMENS" });
            items.Add(new SelectListItem { Text ="SONACOMS", Value="SONACOMS" });
            items.Add(new SelectListItem { Text ="SBIN", Value="SBIN" });
            items.Add(new SelectListItem { Text ="SAIL", Value="SAIL" });
            items.Add(new SelectListItem { Text ="SUNPHARMA", Value="SUNPHARMA" });
            items.Add(new SelectListItem { Text ="SUNTV", Value="SUNTV" });
            items.Add(new SelectListItem { Text ="SYNGENE", Value="SYNGENE" });
            items.Add(new SelectListItem { Text ="TVSMOTOR", Value="TVSMOTOR" });
            items.Add(new SelectListItem { Text ="TATACHEM", Value="TATACHEM" });
            items.Add(new SelectListItem { Text ="TATACOMM", Value="TATACOMM" });
            items.Add(new SelectListItem { Text ="TCS", Value="TCS" });
            items.Add(new SelectListItem { Text ="TATACONSUM", Value="TATACONSUM" });
            items.Add(new SelectListItem { Text ="TATAELXSI", Value="TATAELXSI" });
            items.Add(new SelectListItem { Text ="TATAMOTORS", Value="TATAMOTORS" });
            items.Add(new SelectListItem { Text ="TATAPOWER", Value="TATAPOWER"});
            items.Add(new SelectListItem { Text ="TATASTEEL", Value="TATASTEEL" });
            items.Add(new SelectListItem { Text ="TECHM", Value="TECHM" });
            items.Add(new SelectListItem { Text ="RAMCOCEM", Value="RAMCOCEM" });
            items.Add(new SelectListItem { Text ="TITAN", Value="TITAN" });
            items.Add(new SelectListItem { Text ="TORNTPHARM", Value="TORNTPHARM" });
            items.Add(new SelectListItem { Text ="TORNTPOWER", Value="TORNTPOWER" });
            items.Add(new SelectListItem { Text ="TRENT", Value="TRENT" });
            items.Add(new SelectListItem { Text ="TRIDENT", Value="TRIDENT" });
            items.Add(new SelectListItem { Text ="UPL", Value="UPL" });
            items.Add(new SelectListItem { Text ="ULTRACEMCO", Value="ULTRACEMCO" });
            items.Add(new SelectListItem { Text ="UNIONBANK", Value="UNIONBANK" });
            items.Add(new SelectListItem { Text ="UBL", Value="UBL" });
            items.Add(new SelectListItem { Text ="MCDOWELL-N", Value="MCDOWELL-N" });
            items.Add(new SelectListItem { Text ="VBL", Value="VBL" });
            items.Add(new SelectListItem { Text ="VEDL", Value="VEDL" });
            items.Add(new SelectListItem { Text ="IDEA", Value="IDEA" });
            items.Add(new SelectListItem { Text ="VOLTAS", Value="VOLTAS" });
            items.Add(new SelectListItem { Text ="WHIRLPOOL", Value="WHIRLPOOL" });
            items.Add(new SelectListItem { Text ="WIPRO", Value="WIPRO" });
            items.Add(new SelectListItem { Text ="YESBANK", Value="YESBANK" });
            items.Add(new SelectListItem { Text ="ZEEL", Value="ZEEL" });
            items.Add(new SelectListItem { Text ="ZOMATO", Value="ZOMATO" });
            items.Add(new SelectListItem { Text ="ZYDUSLIFE", Value="ZYDUSLIFE" });

            this.Scripts = new SelectList(items, "Value", "Text");
        }
    }
}