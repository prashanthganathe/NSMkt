using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSMkt.Models;

namespace NSMkt.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {


        [HttpGet]
        [Route("LineChartData")]
        public async Task<string> LineChartData(string bnfchart = "")
        {
            var ret = new LineSample();
            ret.Data= new List<SampleLine>();
            for (int i = 0; i<30; i++)
            {
                ret.Data.Add(new SampleLine {  X=i,  Y= i});
            }
            return JsonConvert.SerializeObject(ret);
        }


        [HttpGet]
        [Route("ChartData")]
        public async Task<string> ChartData(string bnfchart="")
        {
            var ret = new SampleChart();

            //1
            ret.MonthDataSeries1=new MonthDataSeries1();
            ret.MonthDataSeries1.Prices=new List<decimal>();
            ret.MonthDataSeries1.Dates= new List<string>();
            for (int i = 0; i<30;i++)
            {
                ret.MonthDataSeries1.Prices.Add(decimal.Multiply(8107m,i));
                ret.MonthDataSeries1.Dates.Add(DateTime.Now.AddMinutes(1).ToString("HH:mm"));
            
            }


            //2
            ret.MonthDataSeries2=new MonthDataSeries2();
            ret.MonthDataSeries2.Prices=new List<decimal>();
            ret.MonthDataSeries2.Dates= new List<string>();
            for (int i = 0; i<30; i++)
            {
                ret.MonthDataSeries2.Prices.Add(decimal.Multiply(8107m, i++));
                ret.MonthDataSeries2.Dates.Add(DateTime.Now.AddMinutes(1).ToString("HH:mm"));

            }

            //3
            ret.MonthDataSeries3=new MonthDataSeries3();
            ret.MonthDataSeries3.Prices=new List<decimal>();
            ret.MonthDataSeries3.Dates= new List<string>();
            for (int i = 30; i>0; i--)
            {
                ret.MonthDataSeries3.Prices.Add(decimal.Multiply(8107m, i));
                ret.MonthDataSeries3.Dates.Add(DateTime.Now.AddMinutes(1).ToString("HH:mm"));

            }

            return JsonConvert.SerializeObject(ret);
        }
    }
}
