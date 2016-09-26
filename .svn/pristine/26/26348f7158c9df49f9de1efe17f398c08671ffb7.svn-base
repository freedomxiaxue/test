using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Collections;
using tcpjw3.oa.Models;
using tcpjw3.oa.Models.ViewModel;
using tcpjw3.oa.Code;
using System.IO;
using System.Web.Script.Serialization;

namespace tcpjw3.oa.Controllers
{
    /// <summary>
    /// 竞价管理控制器
    /// 最好能够包含定向交易
    /// </summary>
    public class DiscountController : Controller
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
                         where discount.UploadChannel.Equals(0) || discount.UploadChannel.Equals(1)
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

        public ActionResult PersonInformation(int userID)
        {
            ViewData["userID"] = userID;
            //var model = db.ClientUser.Where(item => item.ID == userID).FirstOrDefault();

            #region MyRegion
            var query = (from cu in db.ClientUser
                         join uc in db.UserCenter on cu.ID equals uc.ID
                         join pro in db.SysStatic on cu.ProvinceID equals pro.Value.ToString()
                         join city in db.SysStatic on cu.CityID equals city.Value.ToString()
                         where uc.ID.Equals(userID)
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

            PersonInfo personInfo = new PersonInfo();
            personInfo.ID = userID;
            personInfo.CityName = query.CityName;
            personInfo.ProvinceName = query.ProvinceName;
            personInfo.Avatar = query.Avatar;
            personInfo.FullName = query.FullName;
            personInfo.Name = query.Name;
            personInfo.NameOfPIC = query.NameOfPIC;
            personInfo.Address = query.Address;
            personInfo.RegisterTime = query.RegisterTime.ToString("yyyy-MM-dd:HH:mm:ss");
            personInfo.LastLoginTime = query.LastLoginTime == null ? "" : ((DateTime)query.LastLoginTime).ToString("yyyy-MM-dd:HH:mm:ss");
            personInfo.Phone = query.Phone;

            string strArea = string.Empty;
            if (!string.IsNullOrEmpty(personInfo.ProvinceName))
            { strArea += personInfo.ProvinceName; }
            if (!string.IsNullOrEmpty(personInfo.CityName))
            { strArea += personInfo.CityName; }
            personInfo.CityProName = strArea;
            #endregion
            return PartialView("PersonInformation", personInfo);

        }



        public ActionResult TicketInformation(int ticketId)
        {

            ViewData["key"] = ticketId;
            var ticketDiscount = db.TicketDiscount.Where(item => item.TicketID == ticketId).FirstOrDefault();
            ticketDiscount.TicketFaceImg= ticketDiscount.TicketFaceImg+ "?v=" + DateTime.Now.ToString("ssfff");
            ticketDiscount.TicketBackImg = ticketDiscount.TicketBackImg + "?v=" + DateTime.Now.ToString("ssfff");
            //var viewDisBidList = db.viewDiscountBidding.Where(item => item.TicketID == ticketId).ToList();

            var viewDisBidList = (from viewDb in db.viewDiscountBidding
                        join pro in db.SysStatic on viewDb.ProvinceID equals pro.Value.ToString()
                        join city in db.SysStatic on viewDb.CityID equals city.Value.ToString()
                                  where viewDb.TicketID.Equals(ticketId)
                                  select new viewDiscountBidding
                        {
                            #region MyRegion
                            TicketID = viewDb.TicketID,
                            BidUserID = viewDb.BidUserID,
                            BidPrice = viewDb.BidPrice,
                            BidRate = viewDb.BidRate,
                            BidTime = viewDb.BidTime,
                            LastEditTime = viewDb.LastEditTime,
                            BidResult = viewDb.BidResult,
                            BidResultNote = viewDb.BidResultNote,
                            LoginMode = viewDb.LoginMode,
                            Phone = viewDb.Phone,
                            Name = viewDb.Name,
                            ProvinceID = pro.Text,
                            CityID = city.Text,
                            #endregion
                        }).Distinct().ToList();

            var ticketPush = db.TicketPush.Where(item => item.TicketID == ticketId).ToList();
            var discountBinding = db.DiscountBidding.Where(item => item.TicketID == ticketId).ToList();
            TicketInfo ticketInfo = new TicketInfo();
            ticketInfo.ticketDiscount = ticketDiscount;
            ticketInfo.viewDisBidList = viewDisBidList;
            ticketInfo.TicketPushCount = ticketPush.Count.ToString();
            ticketInfo.QuoteCount = discountBinding.Count.ToString();
            return PartialView("TicketInformation", ticketInfo);

        }

        public ActionResult TicketFaceImgInformation(int ticketId)
        {
            //if (ticketId == null) return PartialView("DetailPageControl", new TicketDiscount());
            ViewData["key"] = ticketId;
            var model = db.TicketDiscount.Where(item => item.TicketID == ticketId).FirstOrDefault();
            model.TicketFaceImg = model.TicketFaceImg + "?v=" + DateTime.Now.ToString("ssfff");
            return PartialView("TicketFaceImgInformation", model);

        }


        public ActionResult TicketBackImgInformation(int ticketId)
        {
            //if (ticketId == null) return PartialView("DetailPageControl", new TicketDiscount());
            ViewData["key"] = ticketId;
            var model = db.TicketDiscount.Where(item => item.TicketID == ticketId).FirstOrDefault();
            model.TicketBackImg = model.TicketBackImg + "?v=" + DateTime.Now.ToString("ssfff");
            return PartialView("TicketBackImgInformation", model);

        }


        public ActionResult DiscountTicketInformation(int ticketId)
        {
            //if (ticketId == null) return PartialView("DetailPageControl", new TicketDiscount());
            ViewData["key"] = ticketId;
            var model = db.TicketDiscount.Where(item => item.TicketID == ticketId).FirstOrDefault();
            ViewData["Pro"] = StaticDictiory.GetProDataSource();
            ViewData["City"] = StaticDictiory.GetCityDataSource(model.ProvinceID);
            ViewData["Bank"] = StaticDictiory.GetBankDataSource(model.BankType);
            return PartialView("DiscountTicketInformation", model);

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
                        modelItem.TermType = StaticDictiory.getTerm((int)modelItem.TicketType,(int) modelItem.TicketCategory, Convert.ToDateTime(Convert.ToDateTime(modelItem.PublishTime).ToString("yyyy-MM-dd 23:59:59")));
                        modelItem.TicketEndTime = Convert.ToDateTime(Convert.ToDateTime(modelItem.TicketEndTime).ToString("yyyy-MM-dd 23:59:59"));
                        modelItem.AuditTime = DateTime.Now;
                        modelItem.AuditorID = 0;
                        modelItem.AuditorName = "管理员";
                        #region 审核通过
                        if (item.AuditState ==(int)AuditState.审核通过)
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
                                    #region 给上传汇票的用户发送审核通过提醒

                                    #endregion

                                    #region 推送实体
                                    if (cbPush=="C")
                                    {
                                        agentList = db.viewUserDetail.ToList();

                                        foreach(viewUserDetail agent in agentList)
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
                                            push.TicketEndTime =(DateTime) modelItem.TicketEndTime;
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
                            foreach( TicketPush push in pushList)
                            {
                                pushModel.Add(push);
                            }
                            #endregion
                        }
                        #endregion
                        #region 审核不通过
                        else if (item.AuditState ==(int)AuditState.审核不通过 )
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
                             where discount.UploadChannel.Equals(0) || discount.UploadChannel.Equals(1)
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
                             where discount.UploadChannel.Equals(0) || discount.UploadChannel.Equals(1)
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

        [HttpPost, ValidateInput(false)]
        public ActionResult IndexPartialAddNew(tcpjw3.oa.Models.TicketDiscount item)
        {


            var model = db.TicketDiscount;
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
            return PartialView("_MasterGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult IndexPartialDelete(System.Int32 TicketID)
        {
            var model = db.TicketDiscount;
            if (TicketID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.TicketID == TicketID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_MasterGridViewPartial", model);
        }


        public ActionResult AjaxCityCombox(string proID)
        {
            ViewData["City"] = StaticDictiory.GetCityDataSource(proID);
            return PartialView(StaticDictiory.GetCityDataSource(proID));
        }
        public ActionResult AjaxBankCombox(int? ticketType)
        {
            ViewData["Bank"] = StaticDictiory.GetBankDataSource(ticketType);
            return PartialView(StaticDictiory.GetBankDataSource(ticketType));
        }

        [HttpPost]
        public ActionResult AjaxDcmosaics()
        {
            //string imagurl = url;
            //string rect = rects;
            string pstr = System.Web.HttpContext.Current.Request.Form["Param"];
            JavaScriptSerializer s = new JavaScriptSerializer(); //继承自 System.Web.Script.Serialization;
            JsonRequest jr = s.Deserialize<JsonRequest>(pstr); //只要你的JSON串没问题就可以转

            try
            {
                System.Drawing.Bitmap bmp = StaticDictiory.MosaicBitmap(
                jr.url,
                jr.rects.ConvertAll<MosaicsRect>(new Converter<MosaicsRect, MosaicsRect>(StaticDictiory.convertFromAPIMosaicsRect)));

                Uri uri = new Uri(jr.url);
                //string serverPath = System.Web.HttpContext.Current.Server.MapPath(uri.AbsolutePath);
                string serverPath = _root + uri.AbsolutePath;
                string directory = string.Empty;
                string directoryPath = string.Empty;
                for (int i = 0; i < uri.Segments.Length - 1; i++)
                    directory += uri.Segments[i];
                //directoryPath = System.Web.HttpContext.Current.Server.MapPath(directory);
                directoryPath = _root + directory;
                if (!System.IO.Directory.Exists(directoryPath)) System.IO.Directory.CreateDirectory(directoryPath);
                bmp.Save(serverPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                return Json(new { success = true, Message = "成功！！" });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, Message = "失败！！" });
            }

            return null;
        }

        /// <summary>
        /// Json
        /// </summary>
        public class JsonRequest
        {
            public string url { get; set; }
            public List<MosaicsRect> rects { get; set; }
        }


        [HttpPost]
        public ActionResult AjaxDcrotate()
        {
            //string imagurl = url;
            //string rect = rects;
            string url = System.Web.HttpContext.Current.Request.Form["url"];
            string degree= System.Web.HttpContext.Current.Request.Form["degree"];


            try
            {
                System.Drawing.Bitmap bmp = StaticDictiory.RotateBitmap(url, Convert.ToInt32( degree));
                Uri uri = new Uri(url);
                //string serverPath = System.Web.HttpContext.Current.Server.MapPath(uri.AbsolutePath);
                string serverPath = _root + uri.AbsolutePath;
                string directory = string.Empty;
                string directoryPath = string.Empty;
                for (int i = 0; i < uri.Segments.Length - 1; i++)
                    directory += uri.Segments[i];
                //directoryPath = System.Web.HttpContext.Current.Server.MapPath(directory);
                directoryPath = _root + directory;
                if (!System.IO.Directory.Exists(directoryPath)) System.IO.Directory.CreateDirectory(directoryPath);
                bmp.Save(serverPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                return Json(new { success = true, Message = "成功！！" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Message = "失败！！" });
            }

            return null;
        }

        public ActionResult TicketFaceUpload()
        {
            UploadControlExtension.GetUploadedFiles("TicketFace", DiscountControllerTicketFaceSettings.UploadValidationSettings, DiscountControllerTicketFaceSettings.FileUploadComplete);
            return null;
        }

        public ActionResult ticketBackUpload()
        {
            UploadControlExtension.GetUploadedFiles("ticketBack", DiscountControllerticketBackSettings.UploadValidationSettings, DiscountControllerticketBackSettings.FileUploadComplete);
            return null;
        }
    }
    public class DiscountControllerticketBackSettings
    {
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg" },
            MaxFileSize = 4000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            MVCxUploadControl upControl = sender as MVCxUploadControl;
            int ticketId = Convert.ToInt32(upControl.Request.Params["ticketID"]);

            if (e.UploadedFile.IsValid)
            {
                tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();
                TicketDiscount ticketDiscount = db.TicketDiscount.Where(t => t.TicketID == ticketId).FirstOrDefault();

                string filePath = ticketDiscount.TicketBackImg;
                Uri uri = new Uri(filePath);

                //var fileName = Path.Combine(upControl.Request.MapPath("~/"), uri.AbsolutePath);
                //var fileName = upControl.Request.MapPath("~/")+uri.AbsolutePath;
                var fileName = "E:\\TCPJW_Developer\\Code\\TCPJW.OA" + uri.AbsolutePath;//路径先这样写
                e.UploadedFile.SaveAs(fileName);
                //e.UploadedFile.SaveAs(Server.MapPath("~/") + uri.AbsolutePath);
                e.CallbackData = ticketDiscount.TicketBackImg;
            }
        }
    }

    public class DiscountControllerTicketFaceSettings
    {
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg" },
            MaxFileSize = 4000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            //
            MVCxUploadControl upControl = sender as MVCxUploadControl;
            int ticketId = Convert.ToInt32(upControl.Request.Params["ticketID"]);

            if (e.UploadedFile.IsValid)
            {
                // Save uploaded file to some location
                tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();
                TicketDiscount ticketDiscount = db.TicketDiscount.Where(t => t.TicketID == ticketId).FirstOrDefault();

                string filePath = ticketDiscount.TicketFaceImg;
                Uri uri = new Uri(filePath);

                //var fileName = Path.Combine(upControl.Request.MapPath("~/"), uri.AbsolutePath);
                //var fileName = upControl.Request.MapPath("~/")+uri.AbsolutePath;
                var fileName = "E:\\TCPJW_Developer\\Code\\TCPJW.OA" + uri.AbsolutePath;//路径先这样写
                e.UploadedFile.SaveAs(fileName);
                //e.UploadedFile.SaveAs(Server.MapPath("~/") + uri.AbsolutePath);
                e.CallbackData = ticketDiscount.TicketFaceImg;
            }
        }
    }

}