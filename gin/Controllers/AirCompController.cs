using gin.Models;
using gin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Presentation;

namespace gin.Controllers
{
    public class AirCompController : Controller
    {
        private readonly ZDBContext _ZDBContext;

        public AirCompController(ZDBContext zDBContext)
        {
            _ZDBContext = zDBContext;
        }

        //每日資料
        [Authorize(Policy = "CustomPolicy")]
        public IActionResult AirCompList(string factory, string day, string m)
        {
            string newDay = day;
            string newDDay = "";
            if (newDay == null)
            {
                newDay = DateTime.Now.ToString("yyyy-MM-dd");
                newDDay = DateTime.Now.ToString("yyyy-MM");
                m = "#0";
            }
            else
            {
                newDay = DateTime.Now.ToString(day);
                DateTime dateTimee = DateTime.Parse(day);
                newDDay = dateTimee.ToString("yyyy-MM").Substring(0, 7);
                m = m;
            }

            ViewBag.day = newDay;
            ViewBag.factory = factory;
            ViewBag.firstM = m;
            ViewBag.newDay = newDDay;

            var data = _ZDBContext.GAirCompHs.Where(x => x.FactoryId == factory && x.DataDate == DateTime.Parse(newDay) && x.Mid == m).ToList();
            var air = _ZDBContext.GAirCompMappings.Where(x => x.FactoryId == factory).OrderBy(x => x.Mid).Select(x => x.Mid).ToList();
            ViewBag.air = air;

            decimal? sumPowerC = 0;
            decimal? sumAirCon = 0;
            decimal? avgPower = 0;
            int j = 0;
            string[] specificPower = new string[data.Count];
            string[] dateTime = new string[data.Count];

            foreach (var i in data)
            {
                dateTime[j] = i.Dtime.ToString("HH:mm");
                specificPower[j] = i.SpecificPower.ToString();
                if (i.PowerC01 != null)
                {
                    sumPowerC += i.PowerC01;
                }
                if (i.PowerC02 != null)
                {
                    sumPowerC += i.PowerC02;
                }
                if (i.PowerC03 != null)
                {
                    sumPowerC += i.PowerC03;
                }
                if (i.PowerC04 != null)
                {
                    sumPowerC += i.PowerC04;
                }
                if (i.PowerC05 != null)
                {
                    sumPowerC += i.PowerC05;
                }
                if (i.AirConsumption != null)
                {
                    if (i.AirConsumption < 1000)
                    {
                        sumAirCon += i.AirConsumption;
                    }
                }
                j++;
            }
            if (data.Count > 0)
            {
                if (sumAirCon > 0 && sumAirCon > 0)
                {
                    avgPower = sumPowerC / sumAirCon;
                }
                else
                {
                    avgPower = 0;
                }
            }
            else
            {
                avgPower = 0;
            }


            string[] avg = new string[data.Count];
            if (data.Count > 0)
            {
                for (int a = 0; a < data.Count; a++)
                {
                    avg[a] = string.Format("{0:#,0.##}", avgPower);
                }
            }
            else
            {
                avg = new string[1];
                avg[0] = "0";
            }

            AirCompHViewModel airCompHViewModel = new AirCompHViewModel();
            airCompHViewModel.airCompH = data;
            airCompHViewModel.specificPower = specificPower;
            airCompHViewModel.dateTime = dateTime;
            airCompHViewModel.Avg = avg;
            return View(airCompHViewModel);
        }

        //每日資料刷新Chartjs //Json
        public IActionResult LoadNewData(string p, string d, string f, string m)
        {
            var data = _ZDBContext.GAirCompHs.Where(x => x.FactoryId == f && x.DataDate == DateTime.Parse(d) && x.Mid == m).ToList();
            List<decimal?> D = new List<decimal?>();
            switch (p)
            {
                case "AirConsumption":
                    D = data.Select(x => x.AirConsumption).ToList();
                    break;
                case "PowerC":
                    D = data.Select(x => x.PowerC).ToList();
                    break;
                case "PowerC01":
                    D = data.Select(x => x.PowerC01).ToList();
                    break;
                case "WorkTime01":
                    D = data.Select(x => x.WorkTime01 / 60).ToList();
                    break;
                case "PowerC02":
                    D = data.Select(x => x.PowerC02).ToList();
                    break;
                case "WorkTime02":
                    D = data.Select(x => x.WorkTime02 / 60).ToList();
                    break;
                case "PowerC03":
                    D = data.Select(x => x.PowerC03).ToList();
                    break;
                case "WorkTime03":
                    D = data.Select(x => x.WorkTime03 / 60).ToList();
                    break;
                case "PowerC04":
                    D = data.Select(x => x.PowerC04).ToList();
                    break;
                case "WorkTime04":
                    D = data.Select(x => x.WorkTime04 / 60).ToList();
                    break;
                case "PowerC05":
                    D = data.Select(x => x.PowerC05).ToList();
                    break;
                case "WorkTime05":
                    D = data.Select(x => x.WorkTime05 / 60).ToList();
                    break;
            }
            return Json(D);
        }

