using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcpjw3.oa.Models.ViewModel
{
    #region MyRegion
    public class PersonInfo
    {
        public int ID { get; set; }
        public string Avatar { get; set; }
        public string CityName { get; set; }
        public string ProvinceName { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string NameOfPIC { get; set; }
        public string Address { get; set; }
        public string RegisterTime { get; set; }
        public string LastLoginTime { get; set; }
        public string Phone { get; set; }

        public string CityProName { get; set; }
    }
    #endregion
}