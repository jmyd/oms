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
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using wojilu.Reflection;
using wojilu.Web.Mvc.Attr;
using wojilu.Web.Mvc.Interface;
using wojilu.Web.Mvc.Utils;
using wojilu.Web.Context;
using wojilu.DI;

namespace wojilu.Web.Mvc {

    /// <summary>
    /// 控制器基类，wojilu mvc 中最常使用的对象
    /// </summary>
    public abstract class ControllerBase {

        /// <summary>
        /// 链接控件
        /// </summary>
        public Link Link;

        /// <summary>
        /// 当前 controller 中发生的错误信息
        /// </summary>
        protected Result errors;

        /// <summary>
        /// 当前mvc的上下文(context)，包括一些通用的数据和方法
        /// </summary>
        public MvcContext ctx;

        /// <summary>
        /// 设置或获取布局控制器
        /// </summary>
        public Type LayoutControllerType;

        private ControllerCore _utils;

        /// <summary>
        /// 页面元信息(包括Title/Keywords/Description/RssLink)
        /// </summary>
        public PageMeta Page {
            get { return this.ctx.GetPageMeta(); }
        }

        internal void setContext( MvcContext wctx ) {
            ctx = wctx;
            Link = new Link( wctx );
            errors = wctx.errors;
            _utils = new ControllerCore( this );
        }

        /// <summary>
        /// 一些帮助方法，主要是框架调用
        /// </summary>
        public ControllerCore utils {
            get { return _utils; }
        }

        /// <summary>
        /// 检查权限
        /// </summary>
        public virtual void CheckPermission() { }

        /// <summary>
        /// 布局方法
        /// </summary>
        public virtual void Layout() { }

        internal readonly List<Type> hidedLayouts = new List<Type>();
        internal readonly List<Type> hidedPermission = new List<Type>();

        /// <summary>
        /// 隐藏某个布局
        /// </summary>
        /// <param name="layoutType">需要被隐藏的 LayoutController 类型</param>
        protected void HideLayout( Type layoutType ) {
            hidedLayouts.Add( layoutType );
        }

        /// <summary>
        /// 隐藏某个权限检查步骤
        /// </summary>
        /// <param name="layoutType">需要被隐藏的权限检查 controller 类型</param>
        protected void HidePermission( Type layoutType ) {
            hidedPermission.Add( layoutType );
        }

        //-------------------------------------- 绑定 ----------------------------------------------

        /// <summary>
        /// 绑定链接
        /// </summary>
        /// <param name="tpl"></param>
        /// <param name="lbl"></param>
        /// <param name="obj"></param>
        protected virtual void bindOtherLink( IBlock tpl, String lbl, Object obj ) {
        }

        /// <summary>
        /// 根据名称获取模板中某个block
        /// </summary>
        /// <param name="blockName">block名称</param>
        /// <returns></returns>
        protected IBlock getBlock( String blockName ) {
            return utils.getCurrentView().GetBlock( blockName );
        }

        /// <summary>
        /// 手动指定当前 action 的视图文件(指定视图文件之后，默认的模板将被忽略)
        /// </summary>
        /// <param name="actionViewName">视图文件的名称</param>
        public void view( String actionViewName ) {
            utils.setCurrentView( utils.getTemplateByAction( actionViewName ) );
        }

        /// <summary>
        /// 自定义当前视图模的内容(自定义内容之后，默认的模板将被忽略)
        /// </summary>
        /// <param name="templateContent">模板的内容</param>
        public void viewContent( String templateContent ) {
            Template t = new Template();
            t.InitContent( templateContent );
            utils.setCurrentView( t );
        }

        /// <summary>
        /// 给模板中的变量赋值
        /// </summary>
        /// <param name="lbl">变量名称</param>
        /// <param name="val"></param>
        public void set( String lbl, Object val ) {
            utils.getCurrentView().Set( lbl, val );
        }

