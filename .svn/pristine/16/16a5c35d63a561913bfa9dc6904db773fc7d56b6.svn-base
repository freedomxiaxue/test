using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.SessionState;
using System.Web.Http;
using System.Web;
using System.Xml;

namespace tcpjw3.oa.Controllers.ApiControllers
{
    public class SuperDogController : ApiController, IRequiresSessionState
    {
        [DllImport("dog_auth_srv.dll", EntryPoint = "verifyDigest", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int verifyDigest(int ivendorid, int idogid, String strchlge, String strrspn, String strfctr);

        [DllImport("dog_auth_srv_x64.dll", EntryPoint = "verifyDigest", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int verifyDigest_x64(int ivendorid, int idogid, String strchlge, String strrspn, String strfctr);

        public class DllInvoke
        {
            [DllImport("kernel32.dll")]
            private extern static IntPtr LoadLibrary(String path);
            [DllImport("kernel32.dll")]
            private extern static IntPtr GetProcAddress(IntPtr lib, String funcName);
            [DllImport("kernel32.dll")]
            private extern static bool FreeLibrary(IntPtr lib);
            private IntPtr hLib;
            public DllInvoke(String DLLPath)
            {
                hLib = LoadLibrary(DLLPath);
            }
            ~DllInvoke()
            {
                FreeLibrary(hLib);
            }

            public Delegate Invoke(String APIName, Type t)
            {
                IntPtr api = GetProcAddress(hLib, APIName);
                return (Delegate)Marshal.GetDelegateForFunctionPointer(api, t);
            }
        }
        /// <summary>
        /// Authenticate string is match or not
        /// </summary>
        /// <param name="context"></param>
        [HttpGet]
        public string Authentication(string p)
        {
            //获取参数
            if (string.IsNullOrEmpty(p)) return string.Empty;
            try
            {
                string[] ps = p.Split(',');

                int iVendorID = Convert.ToInt32(ps[0]);
                int iDogID = Convert.ToInt32(ps[1]);

                string sChallenge = ps[2];
                string sResult = ps[3];
                string sFactor = ps[4];

                int ret = verifyDigest(iVendorID, iDogID, sChallenge, sResult, sFactor);

                HttpContext.Current.Session.Add("AuthState", ret);
                return ret.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// Generate random string
        /// </summary>
        /// <param name="context"></param>
        [HttpPost]
        public string getChallenge()
        {
            String strChage = Guid.NewGuid().ToString().Replace("-", "").ToUpper();

            HttpContext.Current.Session.Add("LoginChallengeStr", strChage);

            return strChage;
        }

        /// <summary>
        /// Get vendor id from server
        /// </summary>
        /// <param name="context"></param>
        [HttpPost]
        public string getVendorID()
        {
            String strVendorID = String.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(string.Format("{0}App_Data\\SuperDog\\auth_code.xml", AppDomain.CurrentDomain.BaseDirectory));
                XmlElement root = (XmlElement)xmlDoc.SelectSingleNode("//dogauth");
                if (null != root)
                {
                    XmlNodeList vendorNodes = root.GetElementsByTagName("vendor");
                    foreach (XmlNode node in vendorNodes)
                    {
                        strVendorID = ((XmlElement)node).GetAttribute("id");
                        return strVendorID;
                    }
                    return string.Empty;
                }
                else
                {
                    return "The node root is not existed";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Get auth code from server
        /// </summary>
        /// <param name="context"></param>
        [HttpPost]
        public string getAuthCode()
        {
            String strAuthCode = String.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(string.Format("{0}App_Data\\SuperDog\\auth_code.xml", AppDomain.CurrentDomain.BaseDirectory));
                XmlNode root = xmlDoc.SelectSingleNode("//dogauth");
                if (null != root)
                {
                    strAuthCode = (root.SelectSingleNode("authcode")).InnerText;
                    return strAuthCode;
                }
                else
                {
                    return "The node root is not existed";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Get authentication factor from server
        /// </summary>
        /// <param name="context"></param>
        [HttpPost]
        public string getFactor()
        {
            String strFctr = String.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(string.Format("{0}App_Data\\SuperDog\\auth_factor.xml", AppDomain.CurrentDomain.BaseDirectory));
                XmlNode root = xmlDoc.SelectSingleNode("//dogauth");
                if (null != root)
                {
                    strFctr = (root.SelectSingleNode("factor")).InnerText;
                    return strFctr;
                }
                else
                {
                    return "The node root is not existed";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
