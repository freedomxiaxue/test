using BATradingManagement.BLL;
using DevExpress.Web.Mvc;
using EndorseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TCPJW_BATradingSystemCITIC;
using tcpjw3.oa.Code;
using tcpjw3.oa.Models;
using tcpjw3.oa.Models.ViewModel;

namespace tcpjw3.oa.Controllers
{
    public class AgencyTradeController : Controller
    {
        
        tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();
        public string _root = "E:\\TCPJW_Developer\\Code\\TCPJW.OA";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SpliterMaster()
        {
            return PartialView();
        }

        [ValidateInput(false)]
        public ActionResult MasterGridViewPartial()
        {
            //var model = db.TicketDiscount;

            var query = (from discount in db.TicketDiscount
                         join pro in db.SysStatic on discount.ProvinceID equals pro.Value.ToString()
                         join city in db.SysStatic on discount.CityID equals city.Value.ToString()
                         where  discount.UploadChannel.Equals(2)
                         //orderby discount.PublishTime descending
                         select new
                         {
                             #region MyRegion
                             CityName = city.Text,
                             ProvinceName = pro.Text,
                             discount.TicketID,
                             discount.TicketType,
                             discount.BankType,
                             discount.BankName,
                             discount.TicketCategory,
                             discount.TermType,
                             discount.TicketPrice,
                             discount.TicketStartTime,
                             discount.TicketEndTime,
                             discount.TicketFaceImg,
                             discount.TicketBackImg,
                             discount.ProvinceID,
                             discount.CityID,
                             discount.TradeState,
                             discount.PublishTime,
                             discount.LastEditTime,
                             discount.UserID,
                             discount.UserName,
                             discount.AuditorID,
                             discount.PublishTunes,
                             discount.AuditTime,
                             discount.AuditNote,
                             discount.AuditorName,
                             discount.AuditState,
                             discount.BidPrice,
                             discount.BidId,
                             discount.ToAccount,
                             discount.Hits,
                             discount.UserNote,
                             discount.UploadChannel,
                             discount.JjzTime,
                             #endregion
                         }
                      ).Distinct().OrderByDescending(p => p.PublishTime);
            return PartialView("_MasterGridViewPartial", query.ToList());

            //return PartialView("_MasterGridViewPartial", model);

        }


        public ActionResult DetailPage(int ticketId)
        {
            //if (ticketId == null) return PartialView("DetailPageControl", new TicketDiscount());
            ViewData["key"] = ticketId;
            var model = db.TicketDiscount.Where(item => item.TicketID == ticketId).FirstOrDefault();
            return PartialView("DetailPageControl", model);

        }

        public ActionResult DiscountTicketInformation(int ticketId)
        {
            ViewData["key"] = ticketId;
            var model = db.TicketDiscount.Where(item => item.TicketID == ticketId).FirstOrDefault();

            ViewData["Pro"] = StaticDictiory.GetProDataSource();
            ViewData["City"] = StaticDictiory.GetCityDataSource(model.ProvinceID);
            ViewData["Bank"] = StaticDictiory.GetBankDataSource(model.BankType);
            #region 年利率
            //票面金额-成交价格=票面金额*(（年息/100）/360)*实际天数
            Decimal interest = (Decimal)(model.TicketPrice - model.BidPrice);//利息
            int resDayca = RestDays(model.TicketEndTime);//实际天数
            Decimal ratca = resDayca <= 0 ? 0 : interest * 360 * 100 / (model.TicketPrice * resDayca);//例如3.17%
            ViewData["Rate"] = ratca.ToString("N2").Replace(",", "");
            #endregion
            AgencyTrade atmodel = new AgencyTrade();
            atmodel.ticketDiscount = model;

            #region MyRegion
            EndorseInfo.UserAccountInfo uif = new EndorseInfo.UserAccountInfo(model.UserID.ToString());//持票人的虚拟账户信息
            EndorseInfo.UserAccountInfo zf = new EndorseInfo.UserAccountInfo(model.BidId.ToString());//资金方的虚拟账户信息
            List<TCPJW_BATradingSystemCITIC.AccountBalance> fablist =
                   TCPJW_BATradingSystemCITIC.CITICYQZL.GetAccountBalance(zf.Account);
            string alertsel = string.Empty;
            if (fablist == null || fablist.Count == 0)
                atmodel.PayAccount = "可用余额:0元   ";


            List<TCPJW_BATradingSystemCITIC.AccountBalance> sablist =
                TCPJW_BATradingSystemCITIC.CITICYQZL.GetAccountBalance(uif.Account);
            if (sablist == null || sablist.Count == 0)
                atmodel.GetAccount = "可用余额:0元   ";
            foreach (var item in fablist)
                atmodel.PayAccount += " 可用余额:" + item.Kyamt + "元 ";
            foreach (var item in sablist)
                atmodel.GetAccount += " 可用余额:" + item.Kyamt + "元";

            Random ro = new Random();
            int rand = ro.Next(100, 999);//返回三位随机数
            atmodel.ZzMemo = string.Format("DP{0}{1}", DateTime.Now.ToString("yyMMdd"), rand.ToString());
            #endregion

            return PartialView("DiscountTicketInformation", atmodel);

        }