        //驗證有無資料再下載excel
        public IActionResult CheckData(string data)
        {
            var dd = JsonConvert.DeserializeObject<CreateExcel>(data);
            if (dd.specificPower.Count != 0)
            {
                return Json("Ok");
            }
            else
            {
                return Json("No");
            }

        }

        //日的excel 
        public IActionResult CreatEexcelday(string fock)
        {
            //將 JSON 字串轉換成 CreateExcel 物件
            var data = JsonConvert.DeserializeObject<CreateExcel>(fock);

            // 創建一個新的 excel 資料包
            using var package = new ExcelPackage();
            // 添加一個工作表
            var worksheet = package.Workbook.Worksheets.Add("Chart");
            // 添加數據
            string factory = data.factoryId;
            var gAirComp = _ZDBContext.GAirCompHs.Where(x => x.FactoryId == factory && x.DataDate == DateTime.Parse(data.day) && x.Mid == data.m).ToList();
            List<GAirCompH?> D = new List<GAirCompH?>();
            D = gAirComp.ToList();
            string fName = "";
            switch (factory)
            {
                case "KY-T1HIST":
                    fName = "觀音廠";
                    break;
                case "BL-T1HIST":
                    fName = "八里廠";
                    break;
                case "QX-T1HIST":
                    fName = "全興廠";
                    break;
                case "ZB-T1HIST":
                    fName = "彰濱廠";
                    break;
                case "KH-PCC-LH":
                    fName = "高雄廠";
                    break;
                case "LD-T1HIST":
                    fName = "龍德廠";
                    break;
                case "LZ-T1HIST":
                    fName = "利澤廠";
                    break;
                case "HL-T1HIST":
                    fName = "花蓮廠";
                    break;
            }

            int t = 0;
            int da = 200;
            int row = 21;
            int count = data.date.Count;
            string mill = data.m;
            row += count;
            da += count;
            string newRow = "B22:B" + row;
            string daR = "A201:A" + da;
            string spR = "B201:B" + da;
            string m = data.m == "#0" ? "" : data.m;
            string title = fName + "_空壓機/比功率" + m + "_" + data.day;

            string airC = "C22:C" + row;
            string pC = "D22:D" + row;

            string pC1 = "E22:E" + row;
            string pC1N = "E21";
            string wT01 = "G22:G" + row;
            string wT01N = "G21";
            string pC2 = "H22:H" + row;
            string pC2N = "H21";
            string wT02 = "J22:J" + row;
            string wT02N = "J21";
            string pC3 = "K22:K" + row;
            string pC3N = "K21";
            string wT03 = "M22:M" + row;
            string wT03N = "M21";
            string pC4 = "N22:N" + row;
            string pC4N = "N21";
            string wT04 = "P22:P" + row;
            string wT04N = "P21";
            string pC5 = "Q22:Q" + row;
            string pC5N = "Q21";
            string wT05 = "S22:S" + row;
            string wT05N = "S21";

            worksheet.Cells["B200"].Value = "平均比功率";
            worksheet.Cells["A21"].Value = "日期";
            worksheet.Cells["B21"].Value = "比功率";
            worksheet.Cells["C21"].Value = "空氣用量M3/Min";
            worksheet.Cells["D21"].Value = "用電量";

            foreach (var gAirD in D)
            {
                worksheet.Cells[22 + t, 1].Value = gAirD.Dtime.ToString("MM-dd HH:mm");
                worksheet.Cells[22 + t, 3].Value = gAirD.AirConsumption;
                worksheet.Cells[22 + t, 4].Value = gAirD.PowerC;
                t++;
            }
            t = 0;
            if (factory == "KY-T1HIST" || factory == "QX-T1HIST")
            {
                if (mill == "#0")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["L21"].Value = "#3KWH7轉(分)";
                    worksheet.Cells["M21"].Value = "#3運轉(分)";
                    worksheet.Cells["N21"].Value = "#4用電量";
                    worksheet.Cells["O21"].Value = "#4KWH(時)";
                    worksheet.Cells["P21"].Value = "#4運轉(分)";
                    foreach (var gAirD in D)
                    {

                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 60;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 60;
                        worksheet.Cells[22 + t, 11].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 12].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 13].Value = gAirD.WorkTime03 / 60;
                        worksheet.Cells[22 + t, 14].Value = gAirD.PowerC04;
                        worksheet.Cells[22 + t, 15].Value = gAirD.PowerCh04;
                        worksheet.Cells[22 + t, 16].Value = gAirD.WorkTime04 / 60;
                        t++;
                    }
                }
                if (factory == "KY-T1HIST" && mill == "#1")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 60;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 60;

