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
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;
using wojilu.Common;

namespace wojilu.Web {

    /// <summary>
    /// web 原始数据和方法的接口
    /// </summary>
    public interface IWebContext {

        Uri Url { get; }

        String PathRoot { get; }
        String PathAbsolute { get; }
        String PathApplication { get; }
        String PathRawUrl { get; }
        String PathHost { get; }
        String PathInfo { get; }
        String PathReferrer { get; }
        String PathReferrerHost { get; }

        String ClientHttpMethod { get; }
        String ClientIp { get; }
        String ClientAgent { get; }
        String[] ClientLanguages { get; }
        String ClientVar( String key );

        void CompleteRequest();
        void ResponseWrite( String content );
        void ResponseStatus( String status );
        void ResponseFlush( );
        void ResponseEnd();

        String UrlDecode( String path );
        String UrlEncode( String path );
        void RenderJson( String content );
        void RenderXml( String content );

        String post( String key );
        Boolean postHas( String key );
        NameValueCollection postValueAll();
        String[] postValuesByKey( String name );

        String get( String key );
        Boolean getHas( String key );

        String param( String key );
        HttpFileCollection getUploadFiles();

        void Redirect( String url );
        void Redirect( String url, bool endResponse );

        int UserId();
        bool UserIsLogin { get; }
        void UserLogin( int userId, String userName, LoginTime expiration );
        void UserLogout();

        String CookieAuthName();
        String CookieAuthValue();
        void CookieClear();
        String CookieGet( String key );
        void CookieRemove( String key );
        void CookieSet( String key, String val );
        void CookieSetLang( String val );

        object SessionGet( String key );
        void SessionSet( String key, object val );
        String SessionId { get; }

        String GetAuthJson();

        object Session { get; }
        object Context { get; }

    }

}