        /// <summary>
        /// 给模板中的变量赋值
        /// </summary>
        /// <param name="lbl">变量名称</param>
        /// <param name="val"></param>
        public void set( String lbl, String val ) {
            utils.getCurrentView().Set( lbl, val );
        }

        /// <summary>
        /// 将对象绑定到模板
        /// </summary>
        /// <param name="val"></param>
        protected void bind( Object val ) {
            utils.getCurrentView().Bind( val );
        }

        /// <summary>
        /// 将对象绑定到模板，并指定对象在模板中的变量名
        /// </summary>
        /// <param name="lbl">对象在模板中的变量名</param>
        /// <param name="val"></param>
        protected void bind( String lbl, Object val ) {
            utils.getCurrentView().Bind( lbl, val );
        }

        /// <summary>
        /// 将对象列表绑定到模板
        /// </summary>
        /// <param name="listName">需要被绑定的列表名</param>
        /// <param name="lbl">对象在模板中的变量名</param>
        /// <param name="objList">对象的列表</param>
        protected void bindList( String listName, String lbl, IList objList ) {
            bindList( listName, lbl, objList, bindOtherLink );
        }

        /// <summary>
        /// 将对象列表绑定到模板
        /// </summary>
        /// <param name="listName">需要被绑定的列表名</param>
        /// <param name="lbl">对象在模板中的变量名</param>
        /// <param name="objList">对象的列表</param>
        /// <param name="otherBinder">附加的绑定器</param>
        protected void bindList( String listName, String lbl, IList objList, otherBindFunction otherBinder ) {
            utils.getCurrentView().bindOtherFunc = otherBinder;
            utils.getCurrentView().BindList( listName, lbl, objList );
        }

        /// <summary>
        /// 将对象列表绑定到模板
        /// </summary>
        /// <param name="listName">需要被绑定的列表名</param>
        /// <param name="lbl">对象在模板中的变量名</param>
        /// <param name="objList">对象的列表</param>
        /// <param name="otherBinder">附加的绑定器</param>
        protected void bindList( String listName, String lbl, IList objList, bindFunction otherBinder ) {
            utils.getCurrentView().bindFunc = otherBinder;
            utils.getCurrentView().BindList( listName, lbl, objList );
        }

        /// <summary>
        /// 设置模板中表单提交的target
        /// </summary>
        /// <param name="url"></param>
        protected void target( String url ) {
            set( "ActionLink", url );
        }

        /// <summary>
        /// 设置模板中表单提交的target
        /// </summary>
        /// <param name="action"></param>
        protected void target( aAction action ) {
            set( "ActionLink", to( action ) );
        }

        /// <summary>
        /// 设置模板中表单提交的target
        /// </summary>
        /// <param name="action"></param>
        /// <param name="id"></param>
        protected void target( aActionWithId action, int id ) {
            set( "ActionLink", to( action, id ) );
        }

        //-------------------------------------- 控件 ----------------------------------------------

        /// <summary>
        /// 编辑器，工具栏只包括基本按钮
        /// </summary>
        /// <param name="propertyName">属性名称(也是编辑器名称)</param>
        /// <param name="propertyValue">需要被编辑的内容</param>
        /// <param name="height">编辑器高度(必须手动指定px单位)</param>
        protected void editor( String propertyName, String propertyValue, String height ) {

            if (ctx.route.isAdmin) {
                editorFull( propertyName, propertyValue, height );
                return;
            }

            Editor ed = Editor.NewOne( propertyName, propertyValue, height, sys.Path.Editor, MvcConfig.Instance.JsVersion, Editor.ToolbarType.Basic );
            ed.AddUploadUrl( ctx );
            set( "Editor", ed );
        }