        [HttpPost, ValidateInput(false)]
        //[Bind(Include = "ProvinceID,CityID")]
        public ActionResult IndexPartialUpdate(tcpjw3.oa.Models.TicketDiscount item, FormCollection Form)
        {
            //string aa = Form["ProvinceID"].ToString();
            string cbPush = Form["dASPxCheckBoxPush"].ToString();//C-选中 I-未选中
            string cbData = Form["cbDate"].ToString();
            //string aa = Form["comboCs"].ToString();
            List<viewUserDetail> agentList = new List<viewUserDetail>();
            List<TicketPush> pushList = new List<TicketPush>();

            var model = db.TicketDiscount;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.TicketID == item.TicketID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);//修改模型必须在此之后
                        modelItem.TicketCategory = StaticDictiory.getCategory((int)modelItem.TicketType, modelItem.TicketPrice);
                        modelItem.TermType = StaticDictiory.getTerm((int)modelItem.TicketType, (int)modelItem.TicketCategory, Convert.ToDateTime(Convert.ToDateTime(modelItem.PublishTime).ToString("yyyy-MM-dd 23:59:59")));
                        modelItem.TicketEndTime = Convert.ToDateTime(Convert.ToDateTime(modelItem.TicketEndTime).ToString("yyyy-MM-dd 23:59:59"));
                        modelItem.AuditTime = DateTime.Now;
                        modelItem.AuditorID = 0;
                        modelItem.AuditorName = "管理员";
                        #region 审核通过
                        if (item.AuditState == 2)
                        {
                            #region
                            if (modelItem.TradeState == 128)
                            {
                                string yyTime = string.Format("{0} {1}:00", DateTime.Now.ToString("yyyy-MM-dd"), cbData);
                                modelItem.YykbTime = Convert.ToDateTime(yyTime);
                            }
                            else if (modelItem.TradeState == 1)
                            {
                                modelItem.JjzTime = DateTime.Now;
                                modelItem.YykbTime = DateTime.Now;
                            }

                            switch (modelItem.TradeState)
                            {
                                case 128:
                                    #region 推送实体
                                    if (cbPush == "C")
                                    {
                                        agentList = db.viewUserDetail.ToList();

                                        foreach (viewUserDetail agent in agentList)
                                        {
                                            TicketPush push = new TicketPush();
                                            push.BankName = modelItem.BankName;
                                            push.BankType = modelItem.BankType;
                                            push.CityID = modelItem.CityID;
                                            push.ProvinceID = modelItem.ProvinceID;
                                            push.PushTime = DateTime.Now;
                                            push.State = 1;//新推送
                                            push.TermType = modelItem.TermType;
                                            push.TicketType = (int)modelItem.TicketType;
                                            push.TicketCategory = modelItem.TicketCategory;
                                            push.TicketEndTime = (DateTime)modelItem.TicketEndTime;
                                            push.TicketID = modelItem.TicketID;
                                            push.TicketPrice = modelItem.TicketPrice;
                                            push.ToUserID = agent.ID;
                                            push.UserID = modelItem.UserID;
                                            pushList.Add(push);

                                        }

                                    }
                                    #endregion

                                    #region 推送 -- 票源推送， 电票， 预约开标

                                    #endregion
                                    break;

                                case 1:
                                    #region 给上传汇票的用户发送审核通过提醒

                                    #endregion
                                    #region 推送实体
                                    if (cbPush == "C")
                                    {
                                        agentList = db.viewUserDetail.ToList();

                                        foreach (viewUserDetail agent in agentList)
                                        {
                                            TicketPush push = new TicketPush();
                                            push.BankName = modelItem.BankName;
                                            push.BankType = modelItem.BankType;
                                            push.CityID = modelItem.CityID;
                                            push.ProvinceID = modelItem.ProvinceID;
                                            push.PushTime = DateTime.Now;
                                            push.State = 1;//新推送
                                            push.TermType = modelItem.TermType;
                                            push.TicketType = (int)modelItem.TicketType;
                                            push.TicketCategory = modelItem.TicketCategory;
                                            push.TicketEndTime = (DateTime)modelItem.TicketEndTime;
                                            push.TicketID = modelItem.TicketID;
                                            push.TicketPrice = modelItem.TicketPrice;
                                            push.ToUserID = agent.ID;
                                            push.UserID = modelItem.UserID;
                                            pushList.Add(push);

                                        }

                                    }
                                    #endregion

                                    #region 推送 -- 票源审核通知， 电票， 竞价中

                                    #endregion
                                    break;
                            }
                            #endregion

                            #region 新增推送
                            var pushModel = db.TicketPush;
                            foreach (TicketPush push in pushList)
                            {
                                pushModel.Add(push);
                            }
                            #endregion
                        }
                        #endregion
                        else if (item.AuditState == 4)
                        #region 审核不通过
                        {
                            if (string.IsNullOrEmpty(modelItem.BankName))
                            {
                                modelItem.BankName = "未填写";
                            }

                            #region 给发票人发送消息推送

                            #endregion
                        }
                        #endregion

                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }

