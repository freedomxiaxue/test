using DevExpress.Web;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcpjw3.oa.Models;
using tcpjw3.oa.ViewModels;

namespace tcpjw3.oa.Controllers
{
    public class ShowArticleController : Controller
    {
        // GET: ShowArticle
        public ActionResult ShowArticleList()
        {
            return View();
        }

        tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();

        [ValidateInput(false)]
        public ActionResult ShowAritclesGVPartial()
        {
            var model = db.NewsList.OrderByDescending(n=>n.ID);
            return PartialView("_ShowAritclesGVPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ShowAritclesGVPartialAddNew(tcpjw3.oa.Models.NewsList item)
        {
            var model = db.NewsList;
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
            return PartialView("_ShowAritclesGVPartial", model.ToList());
        }


        [HttpGet]
        public ActionResult ShowAritclesGVPartialUpdate(int newId)
        {
            var nmodel = (from n in db.NewsList where n.ID.Equals(newId) select n).FirstOrDefault();
            NewsList newslist = new NewsList();
            if (newslist == null)
                newslist.ID = -1;
            else
                newslist = nmodel as NewsList;

            ViewData["AGetClassName"] = new SelectList(VMShowArticles.AGetClassName(), "Value", "Text", newslist.Classname);   //VMShowArticles.AGetClassName();//new SelectList(VMShowUsers.UGetNodes("newslist"),"Value","Text",newslist.Classname);  
            return PartialView("_ShowAritclesGVPartialUpdate", newslist);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ShowAritclesGVPartialUpdate(tcpjw3.oa.Models.NewsList item)
        {
            var model = db.NewsList;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
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
            return PartialView("_ShowAritclesGVPartialUpdate", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ShowAritclesGVPartialDelete(System.Int32 ID)
        {
            var model = db.NewsList;
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_ShowAritclesGVPartial", model.ToList());
        }



        public ActionResult ArticleHEPartial()
        {
            return PartialView("_ArticleHEPartial");
        }
        public ActionResult ArticleHEPartialImageSelectorUpload()
        {
            HtmlEditorExtension.SaveUploadedImage("ArticleHE", ShowArticleControllerArticleHESettings.ImageSelectorSettings);
            return null;
        }
        public ActionResult ArticleHEPartialImageUpload()
        {
            HtmlEditorExtension.SaveUploadedFile("ArticleHE", ShowArticleControllerArticleHESettings.ImageUploadValidationSettings, ShowArticleControllerArticleHESettings.ImageUploadDirectory);
            return null;
        }
    }
    public class ShowArticleControllerArticleHESettings
    {
        public const string ImageUploadDirectory = "~/Content/UploadImages/";
        public const string ImageSelectorThumbnailDirectory = "~/Content/Thumb/";

        public static DevExpress.Web.UploadControlValidationSettings ImageUploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".png" },
            MaxFileSize = 4000000
        };

        static DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings imageSelectorSettings;
        public static DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings ImageSelectorSettings
        {
            get
            {
                if (imageSelectorSettings == null)
                {
                    imageSelectorSettings = new DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings(null);
                    imageSelectorSettings.Enabled = true;
                    imageSelectorSettings.UploadCallbackRouteValues = new { Controller = "ShowArticle", Action = "ArticleHEPartialImageSelectorUpload" };
                    imageSelectorSettings.CommonSettings.RootFolder = ImageUploadDirectory;
                    imageSelectorSettings.CommonSettings.ThumbnailFolder = ImageSelectorThumbnailDirectory;
                    imageSelectorSettings.CommonSettings.AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif" };
                    imageSelectorSettings.UploadSettings.Enabled = true;
                }
                return imageSelectorSettings;
            }
        }
    }

}