        /// <summary>
        /// 编辑器，工具栏只包括基本按钮
        /// </summary>
        /// <param name="varName">模板中的变量名称</param>
        /// <param name="propertyName">需要编辑的属性名称</param>
        /// <param name="propertyValue">需要编辑的内容</param>
        /// <param name="height">编辑器高度(必须手动指定px单位)</param>
        protected void editor( String varName, String propertyName, String propertyValue, String height ) {
            editor( varName, propertyName, propertyValue, height, Editor.ToolbarType.Basic );
        }

        /// <summary>
        /// 编辑器
        /// </summary>
        /// <param name="varName">模板中的变量名称</param>
        /// <param name="propertyName">需要编辑的属性名称</param>
        /// <param name="propertyValue">需要编辑的内容</param>
        /// <param name="height">编辑器高度(必须手动指定px单位)</param>
        /// <param name="toolbar">工具栏类型：基本按钮或全部按钮</param>
        protected void editor( String varName, String propertyName, String propertyValue, String height, Editor.ToolbarType toolbar ) {

            String currentEditorKey = "currentEditor";

            List<String> editorList = ctx.GetItem( currentEditorKey ) as List<String>;
            if (editorList != null && editorList.Contains( propertyName )) throw new Exception( lang( "exEditorNameUnique" ) );

            Editor ed = Editor.NewOne( propertyName, propertyValue, height, sys.Path.Editor, MvcConfig.Instance.JsVersion, toolbar );
            ed.AddUploadUrl( ctx );
            if (editorList != null && editorList.Count > 0) ed.IsUnique = false;
            set( varName, ed );

            if (editorList == null) editorList = new List<string>();
            editorList.Add( propertyName );
            ctx.SetItem( currentEditorKey, editorList );
        }

        /// <summary>
        /// 编辑器，包括全部的工具栏
        /// </summary>
        /// <param name="propertyName">属性名称(也是编辑器名称)</param>
        /// <param name="propertyValue">需要被编辑的内容</param>
        /// <param name="height">编辑器高度(必须手动指定px单位)</param>
        protected void editorFull( String propertyName, String propertyValue, String height ) {

            Editor ed = Editor.NewOne( propertyName, propertyValue, height, sys.Path.Editor, MvcConfig.Instance.JsVersion, Editor.ToolbarType.Full );
            ed.AddUploadUrl( ctx );
            set( "Editor", ed );
        }

        /// <summary>
        /// 下拉控件(用数组填充)
        /// </summary>
        /// <param name="varName">控件名称</param>
        /// <param name="options">填充下拉框的字符数组</param>
        /// <param name="val">选定的值</param>
        protected void dropList( String varName, String[] options, Object val ) {
            set( varName, Html.DropList( options, varName, val ) );
        }

        /// <summary>
        /// 下拉控件(用 Dictionary 填充)
        /// </summary>
        /// <param name="varName">控件名称</param>
        /// <param name="dic">填充下拉框的Dictionary</param>
        /// <param name="val">选定的值</param>
        protected void dropList( string varName, Dictionary<string, string> dic, string val ) {
            set( varName, Html.DropList( dic, varName, val ) );
        }

        /// <summary>
        /// 下拉控件(用对象列表填充)
        /// </summary>
        /// <param name="varName">控件名称</param>
        /// <param name="list">填充下拉框的对象列表</param>
        /// <param name="nameValuePair">名值对，比如"Name=Id"表示用对象的属性Name填充选项的文本，用对象的属性Id填充选项的值</param>
        /// <param name="val">选定的值</param>
        protected void dropList( String varName, IList list, String nameValuePair, Object val ) {

            if (list == null || list.Count == 0) {
                set( varName, "" );
                return;
            }

            String[] arr = nameValuePair.Split( '=' );
            String dropString = Html.DropList( list, varName, arr[0], arr[1], val );
            set( varName, dropString );
        }

        /// <summary>
        /// 多个单选的列表(用字符数组填充)
        /// </summary>
        /// <param name="varName">控件名称</param>
        /// <param name="options">填充列表的字符数组</param>
        /// <param name="val">选定的值</param>
        protected void radioList( String varName, String[] options, Object val ) {
            set( varName, Html.RadioList( options, varName, val ) );
        }

