$("#back-to-top").fadeIn(),
    $("#back-to-top").click((function () {
        return $("body,html").animate({
            scrollTop: 0
        }, 200),
            !1
    }
    ));

$("#back-to-bottom").fadeIn(),
    $("#back-to-bottom").click((function () {
        return $("body, html").animate({
            scrollTop: $(document).height()
        }, 200)
    }
    ));