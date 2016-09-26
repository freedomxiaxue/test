using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using tcpjw3.oa.Models.ViewModel;

namespace tcpjw3.oa.Code
{
    public static class StaticDictiory
    {
        private static string _root = "E:\\TCPJW_Developer\\Code\\TCPJW.OA\\ImageServer";// SysStatic.GetNoStaticNode("imageServer").Text;

        /// <summary>
        /// 省
        /// </summary>
        /// <returns></returns>
        public static List<StaticEntity> GetProDataSource()
        {
            tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();
            List<StaticEntity> list = new List<StaticEntity>();
            var query = (from sysParent in db.SysStatic
                        join sysChild in db.SysStatic on sysParent.ID equals sysChild.PID
                        where sysParent.Value.Equals("administrative_regions")
                        select sysChild).Distinct();

            foreach(var item in query)
            {
                StaticEntity entity = new StaticEntity();
                entity.Text = item.Text;
                entity.Value = item.Value;
                list.Add(entity);
            }
            return list;

        }


        /// <summary>
        /// 城市
        /// </summary>
        /// <returns></returns>
        public static List<StaticEntity> GetCityDataSource(string parentValue)
        {
            tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();
            List<StaticEntity> list = new List<StaticEntity>();
            if (string.IsNullOrEmpty(parentValue))
            {
                return list;
            }
            var query = (from sysParent in db.SysStatic
                         join sysChild in db.SysStatic on sysParent.ID equals sysChild.PID
                         where sysParent.Value.Equals(parentValue)
                         select sysChild).Distinct();

            foreach (var item in query)
            {
                StaticEntity entity = new StaticEntity();
                entity.Text = item.Text;
                entity.Value = item.Value;
                list.Add(entity);
            }
            return list;

        }


        /// <summary>
        /// Bank
        /// </summary>
        /// <returns></returns>
        public static List<StaticEntity> GetBankDataSource(int? TicketType)
        {
            List<StaticEntity> list = new List<StaticEntity>();
            if(TicketType==1||TicketType==2)
            {
                list.Add(new StaticEntity { Text = "国股银行", Value = "1" });
                list.Add(new StaticEntity { Text = "大型城商行", Value = "2" });
                list.Add(new StaticEntity { Text = "小型城商行", Value = "4" });
                list.Add(new StaticEntity { Text = "其他", Value = "8" });
            }
            else
            {
                list.Add(new StaticEntity { Text = "央企", Value = "1" });
                list.Add(new StaticEntity { Text = "国企", Value = "2" });
                list.Add(new StaticEntity { Text = "上市", Value = "4" });
                list.Add(new StaticEntity { Text = "地方", Value = "8" });

            }

            return list;

        }


        /// <summary>
        /// 获取汇票金额类型
        /// </summary>
        /// <param name="type">汇票类型</param>
        /// <param name="price">汇票金额</param>
        /// <returns></returns>
        public static int getCategory(int type, decimal price)
        {
            int category = 0;
            if (type == 1 || type == 2)
            {
                // 银纸
                if (price >= 5000000)
                    // 票面金额大于等于500W，属于大额
                    category = (int)TicketCategories.大票;
                else
                    // 票面金额小于500W， 属于小额
                    category = (int)TicketCategories.小票;
            }
            return category;
        }

        public enum TicketCategories
        {
            大票 = 1,
            小票 = 2
        }


        /// <summary>
        /// 回去汇票期限类型
        /// </summary>
        /// <param name="type">汇票类型</param>
        /// <param name="category">汇票金额类型</param>
        /// <param name="restDays">剩余天数</param>
        /// <returns></returns>
        public static int getTerm(int type, int category, int restDays)
        {
            int term = 1;
            // 期限判断
            if (type == 1)
            // 银纸
            {
                if (category == (int)TicketCategories.大票)
                // 大票
                {
                    if (restDays >= 180)
                        // 足月
                        term = 1;
                    else if (restDays < 180)
                        // 不足月
                        term = 2;
                }
                else if (category == (int)TicketCategories.小票)
                {
                    // 小票
                    if (restDays > 90)
                        // 长票
                        term = 1;
                    else if (restDays <= 90)
                        // 短票
                        term = 2;
                }
            }
            else if (type == 2)
            // 银电
            {
                if (category == (int)TicketCategories.大票)
                // 大票
                {
                    if (restDays >= 360)
                        // 足月一年期
                        term = 1;
                    else if (restDays > 190 && restDays < 360)
                        // 不足月一年期
                        term = 2;
                    else if (restDays >= 180 && restDays <= 190)
                        // 足月半年期
                        term = 4;
                    else if (restDays >= 1 && restDays < 180)
                        // 不足月半年期
                        term = 8;
                }
                else if (category == (int)TicketCategories.小票)
                // 小票
                {
                    if (restDays >= 1 && restDays <= 90)
                        // 1-3个月
                        term = 1;
                    else if (restDays >= 91 && restDays <= 190)
                        // 4-6个月
                        term = 2;
                    else if (restDays >= 191 && restDays <= 270)
                        // 7-9个月
                        term = 4;
                    else if (restDays >= 271 && restDays <= 370)
                        // 10-12个月
                        term = 8;
                }
            }
            else if (type == 4)
            {
                // 商纸
                if (restDays >= 180)
                    // 足月
                    term = 1;
                else if (restDays < 180)
                    // 不足月
                    term = 2;
            }
            else if (type == 8)
            {
                // 商电
                if (restDays >= 360)
                    // 足月一年期
                    term = 1;
                else if (restDays > 190 && restDays < 360)
                    // 不足月一年期
                    term = 2;
                else if (restDays >= 180 && restDays <= 190)
                    // 足月半年期
                    term = 4;
                else if (restDays >= 1 && restDays < 180)
                    // 不足月半年期
                    term = 8;
            }
            return term;
        }


