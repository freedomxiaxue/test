using DevExpress.DataAccess.Native.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcpjw3.oa.Models;

namespace tcpjw3.oa.ViewModels
{
    public class VMShowUsers
    {
        private static tcpjwEntities tdb = new tcpjwEntities();

        /// <summary>
        /// 贴现机构等级
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> ALBearerLevellist()
        {
            List<SelectListItem> hourList = new List<SelectListItem>();
            hourList.Add(new SelectListItem { Text = "V1", Value = "0" });
            hourList.Add(new SelectListItem { Text = "V2", Value = "1" });
            hourList.Add(new SelectListItem { Text = "V3", Value = "2" });
            hourList.Add(new SelectListItem { Text = "V4", Value = "3" });
            return hourList;
        }

        /// <summary>
        /// 持票企业等级
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> ALTakerLevellist()
        {
            List<SelectListItem> hourList = new List<SelectListItem>();
            hourList.Add(new SelectListItem { Text = "C1", Value = "0" });
            hourList.Add(new SelectListItem { Text = "C2", Value = "1" });
            hourList.Add(new SelectListItem { Text = "C3", Value = "2" });
            hourList.Add(new SelectListItem { Text = "C4", Value = "3" });
            return hourList;
        }
        /// <summary>
        /// 是否中介
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> IsAgencylist()
        {
            List<SelectListItem> hourList = new List<SelectListItem>();
            hourList.Add(new SelectListItem { Text = "否", Value = "0" });
            hourList.Add(new SelectListItem { Text = "是", Value = "1" });
            return hourList;
        }

        // <summary>
        /// 认定的贴现机构
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Identorlist()
        {
            List<SelectListItem> hourList = new List<SelectListItem>();
            hourList.Add(new SelectListItem { Text = "否", Value = "0" });
            hourList.Add(new SelectListItem { Text = "是", Value = "1" });
            return hourList;
        }

        //获取省份列表
        private static List<SysStatic> UGetProvinces()
        {
            return UGetNodes("administrative_regions");
        }
        public static List<SelectListItem> UGetAllProvince()
        {
            List<SelectListItem> treelist = new List<SelectListItem>();
            foreach (var ssitem in UGetProvinces())
            {
                treelist.Add(new SelectListItem { Text=ssitem.Text,Value=ssitem.Value.ToString()});
            }
            return treelist;
        }
        //根据省份获取城市
        private static List<SysStatic> UGetCitys(string provincename)
        {
            return UGetNodes(provincename);
        }
        public static List<SelectListItem> UGetCitysByProvinceName(string provincename)
        {
            List<SelectListItem> treelist = new List<SelectListItem>();
            foreach (var ssitem in UGetCitys(provincename))
            {
                treelist.Add(new SelectListItem { Text = ssitem.Text, Value = ssitem.Value.ToString() });
            }
            return treelist;
        }

        /// <summary>
        /// 根据父级值获取所有节点
        /// </summary>
        /// <param name="parentId">父级编号</param>
        /// <returns>节点列表</returns>
        public static List<SysStatic> UGetNodes(string parentValue)
        {
            var sysstaticlist = tdb.SysStatic.Where(ss=>(from s in tdb.SysStatic where s.Value.Equals(parentValue) select s.ID).Contains<int>((int)ss.PID));
            List<SysStatic> sslist = new List<SysStatic>();
            foreach (var item in sysstaticlist.ToList())
            {
                SysStatic ssmodel = new SysStatic() { ID=item.ID,IsRoot=item.IsRoot,Note=item.Note,PID=item.PID,Sort=item.Sort,Text=item.Text,Value=item.Value};
                sslist.Add(ssmodel);
            }
            return sslist;
        }
        

    }
}