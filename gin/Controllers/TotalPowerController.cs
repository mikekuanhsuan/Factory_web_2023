using DocumentFormat.OpenXml.Bibliography;
using gin.Models;
using gin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace gin.Controllers
{
    public class TotalPowerController : Controller
    {
        private readonly ZDBContext _ZDBContext;
        public TotalPowerController(ZDBContext zDBContext)
        {
            _ZDBContext = zDBContext;
        }

        [Authorize(Policy = "CustomPolicy")]
        public IActionResult TotalPowerShow(string factoryId)
        {
            ViewBag.FactoryId = factoryId;
            ViewBag.day = DateTime.Now.ToString("yyyy-MM");
            return View();
        }

        public IActionResult TotalPower(string factory, string day)
        {
            string factoryId = factory;

            TotalPower totalPower = new TotalPower();
            List<GTpcM> gTpcM = new List<GTpcM>();

            totalPower.factoryId = factoryId;
            DateTime nowMon = DateTime.Parse(day); //2023-00-00

            //--台電資料--

            var taipower = _ZDBContext.GTpcMs.Where(x => x.FactoryId == factoryId && x.Dtime == nowMon).Select(x => x.PowerKw).ToList();
            double totalSum = 0;
            if (taipower.Count == 0)
            {
                totalPower.contract = "0";
                totalPower.peak = "0";
                totalPower.halfpeak = "0";
                totalPower.sixpeak = "0";
                totalPower.offpeak = "0";
            }
            else
            {
                if (taipower.Count == 5)
                {
                    totalSum = (int)taipower[1] + (int)taipower[0] + (int)taipower[2] + (int)taipower[4];
                    totalPower.contract = (int)taipower[3] == 0 ? "0" : taipower[3].ToString();

                    totalPower.contract = taipower[3].ToString();
                    totalPower.peak = taipower[1].ToString();
                    totalPower.halfpeak = taipower[0].ToString();
                    totalPower.sixpeak = taipower[2].ToString();
                    totalPower.offpeak = taipower[4].ToString();

                    totalPower.peakk = (int)taipower[1] == 0 ? "0" : Math.Round((((int)taipower[1] * 100) / totalSum), 0).ToString();
                    totalPower.halfpeakk = (int)taipower[0] == 0 ? "0" : Math.Round((((int)taipower[0] * 100) / totalSum), 0).ToString();
                    totalPower.sixpeakk = (int)taipower[2] == 0 ? "0" : Math.Round((((int)taipower[2] * 100) / totalSum), 0).ToString();
                    totalPower.offpeakk = (int)taipower[4] == 0 ? "0" : Math.Round((((int)taipower[4] * 100) / totalSum), 0).ToString();
                }
                else
                {
                    totalPower.contract = "0";
                    totalPower.peak = "0";
                    totalPower.halfpeak = "0";
                    totalPower.sixpeak = "0";
                    totalPower.offpeak = "0";

                    totalPower.peakk = "0";
                    totalPower.halfpeakk = "0";
                    totalPower.sixpeakk = "0";
                    totalPower.offpeakk = "0";
                }

            }

            //--台電資料 END--

            //--太陽能資料--
            string nowwMon = DateTime.Now.ToString("yyyy-MM"); // 抓取當下的月份20XX-XX
            DateTime firstDay = DateTime.Parse(DateTime.Now.ToString(day) + "-01");  //抓取當月的第一天
            DateTime lastDay = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")); //抓取當下的最後一天
            double totalDay = Convert.ToDouble(DateTime.Now.ToString("dd"));  //當下第幾天

            if (day != nowwMon)
            {
                lastDay = nowMon.AddMonths(+1).AddDays(-1);
                totalDay = Convert.ToDouble(nowMon.AddMonths(1).AddDays(-1).ToString("dd"));
            }

            var seId = _ZDBContext.GSes.Where(x => x.FactoryId == factoryId).ToList();
            string sEid = "";
            if (seId.Count != 0)
            {
                if (factoryId == "ZB-T1HIST")
                {
                    sEid = seId[1].SeId.ToString();

                    var solarenergydata2 = _ZDBContext.GSeDs.Where(x => x.SeId == sEid && x.Ddate >= firstDay && x.Ddate <= lastDay).Sum(x => x.PowerGeneration).ToString();

                    double d2 = totalDay;
                    double build_Volume_kwh2 = Double.Parse(seId[0].BuildVolumeKwh.ToString());
                    double factorybulid2 = build_Volume_kwh2;

                    //發電量
                    totalPower.v2 = Math.Round(Double.Parse(solarenergydata2) / factorybulid2 / d2, 2).ToString();
                    //發電量(度/日)
                    totalPower.solarenergy2 = solarenergydata2.ToString();

                    totalPower.seid2 = factorybulid2;
                }
                sEid = seId[0].SeId.ToString();
                var solarenergydata = _ZDBContext.GSeDs.Where(x => x.SeId == sEid && x.Ddate >= firstDay && x.Ddate <= lastDay).Sum(x => x.PowerGeneration).ToString();

                double d = totalDay;
                double build_Volume_kwh = Double.Parse(seId[0].BuildVolumeKwh.ToString());
                double factorybulid = build_Volume_kwh;

                //發電量
                totalPower.v = Math.Round(Double.Parse(solarenergydata) / factorybulid / d, 2).ToString();
                //發電量(度/日)
                totalPower.solarenergy = solarenergydata.ToString();

                totalPower.seid = factorybulid;
            }
            else
            {
                //發電量
                totalPower.v = "0";
                //發電量(度/日)
                totalPower.solarenergy = "0";
                //合約電量
                totalPower.seid = 0;
            }
            //--太陽能資料 END--
            //--廠內總用電量--
            string month = day.Replace("-", "");
            string totPower = "";
            var totalFactoryPower = _ZDBContext.GPowerMs.Where(x => x.FactoryId == factoryId && x.Dmonth == month).Select(x => x.PowerCTotal).ToList();
            if (totalFactoryPower.Count() > 0)
            {
                int t = totalFactoryPower[0] == null ? 0 : (int)totalFactoryPower[0];
                totPower = string.Format("{0:#,0.####}", t);
                totalPower.factoryPower = totPower.ToString();
            }
            else
            {
                totalPower.factoryPower = "0";
            }
            //--廠內總用電量 END--
            //--空壓機--
            var airdata = _ZDBContext.GAirComps.Where(x => x.FactoryId == factoryId && x.DataDate >= firstDay && x.DataDate <= lastDay)
                .Sum(x => x.PowerCh01 + x.PowerCh02 + x.PowerCh03 + x.PowerCh04 + x.PowerCh05);
            if (airdata != null)
            {
                totalPower.airtotal = ((int)airdata).ToString("#,##,##");
            }
            else
            {
                totalPower.airtotal = "0";
            }
            //--空壓機 END--
            var millPower = _ZDBContext.GPowerMs.Where(x => x.FactoryId == factoryId && x.Dmonth == month)
                .Select(x => new { x.PowerC01, x.PowerC02, x.PowerC03, x.PowerC04, x.PowerC05, x.PowerC06, x.PowerC07, x.PowerC08 }).ToList();
            List<GPowerM> gPowerMs = new List<GPowerM>();
            GPowerM gPowerM = new GPowerM();
            string[] millChart = new string[8];
            if (millPower.Count != 0)
            {
                foreach (var i in millPower)
                {
                    gPowerM.PowerC01 = i.PowerC01 == null ? 0 : i.PowerC01;
                    millChart[0] = i.PowerC01 == null ? "0" : i.PowerC01.ToString();
                    gPowerM.PowerC02 = i.PowerC02 == null ? 0 : i.PowerC02;
                    millChart[1] = i.PowerC02 == null ? "0" : i.PowerC02.ToString();
                    gPowerM.PowerC03 = i.PowerC03 == null ? 0 : i.PowerC03;
                    millChart[2] = i.PowerC03 == null ? "0" : i.PowerC03.ToString();
                    gPowerM.PowerC04 = i.PowerC04 == null ? 0 : i.PowerC04;
                    millChart[3] = i.PowerC04 == null ? "0" : i.PowerC04.ToString();
                    gPowerM.PowerC05 = i.PowerC05 == null ? 0 : i.PowerC05;
                    millChart[4] = i.PowerC05 == null ? "0" : i.PowerC05.ToString();
                    gPowerM.PowerC06 = i.PowerC06 == null ? 0 : i.PowerC06;
                    millChart[5] = i.PowerC06 == null ? "0" : i.PowerC06.ToString();
                    gPowerM.PowerC07 = i.PowerC07 == null ? 0 : i.PowerC07;
                    millChart[6] = i.PowerC07 == null ? "0" : i.PowerC07.ToString();
                    gPowerM.PowerC08 = i.PowerC08 == null ? 0 : i.PowerC08;
                    millChart[7] = i.PowerC08 == null ? "0" : i.PowerC08.ToString();
                    gPowerMs.Add(gPowerM);
                }
            }
            totalPower.GPowerM = gPowerMs;

            string[] chartmill = new string[millChart.Length + 1];
            string[] chartmillName = new string[millChart.Length + 1];
            int total = 100;
            for (int i = 0; i < millChart.Length; i++)
            {
                if (millChart[i] != "0")
                {
                    if (totPower != "0")
                    {
                        double tp = double.Parse(totPower);
                        double mi = double.Parse(millChart[i]);
                        double sum = Math.Round(mi / tp * 100, 0);
                        total -= Convert.ToInt32(sum);
                        chartmill[i] = sum.ToString();
                        chartmillName[i] = "#" + (i + 1) + " " + sum + "%";
                    }
                }
                else
                {
                    chartmill[i] = "0";
                    chartmillName[i] = "0";
                }
            }

            chartmillName[millChart.Length] = "#其他" + total + "%";
            //將不等於0的留下
            chartmill[millChart.Length] = total.ToString();
            chartmill = chartmill.Where(x => x != "0").ToArray();

            //將不等於0的留下
            chartmillName = chartmillName.Where(x => x != "0").ToArray();

            totalPower.millChart = chartmill;
            totalPower.millNameChart = chartmillName;

            return Json(totalPower);
        }
    }
}