        /// <summary>
        /// 多个单选的列表(用 Dictionary 填充)
        /// </summary>
        /// <param name="varName">控件名称</param>
        /// <param name="dic">填充列表的 Dictionary</param>
        /// <param name="val">选定的值</param>
        protected void radioList( string varName, Dictionary<string, string> dic, string val ) {
            set( varName, Html.RadioList( dic, varName, val ) );
        }

        /// <summary>
        /// 多个单选的列表(用对象列表填充)
        /// </summary>
        /// <param name="varName">控件名称</param>
        /// <param name="list">填充单选列表的对象列表</param>
        /// <param name="nameValuePair">名值对，比如"Name=Id"表示用对象的属性Name填充选项的文本，用对象的属性Id填充选项的值</param>
        /// <param name="val">选定的值</param>
        protected void radioList( String varName, IList list, String nameValuePair, Object val ) {
            String[] arr = nameValuePair.Split( '=' );
            set( varName, Html.RadioList( list, varName, arr[0], arr[1], val ) );
        }

        /// <summary>
        /// 多选框(用数组填充)
        /// </summary>
        /// <param name="varName">控件名称</param>
        /// <param name="options">填充列表的字符数组</param>
        /// <param name="val">选定的值，多个选值之间用英文逗号分开，比如 "2, 6, 13"</param>
        protected void checkboxList( String varName, String[] options, Object val ) {
            set( varName, Html.CheckBoxList( options, varName, val ) );
        }

        /// <summary>
        /// 多选框(用 Dictionary 填充)
        /// </summary>
        /// <param name="varName">控件名称</param>
        /// <param name="dic">填充列表的 Dictionary</param>
        /// <param name="val">选定的值，多个选值之间用英文逗号分开，比如 "2, 6, 13"</param>
        protected void checkboxList( string varName, Dictionary<string, string> dic, string val ) {
            set( varName, Html.CheckBoxList( dic, varName, val ) );
        }

        /// <summary>
        /// 多选框(用对象列表填充)
        /// </summary>
        /// <param name="varName">控件名称</param>
        /// <param name="list">填充多选列表的对象列表</param>
        /// <param name="nameValuePair">名值对，比如"Name=Id"表示用对象的属性Name填充选项的文本，用对象的属性Id填充选项的值</param>
        /// <param name="val">选定的值，多个选值之间用英文逗号分开，比如 "2, 6, 13"</param>
        protected void checkboxList( String varName, IList list, String nameValuePair, Object val ) {
            String[] arr = nameValuePair.Split( '=' );
            set( varName, Html.CheckBoxList( list, varName, arr[0], arr[1], val ) );
        }

        //-------------------------------------- 内部链接(快捷方式) ----------------------------------------------

        /// <summary>
        /// 链接到某个 action
        /// </summary>
        /// <param name="action"></param>
        /// <returns>返回一个链接</returns>
        public String to( aAction action ) {
            return this.Link.To( action );
        }

        /// <summary>
        /// 链接到某个 action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="id"></param>
        /// <returns>返回一个链接</returns>
        public String to( aActionWithId action, int id ) {
            return this.Link.To( action, id );
        }

        //protected String to( aActionWithQuery action, String param ) {
        //    return this.Link.To( action, param );
        //}

        /// <summary>
        /// 链接到某个 action，链接中不包含 appId 信息
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public String t2( aAction action ) {
            return this.Link.T2( action );
        }

        /// <summary>
        /// 链接到某个 action，链接中不包含 appId 信息
        /// </summary>
        /// <param name="action"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public String t2( aActionWithId action, int id ) {
            return this.Link.T2( action, id );
        }

        //protected String t2( aActionWithQuery action, String param ) {
        //    return this.Link.T2( action, param );
        //}