                var query = (from discount in db.TicketDiscount
                             join pro in db.SysStatic on discount.ProvinceID equals pro.Value.ToString()
                             join city in db.SysStatic on discount.CityID equals city.Value.ToString()
                             where discount.UploadChannel.Equals(2)
                             //orderby discount.PublishTime descending
                             select new
                             {
                                 #region MyRegion
                                 CityName = city.Text,
                                 ProvinceName = pro.Text,
                                 discount.TicketID,
                                 discount.TicketType,
                                 discount.BankType,
                                 discount.BankName,
                                 discount.TicketCategory,
                                 discount.TermType,
                                 discount.TicketPrice,
                                 discount.TicketStartTime,
                                 discount.TicketEndTime,
                                 discount.TicketFaceImg,
                                 discount.TicketBackImg,
                                 discount.ProvinceID,
                                 discount.CityID,
                                 discount.TradeState,
                                 discount.PublishTime,
                                 discount.LastEditTime,
                                 discount.UserID,
                                 discount.UserName,
                                 discount.AuditorID,
                                 discount.PublishTunes,
                                 discount.AuditTime,
                                 discount.AuditNote,
                                 discount.AuditorName,
                                 discount.AuditState,
                                 discount.BidPrice,
                                 discount.BidId,
                                 discount.ToAccount,
                                 discount.Hits,
                                 discount.UserNote,
                                 discount.UploadChannel,
                                 discount.JjzTime,
                                 #endregion
                             }
                            ).Distinct().OrderByDescending(p => p.PublishTime);

                return Content("<script>alert('编辑成功！');window.parent.location.href='/Discount/Index'</script>");
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";

                var query = (from discount in db.TicketDiscount
                             join pro in db.SysStatic on discount.ProvinceID equals pro.Value.ToString()
                             join city in db.SysStatic on discount.CityID equals city.Value.ToString()
                             where discount.UploadChannel.Equals(2) 
                             //orderby discount.PublishTime descending
                             select new
                             {
                                 #region MyRegion
                                 CityName = city.Text,
                                 ProvinceName = pro.Text,
                                 discount.TicketID,
                                 discount.TicketType,
                                 discount.BankType,
                                 discount.BankName,
                                 discount.TicketCategory,
                                 discount.TermType,
                                 discount.TicketPrice,
                                 discount.TicketStartTime,
                                 discount.TicketEndTime,
                                 discount.TicketFaceImg,
                                 discount.TicketBackImg,
                                 discount.ProvinceID,
                                 discount.CityID,
                                 discount.TradeState,
                                 discount.PublishTime,
                                 discount.LastEditTime,
                                 discount.UserID,
                                 discount.UserName,
                                 discount.AuditorID,
                                 discount.PublishTunes,
                                 discount.AuditTime,
                                 discount.AuditNote,
                                 discount.AuditorName,
                                 discount.AuditState,
                                 discount.BidPrice,
                                 discount.BidId,
                                 discount.ToAccount,
                                 discount.Hits,
                                 discount.UserNote,
                                 discount.UploadChannel,
                                 discount.JjzTime,
                                 #endregion
                             }
                ).Distinct().OrderByDescending(p => p.PublishTime);