                        t++;
                    }
                }
                else if (factory == "QX-T1HIST" && mill == "#1")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 60;
                        t++;
                    }
                }
                else if (mill == "#2")
                {
                    pC3 = "E22:E" + row;
                    pC3N = "E21";
                    wT03 = "G22:G" + row;
                    wT03N = "G21";

                    pC4 = "H22:H" + row;
                    pC4N = "H21";
                    wT04 = "J22:J" + row;
                    wT04N = "J21";

                    worksheet.Cells["E21"].Value = "#3用電量";
                    worksheet.Cells["F21"].Value = "#3KWH(時)";
                    worksheet.Cells["G21"].Value = "#3運轉(分)";
                    worksheet.Cells["H21"].Value = "#4用電量";
                    worksheet.Cells["I21"].Value = "#4KWH(時)";
                    worksheet.Cells["J21"].Value = "#4運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime03 / 60;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC04;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh04;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime04 / 60;
                        t++;
                    }
                }
                else if (mill == "#2#3#4")
                {
                    pC2 = "E22:E" + row;
                    pC2N = "E21";
                    wT02 = "G22:G" + row;
                    wT02N = "G21";

                    pC3 = "H22:H" + row;
                    pC3N = "H21";
                    wT03 = "J22:J" + row;
                    wT03N = "J21";

                    pC4 = "K22:K" + row;
                    pC4N = "K21";
                    wT04 = "M22:M" + row;
                    wT04N = "M21";

                    worksheet.Cells["E21"].Value = "#2用電量";
                    worksheet.Cells["F21"].Value = "#2KWH(時)";
                    worksheet.Cells["G21"].Value = "#2運轉(分)";
                    worksheet.Cells["H21"].Value = "#3用電量";
                    worksheet.Cells["I21"].Value = "#3KWH7轉(分)";
                    worksheet.Cells["J21"].Value = "#3運轉(分)";
                    worksheet.Cells["K21"].Value = "#4用電量";
                    worksheet.Cells["L21"].Value = "#4KWH(時)";
                    worksheet.Cells["M21"].Value = "#4運轉(分)";

                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime02 / 60;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime03 / 60;
                        worksheet.Cells[22 + t, 11].Value = gAirD.PowerC04;
                        worksheet.Cells[22 + t, 12].Value = gAirD.PowerCh04;
                        worksheet.Cells[22 + t, 13].Value = gAirD.WorkTime04 / 60;
                        t++;
                    }
                }
            }
            else if (factory == "BL-T1HIST" || factory == "LD-T1HIST" || factory == "LZ-T1HIST")
            {
                if (mill == "#0")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["L21"].Value = "#3KWH(時)";
                    worksheet.Cells["M21"].Value = "#3運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 60;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 60;
                        worksheet.Cells[22 + t, 11].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 12].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 13].Value = gAirD.WorkTime03 / 60;
                        t++;
                    }
                }
                else if (factory == "LD-T1HIST" && mill == "#1")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 60;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 60;
                        t++;
                    }
                }
                else if (factory == "LD-T1HIST" && mill == "#2")
                {
                    pC3 = "E22:E" + row;
                    pC3N = "E22";
                    wT03 = "G22:G" + row;
                    wT03N = "G21";

                    worksheet.Cells["E21"].Value = "#3用電量";
                    worksheet.Cells["F21"].Value = "#3KWH(時)";
                    worksheet.Cells["G21"].Value = "#3運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime03 / 60;
                        t++;
                    }
                }
            }
            else if (factory == "ZB-T1HIST")
            {
                if (mill == "#0")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["L21"].Value = "#3KWH(時)";
                    worksheet.Cells["M21"].Value = "#3運轉(分)";
                    worksheet.Cells["N21"].Value = "#4用電量";
                    worksheet.Cells["O21"].Value = "#4KWH(時)";
                    worksheet.Cells["P21"].Value = "#4運轉(分)";
                    worksheet.Cells["Q21"].Value = "#5用電量";
                    worksheet.Cells["R21"].Value = "#5KWH(時)";
                    worksheet.Cells["S21"].Value = "#5運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 60;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 60;
                        worksheet.Cells[22 + t, 11].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 12].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 13].Value = gAirD.WorkTime03 / 60;
                        worksheet.Cells[22 + t, 14].Value = gAirD.PowerC04;
                        worksheet.Cells[22 + t, 15].Value = gAirD.PowerCh04;
                        worksheet.Cells[22 + t, 16].Value = gAirD.WorkTime04 / 60;
                        worksheet.Cells[22 + t, 17].Value = gAirD.PowerC05;
                        worksheet.Cells[22 + t, 18].Value = gAirD.PowerCh05;
                        worksheet.Cells[22 + t, 19].Value = gAirD.WorkTime05 / 60;
                        t++;
                    }
                }
                else if (mill == "#1#2#3")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["L21"].Value = "#3KWH(時)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 60;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 60;
                        worksheet.Cells[22 + t, 11].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 12].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 13].Value = gAirD.WorkTime03 / 60;
                        t++;
                    }
                }
                else
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 60;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 60;
                        t++;
                    }
                }

            }
            else
            {
                worksheet.Cells["E21"].Value = "#1用電量";
                worksheet.Cells["F21"].Value = "#1KWH(時)";
                worksheet.Cells["G21"].Value = "#1運轉(分)";
                worksheet.Cells["H21"].Value = "#2用電量";
                worksheet.Cells["I21"].Value = "#2KWH(時)";
                worksheet.Cells["J21"].Value = "#2運轉(分)";
                foreach (var gAirD in D)
                {
                    worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                    worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                    worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 60;
                    worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                    worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                    worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 60;
                    t++;
                }
            }
            t = 0;
            foreach (var d in data.date)
            {
                worksheet.Cells[22 + t, 2].Value = float.Parse(data.specificPower[t]);
                worksheet.Cells[201 + t, 1].Value = d;
                worksheet.Cells[201 + t, 2].Value = float.Parse(data.avg[t]);
                t++;
            }


            // 創建一個折線圖系列對象，設置數據範圍和類型 -- 平均比功率圖
            var chart = worksheet.Drawings.AddChart("", eChartType.LineMarkers);
            var lineChartSeries = chart.Series.Add(worksheet.Cells[spR], worksheet.Cells[daR]);
            lineChartSeries.HeaderAddress = worksheet.Cells["B200"];   //線條名稱

            // 設置圖表標題和軸標籤
            chart.Title.Text = title;
            chart.Legend.Add();
            chart.Legend.Position = eLegendPosition.Bottom;
            chart.ShowHiddenData = true;
            chart.SetPosition(0, 0);  //圖表位置
            chart.SetSize(1300, 400);  //圖表大小

            // 創建一個柱狀圖系列對象，設置數據範圍和類型 -- 比功率
            var linChart2 = chart.PlotArea.ChartTypes.Add(eChartType.LineMarkers);
            var linChartSeries2 = linChart2.Series.Add(worksheet.Cells[newRow]);
            linChartSeries2.HeaderAddress = worksheet.Cells["B21"];

            var bar = chart.PlotArea.ChartTypes.Add(eChartType.ColumnClustered);
            ExcelChartSerie bar2 = null;
            bar.UseSecondaryAxis = true; // 設置另一條Y軸

            if (data.checkBox.Count > 0)
            {
                foreach (var s in data.checkBox)
                {
                    switch (s)
                    {
                        case "AirConsumption":
                            bar2 = bar.Series.Add(worksheet.Cells[airC]);
                            bar2.HeaderAddress = worksheet.Cells["C21"];
                            break;
                        case "PowerC":
                            bar2 = bar.Series.Add(worksheet.Cells[pC]);
                            bar2.HeaderAddress = worksheet.Cells["D21"];
                            break;
                        case "PowerC01":
                            bar2 = bar.Series.Add(worksheet.Cells[pC1]);
                            bar2.HeaderAddress = worksheet.Cells[pC1N];
                            break;
                        case "WorkTime01":
                            bar2 = bar.Series.Add(worksheet.Cells[wT01]);
                            bar2.HeaderAddress = worksheet.Cells[wT01N];
                            break;
                        case "PowerC02":
                            bar2 = bar.Series.Add(worksheet.Cells[pC2]);
                            bar2.HeaderAddress = worksheet.Cells[pC2N];
                            break;
                        case "WorkTime02":
                            bar2 = bar.Series.Add(worksheet.Cells[wT02]);
                            bar2.HeaderAddress = worksheet.Cells[wT02N];
                            break;
                        case "PowerC03":
                            bar2 = bar.Series.Add(worksheet.Cells[pC3]);
                            bar2.HeaderAddress = worksheet.Cells[pC3N];
                            break;
                        case "WorkTime03":
                            bar2 = bar.Series.Add(worksheet.Cells[wT03]);
                            bar2.HeaderAddress = worksheet.Cells[wT03N];
                            break;
                        case "PowerC04":
                            bar2 = bar.Series.Add(worksheet.Cells[pC4]);
                            bar2.HeaderAddress = worksheet.Cells[pC4N];
                            break;
                        case "WorkTime04":
                            bar2 = bar.Series.Add(worksheet.Cells[wT04]);
                            bar2.HeaderAddress = worksheet.Cells[wT04N];
                            break;
                        case "PowerC05":
                            bar2 = bar.Series.Add(worksheet.Cells[pC5]);
                            bar2.HeaderAddress = worksheet.Cells[pC5N];
                            break;
                        case "WorkTime05":
                            bar2 = bar.Series.Add(worksheet.Cells[wT05]);
                            bar2.HeaderAddress = worksheet.Cells[wT05N];
                            break;
                    }
                }
            }

            var stream = new MemoryStream();
            package.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);

            // 回傳 Excel 文件
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", title + ".xlsx");

        }

        //每月資料
        [Authorize(Policy = "CustomPolicy")]
        public IActionResult AirCompMonList(string factory, string day, string m)
        {
            string newDay = day;
            m = m;
            ViewBag.day = newDay;
            ViewBag.firstM = m;
            DateTime nowMon = DateTime.Parse(newDay);

            string nowwMon = DateTime.Now.ToString("yyyy-MM"); // 抓取當下的月份20XX-XX
            DateTime firstDay = DateTime.Parse(DateTime.Now.ToString(newDay) + "-01");  //抓取當月的第一天
            DateTime lastDay = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")); //抓取當下的這一天

            if (day != nowwMon)
            {
                lastDay = nowMon.AddMonths(+1).AddDays(-1);
            }
            ViewBag.factory = factory;

            var data = _ZDBContext.GAirComps.Where(x => x.FactoryId == factory && x.DataDate >= firstDay && x.DataDate <= lastDay && x.Mid == m).ToList();
            var air = _ZDBContext.GAirCompMappings.Where(x => x.FactoryId == factory).OrderBy(x => x.Mid).Select(x => x.Mid).ToList();
            ViewBag.air = air;

            decimal? sumPowerC = 0;
            decimal? sumAirCon = 0;
            decimal? avgPower = 0;
            int j = 0;
            string[] specificPower = new string[data.Count];
            string[] dateTime = new string[data.Count];
            foreach (var i in data)
            {
                dateTime[j] = i.DataDate.ToString("MM-dd");
                specificPower[j] = i.SpecificPower.ToString();
                if (i.PowerC01 != null)
                {
                    sumPowerC += i.PowerC01;
                }
                if (i.PowerC02 != null)
                {
                    sumPowerC += i.PowerC02;
                }
                if (i.PowerC03 != null)
                {
                    sumPowerC += i.PowerC03;
                }
                if (i.PowerC04 != null)
                {
                    sumPowerC += i.PowerC04;
                }
                if (i.PowerC05 != null)
                {
                    sumPowerC += i.PowerC05;
                }
                if (i.AirConsumption != null)
                {
                    sumAirCon += i.AirConsumption;
                }
                j++;
            }
            if (data.Count > 0)
            {
                avgPower = sumPowerC / sumAirCon;
            }
            else
            {
                avgPower = 0;
            }

            string[] avg = new string[data.Count];
            if (data.Count > 0)
            {
                for (int a = 0; a < data.Count; a++)
                {
                    avg[a] = string.Format("{0:#,0.##}", avgPower);
                }
            }
            else
            {
                avg = new string[1];
                avg[0] = "0";
            }

            AirCompViewModel airCompViewModel = new AirCompViewModel();
            airCompViewModel.airComp = data;
            airCompViewModel.specificPower = specificPower;
            airCompViewModel.dateTime = dateTime;
            airCompViewModel.Avg = avg;
            return View(airCompViewModel);
        }

        //每月資料刷新Chartjs //Json
        public IActionResult LoadNewMonData(string p, string d, string f, string m)
        {
            string newDay = d;
            if (newDay == null)
            {
                newDay = DateTime.Now.ToString("yyyy-MM");
            }
            else
            {
                newDay = DateTime.Now.ToString(d);
            }
            DateTime nowMon = DateTime.Parse(newDay);
            ViewBag.day = newDay;
            string nowwMon = DateTime.Now.ToString("yyyy-MM"); // 抓取當下的月份20XX-XX
            DateTime firstDay = DateTime.Parse(DateTime.Now.ToString(newDay) + "-01");  //抓取當月的第一天
            DateTime lastDay = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")); //抓取當下的這一天

            if (d != nowwMon)
            {
                lastDay = nowMon.AddMonths(+1).AddDays(-1);
            }

            var data = _ZDBContext.GAirComps.Where(x => x.FactoryId == f && x.DataDate >= firstDay && x.DataDate <= lastDay && x.Mid == m).ToList();
            List<decimal?> D = new List<decimal?>();

            switch (p)
            {
                case "AirConsumption":
                    D = data.Select(x => x.AirConsumption).ToList();
                    break;
                case "PowerC":
                    D = data.Select(x => x.PowerC).ToList();
                    break;
                case "PowerC01":
                    D = data.Select(x => x.PowerC01).ToList();
                    break;
                case "WorkTime01":
                    D = data.Select(x => x.WorkTime01 / 3600).ToList();
                    break;
                case "PowerC02":
                    D = data.Select(x => x.PowerC02).ToList();
                    break;
                case "WorkTime02":
                    D = data.Select(x => x.WorkTime02 / 3600).ToList();
                    break;
                case "PowerC03":
                    D = data.Select(x => x.PowerC03).ToList();
                    break;
                case "WorkTime03":
                    D = data.Select(x => x.WorkTime03 / 3600).ToList();
                    break;
                case "PowerC04":
                    D = data.Select(x => x.PowerC04).ToList();
                    break;
                case "WorkTime04":
                    D = data.Select(x => x.WorkTime04 / 3600).ToList();
                    break;
                case "PowerC05":
                    D = data.Select(x => x.PowerC05).ToList();
                    break;
                case "WorkTime05":
                    D = data.Select(x => x.WorkTime05 / 3600).ToList();
                    break;
            }
            return Json(D);
        }
        public IActionResult CreatEexceldMon(string fock)
        {
            //將 JSON 字串轉換成 CreateExcel 物件
            var data = JsonConvert.DeserializeObject<CreateExcel>(fock);

            string newDay = data.day;
            DateTime nowMon = DateTime.Parse(newDay);

            string nowwMon = DateTime.Now.ToString("yyyy-MM"); // 抓取當下的月份20XX-XX
            DateTime firstDay = DateTime.Parse(DateTime.Now.ToString(newDay) + "-01");  //抓取當月的第一天

            string input = newDay;
            var year = int.Parse(input.Split("-")[0]);
            var month = int.Parse(input.Split("-")[1]);
            var daysInMonth = DateTime.DaysInMonth(year, month);
            var lastDayOfMonth = new DateTime(year, month, daysInMonth);
            DateTime lastDay = DateTime.Parse(lastDayOfMonth.ToString("yyyy-MM-dd"));

            // 創建一個新的 excel 資料包
            using var package = new ExcelPackage();
            // 添加一個工作表
            var worksheet = package.Workbook.Worksheets.Add("Chart");
            // 添加數據
            string factory = data.factoryId;
            var gAirComp = _ZDBContext.GAirComps.Where(x => x.FactoryId == factory && x.DataDate >= firstDay && x.DataDate <= lastDay && x.Mid == data.m).ToList();
            List<GAirComp?> D = new List<GAirComp?>();
            D = gAirComp.ToList();
            string fName = "";
            switch (factory)
            {
                case "KY-T1HIST":
                    fName = "觀音廠";
                    break;
                case "BL-T1HIST":
                    fName = "八里廠";
                    break;
                case "QX-T1HIST":
                    fName = "全興廠";
                    break;
                case "ZB-T1HIST":
                    fName = "彰濱廠";
                    break;
                case "KH-PCC-LH":
                    fName = "高雄廠";
                    break;
                case "LD-T1HIST":
                    fName = "龍德廠";
                    break;
                case "LZ-T1HIST":
                    fName = "利澤廠";
                    break;
                case "HL-T1HIST":
                    fName = "花蓮廠";
                    break;
            }

            int t = 0;
            int da = 200;
            int row = 21;
            int count = data.date.Count;
            row += count;
            da += count;
            string mill = data.m;
            string newRow = "B22:B" + row;
            string daR = "A201:A" + da;
            string spR = "B201:B" + da;
            string m = data.m == "#0" ? "" : data.m;
            string title = fName + "_空壓機/比功率" + m + "_" + data.day;

            worksheet.Cells["B200"].Value = "平均比功率";
            worksheet.Cells["A21"].Value = "日期";
            worksheet.Cells["B21"].Value = "比功率";
            worksheet.Cells["C21"].Value = "空氣用量M3/Min";
            worksheet.Cells["D21"].Value = "用電量";

            string airC = "C22:C" + row;
            string pC = "D22:D" + row;

            string pC1 = "E22:E" + row;
            string pC1N = "E21";
            string wT01 = "G22:G" + row;
            string wT01N = "G21";
            string pC2 = "H22:H" + row;
            string pC2N = "H21";
            string wT02 = "J22:J" + row;
            string wT02N = "J21";
            string pC3 = "K22:K" + row;
            string pC3N = "K21";
            string wT03 = "M22:M" + row;
            string wT03N = "M21";
            string pC4 = "N22:N" + row;
            string pC4N = "N21";
            string wT04 = "P22:P" + row;
            string wT04N = "P21";
            string pC5 = "Q22:Q" + row;
            string pC5N = "Q21";
            string wT05 = "S22:S" + row;
            string wT05N = "S21";

            worksheet.Cells["B200"].Value = "平均比功率";
            worksheet.Cells["A21"].Value = "日期";
            worksheet.Cells["B21"].Value = "比功率";
            worksheet.Cells["C21"].Value = "空氣用量M3/Min";
            worksheet.Cells["D21"].Value = "用電量";

            foreach (var gAirD in D)
            {
                worksheet.Cells[22 + t, 1].Value = gAirD.DataDate.ToString("yyyy-MM-dd");
                worksheet.Cells[22 + t, 3].Value = gAirD.AirConsumption;
                worksheet.Cells[22 + t, 4].Value = gAirD.PowerC;
                t++;
            }
            t = 0;
            if (factory == "KY-T1HIST" || factory == "QX-T1HIST")
            {
                if (mill == "#0")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["L21"].Value = "#3KWH7轉(分)";
                    worksheet.Cells["M21"].Value = "#3運轉(分)";
                    worksheet.Cells["N21"].Value = "#4用電量";
                    worksheet.Cells["O21"].Value = "#4KWH(時)";
                    worksheet.Cells["P21"].Value = "#4運轉(分)";
                    foreach (var gAirD in D)
                    {

                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 3600;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 3600;
                        worksheet.Cells[22 + t, 11].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 12].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 13].Value = gAirD.WorkTime03 / 3600;
                        worksheet.Cells[22 + t, 14].Value = gAirD.PowerC04;
                        worksheet.Cells[22 + t, 15].Value = gAirD.PowerCh04;
                        worksheet.Cells[22 + t, 16].Value = gAirD.WorkTime04 / 3600;
                        t++;
                    }
                }
                if (factory == "KY-T1HIST" && mill == "#1")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 3600;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 3600;

                        t++;
                    }
                }
                else if (factory == "QX-T1HIST" && mill == "#1")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 3600;
                        t++;
                    }
                }
                else if (mill == "#2")
                {
                    pC3 = "E22:E" + row;
                    pC3N = "E21";
                    wT03 = "G22:G" + row;
                    wT03N = "G21";

                    pC4 = "H22:H" + row;
                    pC4N = "H21";
                    wT04 = "J22:J" + row;
                    wT04N = "J21";

                    worksheet.Cells["E21"].Value = "#3用電量";
                    worksheet.Cells["F21"].Value = "#3KWH(時)";
                    worksheet.Cells["G21"].Value = "#3運轉(分)";
                    worksheet.Cells["H21"].Value = "#4用電量";
                    worksheet.Cells["I21"].Value = "#4KWH(時)";
                    worksheet.Cells["J21"].Value = "#4運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime03 / 3600;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC04;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh04;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime04 / 3600;
                        t++;
                    }
                }
                else if (mill == "#2#3#4")
                {
                    pC2 = "E22:E" + row;
                    pC2N = "E21";
                    wT02 = "G22:G" + row;
                    wT02N = "G21";

                    pC3 = "H22:H" + row;
                    pC3N = "H21";
                    wT03 = "J22:J" + row;
                    wT03N = "J21";

                    pC4 = "K22:K" + row;
                    pC4N = "K21";
                    wT04 = "M22:M" + row;
                    wT04N = "M21";

                    worksheet.Cells["E21"].Value = "#2用電量";
                    worksheet.Cells["F21"].Value = "#2KWH(時)";
                    worksheet.Cells["G21"].Value = "#2運轉(分)";
                    worksheet.Cells["H21"].Value = "#3用電量";
                    worksheet.Cells["I21"].Value = "#3KWH7轉(分)";
                    worksheet.Cells["J21"].Value = "#3運轉(分)";
                    worksheet.Cells["K21"].Value = "#4用電量";
                    worksheet.Cells["L21"].Value = "#4KWH(時)";
                    worksheet.Cells["M21"].Value = "#4運轉(分)";

                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime02 / 3600;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime03 / 3600;
                        worksheet.Cells[22 + t, 11].Value = gAirD.PowerC04;
                        worksheet.Cells[22 + t, 12].Value = gAirD.PowerCh04;
                        worksheet.Cells[22 + t, 13].Value = gAirD.WorkTime04 / 3600;
                        t++;
                    }
                }
            }
            else if (factory == "BL-T1HIST" || factory == "LD-T1HIST" || factory == "LZ-T1HIST")
            {
                if (mill == "#0")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["L21"].Value = "#3KWH(時)";
                    worksheet.Cells["M21"].Value = "#3運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 3600;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 3600;
                        worksheet.Cells[22 + t, 11].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 12].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 13].Value = gAirD.WorkTime03 / 3600;
                        t++;
                    }
                }
                else if (factory == "LD-T1HIST" && mill == "#1")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 3600;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 3600;
                        t++;
                    }
                }
                else if (factory == "LD-T1HIST" && mill == "#2")
                {
                    pC3 = "E22:E" + row;
                    pC3N = "E22";
                    wT03 = "G22:G" + row;
                    wT03N = "G21";

                    worksheet.Cells["E21"].Value = "#3用電量";
                    worksheet.Cells["F21"].Value = "#3KWH(時)";
                    worksheet.Cells["G21"].Value = "#3運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime03 / 3600;
                        t++;
                    }
                }
            }
            else if (factory == "ZB-T1HIST")
            {
                if (mill == "#0")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["L21"].Value = "#3KWH(時)";
                    worksheet.Cells["M21"].Value = "#3運轉(分)";
                    worksheet.Cells["N21"].Value = "#4用電量";
                    worksheet.Cells["O21"].Value = "#4KWH(時)";
                    worksheet.Cells["P21"].Value = "#4運轉(分)";
                    worksheet.Cells["Q21"].Value = "#5用電量";
                    worksheet.Cells["R21"].Value = "#5KWH(時)";
                    worksheet.Cells["S21"].Value = "#5運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 3600;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 3600;
                        worksheet.Cells[22 + t, 11].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 12].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 13].Value = gAirD.WorkTime03 / 3600;
                        worksheet.Cells[22 + t, 14].Value = gAirD.PowerC04;
                        worksheet.Cells[22 + t, 15].Value = gAirD.PowerCh04;
                        worksheet.Cells[22 + t, 16].Value = gAirD.WorkTime04 / 3600;
                        worksheet.Cells[22 + t, 17].Value = gAirD.PowerC05;
                        worksheet.Cells[22 + t, 18].Value = gAirD.PowerCh05;
                        worksheet.Cells[22 + t, 19].Value = gAirD.WorkTime05 / 3600;
                        t++;
                    }
                }
                else if (mill == "#1#2#3")
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["K21"].Value = "#3用電量";
                    worksheet.Cells["L21"].Value = "#3KWH(時)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 3600;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 3600;
                        worksheet.Cells[22 + t, 11].Value = gAirD.PowerC03;
                        worksheet.Cells[22 + t, 12].Value = gAirD.PowerCh03;
                        worksheet.Cells[22 + t, 13].Value = gAirD.WorkTime03 / 3600;
                        t++;
                    }
                }
                else
                {
                    worksheet.Cells["E21"].Value = "#1用電量";
                    worksheet.Cells["F21"].Value = "#1KWH(時)";
                    worksheet.Cells["G21"].Value = "#1運轉(分)";
                    worksheet.Cells["H21"].Value = "#2用電量";
                    worksheet.Cells["I21"].Value = "#2KWH(時)";
                    worksheet.Cells["J21"].Value = "#2運轉(分)";
                    foreach (var gAirD in D)
                    {
                        worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                        worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                        worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 3600;
                        worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                        worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                        worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 3600;
                        t++;
                    }
                }

            }
            else
            {
                worksheet.Cells["E21"].Value = "#1用電量";
                worksheet.Cells["F21"].Value = "#1KWH(時)";
                worksheet.Cells["G21"].Value = "#1運轉(分)";
                worksheet.Cells["H21"].Value = "#2用電量";
                worksheet.Cells["I21"].Value = "#2KWH(時)";
                worksheet.Cells["J21"].Value = "#2運轉(分)";
                foreach (var gAirD in D)
                {
                    worksheet.Cells[22 + t, 5].Value = gAirD.PowerC01;
                    worksheet.Cells[22 + t, 6].Value = gAirD.PowerCh01;
                    worksheet.Cells[22 + t, 7].Value = gAirD.WorkTime01 / 3600;
                    worksheet.Cells[22 + t, 8].Value = gAirD.PowerC02;
                    worksheet.Cells[22 + t, 9].Value = gAirD.PowerCh02;
                    worksheet.Cells[22 + t, 10].Value = gAirD.WorkTime02 / 3600;
                    t++;
                }
            }
            t = 0;
            foreach (var d in data.date)
            {
                worksheet.Cells[22 + t, 2].Value = float.Parse(data.specificPower[t]);
                worksheet.Cells[201 + t, 1].Value = d;
                worksheet.Cells[201 + t, 2].Value = float.Parse(data.avg[t]);
                t++;
            }



            // 創建一個折線圖系列對象，設置數據範圍和類型 -- 平均比功率圖
            var chart = worksheet.Drawings.AddChart("", eChartType.LineMarkers);
            var lineChartSeries = chart.Series.Add(worksheet.Cells[spR], worksheet.Cells[daR]);
            lineChartSeries.HeaderAddress = worksheet.Cells["B200"];   //線條名稱

            // 設置圖表標題和軸標籤
            chart.Title.Text = title;
            chart.Legend.Add();
            chart.Legend.Position = eLegendPosition.Bottom;
            chart.ShowHiddenData = true;
            chart.SetPosition(0, 0);  //圖表位置
            chart.SetSize(1300, 400);  //圖表大小

            // 創建一個柱狀圖系列對象，設置數據範圍和類型 -- 比功率
            var linChart2 = chart.PlotArea.ChartTypes.Add(eChartType.LineMarkers);
            var linChartSeries2 = linChart2.Series.Add(worksheet.Cells[newRow]);
            linChartSeries2.HeaderAddress = worksheet.Cells["B21"];

            var bar = chart.PlotArea.ChartTypes.Add(eChartType.ColumnClustered);
            ExcelChartSerie bar2 = null;
            bar.UseSecondaryAxis = true; // 設置另一條Y軸


            if (data.checkBox.Count > 0)
            {
                foreach (var s in data.checkBox)
                {
                    switch (s)
                    {
                        case "AirConsumption":
                            bar2 = bar.Series.Add(worksheet.Cells[airC]);
                            bar2.HeaderAddress = worksheet.Cells["C21"];
                            break;
                        case "PowerC":
                            bar2 = bar.Series.Add(worksheet.Cells[pC]);
                            bar2.HeaderAddress = worksheet.Cells["D21"];
                            break;
                        case "PowerC01":
                            bar2 = bar.Series.Add(worksheet.Cells[pC1]);
                            bar2.HeaderAddress = worksheet.Cells[pC1N];
                            break;
                        case "WorkTime01":
                            bar2 = bar.Series.Add(worksheet.Cells[wT01]);
                            bar2.HeaderAddress = worksheet.Cells[wT01N];
                            break;
                        case "PowerC02":
                            bar2 = bar.Series.Add(worksheet.Cells[pC2]);
                            bar2.HeaderAddress = worksheet.Cells[pC2N];
                            break;
                        case "WorkTime02":
                            bar2 = bar.Series.Add(worksheet.Cells[wT02]);
                            bar2.HeaderAddress = worksheet.Cells[wT02N];
                            break;
                        case "PowerC03":
                            bar2 = bar.Series.Add(worksheet.Cells[pC3]);
                            bar2.HeaderAddress = worksheet.Cells[pC3N];
                            break;
                        case "WorkTime03":
                            bar2 = bar.Series.Add(worksheet.Cells[wT03]);
                            bar2.HeaderAddress = worksheet.Cells[wT03N];
                            break;
                        case "PowerC04":
                            bar2 = bar.Series.Add(worksheet.Cells[pC4]);
                            bar2.HeaderAddress = worksheet.Cells[pC4N];
                            break;
                        case "WorkTime04":
                            bar2 = bar.Series.Add(worksheet.Cells[wT04]);
                            bar2.HeaderAddress = worksheet.Cells[wT04N];
                            break;
                        case "PowerC05":
                            bar2 = bar.Series.Add(worksheet.Cells[pC5]);
                            bar2.HeaderAddress = worksheet.Cells[pC5N];
                            break;
                        case "WorkTime05":
                            bar2 = bar.Series.Add(worksheet.Cells[wT05]);
                            bar2.HeaderAddress = worksheet.Cells[wT05N];
                            break;
                    }
                }
            }

            //// 設置圖表軸標籤
            //chart.XAxis.Title.Font.Size = 14;
            //chart.YAxis.Title.Font.Size = 14;

            var stream = new MemoryStream();
            package.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);

            // 回傳 Excel 文件
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", title + ".xlsx");
        }


    }
}