        /// <summary>
        /// 设置当前 action 返回的内容（一旦设置，先前绑定的模板内容将被覆盖）
        /// </summary>
        /// <param name="content"></param>
        public void actionContent( String content ) {
            utils.setActionContent( content );
        }

        //-------------------------------------- 显示消息 ----------------------------------------------

        /// <summary>
        /// 根据模板显示提示信息。ajax情况不使用模板，只显示内容。
        /// </summary>
        /// <param name="msg"></param>
        public void echo( String msg ) {
            if (ctx.utils.isAjax)
                echoText( msg );
            else if (isFrame())
                showByMsgBoxTemplate( msg );
            else
                showEndByViewTemplate( msg );
        }

        /// <summary>
        /// 直接显示内容(不根据模板)，然后结束
        /// </summary>
        /// <param name="msg"></param>
        public void echoText( String msg ) {
            actionContent( msg );
            ctx.utils.end();
        }

        /// <summary>
        /// 将字符串 ok 显示到客户端
        /// </summary>
        protected void echoAjaxOk() {
            echoText( "ok" );
        }

        /// <summary>
        /// 显示错误信息。支持ajax。
        /// </summary>
        protected void echoError() {
            if (ctx.utils.isAjax) {
                actionContent( errors.ErrorsJson );
            }
            else {
                forward( errors.ErrorsHtml, getReturnUrl() );
            }
            ctx.utils.end();
        }

        /// <summary>
        /// 显示错误信息。支持ajax。
        /// </summary>
        /// <param name="msg"></param>
        protected void echoError( String msg ) {
            errors.Add( msg );
            echoError();
        }

        /// <summary>
        /// 显示错误信息。支持ajax。
        /// </summary>
        /// <param name="result"></param>
        protected void echoError( Result result ) {
            errors.Join( result );
            echoError();
        }


        //----------------------------- 显示信息然后跳转 -----------------------------------

        /// <summary>
        /// 先显示提示信息(echo)，然后跳转页面(redirect)。支持ajax。
        /// </summary>
        /// <param name="msg"></param>
        public void echoRedirect( String msg ) {
            // ajaxPostForm状态下，不跳转页面
            String returnUrl = ctx.utils.isAjax ? "" : getReturnUrl();
            echoRedirect( msg, returnUrl );
        }

        /// <summary>
        /// 先显示提示信息(echo)，然后跳转到指定页面(redirect)。支持ajax。
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="action"></param>
        public void echoRedirect( String msg, aAction action ) {
            echoRedirect( msg, to( action ) );
        }

        /// <summary>
        /// 先显示提示信息(echo)，然后跳转到指定页面(redirect)。支持ajax。
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public void echoRedirect( String msg, String url ) {

            if (ctx.utils.isAjax) {

                url = addFrameParamsWhenForm( url );

                String returnJson = "{\"IsValid\":true, \"Msg\":\"" + strUtil.Text2Html( msg ).Replace( "\"", "'" ) + "\", \"ForwardUrl\":\"" + url + "\"}";
                actionContent( returnJson );
            }
            else if (isFrame()) {
                url = addFrameParams( url );
                forward( msg, url );
            }
            else {
                forward( msg, url );
            }

            ctx.utils.end();
        }

        // 表单下
        private String addFrameParamsWhenForm( String url ) {

            if (ctx.Post( "frm" ) != null && ctx.Post( "frm" ) == "true") {
                return addFrameParams( url );
            }

            return url;
        }

        // 如果 url 中已经有 frm=true了，则直接返回
        private String addFrameParams( String url ) {

            String frmStr = "frm=true";
            if (url.IndexOf( frmStr ) > 0) return url;


            if (url.IndexOf( '?' ) >= 0) {
                if (url.EndsWith( "&" )) {
                    return url + frmStr;
                }
                else {
                    return url + "&" + frmStr;
                }
            }
            else {
                return url + "?" + frmStr;
            }
        }

