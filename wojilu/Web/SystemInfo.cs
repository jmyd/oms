/*
 * Copyright 2010 www.wojilu.com
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Web;

namespace wojilu.Web {

    /// <summary>
    /// 系统的固定数据，比如网站根路径、app路径、主机名称等
    /// </summary>
    public class SystemInfo {

        public static SystemInfo Instance = loadSystemInfo();

        private SystemInfo() { }

        /// <summary>
        /// 比 ApplicationPath 多一个斜杠
        /// </summary>
        public static String RootPath { get { return SystemInfo.Instance.rootPath; } }
        public static String ApplicationPath { get { return SystemInfo.Instance.applicationPath; } }
        public static String Host { get { return SystemInfo.Instance.host; } }

        /// <summary>
        /// 主机名(或ip地址)+端口号
        /// </summary>
        public static String Authority { get { return SystemInfo.Instance.authority; } }

        private String rootPath;
        private String applicationPath;
        private String host;
        private String authority;

        //-------------------------------------------------------------------------------------------------


        private static bool _hasInitialized = false;
        private static Object _objLock = new Object();

        public static void Init() {

            if (_hasInitialized) return;

            lock (_objLock) {
                if (_hasInitialized) return;
                SystemInfo obj = SystemInfo.Instance;
                _hasInitialized = true;
            }
        }


        private static SystemInfo loadSystemInfo() {

            SystemInfo obj = new SystemInfo();

            if (IsWeb) {
                obj.applicationPath = HttpContext.Current.Request.ApplicationPath;
                obj.rootPath = addEndSlash( obj.applicationPath );
                obj.host = HttpContext.Current.Request.Url.Host;
                obj.authority = HttpContext.Current.Request.Url.Authority;
            }
            else {
                obj.applicationPath = "/";
                obj.rootPath = "/";
                obj.host = "localhost";
            }

            return obj;

        }

        private static String addEndSlash( String appPath ) {
            if (!appPath.EndsWith( "/" )) return appPath + "/";
            return appPath;
        }


        public static Boolean IsWeb { get { return HttpContext.Current != null; } }
        public static Boolean IsWindows {
            get { return Environment.OSVersion.VersionString.ToLower().IndexOf( "windows" ) >= 0; }
        }

        //-------------------------------------------------------------------------------------------------

        public static void UpdateSessionId() {
            String sessionId = getSessionId();
            if (sessionId != null) updateCookie( sessionId );
        }

        private static String getSessionId() {
            String sessionId = "ASPNET_SESSIONID";
            HttpRequest req = HttpContext.Current.Request;
            if (req.Form[sessionId] != null) return req.Form[sessionId];
            if (req.QueryString[sessionId] != null) return req.QueryString[sessionId];
            return null;
        }

        private static void updateCookie( String sessionId ) {

            String cookieName = "ASP.NET_SESSIONID";

            HttpRequest req = HttpContext.Current.Request;
            HttpResponse res = HttpContext.Current.Response;

            HttpCookie cookie = req.Cookies.Get( cookieName );

            if (cookie == null) {
                res.Cookies.Add( new HttpCookie( cookieName, sessionId ) );
            }
            else {
                cookie.Value = sessionId;
                req.Cookies.Set( cookie );
            }
        }


    }

}
