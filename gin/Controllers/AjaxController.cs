using ClosedXML.Excel;
//using DocumentFormat.OpenXml.Bibliography;
//using DocumentFormat.OpenXml.Drawing.Charts;
//using DocumentFormat.OpenXml.Drawing.Spreadsheet;
//using DocumentFormat.OpenXml.Math;
//using DocumentFormat.OpenXml.Office.Excel;
//using DocumentFormat.OpenXml.Spreadsheet;
using gin.Models;
using MathNet.Numerics.Statistics.Mcmc;
using MessagePack;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.DirectoryServices.Protocols;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace gin.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ZDBContext _ZDBContext;
        public AjaxController(ZDBContext zDBContext)
        {
            _ZDBContext = zDBContext;
        }
        public IActionResult Mill_Report(string? date)
        {
            DateTime nowDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 08:00:00"));
            DateTime yesDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 07:00:00")).AddDays(1);

            var milldata = _ZDBContext.GMillingMachines.Where(x => x.FactoryId == "KY-T1HIST" && x.DataTime >= nowDate && x.DataTime <= yesDate && x.MillId == "#1#2").ToList();

            return Json(milldata);
        }
        //磨機日報匯出Excel
        public IActionResult Excel(string? day, string? millId, string? factoryid)
        {
            DateTime nowDate;
            DateTime yesDate;
            if (day == null)
            {
                nowDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 08:00:00"));
                yesDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 07:00:00")).AddDays(1);
            }
            else
            {
                nowDate = DateTime.Parse(DateTime.Now.ToString(day + " 08:00:00"));
                yesDate = DateTime.Parse(DateTime.Now.ToString(day + " 07:00:00")).AddDays(1);
            }
            var data = _ZDBContext.GMillingMachines.Where(x => x.FactoryId == factoryid && x.DataTime >= nowDate && x.DataTime <= yesDate && x.MillId == millId).ToList();

            string factory = "";
            switch (factoryid)//switch (比對的運算式)
            {
                case "KY-T1HIST":
                    factory = "觀音廠";
                    break;
                case "BL-T1HIST":
                    factory = "八里廠";
                    break;
                case "QX-T1HIST":
                    factory = "全興廠";
                    break;
                case "ZB-T1HIST":
                    factory = "彰濱廠";
                    break;
                case "KH-PCC-LH":
                    factory = "高雄廠";
                    break;
                case "LD-T1HIST":
                    factory = "龍德廠";
                    break;
                case "LZ-T1HIST":
                    factory = "利澤廠";
                    break;
                default:

                    break;
            }

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = factory + "磨機日報" + millId + "-" + day + ".xlsx";

            //建立Excel
            var workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("磨機日報" + millId + factory + day);

            //設定標題列名稱與樣式

            string m11 = "", m22 = "";
            switch (millId)//switch (比對的運算式)
            {
                case "#1":
                    m11 = "#1"; m22 = "";
                    break;
                case "#1#2":
                    m11 = "#1"; m22 = "#2";
                    break;
                case "#2#3":
                    m11 = "#2"; m22 = "#3";
                    break;
                case "#3#4":
                    m11 = "#3"; m22 = "#4";
                    break;
                case "#5#6":
                    m11 = "#5"; m22 = "#6";
                    break;
                case "#7#8":
                    m11 = "#7"; m22 = "#8";
                    break;
                default:

                    break;
            }

            worksheet.Range(1, 1, 10, 1).Merge();
            worksheet.Cell(1, 1).Value = "時間";
            worksheet.Cell(1, 1).Style.Font.SetFontSize(12);
            worksheet.Cell(1, 1).Style.Font.SetBold();
            worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell(1, 1).Style.Alignment.SetTopToBottom(true);
            //<---馬達---
            worksheet.Range(1, 2, 1, 5).Merge();
            worksheet.Cell(1, 2).Value = "馬達";
            worksheet.Cell(1, 2).Style.Font.SetFontSize(12);
            worksheet.Cell(1, 2).Style.Font.SetBold();
            worksheet.Cell(1, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell(1, 2).Style.Fill.BackgroundColor = XLColor.LightGray;

            worksheet.Range("B2:C5").Merge();
            worksheet.Cell("B2").Value = "電流";
            worksheet.Cell("B2").Style.Font.SetFontSize(12);
            worksheet.Cell("B2").Style.Font.SetBold();
            worksheet.Cell("B2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("B2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("B6:B9").Merge();
            worksheet.Cell("B6").Value = m11;
            worksheet.Cell("B6").Style.Font.SetFontSize(12);
            worksheet.Cell("B6").Style.Font.SetBold();
            worksheet.Cell("B6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("B6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("C6:C9").Merge();
            worksheet.Cell("C6").Value = m22;
            worksheet.Cell("C6").Style.Font.SetFontSize(12);
            worksheet.Cell("C6").Style.Font.SetBold();
            worksheet.Cell("C6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("C6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell("B10").Value = "A";
            worksheet.Cell("B10").Style.Font.SetFontSize(12);
            worksheet.Cell("B10").Style.Font.SetBold();
            worksheet.Cell("B10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("B10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell("C10").Value = "A";
            worksheet.Cell("C10").Style.Font.SetFontSize(12);
            worksheet.Cell("C10").Style.Font.SetBold();
            worksheet.Cell("C10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("C10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("D2:E5").Merge();
            worksheet.Cell("D2").Value = "功率";
            worksheet.Cell("D2").Style.Font.SetFontSize(12);
            worksheet.Cell("D2").Style.Font.SetBold();
            worksheet.Cell("D2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("D2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("D6:D9").Merge();
            worksheet.Cell("D6").Value = m11;
            worksheet.Cell("D6").Style.Font.SetFontSize(12);
            worksheet.Cell("D6").Style.Font.SetBold();
            worksheet.Cell("D6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("D6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("E6:E9").Merge();
            worksheet.Cell("E6").Value = m22;
            worksheet.Cell("E6").Style.Font.SetFontSize(12);
            worksheet.Cell("E6").Style.Font.SetBold();
            worksheet.Cell("E6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("E6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell("D10").Value = "KW";
            worksheet.Cell("D10").Style.Font.SetFontSize(12);
            worksheet.Cell("D10").Style.Font.SetBold();
            worksheet.Cell("D10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("D10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell("E10").Value = "KW";
            worksheet.Cell("E10").Style.Font.SetFontSize(12);
            worksheet.Cell("E10").Style.Font.SetBold();
            worksheet.Cell("E10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("E10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            //---馬達--->
            //<---電流---
            worksheet.Range(1, 6, 1, 12).Merge();
            worksheet.Cell(1, 6).Value = "電流(AMP)";
            worksheet.Cell(1, 6).Style.Font.SetFontSize(12);
            worksheet.Cell(1, 6).Style.Font.SetBold();
            worksheet.Cell(1, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, 6).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell(1, 6).Style.Fill.BackgroundColor = XLColor.LightGray;

            worksheet.Range("F2:F10").Merge();
            worksheet.Cell("F2").Value = "循環提運機";
            worksheet.Cell("F2").Style.Font.SetFontSize(12);
            worksheet.Cell("F2").Style.Font.SetBold();
            worksheet.Cell("F2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("F2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("F2").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("G2:G10").Merge();
            worksheet.Cell("G2").Value = "入庫提運機";
            worksheet.Cell("G2").Style.Font.SetFontSize(12);
            worksheet.Cell("G2").Style.Font.SetBold();
            worksheet.Cell("G2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("G2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("G2").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("H2:I5").Merge();
            worksheet.Cell("H2").Value = "O-SEPA";
            worksheet.Cell("H2").Style.Font.SetFontSize(12);
            worksheet.Cell("H2").Style.Font.SetBold();
            worksheet.Cell("H2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("H2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("H6:H10").Merge();
            worksheet.Cell("H6").Value = "A";
            worksheet.Cell("H6").Style.Font.SetFontSize(12);
            worksheet.Cell("H6").Style.Font.SetBold();
            worksheet.Cell("H6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("H6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("I6:I10").Merge();
            worksheet.Cell("I6").Value = "RPM";
            worksheet.Cell("I6").Style.Font.SetFontSize(12);
            worksheet.Cell("I6").Style.Font.SetBold();
            worksheet.Cell("I6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("I6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("J2:L5").Merge();
            worksheet.Cell("J2").Value = "收塵排風機";
            worksheet.Cell("J2").Style.Font.SetFontSize(12);
            worksheet.Cell("J2").Style.Font.SetBold();
            worksheet.Cell("J2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("J2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("J6:J9").Merge();
            worksheet.Cell("J6").Value = "M";
            worksheet.Cell("J6").Style.Font.SetFontSize(12);
            worksheet.Cell("J6").Style.Font.SetBold();
            worksheet.Cell("J6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("J6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("K6:K9").Merge();
            worksheet.Cell("K6").Value = "M";
            worksheet.Cell("K6").Style.Font.SetFontSize(12);
            worksheet.Cell("K6").Style.Font.SetBold();
            worksheet.Cell("K6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("K6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("L6:L10").Merge();
            worksheet.Cell("L6").Value = "S";
            worksheet.Cell("L6").Style.Font.SetFontSize(12);
            worksheet.Cell("L6").Style.Font.SetBold();
            worksheet.Cell("L6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("L6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell("J10").Value = m11;
            worksheet.Cell("J10").Style.Font.SetFontSize(12);
            worksheet.Cell("J10").Style.Font.SetBold();
            worksheet.Cell("J10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("J10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell("K10").Value = m22;
            worksheet.Cell("K10").Style.Font.SetFontSize(12);
            worksheet.Cell("K10").Style.Font.SetBold();
            worksheet.Cell("K10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("K10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            //---電流--->
            //<---溫度---
            worksheet.Range(1, 13, 1, 26).Merge();
            worksheet.Cell(1, 13).Value = "溫度℃";
            worksheet.Cell(1, 13).Style.Font.SetFontSize(12);
            worksheet.Cell(1, 13).Style.Font.SetBold();
            worksheet.Cell(1, 13).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, 13).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell(1, 13).Style.Fill.BackgroundColor = XLColor.LightGray;

            worksheet.Range("M2:P2").Merge();
            worksheet.Cell("M2").Value = "耳軸承";
            worksheet.Cell("M2").Style.Font.SetFontSize(12);
            worksheet.Cell("M2").Style.Font.SetBold();
            worksheet.Cell("M2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("M2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("M3:N4").Merge();
            worksheet.Cell("M3").Value = m11;
            worksheet.Cell("M3").Style.Font.SetFontSize(12);
            worksheet.Cell("M3").Style.Font.SetBold();
            worksheet.Cell("M3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("M3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("M5:M10").Merge();
            worksheet.Cell("M5").Value = "入口端";
            worksheet.Cell("M5").Style.Font.SetFontSize(12);
            worksheet.Cell("M5").Style.Font.SetBold();
            worksheet.Cell("M5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("M5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("M5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("N5:N10").Merge();
            worksheet.Cell("N5").Value = "出口端";
            worksheet.Cell("N5").Style.Font.SetFontSize(12);
            worksheet.Cell("N5").Style.Font.SetBold();
            worksheet.Cell("N5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("N5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("N5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("O3:P4").Merge();
            worksheet.Cell("O3").Value = m22;
            worksheet.Cell("O3").Style.Font.SetFontSize(12);
            worksheet.Cell("O3").Style.Font.SetBold();
            worksheet.Cell("O3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("O3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("O5:O10").Merge();
            worksheet.Cell("O5").Value = "入口端";
            worksheet.Cell("O5").Style.Font.SetFontSize(12);
            worksheet.Cell("O5").Style.Font.SetBold();
            worksheet.Cell("O5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("O5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("O5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("P5:P10").Merge();
            worksheet.Cell("P5").Value = "出口端";
            worksheet.Cell("P5").Style.Font.SetFontSize(12);
            worksheet.Cell("P5").Style.Font.SetBold();
            worksheet.Cell("P5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("P5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("P5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("Q2:T2").Merge();
            worksheet.Cell("Q2").Value = "潤滑油";
            worksheet.Cell("Q2").Style.Font.SetFontSize(12);
            worksheet.Cell("Q2").Style.Font.SetBold();
            worksheet.Cell("Q2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("Q2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("Q3:R4").Merge();
            worksheet.Cell("Q3").Value = m11;
            worksheet.Cell("Q3").Style.Font.SetFontSize(12);
            worksheet.Cell("Q3").Style.Font.SetBold();
            worksheet.Cell("Q3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("Q3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("Q5:Q10").Merge();
            worksheet.Cell("Q5").Value = "入口端";
            worksheet.Cell("Q5").Style.Font.SetFontSize(12);
            worksheet.Cell("Q5").Style.Font.SetBold();
            worksheet.Cell("Q5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("Q5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("Q5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("R5:R10").Merge();
            worksheet.Cell("R5").Value = "出口端";
            worksheet.Cell("R5").Style.Font.SetFontSize(12);
            worksheet.Cell("R5").Style.Font.SetBold();
            worksheet.Cell("R5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("R5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("R5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("S3:T4").Merge();
            worksheet.Cell("S3").Value = m22;
            worksheet.Cell("S3").Style.Font.SetFontSize(12);
            worksheet.Cell("S3").Style.Font.SetBold();
            worksheet.Cell("S3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("S3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("S5:S10").Merge();
            worksheet.Cell("S5").Value = "入口端";
            worksheet.Cell("S5").Style.Font.SetFontSize(12);
            worksheet.Cell("S5").Style.Font.SetBold();
            worksheet.Cell("S5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("S5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("S5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("T5:T10").Merge();
            worksheet.Cell("T5").Value = "出口端";
            worksheet.Cell("T5").Style.Font.SetFontSize(12);
            worksheet.Cell("T5").Style.Font.SetBold();
            worksheet.Cell("T5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("T5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("T5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("U2:X2").Merge();
            worksheet.Cell("U2").Value = "磨機";
            worksheet.Cell("U2").Style.Font.SetFontSize(12);
            worksheet.Cell("U2").Style.Font.SetBold();
            worksheet.Cell("U2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("U2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("U3:V4").Merge();
            worksheet.Cell("U3").Value = m11;
            worksheet.Cell("U3").Style.Font.SetFontSize(12);
            worksheet.Cell("U3").Style.Font.SetBold();
            worksheet.Cell("U3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("U3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("U5:U10").Merge();
            worksheet.Cell("U5").Value = "料溫";
            worksheet.Cell("U5").Style.Font.SetFontSize(12);
            worksheet.Cell("U5").Style.Font.SetBold();
            worksheet.Cell("U5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("U5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("U5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("V5:V10").Merge();
            worksheet.Cell("V5").Value = "氣溫";
            worksheet.Cell("V5").Style.Font.SetFontSize(12);
            worksheet.Cell("V5").Style.Font.SetBold();
            worksheet.Cell("V5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("V5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("V5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("W3:X4").Merge();
            worksheet.Cell("W3").Value = m22;
            worksheet.Cell("W3").Style.Font.SetFontSize(12);
            worksheet.Cell("W3").Style.Font.SetBold();
            worksheet.Cell("W3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("W3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("W5:W10").Merge();
            worksheet.Cell("W5").Value = "料溫";
            worksheet.Cell("W5").Style.Font.SetFontSize(12);
            worksheet.Cell("W5").Style.Font.SetBold();
            worksheet.Cell("W5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("W5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("W5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("X5:X10").Merge();
            worksheet.Cell("X5").Value = "氣溫";
            worksheet.Cell("X5").Style.Font.SetFontSize(12);
            worksheet.Cell("X5").Style.Font.SetBold();
            worksheet.Cell("X5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("X5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("X5").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("Y2:Y10").Merge();
            worksheet.Cell("Y2").Value = "風析機出口";
            worksheet.Cell("Y2").Style.Font.SetFontSize(12);
            worksheet.Cell("Y2").Style.Font.SetBold();
            worksheet.Cell("Y2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("Y2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("Y2").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("Z2:Z10").Merge();
            worksheet.Cell("Z2").Value = "成品入庫料溫";
            worksheet.Cell("Z2").Style.Font.SetFontSize(12);
            worksheet.Cell("Z2").Style.Font.SetBold();
            worksheet.Cell("Z2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("Z2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("Z2").Style.Alignment.SetTopToBottom(true);
            //---溫度--->
            //<---磨機馬達及軸承溫度℃---
            worksheet.Range(1, 27, 1, 38).Merge();
            worksheet.Cell(1, 27).Value = "磨機馬達及軸承溫度℃";
            worksheet.Cell(1, 27).Style.Font.SetFontSize(12);
            worksheet.Cell(1, 27).Style.Font.SetBold();
            worksheet.Cell(1, 27).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, 27).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell(1, 27).Style.Fill.BackgroundColor = XLColor.LightGray;

            worksheet.Range("AA2:AF2").Merge();
            worksheet.Cell("AA2").Value = m11;
            worksheet.Cell("AA2").Style.Font.SetFontSize(12);
            worksheet.Cell("AA2").Style.Font.SetBold();
            worksheet.Cell("AA2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AA2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("AA3:AA10").Merge();
            worksheet.Cell("AA3").Value = "馬達線圈R";
            worksheet.Cell("AA3").Style.Font.SetFontSize(12);
            worksheet.Cell("AA3").Style.Font.SetBold();
            worksheet.Cell("AA3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AA3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AA3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AB3:AB10").Merge();
            worksheet.Cell("AB3").Value = "馬達線圈S";
            worksheet.Cell("AB3").Style.Font.SetFontSize(12);
            worksheet.Cell("AB3").Style.Font.SetBold();
            worksheet.Cell("AB3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AB3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AB3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AC3:AC10").Merge();
            worksheet.Cell("AC3").Value = "馬達線圈T";
            worksheet.Cell("AC3").Style.Font.SetFontSize(12);
            worksheet.Cell("AC3").Style.Font.SetBold();
            worksheet.Cell("AC3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AC3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AC3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AD3:AD10").Merge();
            worksheet.Cell("AD3").Value = "負載端軸承";
            worksheet.Cell("AD3").Style.Font.SetFontSize(12);
            worksheet.Cell("AD3").Style.Font.SetBold();
            worksheet.Cell("AD3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AD3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AD3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AE3:AE10").Merge();
            worksheet.Cell("AE3").Value = "無負載端軸承";
            worksheet.Cell("AE3").Style.Font.SetFontSize(12);
            worksheet.Cell("AE3").Style.Font.SetBold();
            worksheet.Cell("AE3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AE3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AE3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AF3:AF10").Merge();
            worksheet.Cell("AF3").Value = "主減速機供油溫度";
            worksheet.Cell("AF3").Style.Font.SetFontSize(12);
            worksheet.Cell("AF3").Style.Font.SetBold();
            worksheet.Cell("AF3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AF3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AF3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AG2:AL2").Merge();
            worksheet.Cell("AG2").Value = m22;
            worksheet.Cell("AG2").Style.Font.SetFontSize(12);
            worksheet.Cell("AG2").Style.Font.SetBold();
            worksheet.Cell("AG2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AG2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


            worksheet.Range("AG3:AG10").Merge();
            worksheet.Cell("AG3").Value = "馬達線圈R";
            worksheet.Cell("AG3").Style.Font.SetFontSize(12);
            worksheet.Cell("AG3").Style.Font.SetBold();
            worksheet.Cell("AG3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AG3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AG3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AH3:AH10").Merge();
            worksheet.Cell("AH3").Value = "馬達線圈S";
            worksheet.Cell("AH3").Style.Font.SetFontSize(12);
            worksheet.Cell("AH3").Style.Font.SetBold();
            worksheet.Cell("AH3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AH3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AH3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AI3:AI10").Merge();
            worksheet.Cell("AI3").Value = "馬達線圈T";
            worksheet.Cell("AI3").Style.Font.SetFontSize(12);
            worksheet.Cell("AI3").Style.Font.SetBold();
            worksheet.Cell("AI3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AI3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AI3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AJ3:AJ10").Merge();
            worksheet.Cell("AJ3").Value = "負載端軸承";
            worksheet.Cell("AJ3").Style.Font.SetFontSize(12);
            worksheet.Cell("AJ3").Style.Font.SetBold();
            worksheet.Cell("AJ3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AJ3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AJ3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AK3:AK10").Merge();
            worksheet.Cell("AK3").Value = "無負載端軸承";
            worksheet.Cell("AK3").Style.Font.SetFontSize(12);
            worksheet.Cell("AK3").Style.Font.SetBold();
            worksheet.Cell("AK3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AK3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AK3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AL3:AL10").Merge();
            worksheet.Cell("AL3").Value = "主減速機供油溫度";
            worksheet.Cell("AL3").Style.Font.SetFontSize(12);
            worksheet.Cell("AL3").Style.Font.SetBold();
            worksheet.Cell("AL3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AL3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AL3").Style.Alignment.SetTopToBottom(true);
            //---磨機馬達及軸承溫度℃--->
            //<---風壓(MMWG)---
            worksheet.Range(1, 39, 1, 43).Merge();
            worksheet.Cell(1, 39).Value = "風壓(MMWG)";
            worksheet.Cell(1, 39).Style.Font.SetFontSize(12);
            worksheet.Cell(1, 39).Style.Font.SetBold();
            worksheet.Cell(1, 39).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, 39).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell(1, 39).Style.Fill.BackgroundColor = XLColor.LightGray;

            worksheet.Range("AM2:AN9").Merge();
            worksheet.Cell("AM2").Value = "磨機出口";
            worksheet.Cell("AM2").Style.Font.SetFontSize(12);
            worksheet.Cell("AM2").Style.Font.SetBold();
            worksheet.Cell("AM2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AM2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AM2").Style.Alignment.SetTopToBottom(true);

            worksheet.Cell("AM10").Value = m11;
            worksheet.Cell("AM10").Style.Font.SetFontSize(12);
            worksheet.Cell("AM10").Style.Font.SetBold();
            worksheet.Cell("AM10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AM10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell("AN10").Value = m22;
            worksheet.Cell("AN10").Style.Font.SetFontSize(12);
            worksheet.Cell("AN10").Style.Font.SetBold();
            worksheet.Cell("AN10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AN10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("AO2:AO10").Merge();
            worksheet.Cell("AO2").Value = "風析機出口";
            worksheet.Cell("AO2").Style.Font.SetFontSize(12);
            worksheet.Cell("AO2").Style.Font.SetBold();
            worksheet.Cell("AO2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AO2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AO2").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AP2:AQ5").Merge();
            worksheet.Cell("AP2").Value = "s系排風機";
            worksheet.Cell("AP2").Style.Font.SetFontSize(12);
            worksheet.Cell("AP2").Style.Font.SetBold();
            worksheet.Cell("AP2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AP2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("AP6:AP10").Merge();
            worksheet.Cell("AP6").Value = "入口";
            worksheet.Cell("AP6").Style.Font.SetFontSize(12);
            worksheet.Cell("AP6").Style.Font.SetBold();
            worksheet.Cell("AP6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AP6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AP6").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AQ6:AQ10").Merge();
            worksheet.Cell("AQ6").Value = "壓差";
            worksheet.Cell("AQ6").Style.Font.SetFontSize(12);
            worksheet.Cell("AQ6").Style.Font.SetBold();
            worksheet.Cell("AQ6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AQ6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AQ6").Style.Alignment.SetTopToBottom(true);
            //---風壓(MMWG)--->
            //<---轉速(RPM)---
            worksheet.Range(1, 44, 1, 46).Merge();
            worksheet.Cell(1, 44).Value = "轉速(RPM)";
            worksheet.Cell(1, 44).Style.Font.SetFontSize(12);
            worksheet.Cell(1, 44).Style.Font.SetBold();
            worksheet.Cell(1, 44).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, 44).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell(1, 44).Style.Fill.BackgroundColor = XLColor.LightGray;

            worksheet.Range("AR2:AT5").Merge();
            worksheet.Cell("AR2").Value = "收塵排風機";
            worksheet.Cell("AR2").Style.Font.SetFontSize(12);
            worksheet.Cell("AR2").Style.Font.SetBold();
            worksheet.Cell("AR2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AR2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("AR6:AS9").Merge();
            worksheet.Cell("AR6").Value = "M系";
            worksheet.Cell("AR6").Style.Font.SetFontSize(12);
            worksheet.Cell("AR6").Style.Font.SetBold();
            worksheet.Cell("AR6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AR6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell("AR10").Value = m11;
            worksheet.Cell("AR10").Style.Font.SetFontSize(12);
            worksheet.Cell("AR10").Style.Font.SetBold();
            worksheet.Cell("AR10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AR10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell("AS10").Value = m22;
            worksheet.Cell("AS10").Style.Font.SetFontSize(12);
            worksheet.Cell("AS10").Style.Font.SetBold();
            worksheet.Cell("AS10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AS10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("AT6:AT10").Merge();
            worksheet.Cell("AT6").Value = "S系";
            worksheet.Cell("AT6").Style.Font.SetFontSize(12);
            worksheet.Cell("AT6").Style.Font.SetBold();
            worksheet.Cell("AT6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AT6").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            //---轉速(RPM)--->
            //<---#1秤伺機---
            worksheet.Range(1, 47, 1, 52).Merge();
            worksheet.Cell(1, 47).Value = m11 + "秤飼機";
            worksheet.Cell(1, 47).Style.Font.SetFontSize(12);
            worksheet.Cell(1, 47).Style.Font.SetBold();
            worksheet.Cell(1, 47).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, 47).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell(1, 47).Style.Fill.BackgroundColor = XLColor.LightGray;

            worksheet.Range("AU2:AW2").Merge();
            worksheet.Cell("AU2").Value = "熟料/爐石";
            worksheet.Cell("AU2").Style.Font.SetFontSize(12);
            worksheet.Cell("AU2").Style.Font.SetBold();
            worksheet.Cell("AU2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AU2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("AU3:AU10").Merge();
            worksheet.Cell("AU3").Value = "飼量調節器";
            worksheet.Cell("AU3").Style.Font.SetFontSize(12);
            worksheet.Cell("AU3").Style.Font.SetBold();
            worksheet.Cell("AU3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AU3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AU3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AV3:AV9").Merge();
            worksheet.Cell("AV3").Value = "積數器";
            worksheet.Cell("AV3").Style.Font.SetFontSize(12);
            worksheet.Cell("AV3").Style.Font.SetBold();
            worksheet.Cell("AV3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AV3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AV3").Style.Alignment.SetTopToBottom(true);


            worksheet.Range("AV10:AW10").Merge();
            worksheet.Cell("AV10").Value = "(T/H)";
            worksheet.Cell("AV10").Style.Font.SetFontSize(12);
            worksheet.Cell("AV10").Style.Font.SetBold();
            worksheet.Cell("AV10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AV10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


            worksheet.Range("AW3:AW9").Merge();
            worksheet.Cell("AW3").Value = "飼料量";
            worksheet.Cell("AW3").Style.Font.SetFontSize(12);
            worksheet.Cell("AW3").Style.Font.SetBold();
            worksheet.Cell("AW3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AW3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AW3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AX2:AZ2").Merge();
            worksheet.Cell("AX2").Value = "石膏";
            worksheet.Cell("AX2").Style.Font.SetFontSize(12);
            worksheet.Cell("AX2").Style.Font.SetBold();
            worksheet.Cell("AX2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AX2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("AX3:AX10").Merge();
            worksheet.Cell("AX3").Value = "飼量調節器";
            worksheet.Cell("AX3").Style.Font.SetFontSize(12);
            worksheet.Cell("AX3").Style.Font.SetBold();
            worksheet.Cell("AX3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AX3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AX3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AY3:AY9").Merge();
            worksheet.Cell("AY3").Value = "積數器";
            worksheet.Cell("AY3").Style.Font.SetFontSize(12);
            worksheet.Cell("AY3").Style.Font.SetBold();
            worksheet.Cell("AY3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AY3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AY3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("AY10:AZ10").Merge();
            worksheet.Cell("AY10").Value = "(T/H)";
            worksheet.Cell("AY10").Style.Font.SetFontSize(12);
            worksheet.Cell("AY10").Style.Font.SetBold();
            worksheet.Cell("AY10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AY10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("AZ3:AZ9").Merge();
            worksheet.Cell("AZ3").Value = "飼料量";
            worksheet.Cell("AZ3").Style.Font.SetFontSize(12);
            worksheet.Cell("AZ3").Style.Font.SetBold();
            worksheet.Cell("AZ3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("AZ3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("AZ3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("BA1:BA10").Merge();
            worksheet.Cell("BA1").Value = "添加劑飼料量";
            worksheet.Cell("BA1").Style.Font.SetFontSize(12);
            worksheet.Cell("BA1").Style.Font.SetBold();
            worksheet.Cell("BA1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BA1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("BA1").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("BB1:BB10").Merge();
            worksheet.Cell("BB1").Value = "產量";
            worksheet.Cell("BB1").Style.Font.SetFontSize(12);
            worksheet.Cell("BB1").Style.Font.SetBold();
            worksheet.Cell("BB1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BB1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("BB1").Style.Alignment.SetTopToBottom(true);
            //---#1秤伺機--->
            //<---#5秤伺機---
            worksheet.Range(1, 55, 1, 60).Merge();
            worksheet.Cell(1, 55).Value = m22 + "秤飼機";
            worksheet.Cell(1, 55).Style.Font.SetFontSize(12);
            worksheet.Cell(1, 55).Style.Font.SetBold();
            worksheet.Cell(1, 55).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, 55).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell(1, 55).Style.Fill.BackgroundColor = XLColor.LightGray;

            worksheet.Range("BC2:BE2").Merge();
            worksheet.Cell("BC2").Value = "熟料/爐石";
            worksheet.Cell("BC2").Style.Font.SetFontSize(12);
            worksheet.Cell("BC2").Style.Font.SetBold();
            worksheet.Cell("BC2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BC2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("BC3:BC10").Merge();
            worksheet.Cell("BC3").Value = "飼量調節器";
            worksheet.Cell("BC3").Style.Font.SetFontSize(12);
            worksheet.Cell("BC3").Style.Font.SetBold();
            worksheet.Cell("BC3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BC3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("BC3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("BD3:BD9").Merge();
            worksheet.Cell("BD3").Value = "積數器";
            worksheet.Cell("BD3").Style.Font.SetFontSize(12);
            worksheet.Cell("BD3").Style.Font.SetBold();
            worksheet.Cell("BD3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BD3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("BD3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("BD10:BE10").Merge();
            worksheet.Cell("BD10").Value = "(T/H)";
            worksheet.Cell("BD10").Style.Font.SetFontSize(12);
            worksheet.Cell("BD10").Style.Font.SetBold();
            worksheet.Cell("BD10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BD10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("BE3:BE9").Merge();
            worksheet.Cell("BE3").Value = "飼料量";
            worksheet.Cell("BE3").Style.Font.SetFontSize(12);
            worksheet.Cell("BE3").Style.Font.SetBold();
            worksheet.Cell("BE3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BE3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("BE3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("BF2:BH2").Merge();
            worksheet.Cell("BF2").Value = "石膏";
            worksheet.Cell("BF2").Style.Font.SetFontSize(12);
            worksheet.Cell("BF2").Style.Font.SetBold();
            worksheet.Cell("BF2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BF2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("BF3:BF10").Merge();
            worksheet.Cell("BF3").Value = "飼量調節器";
            worksheet.Cell("BF3").Style.Font.SetFontSize(12);
            worksheet.Cell("BF3").Style.Font.SetBold();
            worksheet.Cell("BF3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BF3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("BF3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("BG3:BG9").Merge();
            worksheet.Cell("BG3").Value = "積數器";
            worksheet.Cell("BG3").Style.Font.SetFontSize(12);
            worksheet.Cell("BG3").Style.Font.SetBold();
            worksheet.Cell("BG3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BG3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("BG3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("BG10:BH10").Merge();
            worksheet.Cell("BG10").Value = "(T/H)";
            worksheet.Cell("BG10").Style.Font.SetFontSize(12);
            worksheet.Cell("BG10").Style.Font.SetBold();
            worksheet.Cell("BG10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BG10").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Range("BH3:BH9").Merge();
            worksheet.Cell("BH3").Value = "飼料量";
            worksheet.Cell("BH3").Style.Font.SetFontSize(12);
            worksheet.Cell("BH3").Style.Font.SetBold();
            worksheet.Cell("BH3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BH3").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("BH3").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("BI1:BI10").Merge();
            worksheet.Cell("BI1").Value = "添加劑飼料量";
            worksheet.Cell("BI1").Style.Font.SetFontSize(12);
            worksheet.Cell("BI1").Style.Font.SetBold();
            worksheet.Cell("BI1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BI1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("BI1").Style.Alignment.SetTopToBottom(true);

            worksheet.Range("BJ1:BJ10").Merge();
            worksheet.Cell("BJ1").Value = "產量";
            worksheet.Cell("BJ1").Style.Font.SetFontSize(12);
            worksheet.Cell("BJ1").Style.Font.SetBold();
            worksheet.Cell("BJ1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("BJ1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Cell("BJ1").Style.Alignment.SetTopToBottom(true);

            int x = 11;

            foreach (var d in data)
            {

                //時間
                worksheet.Cell(x, 1).Value = d.Dtime;
                worksheet.Cell(x, 1).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //馬達電流A
                worksheet.Cell(x, 2).Value = d.MotorCurrentA == null ? 0 : d.MotorCurrentA;
                worksheet.Cell(x, 2).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 2).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //馬達電流B
                worksheet.Cell(x, 3).Value = d.MotorCurrentB == null ? 0 : d.MotorCurrentB;
                worksheet.Cell(x, 3).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 3).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //馬達功率A
                worksheet.Cell(x, 4).Value = d.MotorPowerKwA == null ? 0 : d.MotorPowerKwA;
                worksheet.Cell(x, 4).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 4).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //馬達功率B
                worksheet.Cell(x, 5).Value = d.MotorPowerKwB == null ? 0 : d.MotorPowerKwB;
                worksheet.Cell(x, 5).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 5).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //循環提運機
                worksheet.Cell(x, 6).Value = d.BucketElevatorA == null ? 0 : d.BucketElevatorA;
                worksheet.Cell(x, 6).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 6).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //入庫提運機
                worksheet.Cell(x, 7).Value = d.BucketElevatorB == null ? 0 : d.BucketElevatorB;
                worksheet.Cell(x, 7).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 7).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //O-SEPA A
                worksheet.Cell(x, 8).Value = d.OsepaCurrent == null ? 0 : d.OsepaCurrent;
                worksheet.Cell(x, 8).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 8).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //O-SEPA RPM
                worksheet.Cell(x, 9).Value = d.OsepaRpm == null ? 0 : d.OsepaRpm;
                worksheet.Cell(x, 9).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 9).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //收塵排風機 M B0117
                worksheet.Cell(x, 10).Value = d.BagColletcotM1 == null ? 0 : d.BagColletcotM1;
                worksheet.Cell(x, 10).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 10).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //收塵排風機 M B0217
                worksheet.Cell(x, 11).Value = d.BagColletcotM2 == null ? 0 : d.BagColletcotM2;
                worksheet.Cell(x, 11).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 11).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 11).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //收塵排風機 S B0120
                worksheet.Cell(x, 12).Value = d.BagColletcotS == null ? 0 : d.BagColletcotS;
                worksheet.Cell(x, 12).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 12).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 12).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //耳軸承 M0108 入口
                worksheet.Cell(x, 13).Value = d.TeMillBearingInA == null ? 0 : d.TeMillBearingInA;
                worksheet.Cell(x, 13).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 13).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 13).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //耳軸承 M0108 出口
                worksheet.Cell(x, 14).Value = d.TeMillBearingOutA == null ? 0 : d.TeMillBearingOutA;
                worksheet.Cell(x, 14).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 14).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 14).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //耳軸承 M0208 入口
                worksheet.Cell(x, 15).Value = d.TeMillBearingOilInA == null ? 0 : d.TeMillBearingOilInA;
                worksheet.Cell(x, 15).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 15).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 15).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //耳軸承 M0208 出口
                worksheet.Cell(x, 16).Value = d.TeMillBearingOilOutA == null ? 0 : d.TeMillBearingOilOutA;
                worksheet.Cell(x, 16).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 16).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 16).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //潤滑油 M0108 入口
                worksheet.Cell(x, 17).Value = d.TeMillBearingInB == null ? 0 : d.TeMillBearingInB;
                worksheet.Cell(x, 17).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 17).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 17).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //潤滑油 M0108 出口
                worksheet.Cell(x, 18).Value = d.TeMillBearingOutB == null ? 0 : d.TeMillBearingOutB;
                worksheet.Cell(x, 18).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 18).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 18).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //潤滑油 M0208 入口
                worksheet.Cell(x, 19).Value = d.TeMillBearingOilInB == null ? 0 : d.TeMillBearingOilInB;
                worksheet.Cell(x, 19).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 19).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 19).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //潤滑油 M0208 出口
                worksheet.Cell(x, 20).Value = d.TeMillBearingOilOutB == null ? 0 : d.TeMillBearingOilOutB;
                worksheet.Cell(x, 20).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 20).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 20).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //磨機 M0108 料溫
                worksheet.Cell(x, 21).Value = d.TeMillRawA == null ? 0 : d.TeMillRawA;
                worksheet.Cell(x, 21).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 21).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 21).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //磨機 M0108 氣溫
                worksheet.Cell(x, 22).Value = d.TeMillAirA == null ? 0 : d.TeMillAirA;
                worksheet.Cell(x, 22).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 22).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 22).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //磨機 M0208 料溫
                worksheet.Cell(x, 23).Value = d.TeMillRawB == null ? 0 : d.TeMillRawB;
                worksheet.Cell(x, 23).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 23).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 23).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //磨機 M0208 氣溫
                worksheet.Cell(x, 24).Value = d.TeMillAirB == null ? 0 : d.TeMillAirB;
                worksheet.Cell(x, 24).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 24).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 24).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //風析機出口
                worksheet.Cell(x, 25).Value = d.TeSIn == null ? 0 : d.TeSIn;
                worksheet.Cell(x, 25).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 25).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 25).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //成品入庫料溫
                worksheet.Cell(x, 26).Value = d.TeProduct == null ? 0 : d.TeProduct;
                worksheet.Cell(x, 26).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 26).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 26).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0108 馬達線圈R
                worksheet.Cell(x, 27).Value = d.TeMotor1A == null ? 0 : d.TeMotor1A;
                worksheet.Cell(x, 27).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 27).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 27).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0108 馬達線圈S
                worksheet.Cell(x, 28).Value = d.TeMotor2A == null ? 0 : d.TeMotor2A;
                worksheet.Cell(x, 28).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 28).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 28).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0108 馬達線圈T
                worksheet.Cell(x, 29).Value = d.TeMotor3A == null ? 0 : d.TeMotor3A;
                worksheet.Cell(x, 29).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 29).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 29).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0108 負載端軸承
                worksheet.Cell(x, 30).Value = d.TeMotor4A == null ? 0 : d.TeMotor4A;
                worksheet.Cell(x, 30).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 30).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 30).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0108 無負載端軸承
                worksheet.Cell(x, 31).Value = d.TeMotor5A == null ? 0 : d.TeMotor5A;
                worksheet.Cell(x, 31).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 31).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 31).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0108 主減速機供油溫度
                worksheet.Cell(x, 32).Value = d.TeMotor6A == null ? 0 : d.TeMotor6A;
                worksheet.Cell(x, 32).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 32).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 32).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0208 馬達線圈R
                worksheet.Cell(x, 33).Value = d.TeMotor1B == null ? 0 : d.TeMotor1B;
                worksheet.Cell(x, 33).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 33).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 33).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0208 馬達線圈S
                worksheet.Cell(x, 34).Value = d.TeMotor2B == null ? 0 : d.TeMotor2B;
                worksheet.Cell(x, 34).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 34).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 34).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0208 馬達線圈T
                worksheet.Cell(x, 35).Value = d.TeMotor3B == null ? 0 : d.TeMotor3B;
                worksheet.Cell(x, 35).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 35).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 35).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0208 負載端軸承
                worksheet.Cell(x, 36).Value = d.TeMotor4B == null ? 0 : d.TeMotor4B;
                worksheet.Cell(x, 36).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 36).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 36).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0208 無負載端軸承
                worksheet.Cell(x, 37).Value = d.TeMotor5B == null ? 0 : d.TeMotor5B;
                worksheet.Cell(x, 37).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 37).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 37).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //M0208 主減速機供油溫度
                worksheet.Cell(x, 38).Value = d.TeMotor6B == null ? 0 : d.TeMotor6B;
                worksheet.Cell(x, 38).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 38).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 38).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //磨機出口 風壓 M0108 
                worksheet.Cell(x, 39).Value = d.WpMillA == null ? 0 : d.WpMillA;
                worksheet.Cell(x, 39).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 39).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 39).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //磨機出口 風壓 M0208 
                worksheet.Cell(x, 40).Value = d.WpMillB == null ? 0 : d.WpMillB;
                worksheet.Cell(x, 40).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 40).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 40).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //風析機出口 風壓 
                worksheet.Cell(x, 41).Value = d.WpOsepa == null ? 0 : d.WpOsepa;
                worksheet.Cell(x, 41).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 41).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 41).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //S系排風機入口 風壓
                worksheet.Cell(x, 42).Value = d.WpBcSIn == null ? 0 : d.WpBcSIn;
                worksheet.Cell(x, 42).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 42).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 42).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //S系排風機壓差 風壓
                worksheet.Cell(x, 43).Value = d.WpBcSDiff == null ? 0 : d.WpBcSDiff;
                worksheet.Cell(x, 43).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 43).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 43).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //收塵排風機 M系 
                worksheet.Cell(x, 44).Value = d.RpmBcM1 == null ? 0 : d.RpmBcM1;
                worksheet.Cell(x, 44).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 44).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 44).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //收塵排風機 M系 
                worksheet.Cell(x, 45).Value = d.RpmBcM2 == null ? 0 : d.RpmBcM2;
                worksheet.Cell(x, 45).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 45).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 45).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //收塵排風機 S系 
                worksheet.Cell(x, 46).Value = d.RpmBcS == null ? 0 : d.RpmBcS;
                worksheet.Cell(x, 46).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 46).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 46).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 熟料/爐石 飼量調節器
                worksheet.Cell(x, 47).Value = d.WM1AP == null ? 0 : d.WM1AP;
                worksheet.Cell(x, 47).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 47).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 47).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 熟料/爐石 積數器 
                worksheet.Cell(x, 48).Value = d.WM1AC == null ? 0 : d.WM1AC;
                worksheet.Cell(x, 48).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 48).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 48).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 熟料/爐石 飼料量
                worksheet.Cell(x, 49).Value = d.WM1AQ == null ? 0 : d.WM1AQ;
                worksheet.Cell(x, 49).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 49).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 49).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 石膏 飼量調節器
                worksheet.Cell(x, 50).Value = d.WM1BP == null ? 0 : d.WM1BP;
                worksheet.Cell(x, 50).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 50).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 50).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 石膏 積數器
                worksheet.Cell(x, 51).Value = d.WM1BC == null ? 0 : d.WM1BC;
                worksheet.Cell(x, 51).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 51).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 51).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 石膏 飼料量
                worksheet.Cell(x, 52).Value = d.WM1BQ == null ? 0 : d.WM1BQ;
                worksheet.Cell(x, 52).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 52).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 52).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //添加劑飼料量
                worksheet.Cell(x, 53).Value = 0.00;
                worksheet.Cell(x, 53).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 53).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 53).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //產量
                var sum1 = worksheet.Cell(x, 54);
                sum1.FormulaA1 = "AW" + x + "+AZ" + x;
                worksheet.Cell(x, 54).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 54).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 54).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 熟料/爐石 飼量調節器
                worksheet.Cell(x, 55).Value = d.WM2AP == null ? 0 : d.WM2AP;
                worksheet.Cell(x, 55).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 55).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 55).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 熟料/爐石 積數器 
                worksheet.Cell(x, 56).Value = d.WM2AC == null ? 0 : d.WM2AC;
                worksheet.Cell(x, 56).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 56).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 56).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 熟料/爐石 飼料量
                worksheet.Cell(x, 57).Value = d.WM2AQ == null ? 0 : d.WM2AQ;
                worksheet.Cell(x, 57).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 57).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 57).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 石膏 飼量調節器
                worksheet.Cell(x, 58).Value = d.WM2BP == null ? 0 : d.WM2BP;
                worksheet.Cell(x, 58).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 58).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 58).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 石膏 積數器
                worksheet.Cell(x, 59).Value = d.WM2BC == null ? 0 : d.WM2BC;
                worksheet.Cell(x, 59).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 59).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 59).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //秤伺機 石膏 飼料量
                worksheet.Cell(x, 60).Value = d.WM2BQ == null ? 0 : d.WM2BQ;
                worksheet.Cell(x, 60).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 60).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 60).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //添加劑飼料量
                worksheet.Cell(x, 61).Value = 0.00;
                worksheet.Cell(x, 61).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 61).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 61).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ////產量
                var sum2 = worksheet.Cell(x, 62);
                sum2.FormulaA1 = "BE" + x + "+BH" + x;
                worksheet.Cell(x, 62).Style.Font.SetFontSize(12);
                worksheet.Cell(x, 62).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(x, 62).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                x++;
            }

            worksheet.Rows().AdjustToContents();

            ////寫入檔案
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                return File(content, contentType, fileName);
            }

        }
        //工單資料
        public IActionResult car_history(string? workid)
        {
            var data = _ZDBContext.OccDespatches.Where(x => x.WorkId == workid);
            return Json(data);
        }
        //抓取工單照片
        public IActionResult car_history_Image(string? workid)
        {
            var data = _ZDBContext.FtyPhotos.Where(x => x.WorkId == workid);
            if (data == null)
            {
                return Content("1", "text/plan", Encoding.UTF8);
            }
            return Json(data);
        }
        //登入驗證
        public IActionResult LoginCheck(WLoginUser wLoginUser)
        {
            var state = _ZDBContext.WLoginUsers.FirstOrDefault(x => x.Account == wLoginUser.Account)?.State;

            var check = _ZDBContext.WLoginUsers.Any(x => x.Account == wLoginUser.Account);

            if (check)
            {
                if (state == 0)
                {
                    return Content("false", "text/plan", Encoding.UTF8);
                }
                else
                {
                    HttpContext.Session.SetString("Account", wLoginUser.Account);
                    HttpContext.Session.SetString("Login", "true");

                    var data = _ZDBContext.WLoginUsers.FirstOrDefault(x => x.Account == wLoginUser.Account);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,data.UserName),
                        new Claim(ClaimTypes.Sid,data.Account),
                    };
                    var right = _ZDBContext.WLoginGroupRights.Where(x => x.Account == wLoginUser.Account).ToList();
                    foreach (var i in right)
                    {
                        string a = i.SubId + i.RightId;
                        claims.Add(new Claim(ClaimTypes.Role, a));
                    }
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = false, //是否可以被刷新
                        IsPersistent = true, //設置有效時間
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                              new ClaimsPrincipal(claimsIdentity),
                              authProperties);

                 

                    return Content("true", "text/plan", Encoding.UTF8);
                }
            }
            else
            {
                return Content("error", "text/plan", Encoding.UTF8);
            }

        }
        //登出
        public IActionResult LogOut()
        {
            Response.Cookies.Delete(".AspNetCore.Cookies");
            Response.Cookies.Delete("LoginUser");
            return RedirectToAction("loginlist", "login");
        }

        //AD 驗證 (方法)
        private string ValidateUser(string account, string password)
        {
            try
            {

                LdapConnection ldc = new LdapConnection(new LdapDirectoryIdentifier("192.168.10.24", 389));
                //LdapConnection ldc = new LdapConnection(new LdapDirectoryIdentifier((string)null, false, false));
                NetworkCredential nc = new NetworkCredential(account, password, "advanced-tek.com.tw");
                ldc.Credential = nc;
                ldc.AuthType = AuthType.Negotiate;
                ldc.Bind();

                return "success";
            }
            catch (LdapException ex)
            {
                if (ex.Message == "提供的認證無效。")
                {
                    return "failed";
                }
                else
                {
                    return ex.Message + " ErrorCode:" + ex.ErrorCode;
                }
            }
        }
        //儲存會員權限
        public IActionResult SaveMember(List<string> factory, string acc)
        {
            string account = acc;
            string WebID = "";
            WLoginGroupRight wLoginGroupRight = new WLoginGroupRight();
            var delUser = _ZDBContext.WLoginGroupRights.AsNoTracking().Where(x => x.Account == account).ToList();
            foreach (var u in delUser)
            {
                if (u.FactoryId == "admin")
                {
                }
                else
                {
                    wLoginGroupRight.GroupId = u.GroupId;
                    wLoginGroupRight.Account = u.Account;
                    wLoginGroupRight.FactoryId = u.FactoryId;
                    wLoginGroupRight.SubId = u.SubId;
                    wLoginGroupRight.RightId = u.RightId;

                    _ZDBContext.WLoginGroupRights.Remove(wLoginGroupRight);
                    _ZDBContext.SaveChanges();
                }
            }

            foreach (var i in factory)
            {

                if (i != null)
                {
                    string[] a = i.Split(",");
                    foreach (var s in a)
                    {

                        string[] subb = s.Split("-");
                        int role = int.Parse(subb[2]);
                        string sub = subb[0] + "-" + subb[1];
                        switch (subb[0])
                        {
                            case "KY":
                                {
                                    WebID = "KY-T1HIST";
                                    break;
                                }
                            case "BL":
                                {
                                    WebID = "BL-T1HIST";
                                    break;
                                }
                            case "QX":
                                {
                                    WebID = "QX-T1HIST";
                                    break;
                                }
                            case "ZB":
                                {
                                    WebID = "ZB-T1HIST";
                                    break;
                                }
                            case "KH":
                                {
                                    WebID = "KH-PCC-LH";
                                    break;
                                }
                            case "LD":
                                {
                                    WebID = "LD-T1HIST";
                                    break;
                                }
                            case "LZ":
                                {
                                    WebID = "LZ-T1HIST";
                                    break;
                                }
                            case "HL":
                                {
                                    WebID = "HL-T1HIST";
                                    break;
                                }
                        }
                        //檢查有無申請過
                        var checkUser = _ZDBContext.WLoginGroupRights.Any(x => x.Account == account && x.FactoryId == WebID && x.SubId == sub);
                        if (!checkUser)
                        {
                            wLoginGroupRight.GroupId = 0;
                            wLoginGroupRight.Account = account;
                            wLoginGroupRight.FactoryId = WebID;
                            wLoginGroupRight.SubId = sub;
                            wLoginGroupRight.RightId = role;
                            _ZDBContext.WLoginGroupRights.Add(wLoginGroupRight);
                            _ZDBContext.SaveChanges();
                        }
                        else
                        {
                            wLoginGroupRight.GroupId = 0;
                            wLoginGroupRight.Account = account;
                            wLoginGroupRight.FactoryId = WebID;
                            wLoginGroupRight.SubId = sub;
                            wLoginGroupRight.RightId = role;
                            _ZDBContext.WLoginGroupRights.Add(wLoginGroupRight);
                            _ZDBContext.SaveChanges();
                        }
                    }
                }
            }
            return Content("true", "text/plan", Encoding.UTF8);
        }
        //寄信申請
        public IActionResult SendMail(List<string> factory, string acc)
        {
            string account = acc;
            string text = "";
            string tt = "";

            foreach (var i in factory)
            {

                if (i != null)
                {
                    tt += i + "<br>";
                }
            }
            text = "權限申請通知 : <br> 申請人 : " + account + "<br> 工廠權限 : <br>" + tt;

            try
            {
                MailMessage email = new MailMessage();

                string addmail = "yx.lin@advanced-tek.com.tw";
                email.From = new MailAddress("yx.lin@advanced-tek.com.tw");
                ////email.To.Add(new MailAddress("gx.kao@advanced-tek.com.tw"));
                ////email.To.Add(new MailAddress("zyi.lu@advanced-tek.com.tw"));
                //email.To.Add(new MailAddress("yx.lin@advanced-tek.com.tw"));
                email.To.Add(new MailAddress(addmail));
                email.Subject = "申請通知";

                email.Body = text;

                email.IsBodyHtml = true;
                email.BodyEncoding = Encoding.UTF8;
                email.SubjectEncoding = Encoding.UTF8;

                using (SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("yx.lin@advanced-tek.com.tw", "TGB852yhn");
                    client.Send(email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return Content("fales", "text/plan", Encoding.UTF8);
            }

            return Content("true", "text/plan", Encoding.UTF8);
        }

        //回饋權限管理
        public IActionResult LoderUserRole(string account)
        {
            var data = _ZDBContext.WLoginGroupRights.Where(x => x.Account == account).ToList();
            return Json(data);
        }
        //使用者狀態
        public IActionResult UserState(string account)
        {
            var data = _ZDBContext.WLoginUsers.Where(x => x.Account == account).Select(x => x.State).ToList();
            return Json(data);
        }
        //儲存使用者狀態
        public IActionResult SaveUserState(string account, string state)
        {
            WLoginUser user = _ZDBContext.WLoginUsers.FirstOrDefault(x => x.Account == account);
            if (user != null)
            {
                user.State = int.Parse(state);
                _ZDBContext.SaveChanges();
            }
            return Json("true");
        }
        //讀取使用者權限對應的主頁及子頁
        public IActionResult LoadPage(string account)
        {
            var subPage = _ZDBContext.WLoginGroupRights.Where(x => x.Account == account).Select(x => x.SubId).Distinct().ToList();
            var page = _ZDBContext.WLoginGroupRights.Where(x => x.Account == account).Select(x => x.FactoryId).Distinct().ToList();
            var dict = new Dictionary<string, List<string>>();

            dict.Add("Sub", subPage);
            dict.Add("page", page);

            return Json(dict);
        }

    }
}
