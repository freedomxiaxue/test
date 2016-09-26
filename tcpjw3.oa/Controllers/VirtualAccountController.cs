using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCPJW_BATradingSystemCITIC;

namespace tcpjw3.oa.Controllers
{
    /// <summary>
    /// 虚拟账户控制器
    /// 包括 虚拟账户审核、虚拟账户申请
    /// </summary>
    [Authorize]
    [VirtualAccount]
    public class VirtualAccountController : Controller
    {
        // GET: VirtualAccount
        public ActionResult CompanyVirtualAcc()
        {
            return View();
        }

        tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();

        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {
            var model = db.BAT_VirtualAccount;
            return PartialView("_GridView1Partial", model.ToList().OrderByDescending(it => it.SQSJ));//按照申请时间 排序
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew(tcpjw3.oa.Models.BAT_VirtualAccount item)
        {
            var model = db.BAT_VirtualAccount;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model.ToList().OrderByDescending(it => it.SQSJ));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate(tcpjw3.oa.Models.BAT_VirtualAccount item)
        {
            var model = db.BAT_VirtualAccount;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.YHBH == item.YHBH);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model.ToList().OrderByDescending(it => it.SQSJ));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(System.Int32 YHBH)
        {
            var model = db.BAT_VirtualAccount;
            if (YHBH >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.YHBH == YHBH);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView1Partial", model.ToList().OrderByDescending(it => it.SQSJ));
        }
        #region 操作员信息
        //****************************操作员信息
        tcpjw3.oa.Models.tcpjwEntities db1 = new tcpjw3.oa.Models.tcpjwEntities();

        [ValidateInput(false)]
        public ActionResult FocusViewEn([Bind(Include = "YHBH,YGXM,ZW,SJHM,SFQY,BZ")]System.Int32 YHBH)
        {
            var model = db1.BAT_EnterpriseOperator;
            ViewData["aa"] = YHBH;
            //ViewBag["aa"] = YHBH;
            return PartialView("_FocusViewEn", model.ToList().Where(it => it.YHBH == YHBH));//选中行的用户编号值

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult FocusViewEnAddNew([Bind(Include = "YHBH,YGXM,ZW,SJHM,SFQY,BZ")]tcpjw3.oa.Models.BAT_EnterpriseOperator item)
        {
            var model = db1.BAT_EnterpriseOperator;

            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_FocusViewEn", model.ToList().Where(et => et.YHBH == item.YHBH));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult FocusViewEnUpdate(tcpjw3.oa.Models.BAT_EnterpriseOperator item)
        {
            var model = db1.BAT_EnterpriseOperator;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db1.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_FocusViewEn", model.ToList().Where(et => et.YHBH == item.YHBH));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult FocusViewEnDelete(System.Int32 ID)
        {
            var model = db1.BAT_EnterpriseOperator;

            Models.BAT_EnterpriseOperator item = new Models.BAT_EnterpriseOperator();
            if (ID >= 0)
            {
                try
                {
                    item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_FocusViewEn", model.ToList().Where(et => et.YHBH == item.YHBH));
        }

        #endregion

        #region 资金账户申请
        [ValidateInput(false)]
        public ActionResult GetQymc(string action)
        {


            if (!string.IsNullOrEmpty(Request.Form["username"]))
            {
                if (action == "查询公司名称")
                {
                    string userid = Request.Form["username"];
                    var qymc = from v in db.BAT_VirtualAccount where v.YHBH.ToString() == userid.ToString() select v.QYMC;

                    ViewData["qymc"] = qymc.First();
                    ViewData["Uid"] = userid;//把用户编号赋值给隐藏域

                }

                if (action == "生成虚拟账户")
                {
                    string qymc = Request.Form["qymc"];

                    string xnzh = null;
                    xnzh = CITICYQZL.GetPreContract(qymc).Replace("$$$$", "|");//格式化成 xxx|xxx
                    if (xnzh.Replace("$$$$", "|").Split('|')[0] == "AAAAAAA")//返回正确的虚拟账户情况
                    {
                        xnzh = xnzh.Replace("$$$$", "|").Split('|')[2];//截取虚拟账户部分
                    }

                    ViewData["xnzh"] = xnzh;
                    ViewData["xnusid"] = Request.Form["Uid"];//再次将用户编号赋值给隐藏域  为下面取值提供方便

                    ViewData["cmp"] = Request.Form["qymc"];
                }

                if (action == "保存")
                {
                    string userid = Request.Form["nuid"];
                    string vr = Request.Form["vr"];
                    //string cm = Request.Form["comp"];
                    //string xn = new Models.BAT_VirtualAccount().creater(cm);

                    Models.BAT_VirtualAccount vrbt = db.BAT_VirtualAccount.Where(a => a.YHBH.ToString() ==userid).FirstOrDefault();
                    vrbt.XNZH = vr;

                    db.SaveChanges();



                   // new Models.BAT_VirtualAccount().UpdateVR(Convert.ToInt32(userid), vr);
                    ViewData["result"] = "更新成功";
                }
            }
            return View("GetQymc");
        }
        #endregion

    }
}