                return Content("<script>alert('编辑失败！');window.parent.location.href='/Discount/Index'</script>");
            }

            //return RedirectToAction("Index");
            //return null;

            //return PartialView("DiscountTicketInformation", query.ToList());

        }

        /// <summary>
        /// 资金打款
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxOperFund()
        {
            string ticketID = System.Web.HttpContext.Current.Request.Form["TicketID"];
            string followID = System.Web.HttpContext.Current.Request.Form["FollowID"];

            //return Json(new { success = false, Message = "", Tips = "汇票编号【" + ticketID + "】已进行资金打款，无法重复打款！", Status = 2 });

            TicketDiscount model = db.TicketDiscount.Where(t => t.TicketID == Convert.ToInt32(ticketID)).FirstOrDefault();
            #region MyRegion
            string dkstatus = string.Empty;
            List<GoldAccount> goldAccountList = GoldAccount.GetUserGoldAccountByUsercjrecvaccno(model.UserID, model.ToAccount);
            if (goldAccountList.Count == 0)
            {
                return Json(new { success = false, Message = "请确保出金信息无误",Tips="", Status = 0 });
            }

            EndorseInfo.UserAccountInfo uif = new EndorseInfo.UserAccountInfo(model.UserID.ToString());//持票人的虚拟账户信息
            EndorseInfo.UserAccountInfo zf = new EndorseInfo.UserAccountInfo(model.BidId.ToString());//资金方的虚拟账户信息

            //string queryString = e.Parameters;//button按钮参数
            string subaccno = zf.Account;//"3110510001051004035";//资方 zf.Account
            string srecvaccnm = zf.ComName;//"银承互联网金融信息服务（南京）有限公司";//zf.ComName
            string recvaccno = uif.Account;//"3110510001051004033";//持票人uif.Account
            string recvaccnm = uif.ComName;//"南京赛旭投资管理有限公司";//uif.ComName
            string cjrecvaccno = goldAccountList[0].CjrecvAccNo; // "8110501013300082823";//出金账号 goldAccountList[0].CjrecvAccNo
            string cjrecvaccnm = goldAccountList[0].RecvAccNm; //"银承互联网金融信息服务（南京）有限公司";//出金账号名称
            string tranamt = Convert.ToDecimal(model.BidPrice).ToString("N2").Replace(",", ""); ;//"0.01";
            string zzmemo = followID;
            string cjsamebank = goldAccountList[0].CjsameBank == true ? "1" : "0";
            string cjrecvtgfi = goldAccountList[0].CjrecvTgfi;
            string cjrecvbanknm = goldAccountList[0].CjrecvBankNm;
            string cjmemo = "";
            string cjpreflg = "0";
            string cjpredate = "";
            string cjpretime = "";
            #endregion

            #region MyRegion
            //判断出金账户是否存在
            if (goldAccountList.Count > 0)
            {
                //判断虚拟账户里面的企业名称跟出金账户的企业名称是否一致
                if (uif.ComName != goldAccountList[0].RecvAccNm)
                {
                    return Json(new { success = false, Message = "", Tips = "出金账户与虚拟账户中的企业名称不一致", Status = 0 });
                }
            }
            else
            {
                return Json(new { success = false, Message = "", Tips = "出金账户不存在", Status = 0 });
            }
            #endregion

            try
            {
                #region MyRegion
                CiticPlatformOfGold cpogmodel = new CiticPlatformOfGold();
                cpogmodel = TCPJW_CITICPROJECT.Common.GetCiticPlatformOfGoldByTid(model.TicketID);
                if (cpogmodel != null)
                {
                    if (cpogmodel.Pf_id > 0)
                    {
                        this.UpdateModel(model);//修改模型必须在此之后
                        model.AuditorName = "AAAAAAA";
                        db.SaveChanges();
                        //yybutton.Enabled = false;

                        return Json(new { success = false, Message = "", Tips = "汇票编号【" + model.TicketID + "】已进行资金打款，无法重复打款！", Status = 2 });
                    }
                }

                //返回格式：状态$$$$状态值
                string clientid = "PCJ" + GetRandomNm(); //DateTime.Now.ToString("yyyyMMddHHmmssfff"); //wy：平台出金的客户流水号主要为了后面查询交易状态
               string cid = clientid;

                //if (log.IsInfoEnabled) log.InfoFormat("出金账号加密：{0}", new Encrypt_TCPJW().Encrypto(cjrecvaccno));
                string[] citicstatus = TCPJW_BATradingSystemCITIC.CITICYQZL.OpTransferthegold(subaccno, srecvaccnm, recvaccno, recvaccnm, new Encrypt_TCPJW().Encrypto(cjrecvaccno), new Encrypt_TCPJW().Encrypto(cjrecvaccnm), tranamt, zzmemo,
                    cjsamebank, cjrecvtgfi, cjrecvbanknm, cjmemo, cjpreflg, cjpredate, cjpretime, clientid, model.TicketID).Split(new string[] { "$$$$" }, StringSplitOptions.None);


                if (citicstatus.Count() > 1)
                {
                    dkstatus = citicstatus[0];
                  
                    if (dkstatus == "ZDJError")
                    {
                        //yybutton.Enabled = false;
                        //cjbutton.Visible = true;
                        //cxbutton.Enabled = false;

                        return Json(new { success = false, Message = "", Tips = "出金账户不存在",Status=1 });
                    }
                    if (dkstatus == "AAAAAAE" || dkstatus == "AAAAAAA" ||
                        dkstatus == "AAAAAAB" || dkstatus == "AAAAAAC" || dkstatus == "AAAAAAD")
                    {
                        this.UpdateModel(model);//修改模型必须在此之后
                        model.AuditorName = "AAAAAAA";
                        db.SaveChanges();

                        return Json(new { success = true, Message = "成功", Tips = citicstatus[1], Status = 0 });
                    }

   

                }

                #endregion

            }
            catch (Exception ex)
            {
                return Json(new { success = false, Message = "失败！！", Tips = "资金打款出现异常", Status = 0 });
            }

            return null;
        }

        /// <summary>
        /// 解冻出金
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxUotGold()
        {
            string ticketID = System.Web.HttpContext.Current.Request.Form["TicketID"];
            string followID = System.Web.HttpContext.Current.Request.Form["FollowID"];
            TicketDiscount model = db.TicketDiscount.Where(t => t.TicketID == Convert.ToInt32(ticketID)).FirstOrDefault();
            #region MyRegion
            string dkstatus = string.Empty;
            List<GoldAccount> goldAccountList = GoldAccount.GetUserGoldAccountByUsercjrecvaccno(model.UserID, model.ToAccount);
            if (goldAccountList.Count == 0)
            {
                return Json(new { success = false, Message = "请确保出金信息无误", Tips = "", Status = 0 });
            }

            EndorseInfo.UserAccountInfo uif = new EndorseInfo.UserAccountInfo(model.UserID.ToString());//持票人的虚拟账户信息
            EndorseInfo.UserAccountInfo zf = new EndorseInfo.UserAccountInfo(model.BidId.ToString());//资金方的虚拟账户信息

            //string queryString = e.Parameters;//button按钮参数
            string subaccno = zf.Account;//"3110510001051004035";//资方 zf.Account
            string srecvaccnm = zf.ComName;//"银承互联网金融信息服务（南京）有限公司";//zf.ComName
            string recvaccno = uif.Account;//"3110510001051004033";//持票人uif.Account
            string recvaccnm = uif.ComName;//"南京赛旭投资管理有限公司";//uif.ComName
            string cjrecvaccno = goldAccountList[0].CjrecvAccNo; // "8110501013300082823";//出金账号 goldAccountList[0].CjrecvAccNo
            string cjrecvaccnm = goldAccountList[0].RecvAccNm; //"银承互联网金融信息服务（南京）有限公司";//出金账号名称
            string tranamt = Convert.ToDecimal(model.BidPrice).ToString("N2").Replace(",", ""); ;//"0.01";
            string zzmemo = followID;
            string cjsamebank = goldAccountList[0].CjsameBank == true ? "1" : "0";
            string cjrecvtgfi = goldAccountList[0].CjrecvTgfi;
            string cjrecvbanknm = goldAccountList[0].CjrecvBankNm;
            string cjmemo = "";
            string cjpreflg = "0";
            string cjpredate = "";
            string cjpretime = "";
            #endregion

            //判断出金账户是否存在
            if (goldAccountList.Count > 0)
            {
                //判断虚拟账户里面的企业名称跟出金账户的企业名称是否一致
                if (uif.ComName != goldAccountList[0].RecvAccNm)
                {
                    return Json(new { Tips = "出金账户与虚拟账户中的企业名称不一致", Status = 0 });
                }
            }
            else
            {
                return Json(new { Tips = "出金账户不存在", Status = 0 });
            }
            #region 解冻出金
            CiticPlatformOfGold cpogmodel = new CiticPlatformOfGold();
            cpogmodel = TCPJW_CITICPROJECT.Common.GetCiticPlatformOfGoldByTid(model.TicketID);
            if (cpogmodel != null)
            {
                if (cpogmodel.Pf_id > 0)
                {
                    this.UpdateModel(model);//修改模型必须在此之后
                    model.AuditorName = "AAAAAAA";
                    db.SaveChanges();
                    //yybutton.Enabled = false;
                    //cjbutton.Enabled = false;
                    return Json(new { Tips = "汇票编号【" + model.TicketID + "】已进行资金打款，无法重复打款！", Status = 1 });
                }
            }

            //返回格式：状态$$$$状态值
            string clientid = "PCJ" + GetRandomNm(); //DateTime.Now.ToString("yyyyMMddHHmmssfff"); //wy：平台出金的客户流水号主要为了后面查询交易状态
           string cid = clientid;
            string[] citicstatus = TCPJW_BATradingSystemCITIC.CITICYQZL.OpThrawoutthegold(subaccno, srecvaccnm, recvaccno, recvaccnm, new Encrypt_TCPJW().Encrypto(cjrecvaccno), new Encrypt_TCPJW().Encrypto(cjrecvaccnm), tranamt, zzmemo,
                cjsamebank, cjrecvtgfi, cjrecvbanknm, cjmemo, cjpreflg, cjpredate, cjpretime, clientid, model.TicketID).Split(new string[] { "$$$$" }, StringSplitOptions.None);

            #endregion
            if (citicstatus.Count() > 1)
            {
                dkstatus = citicstatus[0];
                if (dkstatus == "AAAAAAE" || dkstatus == "AAAAAAA" ||
                    dkstatus == "AAAAAAB" || dkstatus == "AAAAAAC" || dkstatus == "AAAAAAD")
                {
                    UpdateModel(model);//修改模型必须在此之后
                    model.AuditorName = "AAAAAAA";
                    db.SaveChanges();
                    //yybutton.Enabled = false;
                    //cjbutton.Enabled = false;
                    //cjbutton.Visible = true;
                    //cxbutton.Enabled = true;
                    return Json(new { Tips = citicstatus[1], Status = 2 });
                }
                return Json(new { Tips = citicstatus[1], Status = 0 });
            }

            return Json(new { Tips = "", Status = 0 });
        }

        /// <summary>
        /// 查询账单余额
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxQueryBalance()
        {
            string ticketID = System.Web.HttpContext.Current.Request.Form["TicketID"];
            TicketDiscount model = db.TicketDiscount.Where(t => t.TicketID == Convert.ToInt32(ticketID)).FirstOrDefault();
            #region MyRegion
            List<GoldAccount> goldAccountList = new List<GoldAccount>();
            goldAccountList = GoldAccount.GetUserGoldAccountByUsercjrecvaccno(model.UserID, model.ToAccount);
            if (goldAccountList.Count == 0)
            {
                return Json(new { success = false, Message = "请确保出金信息无误", Tips = "", Status = 0 });
            }

            EndorseInfo.UserAccountInfo uif = new EndorseInfo.UserAccountInfo(model.UserID.ToString());//持票人的虚拟账户信息
            EndorseInfo.UserAccountInfo zf = new EndorseInfo.UserAccountInfo(model.BidId.ToString());//资金方的虚拟账户信息

            //string queryString = e.Parameters;//button按钮参数
            string subaccno = zf.Account;//"3110510001051004035";//资方 zf.Account
            string srecvaccnm = zf.ComName;//"银承互联网金融信息服务（南京）有限公司";//zf.ComName
            string recvaccno = uif.Account;//"3110510001051004033";//持票人uif.Account
            string recvaccnm = uif.ComName;//"南京赛旭投资管理有限公司";//uif.ComName
            string cjrecvaccno = goldAccountList[0].CjrecvAccNo; // "8110501013300082823";//出金账号 goldAccountList[0].CjrecvAccNo
            string cjrecvaccnm = goldAccountList[0].RecvAccNm; //"银承互联网金融信息服务（南京）有限公司";//出金账号名称
            string tranamt = Convert.ToDecimal(model.BidPrice).ToString("N2").Replace(",", ""); ;//"0.01";
            //string zzmemo = followID;
            string cjsamebank = goldAccountList[0].CjsameBank == true ? "1" : "0";
            string cjrecvtgfi = goldAccountList[0].CjrecvTgfi;
            string cjrecvbanknm = goldAccountList[0].CjrecvBankNm;
            string cjmemo = "";
            string cjpreflg = "0";
            string cjpredate = "";
            string cjpretime = "";
            #endregion

            #region MyRegion
            try
            {
                string cxcid = TCPJW_CITICPROJECT.Common.GetCiticPlatformOfGoldByTid(Convert.ToInt32( ticketID)).Pf_clientid.ToString();
                if (string.IsNullOrEmpty(cxcid))
                {
                    //if (log.IsInfoEnabled) log.InfoFormat("您还没有执行打款，没有交易状态，出金流水编号：{0}", cxcid);
                    return Json(new {  Tips = "您还没有执行打款,没有交易状态" });
                }
            }
            catch (Exception ex)
            {
                //if (log.IsFatalEnabled) log.FatalFormat("打款未成功，无法查询最新余额，异常错误：{0}", ex.Message);
                return Json(new { Tips = "打款未成功,无法查询最新余额" });
            }
            try
            {
                List<TCPJW_BATradingSystemCITIC.AccountBalance> fablist = new List<AccountBalance>();
                fablist = TCPJW_BATradingSystemCITIC.CITICYQZL.GetAccountBalance(subaccno);
                string alertsel = string.Empty;
                if (fablist == null || fablist.Count == 0)
                {
                    //grid.JSProperties["cpScript"] = "alert('付款账号【" + subaccno + "】无余额信息');";
                    return Json(new { Tips = "付款账号【" + subaccno + "】无余额信息" });
                }
                List<TCPJW_BATradingSystemCITIC.AccountBalance> sablist = new List<AccountBalance>();
                sablist = TCPJW_BATradingSystemCITIC.CITICYQZL.GetAccountBalance(recvaccno);
                if (sablist == null || sablist.Count == 0)
                {
                    //grid.JSProperties["cpScript"] = "alert('收款账号【" + subaccno + "】无余额信息');";
                    return Json(new { Tips = "收款账号【" + subaccno + "】无余额信息" });
                }
                foreach (var item in fablist)
                {
                    alertsel += "付款账号【" + subaccno + "】,  可用余额:" + item.Kyamt + "元 \r\n";
                }
                foreach (var item in sablist)
                {
                    alertsel += "收款账号【" + recvaccno + "】,  可用余额:" + item.Kyamt + "元 \r\n";
                }

                return Json(new { Tips = alertsel });
            }
            catch (Exception ex)
            {
               // if (log.IsFatalEnabled) log.FatalFormat("查询最新余额出现异常，付款账号：{0}，收款账号：{1}，异常错误：{2}", subaccno, recvaccno, ex.Message);
                return Json(new { Tips = "查询最新余额出现异常" });
            }
            #endregion
            return Json(new { Tips = "" });

        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxUpdateOrder()
        {
            #region Form参数
            string ticketID = System.Web.HttpContext.Current.Request.Form["TicketID"];
            string followID = System.Web.HttpContext.Current.Request.Form["FollowID"];
            string BankName = System.Web.HttpContext.Current.Request.Form["BankName"];
            string ProvinceID = System.Web.HttpContext.Current.Request.Form["ProvinceID"];
            string CityID = System.Web.HttpContext.Current.Request.Form["CityID"];
            string TicketType = System.Web.HttpContext.Current.Request.Form["TicketType"];
            string BankTyp = System.Web.HttpContext.Current.Request.Form["BankTyp"];
            string TicketEndTime = System.Web.HttpContext.Current.Request.Form["TicketEndTime"];
            string auditState = System.Web.HttpContext.Current.Request.Form["AuditState"];
            string AuditNote = System.Web.HttpContext.Current.Request.Form["AuditNote"];
            string UserNote = System.Web.HttpContext.Current.Request.Form["UserNote"];
            #endregion

            try
            {
            TicketDiscount model = db.TicketDiscount.Where(t => t.TicketID == Convert.ToInt32(ticketID)).FirstOrDefault();
            UpdateModel(model);//修改模型必须在此之后
            #region 编辑信息
            model.TicketCategory = StaticDictiory.getCategory(Convert.ToInt32( TicketType), model.TicketPrice);
            model.TermType = StaticDictiory.getTerm(Convert.ToInt32(TicketType), (int)model.TicketCategory, Convert.ToDateTime(Convert.ToDateTime(model.PublishTime).ToString("yyyy-MM-dd 23:59:59")));
            model.TicketEndTime = Convert.ToDateTime(Convert.ToDateTime(TicketEndTime).ToString("yyyy-MM-dd 23:59:59"));
            model.AuditTime = DateTime.Now;
            model.AuditorID = 0;
            model.BankName = BankName;
            model.ProvinceID = ProvinceID;
            model.CityID = CityID;
            model.TicketType =Convert.ToInt32( TicketType);
            model.BankType = Convert.ToInt32( BankTyp);
            model.AuditState =Convert.ToInt32(auditState);
            model.AuditNote = AuditNote;
            model.UserNote = UserNote;
            #endregion

            if (auditState == AuditState.审核通过.ToString())
            {
                #region 通过
                #region MyRegion
                model.AuditorName = "BBBBBBB";
                model.TradeState =(int) TradeState.交易完成;
                Random ran = new Random();
                model.YykbTime = DateTime.Now;
                model.JjzTime = DateTime.Now;
                model.QryyTime = DateTime.Now.AddMinutes(ran.Next(5, 8)).AddSeconds(ran.Next(0, 59));
                model.ZfdjTime = DateTime.Now.AddMinutes(ran.Next(9, 11)).AddSeconds(ran.Next(0, 59));
                model.CprbsTime = DateTime.Now.AddMinutes(ran.Next(12, 14)).AddSeconds(ran.Next(0, 59));
                model.QsjdTime = DateTime.Now.AddMinutes(ran.Next(15, 17)).AddSeconds(ran.Next(0, 59));
                model.WcjyTime = DateTime.Now.AddMinutes(ran.Next(18, 22)).AddSeconds(ran.Next(0, 59));
                #endregion
                #region MyRegion
                var bidmodel = db.DiscountBidding;
                DiscountBidding biding = new DiscountBidding();
                biding.TicketID = model.TicketID;
                biding.BidUserID = (Int32)model.BidId;
                biding.BidTime = DateTime.Now.AddMinutes(ran.Next(2, 8));
                biding.BidResult = 1;
                biding.BidRelateResult = 1;
                biding.LoginMode = 1;
                biding.TotalPrice = model.BidPrice;
                //(price - parseFloat(inputQuote.val().replace(/,/ig, ''))) * 100000 / price,
                //biding.BidPrice = (decimal)((model.TicketPrice - model.BidPrice) * 100000 / model.TicketPrice);
                biding.BidPrice = (decimal)((model.TicketPrice - model.BidPrice)  / model.TicketPrice);
                //(30 * per10 / days / 100) * 10 / 12;
                Decimal mony = (Decimal)(model.TicketPrice - model.BidPrice);//利息
                int sjdays = RestDays(model.TicketEndTime);//实际天数
                Decimal bidrate = sjdays <= 0 ? 0 : mony * 360 * 100 / (model.TicketPrice * sjdays);//例如3.17%
                biding.BidRate = bidrate;
                bidmodel.Add(biding);
                #endregion
                #region MyRegion
                //ClientUser client=db.ClientUser.Where(u=>u.ID== model.UserID)
                     var client = (from cu in db.ClientUser
                                  join uc in db.UserCenter on cu.ID equals uc.ID
                                  join pro in db.SysStatic on cu.ProvinceID equals pro.Value.ToString()
                                  join city in db.SysStatic on cu.CityID equals city.Value.ToString()
                                  where uc.ID.Equals(model.UserID)
                                  select new
                                  {
                                      #region MyRegion
                                      CityName = pro.Text,
                                      ProvinceName = city.Text,
                                      uc.ID,
                                      cu.Avatar,
                                      cu.FullName,
                                      cu.Name,
                                      cu.NameOfPIC,
                                      cu.Address,
                                      uc.RegisterTime,
                                      uc.LastLoginTime,
                                      uc.Phone
                                      #endregion
                                  }).FirstOrDefault();
                //创建交易请求
                TradingRequest tr = new TradingRequest();
                tr.BZ = null;
                tr.CPRBH = client.ID; //持票企业编号
                tr.CPRDH = client.Phone; //持票企业电话
                tr.CPRMC = null;
                tr.EndTime = null;
                tr.FQR = client.ID; //发起人默认为持票企业
                tr.FQSJ = DateTime.Now; //交易发起时间
                tr.JYSHR = null;
                tr.JYSHSJ = null;
                tr.JYSHZT = "1";
                tr.JYZT = ((int)TradeState.交易完成).ToString();
                tr.SPRBH = (int)model.BidId; //贴现机构编号
                tr.SPRDH = ""; //贴现机构电话
                tr.SPRMC = null;
                tr.YWBH = followID;

                //创建票面信息
                ParValueInfo pv = new ParValueInfo();
                pv.CDHQC = model.BankName;
                Double cjjg = (Convert.ToDouble((model.BidPrice.ToString().Substring(0, model.BidPrice.ToString().LastIndexOf(".") + 3))));
                pv.CJJG = (decimal)cjjg;
                pv.CJMSWJG = biding.BidPrice;
                pv.CJYLL = biding.BidRate;
                pv.DQR = (DateTime)model.TicketEndTime;
                //pv.JYQQBH = followID;
                pv.PMJE = model.TicketPrice;

                int imagesCount = 0;
                List<TicketImage> imageOrigin = db.TicketImage.Where(p => p.TicketID == model.TicketID).ToList();
                if (imagesCount > 0)
                    pv.PMJT = imageOrigin[0].OriginImg;
                else
                    pv.PMJT = model.TicketFaceImg;

                pv.Pvid = model.TicketID;


                //交易记录
                TCPJW_BATradingSystemCore.Trading.Trading.AddTradingDetail(tr, pv, client.ID, (int)model.BidId);
                CapitalDealInfo.UpdateJYCGCS((int)model.BidId);
                CapitalDealInfo.UpdatePJJYHS((int)model.BidId, (DateTime)model.ZfdjTime, (DateTime)model.WcjyTime);
                #endregion


                db.SaveChanges();
                #endregion
            }
            else if(auditState == AuditState.审核不通过.ToString())
            {
                #region 不通过
                model.TradeState =(int)TradeState.竞价中;

                db.SaveChanges();
                #endregion
            }
            else
            {
            }
                return Json(new {  Tips = "操作成功", Status = 1 });
            }
            catch (Exception ex)
            {
                return Json(new {  Tips = "操作失败", Status = 0 });
            }

            return null;
        }

        /// <summary>
        /// 首页显示
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxHomeShow()
        {
            string ticketID = System.Web.HttpContext.Current.Request.Form["TicketID"];
            TicketDiscount model = db.TicketDiscount.Where(t => t.TicketID == Convert.ToInt32(ticketID)).FirstOrDefault();


            try
            {
                UpdateModel(model);//修改模型必须在此之后
                model.AuditorName = "CCCCCCC";
                db.SaveChanges();
                return Json(new {  Tips = "操作成功",Status=1 });
            }
            catch (Exception ex)
            {
                return Json(new { Tips = "操作失败",Status=0 });
            }

            return null;
        }


        /// <summary>
        /// 计算年利率
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxCalRate()
        {
            string ticketID = System.Web.HttpContext.Current.Request.Form["TicketID"];
            string TicketEndTime = System.Web.HttpContext.Current.Request.Form["TicketEndTime"];
            TicketEndTime = Convert.ToDateTime(TicketEndTime).ToString("yyyy-MM-dd 23:59:59");
            TicketDiscount model = db.TicketDiscount.Where(t => t.TicketID == Convert.ToInt32(ticketID)).FirstOrDefault();
            try
            {
                //票面金额-成交价格=票面金额*(（年息/100）/360)*实际天数
                Decimal interest = (Decimal)(model.TicketPrice - model.BidPrice);//利息
                int resDayca = RestDays(Convert.ToDateTime(TicketEndTime));//实际天数
                Decimal ratca = resDayca <= 0 ? 0 : interest * 360 * 100 / (model.TicketPrice * resDayca);//例如3.17%
                string tips = ratca.ToString("N2").Replace(",", "");
                return Json(new { Tips = tips,Status=1 });
            }
            catch (Exception ex)
            {
                return Json(new { Tips = "操作失败", Status = 0 });
            }

            return null;
        }

        public string GetRandomNm()
        {
            string curtime = DateTime.Now.ToString("yyMMddHHmmssfff");
            Random ro = new Random();
            int randnm = ro.Next(10, 99);//返回二位随机数
            return curtime + randnm.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TicketEndTime"></param>
        /// <returns></returns>
        private int RestDays(Object TicketEndTime)
        {

            //return (TicketEndTime.Date - DateTime.Now.Date).Days + 1;
            if (TicketEndTime != null)
            {
                int r = 0;
                DateTime TicketEndDate = (DateTime)TicketEndTime;
                List<HolidayLibrary> list = new List<HolidayLibrary>();
                //List<HolidayLibraryEntity> list = BusinessFacade.HolidayLibraryList(new QueryParam(string.Format(
                //    "WHERE HolidayStart<='{0}' AND HolidayEnd>='{0}' ", ((DateTime)TicketEndDate).Date)), out r);
                list = (from hl in db.HolidayLibrary
                       where hl.HolidayStart <= ((DateTime)TicketEndDate).Date && hl.HolidayEnd >= ((DateTime)TicketEndDate).Date
                       select  hl).ToList();

                //判断是否处于法定假日（周末不算）
                if (list.Count > 0)
                {
                    TimeSpan span = list[0].HolidayEnd - DateTime.Now.Date;
                    return span.Days;
                }
                else
                {
                    int days = ((DateTime)TicketEndTime - DateTime.Now).Days;
                    //判断是否周末（忽略调休）
                    if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                        return days + 2;
                    if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                        return days + 1;
                    return days;
                }
            }
            else
                return -1;

        }

    }

    internal enum TradeState
    {
        /// <summary>
        /// 审核成功之后，汇票所处竞价中状态
        /// </summary>
        竞价中 = 1,

        /// <summary>
        /// 持票企业发起要约， 正在等待贴现机构确认要约
        /// </summary>
        确认要约 = 2,

        /// <summary>
        /// 贴现机构确认要约， 正在向持票企业打款
        /// </summary>
        支付冻结 = 4,

        /// <summary>
        /// 贴现机构打款结束，资金被冻结， 正在等待持票企业背书
        /// </summary>
        持票企业背书 = 8,

        /// <summary>
        /// 持票企业背书完成，正在等待贴现机构签约解冻
        /// </summary>
        签收解冻 = 16,

        /// <summary>
        /// 流程成功，交易已经完成
        /// </summary>
        交易完成 = 32,

        /// <summary>
        /// 流程失败，管理员关闭交易或者用户自主关闭交易
        /// </summary>
        中止交易 = 64,
        /// <summary>
        /// 
        /// </summary>
        预约竞价 = 128,

        /// <summary>
        /// 持票企业发起要约
        /// </summary>
        发起要约 = 256,

        /// <summary>
        /// 所有汇票交易状态
        /// </summary>
        所有状态 = 预约竞价 | 竞价中 | 发起要约 | 确认要约 | 支付冻结 | 持票企业背书 | 签收解冻 | 交易完成 | 中止交易
    }

    internal enum AuditState
    {
        待审核 = 1,

        审核通过 = 2,

        审核不通过 = 4
    }
}