        /// <summary>
        /// (用于弹窗中)显示提示信息，然后关闭当前窗口
        /// </summary>
        /// <param name="msg"></param>
        protected void echoClose( String msg ) {
            echoMsgAndJs( "", 500, msg );
        }

        /// <summary>
        /// (本方法不常用)将一段 html 字符串添加到父窗口的某个 elementID
        /// </summary>
        /// <param name="elementID"></param>
        /// <param name="htmlValue"></param>
        protected void echoHtmlTo( String elementID, String htmlValue ) {
            echoAjaxJson( htmlValue, true, elementID );
        }

        /// <summary>
        /// (用于弹窗中)显示提示信息，然后关闭弹窗，并刷新父页面
        /// </summary>
        /// <param name="msg"></param>
        protected void echoToParent( String msg ) {

            if (ctx.utils.isAjax) {

                String returnJson = "{\"IsValid\":true, \"Msg\":\"" + strUtil.Text2Html( msg ).Replace( "\"", "'" ) + "\", \"ForwardUrl\":\"#\", IsParent:true}";
                actionContent( returnJson );

                return;
            }

            String cmd = "wojilu.tool.parentForward();";

            echoMsgAndJs( cmd, 500, msg );
        }

        /// <summary>
        /// (用于弹窗中)显示提示信息，然后关闭弹窗，并让父页面跳转到指定url
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        protected void echoToParent( String msg, String url ) {

            if (ctx.utils.isAjax) {

                String returnJson = "{\"IsValid\":true, \"Msg\":\"" + strUtil.Text2Html( msg ).Replace( "\"", "'" ) + "\", \"ForwardUrl\":\"" + url + "\", IsParent:true}";
                actionContent( returnJson );

                return;
            }

            String cmd = "wojilu.tool.parentForward('"+url+"');";

            echoMsgAndJs( cmd, 500, msg );
        }

        private Boolean isFrame() {
            return ctx.utils.isFrame();
        }

        private void forward( String msg, String url ) {
            String str = "<script>$(document).ready( function() {wojilu.tool.forward('" + url + "');});</script><div class=\"forward\" id=\"forward\">" + msg + "</div>";
            showEndByViewTemplate( str, MvcConfig.Instance.GetForwardTemplatePath() );
        }

        private void showEndByViewTemplate( String content ) {
            showEndByViewTemplate( content, MvcConfig.Instance.GetMsgTemplatePath() );
        }

        private void showByMsgBoxTemplate( String content ) {
            showEndByViewTemplate( content, MvcConfig.Instance.GetMsgBoxTemplatePath() );
        }

        private void showEndByViewTemplate( String content, String templatePath ) {

            String viewsPath = PathHelper.Map( templatePath );

            Template msgView = new Template( viewsPath );
            msgView.Set( "siteName", config.Instance.Site.SiteName );
            msgView.Set( "msg", content );
            utils.setGlobalVariable( msgView );

            actionContent( msgView.ToString() );
            ctx.utils.end();
        }

        //-------------------------------------- 直接跳转 ----------------------------------------------

        /// <summary>
        /// 自动跳转页面到来时的 url
        /// </summary>
        protected void redirect() {
            redirectUrl( getReturnUrl() );
        }

        /// <summary>
        /// 跳转页面到指定 action
        /// </summary>
        /// <param name="action"></param>
        public void redirect( aAction action ) {
            redirectUrl( Link.To( action ) );
        }

        /// <summary>
        /// 跳转页面到指定 action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="id"></param>
        public void redirect( aActionWithId action, int id ) {
            redirectUrl( Link.To( action, id ) );
        }

        /// <summary>
        /// 跳转页面到指定 action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="id"></param>
        public void redirect( String action, int id ) {
            redirectUrl( Link.To( base.GetType(), action, id ) );
        }

