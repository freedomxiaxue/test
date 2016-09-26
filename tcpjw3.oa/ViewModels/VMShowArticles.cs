using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcpjw3.oa.Models;

namespace tcpjw3.oa.ViewModels
{
    public class VMShowArticles
    {

        private static tcpjwEntities tdb = new tcpjwEntities();
        public static List<SelectListItem> AGetClassName()
        {
            List<SelectListItem> treelist = new List<SelectListItem>();
            List<SysStatic> plist = VMShowUsers.UGetNodes("newslist");
            foreach (var pitem in plist)
            {
                treelist.Add(new SelectListItem { Text = pitem.Text, Value = pitem.Value.ToString() });
                List<SysStatic> childlist = VMShowUsers.UGetNodes(pitem.Value.ToString()); 
                foreach (var childitem in childlist)
                {
                    treelist.Add(new SelectListItem { Text = "├ " + childitem.Text, Value = childitem.Value.ToString() });
                }
            }
            return treelist;
        }

        

        
    }
}