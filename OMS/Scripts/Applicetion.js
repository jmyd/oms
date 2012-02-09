var Application = {};

Application.CurrentSite;

Application.isHMenu = false;

Application.onMainMenuClick = function (ele, flag) {//flag仅在回退/前进时置为true
    if (Application.LastClickMainMenu) {
        Application.LastClickMainMenu.className = '';
    }
    Application.LastClickMainMenu = ele;
    ele.className = "current";
    var parent = $("#_ChildMenu");
    var menu = $("#_Child" + ele.id);
    if (!menu | !jQuery.isEmptyObject(menu)) {
        var arr = $("#" + ele.id).queue("ChildArray");
        var str = [];
        for (var i = 0; i < arr.length; i++) {
            var id = "_ChildMenuItem_" + arr[i][0];
            str.push("<div id='" + id + "' class='divtab' onClick='Application.onChildMenuClick(this)' onMouseOver='Application.onChildMenuMouseOver(this)' onMouseOut='Application.onChildMenuMouseOut(this)' url='" + arr[i][2] + "'><img src='" + arr[i][3] + "' /><b><span>" + arr[i][1] + "</span></b></div>");
        }
        menu = parent.append("<div></div>").children().last();
        menu.attr("id", "_Child_" + ele.id).html(str.join(""));
    }
    var childs = $(parent).children();
    for (var i = 0; i < childs.length; i++) {
        $(childs[i]).hide();
    }
    $(menu).show();

    if (!ele.CurrentItem) {
        ele.CurrentItem = "_ChildMenuItem_" + arr[0][0];
    }
    Application.onChildMenuClick($("#" + ele.CurrentItem)[0], flag);
}

Application.onMainMenuMouseOver = function (ele) {
    ele.className = 'current';
}

Application.onMainMenuMouseOut = function (ele) {
    if (ele != Application.LastClickMainMenu) {
        ele.className = '';
    }
}



var StartTime;
Application.onChildMenuClick = function (ele, flag) {//flag仅在回退/前进时置为true
    StartTime = new Date().getTime();
    if (Application.LastClickMainMenu) {
        Application.LastClickMainMenu.CurrentItem = ele.id;
    }
    //设置hash
    window.location.hash = ele.parentNode.id.substr("_Child_Menu_".length) + "_" + ele.id.substr("_ChildMenuItem_".length);
    if (!flag) {
        var url = ele.getAttribute("url");
        $("#_MainArea").attr("src", url);
    }

    $("div .divtabCurrent").each(function (index) {

        $(this).removeClass("divtabCurrent").addClass("divtab").css("z-index", $("div .divtabCurrent").length - index);
    });
    ele.className = "divtabCurrent";
    ele.style.zIndex = "33";
}

Application.onChildMenuMouseOver = function (ele) {
    if (ele.className == "divtab") {
        ele.className = "divtabHover";
    }
}

Application.onChildMenuMouseOut = function (ele) {
    if (ele.className == "divtabHover") {
        ele.className = "divtab";
    }
}



Application.setCurrentMenu = function (url) {
    if (url.indexOf("#") > 0) {
        url = url.substring(0, url.indexOf("#"));
    }
    if ($("_Navigation")) {
        var arr = $("#_Navigation a");
        for (var i = 0; i < arr.length; i++) {
            var carr = arr[i].ChildArray;
            for (var j = 0; j < carr.length; j++) {
                if (url.indexOf(carr[j][2]) >= 0) {
                    Application.onMainMenuClick(arr[i], true);
                    Application.onChildMenuClick($("#_ChildMenuItem_" + carr[j][0]), true);
                    return;
                }
            }
        }
    }
}

