using NSMkt.Services.Interface;

namespace NSMkt.Services.NSE
{
    public class NSEMarketService: INSEMarketService
    {
       
        public NSEMarketService()
        {
            
        }

        public async Task<HttpClient> GetNSEHttpClient()
        {
           var httpclient= new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            httpclient.DefaultRequestHeaders.ExpectContinue = true;
            httpclient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            httpclient.DefaultRequestHeaders.Add("DNT", "1");
            httpclient.DefaultRequestHeaders.Add("Cache-Control", "max-age=0");
            httpclient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            httpclient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36");
            httpclient.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
            // http.DefaultRequestHeaders.Add("Accept", "application/json");
            httpclient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            httpclient.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
            httpclient.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            httpclient.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
            httpclient.DefaultRequestHeaders.Add("Accept-Language", "en-GB,en-US;q=0.9,en;q=0.8");

            if (CookieClass.nsecookie == null || CookieClass.nsecookie == "")
                await new GlobalVariableService().SetNSECookie().ConfigureAwait(false);
            if (CookieClass.nsecookie != null && CookieClass.nsecookie != "")
            {
                httpclient.DefaultRequestHeaders.Add("Cookie", CookieClass.nsecookie);
            }
            return httpclient;
        }

        public async Task<DateTime> GetMktTime(string mkt = "NSE")
        {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            if (mkt.ToUpper()=="NSE")
            { 
                 tz=TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            }            
           return  TimeZoneInfo.ConvertTime(DateTime.Now, tz);
        }


        public List<DateTime> GetNextComingMonthlyExpiry(DateTime? dt = null)
        {
            if (dt == null)
                dt = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            var nextDate = dt.Value.AddMonths(1);
            var next2Date = dt.Value.AddMonths(2);
            List<DateTime> expiryList = new List<DateTime>();
            expiryList.Add(GetLastThursdayOfTheMonth(dt.Value));
            expiryList.Add(GetLastThursdayOfTheMonth(nextDate));
            expiryList.Add(GetLastThursdayOfTheMonth(next2Date));
            return expiryList;

        }
        public string GetWeeklyExpiryText(DateTime date)
        {
            DateTime exp = GetWeeklyExpiry(date);
            return exp.ToString("dd-MMM-yyyy");
        }

        public string GetMonthlyExpiryText(DateTime date)
        {
            DateTime exp = GetLastThursdayOfTheMonth(date);
            return exp.ToString("dd-MMM-yyyy");
        }

        public string GetMonthlyExpiryFuture(DateTime date)
        {
            DateTime exp = GetLastThursdayOfTheMonth(date);
            return exp.ToString("dd-MM-yyyy")+"XX0.00";//29-07-2021XX0.00
        }


        public DateTime GetWeeklyExpiryDate(DateTime date)
        {


            DateTime exp = GetWeeklyExpiry(date);
            return exp;
        }
        public DateTime GetMonthlyExpiryDate(DateTime date)
        {
            DateTime exp = GetLastThursdayOfTheMonth(date);
            return exp;
        }

        public DateTime GetWeeklyExpiry(DateTime date)
        {
            var currentDate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            while (date.DayOfWeek != DayOfWeek.Thursday)
                date = date.AddDays(1);

            if (IsHoliday(date))
                date = date.AddDays(-1);

            return date;//date.Day.ToString() + date.ToString("MMM", CultureInfo.InvariantCulture).ToUpper() + date.Year.ToString(); ;

        }




        public DateTime GetNextWorkingDay(DateTime? dt)
        {
            if (dt == null)
                dt = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            dt = dt.Value.AddDays(1);
            if (dt.Value.DayOfWeek != DayOfWeek.Saturday && dt.Value.DayOfWeek != DayOfWeek.Sunday && !IsHoliday(dt.Value))
                return dt.Value;
            else
                return GetNextWorkingDay(dt);
        }


        public static DateTime GetLastThursdayOfTheMonth(DateTime date)
        {
            //var lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

            //DateTime lastdate;

            //while (lastDayOfMonth.DayOfWeek != DayOfWeek.Thursday)
            //    lastDayOfMonth = lastDayOfMonth.AddDays(-1);
            //if (lastDayOfMonth.Day > TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")).Day)
            //    lastdate = lastDayOfMonth;
            //else
            //    lastdate = lastDayOfMonth.AddDays(7);
            //return lastdate;// lastdate.Day.ToString() + lastdate.ToString("MMM", CultureInfo.InvariantCulture).ToUpper() + lastdate.Year.ToString();
            var lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

            while (lastDayOfMonth.DayOfWeek != DayOfWeek.Thursday)
                lastDayOfMonth = lastDayOfMonth.AddDays(-1);

            if (TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")).Date > lastDayOfMonth.Date && TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")).Month == lastDayOfMonth.Month)
            {
                var nextmonth = date.AddMonths(1);
                lastDayOfMonth = GetLastThursdayOfTheMonth(nextmonth);
            }

