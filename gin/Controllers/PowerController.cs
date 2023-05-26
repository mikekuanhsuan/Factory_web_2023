using DocumentFormat.OpenXml.Bibliography;
using gin.Models;
using gin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using Microsoft.AspNetCore.Authorization;

namespace gin.Controllers
{
    public class PowerController : Controller
    {
        private readonly ZDBContext _ZDBContext;
        public PowerController(ZDBContext zDBcontext)
        {
            _ZDBContext = zDBcontext;
        }
        //用電量日管理
        [Authorize(Policy = "CustomPolicy")]
        public IActionResult PowerList(string factory, string day)
        {
            ViewBag.factory = factory;

            string newDay = day;
            string newDDay = "";
            string firstDay = day;
            string nextDay = "";
            if (newDay == null)
            {

                newDay = DateTime.Now.ToString("yyyy-MM-dd");
                newDDay = DateTime.Now.ToString("yyyy-MM");
                firstDay = DateTime.Now.ToString("yyyy-MM-dd");
                firstDay = firstDay + " 01:00:00";
                nextDay = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            }
            else
            {
                DateTime dateTimee = DateTime.Parse(day);
                newDDay = dateTimee.ToString("yyyy-MM").Substring(0, 7);
                firstDay = day + " 01:00:00";
                nextDay = DateTime.Parse(day).AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            }

            ViewBag.day = newDay;
            ViewBag.newDay = newDDay;

            var data = _ZDBContext.GPowerHs.Where(x => x.FactoryId == factory && x.Dtime >= DateTime.Parse(firstDay) && x.Dtime <= DateTime.Parse(nextDay)).ToList();
            List<PowerViewModel> powerViewModel = new List<PowerViewModel>();

            foreach (var item in data)
            {
                PowerViewModel power = new PowerViewModel();
                power.dTime = item.Dtime;
                power.PowerCTotal = item.PowerCTotal == null ? 0 : item.PowerCTotal;
                power.PowerC01 = item.PowerC01 == null ? 0 : item.PowerC01;
                power.PowerC02 = item.PowerC02 == null ? 0 : item.PowerC02;
                power.PowerC03 = item.PowerC03 == null ? 0 : item.PowerC03;
                power.PowerC04 = item.PowerC04 == null ? 0 : item.PowerC04;
                power.PowerC05 = item.PowerC05 == null ? 0 : item.PowerC05;
                power.PowerC06 = item.PowerC06 == null ? 0 : item.PowerC06;
                power.PowerC07 = item.PowerC07 == null ? 0 : item.PowerC07;
                power.PowerC08 = item.PowerC08 == null ? 0 : item.PowerC08;
                powerViewModel.Add(power);
            };
            return View(powerViewModel);
        }
        //用電量日管理Checkbox 顯示 chart
        public IActionResult LoadNewData(string p, string d, string f)
        {
            string firstDay = d;
            string nextDay = "";

            firstDay = firstDay + " 01:00:00";
            nextDay = DateTime.Parse(firstDay).AddDays(1).ToString("yyyy-MM-dd 00:00:00");

            var data = _ZDBContext.GPowerHs.Where(x => x.FactoryId == f && x.Dtime >= DateTime.Parse(firstDay) && x.Dtime < DateTime.Parse(nextDay)).ToList();
            List<decimal?> D = new List<decimal?>();
            switch (p)
            {
                case "PowerC01":
                    D = data.Select(x => x.PowerC01).ToList();
                    break;
                case "PowerC02":
                    D = data.Select(x => x.PowerC02).ToList();
                    break;
                case "PowerC03":
                    D = data.Select(x => x.PowerC03).ToList();
                    break;
                case "PowerC04":
                    D = data.Select(x => x.PowerC04).ToList();
                    break;
                case "PowerC05":
                    D = data.Select(x => x.PowerC05).ToList();
                    break;
                case "PowerC06":
                    D = data.Select(x => x.PowerC06).ToList();
                    break;
                case "PowerC07":
                    D = data.Select(x => x.PowerC07).ToList();
                    break;
                case "PowerC08":
                    D = data.Select(x => x.PowerC08).ToList();
                    break;
            }
            return Json(D);
        }
        //確認日是否有資料
        public IActionResult CheckData(string data)
        {
            var dd = JsonConvert.DeserializeObject<CreatePowerExcel>(data);
            if (dd.power.Count != 0)
            {
                return Json("Ok");
            }
            else
            {
                return Json("No");
            }

        }
        //日的excel 
        public IActionResult CreatEexcelday(string fck)
        {
            //將 JSON 字串轉換成 CreateExcel 物件
            var data = JsonConvert.DeserializeObject<CreatePowerExcel>(fck);

            string firstDay = data.day;
            string nextDay = DateTime.Parse(firstDay).AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            firstDay = firstDay + " 01:00:00";
            // 創建一個新的 excel 資料包
            using var package = new ExcelPackage();
            // 添加一個工作表
            var worksheet = package.Workbook.Worksheets.Add("Chart");
            // 添加數據
            string factory = data.factory;
            var powerHs = _ZDBContext.GPowerHs.Where(x => x.FactoryId == factory && x.Dtime >= DateTime.Parse(firstDay) && x.Dtime <= DateTime.Parse(nextDay)).ToList();
            List<GPowerH?> D = new List<GPowerH?>();
            D = powerHs.ToList();
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

            string newRow = "B22:B" + row;
            string daR = "A201:A" + da;
            string title = fName + "_用電量/日管理_" + data.day;

            worksheet.Cells["A21"].Value = "日期";
            worksheet.Cells["B21"].Value = "用電量";
            worksheet.Cells["C21"].Value = "#1 KWH(時)";
            worksheet.Cells["D21"].Value = "#2 KWH(時)";

            foreach (var power in D)
            {

                if (factory == "KY-T1HIST")
                {
                    worksheet.Cells["E21"].Value = "#3 KWH(時)";
                    worksheet.Cells["F21"].Value = "#4 KWH(時)";
                    worksheet.Cells["G21"].Value = "#5 KWH(時)";
                    worksheet.Cells["H21"].Value = "#6 KWH(時)";
                    worksheet.Cells[22 + t, 5].Value = power.PowerC03 == null ? 0 : power.PowerC03;
                    worksheet.Cells[22 + t, 6].Value = power.PowerC04 == null ? 0 : power.PowerC04;
                    worksheet.Cells[22 + t, 7].Value = power.PowerC05 == null ? 0 : power.PowerC05;
                    worksheet.Cells[22 + t, 8].Value = power.PowerC06 == null ? 0 : power.PowerC06;
                }
                else if (factory == "BL-T1HIST")
                {
                    worksheet.Cells["E21"].Value = "#3 KWH(時)";
                    worksheet.Cells["F21"].Value = "#4 KWH(時)";
                    worksheet.Cells[22 + t, 5].Value = power.PowerC03 == null ? 0 : power.PowerC03;
                    worksheet.Cells[22 + t, 6].Value = power.PowerC04 == null ? 0 : power.PowerC04;
                }
                else if (factory == "QX-T1HIST")
                {
                    worksheet.Cells["E21"].Value = "#3 KWH(時)";
                    worksheet.Cells[22 + t, 5].Value = power.PowerC03 == null ? 0 : power.PowerC03;
                }
                else if (factory == "ZB-T1HIST")
                {
                    worksheet.Cells["E21"].Value = "#3 KWH(時)";
                    worksheet.Cells["F21"].Value = "#4 KWH(時)";
                    worksheet.Cells["G21"].Value = "#5 KWH(時)";
                    worksheet.Cells["H21"].Value = "#6 KWH(時)";
                    worksheet.Cells["I21"].Value = "#7 KWH(時)";
                    worksheet.Cells["J21"].Value = "#8 KWH(時)";
                    worksheet.Cells[22 + t, 5].Value = power.PowerC03 == null ? 0 : power.PowerC03;
                    worksheet.Cells[22 + t, 6].Value = power.PowerC04 == null ? 0 : power.PowerC04;
                    worksheet.Cells[22 + t, 7].Value = power.PowerC05 == null ? 0 : power.PowerC05;
                    worksheet.Cells[22 + t, 8].Value = power.PowerC06 == null ? 0 : power.PowerC06;
                    worksheet.Cells[22 + t, 9].Value = power.PowerC07 == null ? 0 : power.PowerC07;
                    worksheet.Cells[22 + t, 10].Value = power.PowerC08 == null ? 0 : power.PowerC08;
                }
                worksheet.Cells[22 + t, 1].Value = power.Dtime.ToString("yyyy-MM-dd");
                worksheet.Cells[22 + t, 3].Value = power.PowerC01 == null ? 0 : power.PowerC01;
                worksheet.Cells[22 + t, 4].Value = power.PowerC02 == null ? 0 : power.PowerC02;

                t++;
            }
            t = 0;
            foreach (var d in data.date)
            {
                float p = float.Parse(data.power[t] == null ? "0" : data.power[t]);
                worksheet.Cells[22 + t, 2].Value = p ;
                worksheet.Cells[201 + t, 1].Value = d;
                t++;
            }

            // 創建一個折線圖系列對象，設置數據範圍和類型 -- 平均比功率圖
            var chart = worksheet.Drawings.AddChart("", eChartType.LineMarkers);
            var lineChartSeries = chart.Series.Add(worksheet.Cells[newRow], worksheet.Cells[daR]);
            lineChartSeries.HeaderAddress = worksheet.Cells["B21"];   //線條名稱

            // 設置圖表標題和軸標籤
            chart.Title.Text = title;
            chart.Legend.Add();
            chart.Legend.Position = eLegendPosition.Bottom;
            chart.ShowHiddenData = true;
            chart.SetPosition(0, 0);  //圖表位置
            chart.SetSize(1300, 400);  //圖表大小

            // 創建一個柱狀圖系列對象，設置數據範圍和類型 -- 比功率
            var bar = chart.PlotArea.ChartTypes.Add(eChartType.ColumnClustered);
            ExcelChartSerie bar2 = null;
            bar.UseSecondaryAxis = true; // 設置另一條Y軸

            string pC01 = "C22:C" + row;
            string pC02 = "D22:D" + row;
            string pC03 = "E22:E" + row;
            string pC04 = "G22:G" + row;
            string pC05 = "H22:H" + row;
            string pC06 = "J22:J" + row;
            string pC07 = "K22:K" + row;
            string pC08 = "M22:M" + row;

            if (data.checkBox.Count > 0)
            {
                foreach (var s in data.checkBox)
                {
                    switch (s)
                    {
                        case "PowerC01":
                            bar2 = bar.Series.Add(worksheet.Cells[pC01]);
                            bar2.HeaderAddress = worksheet.Cells["C21"];
                            break;
                        case "PowerC02":
                            bar2 = bar.Series.Add(worksheet.Cells[pC02]);
                            bar2.HeaderAddress = worksheet.Cells["D21"];
                            break;
                        case "PowerC03":
                            bar2 = bar.Series.Add(worksheet.Cells[pC03]);
                            bar2.HeaderAddress = worksheet.Cells["E21"];
                            break;
                        case "PowerC04":
                            bar2 = bar.Series.Add(worksheet.Cells[pC04]);
                            bar2.HeaderAddress = worksheet.Cells["G21"];
                            break;
                        case "PowerC05":
                            bar2 = bar.Series.Add(worksheet.Cells[pC05]);
                            bar2.HeaderAddress = worksheet.Cells["H21"];
                            break;
                        case "PowerC06":
                            bar2 = bar.Series.Add(worksheet.Cells[pC06]);
                            bar2.HeaderAddress = worksheet.Cells["J21"];
                            break;
                        case "PowerC07":
                            bar2 = bar.Series.Add(worksheet.Cells[pC07]);
                            bar2.HeaderAddress = worksheet.Cells["K21"];
                            break;
                        case "PowerC08":
                            bar2 = bar.Series.Add(worksheet.Cells[pC08]);
                            bar2.HeaderAddress = worksheet.Cells["M21"];
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
        [Authorize(Policy = "CustomPolicy")]
        public IActionResult PowerMonList(string factory, string day)
        {
            ViewBag.factory = factory;

            string newDay = day;
            string firstDay = day;
            string nextDay = "";

            string nowwMon = DateTime.Now.ToString("yyyy-MM");
            firstDay = firstDay + "-01";
            nextDay = DateTime.Now.ToString("yyyy-MM-dd");

            if (day != nowwMon)
            {
                nextDay = (DateTime.Parse(day).AddMonths(+1).AddDays(-1)).ToString();
            }

            ViewBag.day = newDay;


            var data = _ZDBContext.GPowerDs.Where(x => x.FactoryId == factory && x.DataDate >= DateTime.Parse(firstDay) && x.DataDate <= DateTime.Parse(nextDay)).ToList();
            List<PowerDViewModel> powerDViewModel = new List<PowerDViewModel>();

            foreach (var item in data)
            {
                PowerDViewModel power = new PowerDViewModel();
                power.dTime = item.Dtime;
                power.DataDate = item.DataDate;
                power.PowerCTotal = item.PowerCTotal == null ? 0 : item.PowerCTotal;
                power.PowerC01 = item.PowerC01 == null ? 0 : item.PowerC01;
                power.PowerC02 = item.PowerC02 == null ? 0 : item.PowerC02;
                power.PowerC03 = item.PowerC03 == null ? 0 : item.PowerC03;
                power.PowerC04 = item.PowerC04 == null ? 0 : item.PowerC04;
                power.PowerC05 = item.PowerC05 == null ? 0 : item.PowerC05;
                power.PowerC06 = item.PowerC06 == null ? 0 : item.PowerC06;
                power.PowerC07 = item.PowerC07 == null ? 0 : item.PowerC07;
                power.PowerC08 = item.PowerC08 == null ? 0 : item.PowerC08;
                powerDViewModel.Add(power);
            };
            return View(powerDViewModel);
        }
        //用電量月管理Checkbox 顯示 chart
        public IActionResult LoadNewMonData(string p, string d, string f)
        {
            string factory = f;
            string firstDay = d;
            string newDay = d;
            string nextDay = "";

            nextDay = DateTime.Now.ToString(firstDay + "-dd");
            firstDay = firstDay + "-01";

            var data = _ZDBContext.GPowerDs.Where(x => x.FactoryId == factory && x.DataDate >= DateTime.Parse(firstDay) && x.DataDate <= DateTime.Parse(nextDay)).ToList();
            List<decimal?> D = new List<decimal?>();
            switch (p)
            {
                case "PowerC01":
                    D = data.Select(x => x.PowerC01).ToList();
                    break;
                case "PowerC02":
                    D = data.Select(x => x.PowerC02).ToList();
                    break;
                case "PowerC03":
                    D = data.Select(x => x.PowerC03).ToList();
                    break;
                case "PowerC04":
                    D = data.Select(x => x.PowerC04).ToList();
                    break;
                case "PowerC05":
                    D = data.Select(x => x.PowerC05).ToList();
                    break;
                case "PowerC06":
                    D = data.Select(x => x.PowerC06).ToList();
                    break;
                case "PowerC07":
                    D = data.Select(x => x.PowerC07).ToList();
                    break;
                case "PowerC08":
                    D = data.Select(x => x.PowerC08).ToList();
                    break;
            }
            return Json(D);
        }
        //確認日是否有資料
        public IActionResult CreatEexcelMon(string fck)
        {
            //將 JSON 字串轉換成 CreateExcel 物件
            var data = JsonConvert.DeserializeObject<CreatePowerExcel>(fck);

            string firstDay = data.day;

            string input = firstDay;
            var year = int.Parse(input.Split("-")[0]);
            var month = int.Parse(input.Split("-")[1]);
            var daysInMonth = DateTime.DaysInMonth(year, month);
            var lastDayOfMonth = new DateTime(year, month, daysInMonth);
            string nextDay = lastDayOfMonth.ToString("yyyy-MM-dd");

            firstDay = firstDay + "-01";
            // 創建一個新的 excel 資料包
            using var package = new ExcelPackage();
            // 添加一個工作表
            var worksheet = package.Workbook.Worksheets.Add("Chart");
            // 添加數據
            string factory = data.factory;
            var powerDs = _ZDBContext.GPowerDs.Where(x => x.FactoryId == factory && x.DataDate >= DateTime.Parse(firstDay) && x.DataDate <= DateTime.Parse(nextDay)).ToList();
            List<GPowerD?> D = new List<GPowerD?>();
            D = powerDs.ToList();
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

            string newRow = "B22:B" + row;
            string daR = "A201:A" + da;
            string title = fName + "_用電量/月管理_" + data.day;

            worksheet.Cells["A21"].Value = "日期";
            worksheet.Cells["B21"].Value = "用電量";
            worksheet.Cells["C21"].Value = "#1 KWH(時)";
            worksheet.Cells["D21"].Value = "#2 KWH(時)";

            foreach (var power in D)
            {
                if (factory == "KY-T1HIST")
                {
                    worksheet.Cells["E21"].Value = "#3 KWH(時)";
                    worksheet.Cells["F21"].Value = "#4 KWH(時)";
                    worksheet.Cells["G21"].Value = "#5 KWH(時)";
                    worksheet.Cells["H21"].Value = "#6 KWH(時)";
                    worksheet.Cells[22 + t, 5].Value = power.PowerC03 == null ? 0 : power.PowerC03;
                    worksheet.Cells[22 + t, 6].Value = power.PowerC04 == null ? 0 : power.PowerC04;
                    worksheet.Cells[22 + t, 7].Value = power.PowerC05 == null ? 0 : power.PowerC05;
                    worksheet.Cells[22 + t, 8].Value = power.PowerC06 == null ? 0 : power.PowerC06;
                }
                else if (factory == "BL-T1HIST")
                {
                    worksheet.Cells["E21"].Value = "#3 KWH(時)";
                    worksheet.Cells["F21"].Value = "#4 KWH(時)";
                    worksheet.Cells[22 + t, 5].Value = power.PowerC03 == null ? 0 : power.PowerC03;
                    worksheet.Cells[22 + t, 6].Value = power.PowerC04 == null ? 0 : power.PowerC04;
                }
                else if (factory == "QX-T1HIST")
                {
                    worksheet.Cells["E21"].Value = "#3 KWH(時)";
                    worksheet.Cells[22 + t, 5].Value = power.PowerC03 == null ? 0 : power.PowerC03;
                }
                else if (factory == "ZB-T1HIST")
                {
                    worksheet.Cells["E21"].Value = "#3 KWH(時)";
                    worksheet.Cells["F21"].Value = "#4 KWH(時)";
                    worksheet.Cells["G21"].Value = "#5 KWH(時)";
                    worksheet.Cells["H21"].Value = "#6 KWH(時)";
                    worksheet.Cells["I21"].Value = "#7 KWH(時)";
                    worksheet.Cells["J21"].Value = "#8 KWH(時)";
                    worksheet.Cells[22 + t, 5].Value = power.PowerC03 == null ? 0 : power.PowerC03;
                    worksheet.Cells[22 + t, 6].Value = power.PowerC04 == null ? 0 : power.PowerC04;
                    worksheet.Cells[22 + t, 7].Value = power.PowerC05 == null ? 0 : power.PowerC05;
                    worksheet.Cells[22 + t, 8].Value = power.PowerC06 == null ? 0 : power.PowerC06;
                    worksheet.Cells[22 + t, 9].Value = power.PowerC07 == null ? 0 : power.PowerC07;
                    worksheet.Cells[22 + t, 10].Value = power.PowerC08 == null ? 0 : power.PowerC08;
                }
                worksheet.Cells[22 + t, 1].Value = power.DataDate.ToString("yyyy-MM-dd");
                worksheet.Cells[22 + t, 3].Value = power.PowerC01 == null ? 0 : power.PowerC01;
                worksheet.Cells[22 + t, 4].Value = power.PowerC02 == null ? 0 : power.PowerC02;

                t++;
            }

            t = 0;
            foreach (var d in data.date)
            {
                 float p = float.Parse(data.power[t] == null ? "0" : data.power[t]);
                worksheet.Cells[22 + t, 2].Value = p ;
                worksheet.Cells[201 + t, 1].Value = d;
                t++;
            }
          
            // 創建一個折線圖系列對象，設置數據範圍和類型 -- 平均比功率圖
            var chart = worksheet.Drawings.AddChart("", eChartType.LineMarkers);
            var lineChartSeries = chart.Series.Add(worksheet.Cells[newRow], worksheet.Cells[daR]);
            lineChartSeries.HeaderAddress = worksheet.Cells["B21"];   //線條名稱

            // 設置圖表標題和軸標籤
            chart.Title.Text = title;
            chart.Legend.Add();
            chart.Legend.Position = eLegendPosition.Bottom;
            chart.ShowHiddenData = true;
            chart.SetPosition(0, 0);  //圖表位置
            chart.SetSize(1300, 400);  //圖表大小

            // 創建一個柱狀圖系列對象，設置數據範圍和類型 -- 比功率
            var bar = chart.PlotArea.ChartTypes.Add(eChartType.ColumnClustered);
            ExcelChartSerie bar2 = null;
            bar.UseSecondaryAxis = true; // 設置另一條Y軸

            string pC01 = "C22:C" + row;
            string pC02 = "D22:D" + row;
            string pC03 = "E22:E" + row;
            string pC04 = "G22:G" + row;
            string pC05 = "H22:H" + row;
            string pC06 = "J22:J" + row;
            string pC07 = "K22:K" + row;
            string pC08 = "M22:M" + row;

            if (data.checkBox.Count > 0)
            {
                foreach (var s in data.checkBox)
                {
                    switch (s)
                    {
                        case "PowerC01":
                            bar2 = bar.Series.Add(worksheet.Cells[pC01]);
                            bar2.HeaderAddress = worksheet.Cells["C21"];
                            break;
                        case "PowerC02":
                            bar2 = bar.Series.Add(worksheet.Cells[pC02]);
                            bar2.HeaderAddress = worksheet.Cells["D21"];
                            break;
                        case "PowerC03":
                            bar2 = bar.Series.Add(worksheet.Cells[pC03]);
                            bar2.HeaderAddress = worksheet.Cells["E21"];
                            break;
                        case "PowerC04":
                            bar2 = bar.Series.Add(worksheet.Cells[pC04]);
                            bar2.HeaderAddress = worksheet.Cells["G21"];
                            break;
                        case "PowerC05":
                            bar2 = bar.Series.Add(worksheet.Cells[pC05]);
                            bar2.HeaderAddress = worksheet.Cells["H21"];
                            break;
                        case "PowerC06":
                            bar2 = bar.Series.Add(worksheet.Cells[pC06]);
                            bar2.HeaderAddress = worksheet.Cells["J21"];
                            break;
                        case "PowerC07":
                            bar2 = bar.Series.Add(worksheet.Cells[pC07]);
                            bar2.HeaderAddress = worksheet.Cells["K21"];
                            break;
                        case "PowerC08":
                            bar2 = bar.Series.Add(worksheet.Cells[pC08]);
                            bar2.HeaderAddress = worksheet.Cells["M21"];
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
    }
}