        /// <summary>
        /// 回去汇票期限类型
        /// </summary>
        /// <param name="type">汇票类型</param>
        /// <param name="category">汇票金额类型</param>
        /// <param name="ticketEndTime">汇票到期日</param>
        /// <returns></returns>
        public static int getTerm(int type, int category, DateTime ticketEndTime)
        {
            int restDays = (ticketEndTime.Date - DateTime.Now.Date).Days + 1;
            return getTerm(type, category, restDays);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MosaicsRect convertFromAPIMosaicsRect(MosaicsRect entity)
        {
           MosaicsRect rect = new MosaicsRect()
            {
                start = new MosaicsPoint()
                {
                    x = entity.start.x,
                    y = entity.start.y
                },
                end = new MosaicsPoint()
                {
                    x = entity.end.x,
                    y = entity.end.y
                }
            };

            return rect;
        }


        /// <summary>
        /// 图片马赛克
        /// </summary>
        /// <param name="ypath">原图片路径</param>
        /// <param name="Mosaiclist">坐标集合</param>
        /// <returns>马赛克后图片对象</returns>
        public static Bitmap MosaicBitmap(string ypath, List<MosaicsRect> Mosaiclist)
        {
            //原图，以文件流读取进行处理
            WebClient wc = new WebClient();
            Stream streambmp = wc.OpenRead(ypath);
            Bitmap bmp = new Bitmap(streambmp);
            string savePath = _root + string.Format("\\web\\origin\\{0}\\", DateTime.Now.Date.ToString("yyyyMMdd"));
            string filename = DateTime.Now.ToString("HHmmssfff") + new Random(DateTime.Now.Millisecond).Next(9999999).ToString() + ".jpg";
            // 保存原图
            if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);
            bmp.Save(savePath + filename, ImageFormat.Jpeg);
            try
            {

                const int N = 20;    //效果粒度，值越大码越严重
                int r = 0, g = 0, b = 0;
                Color c;
                for (int i = 0; i < Mosaiclist.Count; i++)
                {
                    for (int y = Mosaiclist[i].start.y; y < Mosaiclist[i].end.y; y++)
                    {
                        for (int x = Mosaiclist[i].start.x; x < Mosaiclist[i].end.x; x++)
                        {
                            if (y % N == 0)
                            {
                                if (x % N == 0)//整数倍时，取像素赋值
                                {
                                    c = bmp.GetPixel(x, y);
                                    r = c.R;
                                    g = c.G;
                                    b = c.B;
                                }
                                else
                                {
                                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                                }
                            }
                            else //复制上一行
                            {
                                Color colorPreLine = bmp.GetPixel(x, y - 1);
                                bmp.SetPixel(x, y, colorPreLine);

                            }
                        }
                    }
                }
                return bmp;
            }
            catch(Exception ex)
            {
                //throw new MosaicBitmapException();
                throw ex;
            }
        }

        #region 
        /// <summary>
        /// 图片旋转
        /// </summary>
        /// <param name="ypath"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Bitmap RotateBitmap(string ypath, int degree)
        {
            //原图，以文件流读取进行处理
            WebClient wc = new WebClient();
            Stream streambmp = wc.OpenRead(ypath);
            Bitmap bmp = new Bitmap(streambmp);
            int w = bmp.Width + 2;
            int h = bmp.Height + 2;
            PixelFormat pf;
            Color bkColor = Color.Transparent;
            if (bkColor == Color.Transparent)
            {
                pf = PixelFormat.Format32bppArgb;
            }
            else
            {
                pf = bmp.PixelFormat;
            }
            Bitmap tmp = new Bitmap(w, h, pf);
            Graphics g = Graphics.FromImage(tmp);
            g.Clear(bkColor);
            g.DrawImageUnscaled(bmp, 1, 1);
            g.Dispose();
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, w, h));
            Matrix mtrx = new Matrix();
            mtrx.Rotate(degree);
            RectangleF rct = path.GetBounds(mtrx);
            Bitmap dst = new Bitmap((int)rct.Width, (int)rct.Height, pf);
            g = Graphics.FromImage(dst);
            g.Clear(bkColor);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(degree);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tmp, 0, 0);
            g.Dispose();
            tmp.Dispose();
            return dst;
        }
        #endregion
    }
}