            if (IsHoliday(lastDayOfMonth))
                lastDayOfMonth = lastDayOfMonth.AddDays(-1);
            return lastDayOfMonth;


        }
        //public static DateTime GetLastSpecificDayOfTheMonth(this DateTime date, DayOfWeek dayofweek)
        //{
        //    var lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

        //    while (lastDayOfMonth.DayOfWeek != dayofweek)
        //        lastDayOfMonth = lastDayOfMonth.AddDays(-1);

        //    return lastDayOfMonth;
        //}



        public static bool IsHoliday(DateTime? dt = null)
        {
            if (dt == null)
                dt = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            if (dt.Value == null)
                dt = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            List<DateTime> holidays = new List<DateTime>();

            holidays.Add(new DateTime(2020, 11, 16));
            holidays.Add(new DateTime(2020, 11, 30));
            holidays.Add(new DateTime(2020, 12, 25));


            holidays.Add(new DateTime(2021, 01, 26));
            holidays.Add(new DateTime(2021, 03, 11));
            holidays.Add(new DateTime(2021, 03, 18));
            holidays.Add(new DateTime(2021, 03, 29));
            holidays.Add(new DateTime(2021, 04, 02));
            holidays.Add(new DateTime(2021, 04, 14));

            holidays.Add(new DateTime(2021, 04, 21));
            holidays.Add(new DateTime(2021, 05, 13));
            holidays.Add(new DateTime(2021, 07, 20));
            holidays.Add(new DateTime(2021, 08, 19));
            holidays.Add(new DateTime(2021, 09, 10));
            holidays.Add(new DateTime(2021, 10, 15));
            holidays.Add(new DateTime(2021, 11, 4));
            holidays.Add(new DateTime(2021, 11, 19));

            holidays.Add(new DateTime(2022, 01, 26));
            holidays.Add(new DateTime(2022, 03, 01));
            holidays.Add(new DateTime(2022, 03, 18));
            holidays.Add(new DateTime(2022, 04, 14));
            holidays.Add(new DateTime(2022, 04, 15));
            // holidays.Add(new DateTime(2022, 05, 02));
            holidays.Add(new DateTime(2022, 08, 15));
            holidays.Add(new DateTime(2022, 08, 31));
            holidays.Add(new DateTime(2022, 10, 4));
            holidays.Add(new DateTime(2022, 10, 25));
            holidays.Add(new DateTime(2022, 11, 7));

            bool exist = holidays.Any(d => d.Year==dt.Value.Year && d.Month == dt.Value.Month && d.Day == dt.Value.Day);
            return exist;
        }

        public static bool IsMarketDay(DateTime? today = null)
        {
            if (today == null)
                today = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            if (today.Value.DayOfWeek != DayOfWeek.Saturday && today.Value.DayOfWeek != DayOfWeek.Sunday && !IsHoliday(today))
            {
                return true;
            }
            else
                return false;
        }
        public static DateTime GetPrevMarketDay(DateTime prevDay)
        {
            prevDay = prevDay.AddDays(-1);
            if (prevDay.DayOfWeek != DayOfWeek.Saturday && prevDay.DayOfWeek != DayOfWeek.Sunday && !IsHoliday(prevDay))
            {
                return prevDay;
            }
            else
            {
                return GetPrevMarketDay(prevDay);
            }
        }

        public bool IsMarketTime(bool treatmarketTime = false)
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            if (!IsHoliday(indianTime))
                return true;



            if (IsMarketDay())
            {
                Console.WriteLine("IsMarketDay=true..............");
                var from = indianTime.Date.Add(new TimeSpan(9, 6, 0));
                var to = indianTime.Date.Add(new TimeSpan(15, 36, 0));
                if (indianTime > from && indianTime < to)
                {
                    Console.WriteLine("MktHrs=true..............");
                    return true;
                }
                else
                {
                    Console.WriteLine("MktHrs=false..............");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("IsMarketDay=false..............");
                return false;
            }
        }


        public bool IsUSEMarketTime(bool treatmarketTime = false)
        {

            //return true;
            //if (treatmarketTime)
            //{
            //    Console.WriteLine("TreamMarkettime=true..............");
            //    return true;
            //}

            TimeZoneInfo USE_ZONE = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime usETime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, USE_ZONE);
            if (IsMarketDay())
            {
                Console.WriteLine("IsMarketDay=true..............");
                var from = usETime.Date.Add(new TimeSpan(9, 11, 0));
                var to = usETime.Date.Add(new TimeSpan(15, 50, 0));
                if (usETime > from && usETime < to)
                {
                    Console.WriteLine("MktHrs=true..............");
                    return true;
                }
                else
                {
                    Console.WriteLine("MktHrs=false..............");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("IsMarketDay=false..............");
                return false;
            }
        }

    }
}
