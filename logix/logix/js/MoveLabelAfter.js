function SpanTagMoveInputBottom() {
    $("input[type='text'],textarea,input[type='password']").each(function () {
        $(this).parent().addClass("TextField");

        var labelValue = $(this).parent().children("span:first-child").html();
        //console.log(labelValue);

        if ($(".chzn-search input")) {
            $(".chzn-search input").attr("placeholder", "");
        }

        $(this).parent().children("span:first-child").remove();
        $(this).after("<span>" + labelValue + "</span>");
    });

    //newLine

    $(".chzn-select").each(function () {
        if ($(this).attr("placeholder")) {
            $(this).attr("placeholder", " ")
        } else if ($(this).attr("data-placeholder")) {
            $(this).attr("data-placeholder", " ")
        }
    });

    //newLine
}
