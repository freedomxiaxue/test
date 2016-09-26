using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace tcpjw3.oa.Controllers
{
    public class SuperDogController : Controller
    {
        // GET: SuperDog

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


    }
}