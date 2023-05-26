//using DocumentFormat.OpenXml.Bibliography;
//using DocumentFormat.OpenXml.Drawing.Charts;
//using DocumentFormat.OpenXml.Drawing.Spreadsheet;
//using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
//using DocumentFormat.OpenXml.Wordprocessing;
using gin.Models;
using gin.ViewModel;
using MessagePack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace gin.Controllers
{
    public class MachineMainController : Controller
    {
        private readonly ZDBContext _ZDBContext;
        public MachineMainController(ZDBContext zDBContext)
        {
            _ZDBContext = zDBContext;
        }

        [Authorize(Policy = "CustomPolicy")]
        public IActionResult Car_History(string? factoryId, string? sDay, string? eDay, string? sCaleno, string? prodId, string? hatt, string? txtKey)
        {
            string nowDay = "";
            int count = 0;
            int bulk = 0;

            Car_History car_History = new();
            List<OccDespatch> occ_Despatch = new();
            List<string> workid = new();
            List<hatlist> hat = new();

            DateTime sD = DateTime.Parse(DateTime.Now.ToString(sDay));
            DateTime eD = DateTime.Parse(DateTime.Now.ToString(eDay));

            ViewBag.day1 = sDay;
            ViewBag.day2 = eDay;
            ViewBag.factoryId = factoryId;
            ViewBag.scaleNo = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId).Select(x => x.ScaleNo).Distinct().OrderBy(x => x).ToList();
            ViewBag.prodId = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId).Select(x => x.ProdId).Distinct().OrderBy(x => x);
            ViewBag.count = "0";
            ViewBag.bulk = "0";
            ViewBag.package = "0";

            if (sCaleno == null && prodId == null && hatt == null && txtKey == null)
            {
                nowDay = DateTime.Now.ToString("yyyy-MM-dd");

                ViewBag.day1 = nowDay;
                DateTime date2 = DateTime.Parse(nowDay).AddDays(1);
                ViewBag.day2 = date2.ToString("yyyy-MM-dd");
                ViewBag.time1 = DateTime.Now.ToString("00:00");
                ViewBag.time2 = DateTime.Now.ToString("23:59");
                ViewBag.scaleNo = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate.ToString() == nowDay).Select(x => x.ScaleNo).Distinct();
                ViewBag.prodId = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate.ToString() == nowDay).Select(x => x.ProdId).Distinct();

                var data = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate.ToString() == nowDay).ToList();
                count = data.Count();
                ViewBag.count = data.Count();
                bulk = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate.ToString() == nowDay && x.ScaleNo != "4").Count();
                ViewBag.bulk = bulk;
                ViewBag.package = count - bulk;

                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }
            else if (sCaleno == "0" && prodId == "0" && hatt == "-1" && txtKey == null)
            {
                var data = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD).ToList();

                //var data = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && TimeSpan.Parse(x.ITime) >= TimeSpan.Parse("01:00:00") && TimeSpan.Parse(x.ITime) >= TimeSpan.Parse("12:00:00"));

                count = data.Count();
                bulk = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo != "4").Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = bulk;
                ViewBag.package = count - bulk;
                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }  //1
            else if (sCaleno != "0" && prodId == "0" && hatt == "-1" && txtKey == null)
            {
                var data = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo == sCaleno).ToList();
                count = data.Count();
                bulk = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo != "4").Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = "0";
                ViewBag.package = "0";
                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //2
            else if (sCaleno != "0" && prodId != "0" && hatt == "-1" && txtKey == null)
            {
                var data = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo == sCaleno && x.ProdId == prodId).ToList();
                count = data.Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = "0";
                ViewBag.package = "0";

                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //3
            else if (sCaleno != "0" && prodId != "0" && hatt != "-1" && txtKey == null)
            {
                var data = (from aa in _ZDBContext.OccDespatches
                            join ph in _ZDBContext.FtyPhotos
                            on aa.WorkId equals ph.WorkId
                            where ph.UnsafetyHat == hatt && aa.DeptId == factoryId && aa.ODate >= sD && aa.ODate < eD && aa.ScaleNo == sCaleno && aa.ProdId == prodId
                            select new { aa.WorkId,aa.CarId, aa.CustName, aa.ScaleNo, aa.ITime }).Distinct();

                count = data.Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = "0";
                ViewBag.package = "0";

                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //4
            else if (sCaleno != "0" && prodId != "0" && hatt != "-1" && txtKey != null)
            {
                var data = (from aa in _ZDBContext.OccDespatches
                            join ph in _ZDBContext.FtyPhotos
                            on aa.WorkId equals ph.WorkId
                            where ph.UnsafetyHat == hatt && aa.DeptId == factoryId && aa.ODate >= sD && aa.ODate < eD && aa.ScaleNo == sCaleno && aa.ProdId == prodId && aa.CustId.Contains(txtKey)
                            select new { aa.WorkId, aa.CarId, aa.CustName, aa.ScaleNo, aa.ITime }).Distinct();

                //var data = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo == sCaleno && x.ProdId == prodId);
                count = data.Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = "0";
                ViewBag.package = "0";

                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //5
            else if (sCaleno == "0" && prodId != "0" && hatt == "-1" && txtKey == null)
            {
                var data = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ProdId == prodId).ToList();
                count = data.Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = "0";
                ViewBag.package = "0";
                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //6
            else if (sCaleno == "0" && prodId != "0" && hatt != "-1" && txtKey == null)
            {
                var data = (from aa in _ZDBContext.OccDespatches
                            join ph in _ZDBContext.FtyPhotos
                            on aa.WorkId equals ph.WorkId
                            where ph.UnsafetyHat == hatt && aa.DeptId == factoryId && aa.ODate >= sD && aa.ODate < eD && aa.ProdId == prodId
                            select new { aa.WorkId,aa.CarId , aa.CustName, aa.ScaleNo, aa.ITime }).Distinct();

                count = data.Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = "0";
                ViewBag.package = "0";
                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //7
            else if (sCaleno == "0" && prodId != "0" && hatt == "-1" && txtKey != null)
            {
                var data = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ProdId == prodId && x.CustId.Contains(txtKey)).ToList();
                count = data.Count();
                bulk = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo != "4").Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = bulk;
                ViewBag.package = count - bulk;
                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //8
            else if (sCaleno == "0" && prodId != "0" && hatt != "-1" && txtKey != null)
            {
                var data = (from aa in _ZDBContext.OccDespatches
                            join ph in _ZDBContext.FtyPhotos
                            on aa.WorkId equals ph.WorkId
                            where ph.UnsafetyHat == hatt && aa.DeptId == factoryId && aa.ODate >= sD && aa.ODate < eD && aa.ProdId == prodId && aa.CustId.Contains(txtKey)
                            select new { aa.WorkId,aa.CarId, aa.CustName, aa.ScaleNo, aa.ITime }).Distinct();

                count = data.Count();
                bulk = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo != "4").Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = bulk;
                ViewBag.package = count - bulk;
                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //9
            else if (sCaleno == "0" && prodId == "0" && hatt != "-1" && txtKey == null)
            {
                var data = (from aa in _ZDBContext.OccDespatches
                            join ph in _ZDBContext.FtyPhotos
                            on aa.WorkId equals ph.WorkId
                            where ph.UnsafetyHat == hatt && aa.DeptId == factoryId && aa.ODate >= sD && aa.ODate < eD
                            select new { aa.WorkId,aa.CarId, aa.CustName, aa.ScaleNo, aa.ITime }).Distinct();

                foreach (var j in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = j.WorkId;
                    occ.CarId = j.CarId;
                    occ.CustName = j.CustName;
                    occ.ScaleNo = j.ScaleNo;
                    occ.ITime = j.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(j.WorkId);
                }
                ViewBag.count = data.Count();
                ViewBag.bulk = "0";
                ViewBag.package = "0";

            }   //10
            else if (sCaleno == "0" && prodId == "0" && hatt != "-1" && txtKey != null)
            {
                var data = (from aa in _ZDBContext.OccDespatches
                            join ph in _ZDBContext.FtyPhotos
                            on aa.WorkId equals ph.WorkId
                            where ph.UnsafetyHat == hatt && aa.DeptId == factoryId && aa.ODate >= sD && aa.ODate < eD && aa.CustId.Contains(txtKey)
                            select new { aa.WorkId,aa.CarId , aa.CustName, aa.ScaleNo, aa.ITime }).Distinct();

                count = data.Count();
                bulk = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo != "4").Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = bulk;
                ViewBag.package = count - bulk;
                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //11 
            else if (sCaleno != "0" && prodId == "0" && hatt != "-1" && txtKey != null)
            {
                var data = (from aa in _ZDBContext.OccDespatches
                            join ph in _ZDBContext.FtyPhotos
                            on aa.WorkId equals ph.WorkId
                            where ph.UnsafetyHat == hatt && aa.DeptId == factoryId && aa.ODate >= sD && aa.ODate < eD && aa.ScaleNo != sCaleno && aa.CustId.Contains(txtKey)
                            select new { aa.WorkId,aa.CarId, aa.CustName, aa.ScaleNo, aa.ITime }).Distinct();

                count = data.Count();
                bulk = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo != "4").Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = "0";
                ViewBag.package = "0";
                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //12 
            else if (sCaleno == "0" && prodId == "0" && hatt == "-1" && txtKey != null)
            {
                var data = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.CustId.Contains(txtKey));
                count = data.Count();

                ViewBag.count = data.Count();
                ViewBag.bulk = "0";
                ViewBag.package = "0";
                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //13
            else if (sCaleno != "0" && prodId == "0" && hatt == "-1" && txtKey != null)
            {
                var data = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo == sCaleno && x.CustId.Contains(txtKey)).ToList();
                count = data.Count();
                bulk = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo != "4").Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = "0";
                ViewBag.package = "0";
                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CarId = i.CarId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //14
            else if (sCaleno != "0" && prodId != "0" && hatt == "-1" && txtKey != null)
            {
                var data = _ZDBContext.OccDespatches.Where(x => x.DeptId == factoryId && x.ODate >= sD && x.ODate < eD && x.ScaleNo == sCaleno && x.ProdId == prodId && x.CustId.Contains(txtKey));
                count = data.Count();
                ViewBag.count = data.Count();
                ViewBag.bulk = "0";
                ViewBag.package = "0";
                foreach (var i in data)
                {
                    OccDespatch occ = new();
                    occ.WorkId = i.WorkId;
                    occ.CustName = i.CustName;
                    occ.ScaleNo = i.ScaleNo;
                    occ.ITime = i.ITime;
                    occ_Despatch.Add(occ);
                    workid.Add(i.WorkId);
                }
            }   //15

            foreach (var i in workid)
            {
                var s = _ZDBContext.FtyPhotos.Where(x => x.WorkId == i).Count();

                if (s > 1)
                {
                    hatlist hatlist = new hatlist();
                    hatlist.workId = i;
                    hatlist.shake = "搖車";
                    hat.Add(hatlist);
                }
                else
                {
                    hatlist hatlist = new hatlist();
                    hatlist.workId = i;
                    hatlist.shake = "";
                    hat.Add(hatlist);
                }
            }
            foreach (var i in workid)
            {
                var s = _ZDBContext.FtyPhotos.Any(x => x.WorkId == i && x.UnsafetyHat == "1");

                if (s == true)
                {
                    hatlist hatlist = new hatlist();
                    hatlist.workId = i;
                    hatlist.hat = "未戴";
                    hat.Add(hatlist);
                }
                else
                {
                    hatlist hatlist = new hatlist();
                    hatlist.workId = i;
                    hatlist.hat = "已戴";
                    hat.Add(hatlist);
                }
            }

            car_History.occDespatches = occ_Despatch;
            car_History.hat = hat;

            return View(car_History);
        }
    }
}