        /// <summary>
        /// 跳转页面到指定 url
        /// </summary>
        /// <param name="url"></param>
        public void redirectUrl( String url ) {

            if (ctx.utils.isAjax) {

                url = addFrameParamsWhenForm( url );

                String returnJson = "{\"IsValid\":true, \"ForwardUrl\":\"" + url + "\", \"Time\":0}";
                actionContent( returnJson );
                ctx.utils.end();
            }
            else if (isFrame()) {

                ctx.utils.end();
                ctx.utils.skipRender();
                url = addFrameParams( url );
                ctx.utils.clearResource();
                ctx.web.Redirect( url, false );
            }
            else {
                ctx.utils.end();
                ctx.utils.skipRender();
                ctx.utils.clearResource();
                ctx.web.Redirect( url, false );
            }
        }

        //-------------------------------------- ajax返回值 ----------------------------------------------

        /// <summary>
        /// 显示 json 信息给客户端，提示是否 valid ，返回 {IsValid:true, Msg:'', Info:''}
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="isValid"></param>
        /// <param name="otherInfo"></param>
        protected void echoAjaxJson( String msg, Boolean isValid, String otherInfo ) {
            echoText( MvcUtil.renderValidatorJson( msg, isValid, otherInfo ) );
        }

        private void echoMsgAndJs( String cmd, int msTime, String msg ) {
            String tcall = "setTimeout( function(){" + cmd + ";window.parent.wojilu.ui.box.hideBox();}, " + msTime + " );";
            String content = "$(document).ready( function() { " + tcall + " });";
            content = String.Format( "<script type=\"text/javascript\">{0}</script>", content ) + msg;
            showByMsgBoxTemplate( content );
        }

        private String getReturnUrl() {

            if (strUtil.HasText( ctx.web.PathReferrer ))
                return ctx.web.PathReferrer;

            return ctx.url.AppPath;
        }

        //-------------------------------------- 绑定(加载)局部页面内容 ----------------------------------------------

        /// <summary>
        /// 将某 action 的内容加载到指定位置
        /// </summary>
        /// <param name="sectionName">需要加载内容的位置</param>
        /// <param name="action">被加载的 action</param>
        protected void load( String sectionName, aAction action ) {
            set( sectionName, loadHtml( action ) );
        }

        /// <summary>
        /// 获取某 action 的内容
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public String loadHtml( String controller, String action ) {
            return ControllerRunner.Run( ctx, controller, action );
        }

        /// <summary>
        /// 获取某 action 的内容
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public String loadHtml( String controller, String action, int id ) {
            return ControllerRunner.Run( ctx, controller, action, id );
        }

        // TODO 在被load的action中，使用showEnd无效
        /// <summary>
        /// 获取某 action 的内容
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public String loadHtml( aAction action ) {

            String result;

            if (isSameType( action.Method )) {

                String actionName = action.Method.Name;
                Template originalView = utils.getCurrentView();

                setView( action.Method );
                action();

                Template resultView = utils.getCurrentView();
                utils.setCurrentView( originalView );
                result = resultView.ToString();
            }
            else {

                // 如果继承
                String actionName = action.Method.Name;
                ControllerBase otherController = ControllerFactory.FindController( action.Method.DeclaringType, ctx );
                otherController.view( actionName );
                otherController.utils.runAction( actionName );
                result = otherController.utils.getCurrentView().ToString();

                // 如果没有继承
                //result = ControllerRunner.Run( action, ctx );
            }

            return result;
        }

        /// <summary>
        /// 获取某 action 的内容
        /// </summary>
        /// <param name="action"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public String loadHtml( aActionWithId action, int id ) {

            String result;

