using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2016.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using gin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace gin.Controllers
{
    public class MillController : Controller
    {
        private readonly ZDBContext _ZDBContext;
        public MillController(ZDBContext zDBContext)
        {
            _ZDBContext = zDBContext;
        }

        [Authorize(Policy = "CustomPolicy")]
        public IActionResult Mill_Report(string? day, string? millId, string? factoryId)
        {
            var millid = _ZDBContext.GMillingMachines.Where(x => x.FactoryId == factoryId).Select(x => x.MillId).Distinct().ToList();
            ViewBag.millId = millid;

            if (day == null && millId == null)
            {
                ViewBag.factory = factoryId;
                ViewBag.menu = "#1#2";
                millId = "#1#2";
                ViewBag.day = DateTime.Now.ToString("yyyy-MM-dd");
                DateTime nowDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 08:00:00"));
                DateTime yesDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 07:00:00")).AddDays(1);
                var data = _ZDBContext.GMillingMachines.Where(x => x.FactoryId == factoryId && x.DataTime >= nowDate && x.DataTime <= yesDate && x.MillId == millId).ToList();

                return View(data);
            }
            else
            {
                ViewBag.factory = factoryId;
                ViewBag.day = day;
                ViewBag.menu = millId;
                DateTime nowDate = DateTime.Parse(DateTime.Now.ToString(day + " 08:00:00"));
                DateTime yesDate = DateTime.Parse(DateTime.Now.ToString(day + " 07:00:00")).AddDays(1);

                var data = _ZDBContext.GMillingMachines.Where(x => x.FactoryId == factoryId && x.DataTime >= nowDate && x.DataTime <= yesDate && x.MillId == millId).ToList();

                return View(data);
            }
        }


        public IActionResult Mill_ChartList(string check,string m,string f,string day)
        {

            var gMillingMachineMappings = _ZDBContext.GMillingMachineMappings.Where(x => x.FactoryId == f && x.MillId == m).ToList();
            List<GMillingMachineMapping> millingMachineMappings = gMillingMachineMappings;

            List<string> d = new List<string>();
            List<object[]> dataa = new List<object[]>();

            string dayNow = day;
            DateTime yesDay = DateTime.Parse(dayNow);
            yesDay = yesDay.AddDays(+1);
            string tag_name = "";
            switch (check)
            {
                case "MotorCurrentA":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.MotorCurrentA ?? "0").ToString();
                    break;
                case "MotorCurrentB":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.MotorCurrentB ?? "0").ToString();
                    break;
                case "MotorPowerKwA":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.MotorPowerKwA ?? "0").ToString();
                    break;
                case "MotorPowerKwB":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.MotorPowerKwB ?? "0").ToString();
                    break;
                case "BucketElevatorA":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.BucketElevatorA ?? "0").ToString();
                    break;
                case "BucketElevatorB":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.BucketElevatorB ?? "0").ToString();
                    break;
                case "OsepaCurrent":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.OsepaCurrent ?? "0").ToString();
                    break;
                case "OsepaRpm":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.OsepaRpm ?? "0").ToString();
                    break;
                case "BagColletcotM1":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.BagColletcotM1 ?? "0").ToString();
                    break;
                case "BagColletcotM2":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.BagColletcotM2 ?? "0").ToString();
                    break;
                case "BagColletcotS":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.BagColletcotS ?? "0").ToString();
                    break;
                case "TeMillBearingInA":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillBearingInA ?? "0").ToString();
                    break;
                case "TeMillBearingOutA":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillBearingOutA ?? "0").ToString();
                    break;
                case "TeMillBearingOilInA":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillBearingOilInA ?? "0").ToString();
                    break;
                case "TeMillBearingOilOutA":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillBearingOilOutA ?? "0").ToString();
                    break;
                case "TeMillBearingInB":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillBearingInB ?? "0").ToString();
                    break;
                case "TeMillBearingOutB":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillBearingOutB ?? "0").ToString();
                    break;
                case "TeMillBearingOilInB":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillBearingOilInB ?? "0").ToString();
                    break;
                case "TeMillBearingOilOutB":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillBearingOilOutB ?? "0").ToString();
                    break;
                case "TeMillRawA":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillRawA ?? "0").ToString();
                    break;
                case "TeMillAirA":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillAirA ?? "0").ToString();
                    break;
                case "TeMillRawB":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillRawB ?? "0").ToString();
                    break;
                case "TeMillAirB":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMillAirB ?? "0").ToString();
                    break;
                case "TeSIn":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeSIn ?? "0").ToString();
                    break;
                case "TeProduct":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeProduct ?? "0").ToString();
                    break;
                case "TeMotor1A":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor1A ?? "0").ToString();
                    break;
                case "TeMotor2A":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor2A ?? "0").ToString();
                    break;
                case "TeMotor3A":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor3A ?? "0").ToString();
                    break;
                case "TeMotor4A":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor4A ?? "0").ToString();
                    break;
                case "TeMotor5A":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor5A ?? "0").ToString();
                    break;
                case "TeMotor6A":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor6A ?? "0").ToString();
                    break;
                case "TeMotor1B":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor1B ?? "0").ToString();
                    break;
                case "TeMotor2B":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor2B ?? "0").ToString();
                    break;
                case "TeMotor3B":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor3B ?? "0").ToString();
                    break;
                case "TeMotor4B":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor4B ?? "0").ToString();
                    break;
                case "TeMotor5B":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor5B ?? "0").ToString();
                    break;
                case "TeMotor6B":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.TeMotor6B ?? "0").ToString();
                    break;
                case "WpMillA":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WpMillA ?? "0").ToString();
                    break;
                case "WpMillB":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WpMillB ?? "0").ToString();
                    break;
                case "WpOsepa":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WpOsepa ?? "0").ToString();
                    break;
                case "WpBcSIn":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WpBcSIn ?? "0").ToString();
                    break;
                case "WpBcSDiff":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WpBcSDiff ?? "0").ToString();
                    break;
                case "RpmBcM1":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.RpmBcM1 ?? "0").ToString();
                    break;
                case "RpmBcM2":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.RpmBcM2 ?? "0").ToString();
                    break;
                case "RpmBcS":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.RpmBcS ?? "0").ToString();
                    break;
                case "WM1AP":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM1AP ?? "0").ToString();
                    break;
                case "WM1AC":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM1AC ?? "0").ToString();
                    break;
                case "WM1AQ":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM1AQ ?? "0").ToString();
                    break;
                case "WM1BP":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM1BP ?? "0").ToString();
                    break;
                case "WM1BC":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM1BC ?? "0").ToString();
                    break;
                case "WM1BQ":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM1BQ ?? "0").ToString();
                    break;
                case "WM2AP":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM2AP ?? "0").ToString();
                    break;
                case "WM2AC":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM2AC ?? "0").ToString();
                    break;
                case "WM2AQ":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM2AQ ?? "0").ToString();
                    break;
                case "WM2BP":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM2BP ?? "0").ToString();
                    break;
                case "WM2BC":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM2BC ?? "0").ToString();
                    break;
                case "WM2BQ":
                    tag_name = (millingMachineMappings.FirstOrDefault()?.WM2BQ ?? "0").ToString();
                    break;
            }

            var startTimeParam = new SqlParameter("@STime", SqlDbType.DateTime) { Value = DateTime.Parse(dayNow) };
            var endTimeParam = new SqlParameter("@ETime", SqlDbType.DateTime) { Value = yesDay };
            var factoryIdParam = new SqlParameter("@FactoryID", SqlDbType.NVarChar) { Value = f };
            var tagNameParam = new SqlParameter("@TagName", SqlDbType.NVarChar) { Value = tag_name };
            var result = _ZDBContext.GMMs.FromSqlRaw("EXECUTE dbo.h_GetTagValueList @STime, @ETime, @FactoryID, @TagName", startTimeParam, endTimeParam, factoryIdParam, tagNameParam).ToList();

            List<string> xValues = result.Select(x => x.DateTime.ToString("yyyy-MM-dd HH:mm:ss")).ToList();

            d = result.Select(x => x.Value.ToString("0.00")).ToList();

            dataa = d.Zip(xValues, (value, xValue) => new object[] { xValue, double.Parse(value) }).ToList();

            return Json(dataa);
        }
    }
}
