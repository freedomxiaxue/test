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
    public class ShowUserController : Controller
    {
        // GET: ShowUserList
        public ActionResult ShowUserList()
        {
            return View();
        }

        tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();
             
        public ActionResult SUserListPartial()
        {

            var model = from cu in db.ClientUser
                        join uc in db.UserCenter on cu.ID equals uc.ID
                        orderby uc.RegisterTime descending
                        select new {cu.ID,cu.UserName,cu.FullName,cu.Name,cu.Avatar,cu.RegisterType,cu.ProvinceID,
                        cu.CityID,cu.DistrictID,cu.Telephone,cu.Address,cu.NameOfPIC,cu.PositionOfPIC,cu.QQOfPIC,
                            cu.Zip,cu.Fax,cu.ALTakerLevel,cu.ALBearerLevel,cu.ALAdvantage,cu.ALNote,uc.Phone,
                            uc.Email,uc.RegisterTime,uc.LastLoginTime,cu.Identor,cu.IsAgency};
            return PartialView("_SUserListPartial", model.ToList());
        }

        
        public ActionResult UPageControlPartial(int key)
        {
            ViewData["key"] = key;
            //var model = from cu in db.ClientUser
            //            join uc in db.UserCenter on cu.ID equals uc.ID
            //            where cu.ID == key
            //            orderby uc.RegisterTime descending
            //            select new {cu.ID,cu.UserName,cu.FullName,cu.Name,cu.Avatar,cu.RegisterType,cu.ProvinceID,
            //            cu.CityID,cu.DistrictID,cu.Telephone,cu.Address,cu.NameOfPIC,cu.PositionOfPIC,cu.QQOfPIC,
            //                cu.Zip,cu.Fax,cu.ALTakerLevel,cu.ALBearerLevel,cu.ALAdvantage,cu.ALNote,uc.Phone,
            //                uc.Email,uc.RegisterTime,uc.LastLoginTime,cu.Identor,cu.IsAgency};
            return PartialView("UDetailPageControl");
        }
        
        public ActionResult UProductsGridViewPartial(int key)
        {
            var model = from cu in db.ClientUser
                        join uc in db.UserCenter on cu.ID equals uc.ID
                        where cu.ID == key
                        orderby uc.RegisterTime descending
                        select new { cu.ID, cu.UserName, cu.FullName, cu.Name, cu.Avatar, cu.RegisterType, cu.ProvinceID,
                            cu.CityID, cu.DistrictID, cu.Telephone, cu.Address, cu.NameOfPIC, cu.PositionOfPIC, cu.QQOfPIC,
                            cu.Zip, cu.Fax, cu.ALTakerLevel, cu.ALBearerLevel, cu.ALAdvantage, cu.ALNote, uc.Phone,
                            uc.Email, uc.RegisterTime, uc.LastLoginTime, cu.Identor, cu.IsAgency };
            ClientUserCenter cmodel = new ClientUserCenter()
            {
                ID = model.FirstOrDefault().ID,
                Address = model.FirstOrDefault().Address,
                ALAdvantage = model.FirstOrDefault().ALAdvantage,
                ALBearerLevel = model.FirstOrDefault().ALBearerLevel,
                ALNote = model.FirstOrDefault().ALNote,
                ALTakerLevel = model.FirstOrDefault().ALTakerLevel,
                Avatar = model.FirstOrDefault().Avatar,
                CityID = model.FirstOrDefault().CityID,
                DistrictID = model.FirstOrDefault().DistrictID,
                Email = model.FirstOrDefault().Email,
                Fax = model.FirstOrDefault().Fax,
                FullName = model.FirstOrDefault().FullName,
                Identor = model.FirstOrDefault().Identor,
                IsAgency = model.FirstOrDefault().IsAgency,
                LastLoginTime = model.FirstOrDefault().LastLoginTime,
                Name = model.FirstOrDefault().Name,
                NameOfPIC = model.FirstOrDefault().NameOfPIC,
                Phone = model.FirstOrDefault().Phone,
                PositionOfPIC = model.FirstOrDefault().PositionOfPIC,
                ProvinceID = model.FirstOrDefault().ProvinceID,
                QQOfPIC = model.FirstOrDefault().QQOfPIC,
                RegisterTime = model.FirstOrDefault().RegisterTime,
                RegisterType = model.FirstOrDefault().RegisterType,
                Telephone = model.FirstOrDefault().Telephone,
                UserName = model.FirstOrDefault().UserName,
                Zip = model.FirstOrDefault().Zip
            };
            ViewData["key"] = key;
            ViewData["ALBearerLevellist"] = VMShowUsers.ALBearerLevellist();
            ViewData["ALTakerLevellist"] = VMShowUsers.ALTakerLevellist();
            ViewData["IsAgencylist"] = VMShowUsers.IsAgencylist();
            ViewData["Identorlist"] = VMShowUsers.Identorlist();
            ViewData["UGetAllProvince"] = VMShowUsers.UGetAllProvince();
            ViewData["UGetCitysByProvinceName"] = VMShowUsers.UGetCitysByProvinceName(cmodel.ProvinceID);
            return PartialView("_UProductsGridViewPartial", cmodel);
        }

        public JsonResult GetProvincelist()
        {
            return Json(VMShowUsers.UGetAllProvince(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCitylist(string pid)
        {
            return Json(VMShowUsers.UGetCitysByProvinceName(pid), JsonRequestBehavior.AllowGet);
        }




        }
}