            if (isSameType( action.Method )) {

                String actionName = action.Method.Name;
                Template originalView = utils.getCurrentView();

                setView( action.Method );

                action( id );

                Template resultView = utils.getCurrentView();
                utils.setCurrentView( originalView );
                result = resultView.ToString();
            }
            else {

                //ControllerBase targetController = action.Target as ControllerBase;
                //ControllerFactory.InjectController( targetController, ctx );
                //targetController.view( action.Method.Name );
                //action( id );
                //result = targetController.utils.getCurrentView().ToString();

                result = ControllerRunner.Run( ctx, action, id );
            }

            return result;
        }

        /// <summary>
        /// 运行其他 action，并将运行结果作为当前 action 的内容
        /// </summary>
        /// <param name="action"></param>
        protected void run( aAction action ) {

            if (ctx.utils.isAjax) {
                if (ctx.HasErrors)
                    echoError();
                else
                    echoAjaxOk();
                return;
            }

            if (isSameType( action.Method )) {
                setView( action.Method );
                action();
            }
            else {

                //ControllerBase mycontroller = ControllerFactory.FindController( action.Method.DeclaringType, ctx );
                //mycontroller.view( action.Method.Name );
                //action.Method.Invoke( mycontroller, null );
                //actionContent( mycontroller.utils.getActionResult() );

                actionContent( ControllerRunner.Run( ctx, action ) );
            }
        }

        /// <summary>
        /// 运行其他 action，并将运行结果作为当前 action 的内容
        /// </summary>
        /// <param name="action"></param>
        /// <param name="id"></param>
        protected void run( aActionWithId action, int id ) {

            if (ctx.utils.isAjax) {
                if (ctx.HasErrors)
                    echoError();
                else
                    echoAjaxOk();
                return;
            }

            if (isSameType( action.Method )) {
                setView( action.Method );
                action( id );
            }
            else {

                //ControllerBase mycontroller = ControllerFactory.FindController( action.Method.DeclaringType, ctx );
                //mycontroller.view( action.Method.Name );
                //action.Method.Invoke( mycontroller, new object[] { id } );
                //actionContent( mycontroller.utils.getActionResult() );

                actionContent( ControllerRunner.Run( ctx, action, id ) );
            }
        }



        /// <summary>
        /// 运行其他 action，并将运行结果作为当前 action 的内容
        /// </summary>
        /// <param name="controllerType">被运行的 action 所属的 controller 类型</param>
        /// <param name="actionName">action 名称</param>
        /// <param name="args">需要的参数</param>
        protected void run( String controllerFullTypeName, String actionName, params object[] args ) {

            Type controllerType = ObjectContext.Instance.TypeList[controllerFullTypeName];

            if (controllerType == base.GetType()) {

                view( actionName );
                MethodInfo method = base.GetType().GetMethod( actionName );
                if (method == null) {
                    throw new Exception( "action " + wojilu.lang.get( "exNotFound" ) );
                }
                else {
                    method.Invoke( this, args );
                }

            }
            else {
                actionContent( ControllerRunner.Run( ctx, controllerFullTypeName, actionName, args ) );
            }
        }

        private Boolean isSameType( MethodInfo method ) {
            Boolean result = this.GetType() == method.DeclaringType || this.GetType().IsSubclassOf( method.DeclaringType );
            return result;
        }

        private void setView( MethodInfo method ) {
            if (this.GetType().IsSubclassOf( method.DeclaringType )) {
                String filePath = MvcUtil.getParentViewPath( method, ctx.route.getRootNamespace( method.DeclaringType.FullName ) );
                this.utils.setCurrentView( this.utils.getTemplateByFileName( filePath ) );
            }
            else {
                view( method.Name );
            }
        }


        //------------------------------------------------------------------------

        /// <summary>
        /// 从核心语言包(core.config)中获取多国语言的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected String lang( String key ) {
            return wojilu.lang.get( key );
        }

        /// <summary>
        /// 从各 app 的语言包中获取多国语言的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public String alang( String key ) {
            return utils.getAppLang() == null ? null : utils.getAppLang().get( key );
        }

    }
}
