using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using test_1C.Classes;
using test_1C.Models;
using test_1C.ServiceReference1;

namespace test_1C.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //получение информации из 1С 
            return View(GetSalesStatisticsInfo());
        }

        //метод вызова процедуры в 1С
        public IEnumerable<ManagerSalesStatisticsInfo> GetSalesStatisticsInfo()
        {
            var managerinfo = new List<ManagerSalesStatisticsInfo>();
            Dictionary<string, string> parss = new Dictionary<string, string>();
            parss.Add("aa", "bb");
            List<List<Dictionary<string, string>>> lldd = new List<List<Dictionary<string, string>>>();
            var resultt = OneCService.GetTableOneCData("ВернутьПланыМенеджеровАлматы", ref parss, ref lldd);
            if (resultt.Contains("#")) { throw new Exception(resultt); }
            foreach (var table in lldd)
            {
                foreach (var row in table)
                {
                    managerinfo.Add(new ManagerSalesStatisticsInfo(row));
                }
            }
            return managerinfo;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }




       

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}