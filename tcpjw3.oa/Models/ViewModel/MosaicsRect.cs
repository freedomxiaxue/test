using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tcpjw3.oa.Models.ViewModel
{
    public class MosaicsRect
    {
        /// <summary>
        /// 区域的开始坐标点
        /// </summary>
        public MosaicsPoint start { get; set; }

        /// <summary>
        /// 区域的结束坐标点
        /// </summary>
        public MosaicsPoint end { get; set; }
    }


    /// <summary>
    /// 马赛克坐标点
    /// </summary>
    public class MosaicsPoint
    {
        /// <summary>
        /// 点坐标X
        /// </summary>
        public int x { get; set; }

        /// <summary>
        /// 点坐标Y
        /// </summary>
        public int y { get; set; }
    }
}