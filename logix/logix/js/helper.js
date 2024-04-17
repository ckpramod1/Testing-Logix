function GenerateLabelAfter() {
    placeholderToSpan();
    modSpanAttribs();
    changeControlAttribs();
}

function SpanTagMoveInputBottom() {
    labelToSpan();
    modSpanAttribs();
    changeControlAttribs();
}
function spancolorchange() {
    modSpanAttribs();
    changeControlAttribs();
}
function placeholderToSpan() {
    $("input[type='text'],textarea").each(function () {
        if ($(".chzn-search input")) {
            $(".chzn-search input").attr("placeholder", "");
        }
    });

    $("input[type='text'],input[type='password'],textarea").each(function () {
        if ($(this).attr("placeholder")) {
            var placeholder = $(this).attr("placeholder");
            $(this).after("<span>" + placeholder + "</span>");
            $(this).removeAttr("placeholder");
        } else if ($(this).attr("title")) {
            var tooltip = $(this).attr("title");
            $(this).after("<span>" + tooltip + "</span>");
        }
    });

    $(".chzn-select").each(function () {
        if ($(this).attr("placeholder")) {
            var placeholder = $(this).attr("placeholder");
            $(this).before("<span>" + placeholder + "</span>");
            $(this).removeAttr("placeholder");
        } else if ($(this).attr("data-placeholder")) {
            var dataplaceholder = $(this).attr("data-placeholder");
            $(this).before("<span>" + dataplaceholder + "</span>");
            $(this).attr("data-placeholder", " ");
        } else if ($(this).attr("title")) {
            var tooltip = $(this).attr("title");
            $(this).before("<span>" + tooltip + "</span>");
        }
    });
}

function labelToSpan() {
    $("input[type='text'],textarea,input[type='password']").each(function () {
        $(this).parent().addClass("TextField");
        var labelValue = $(this).parent().children("span:first-child").html();
        if ($(".chzn-search input")) {
            $(".chzn-search input").attr("placeholder", "");
        }
        $(this).parent().children("span:first-child").remove();
        $(this).after("<span>" + labelValue + "</span>");
    });

    $(".chzn-select").each(function () {
        $(this).attr("placeholder", " ");
        $(this).attr("data-placeholder", " ");
    });
}

function modSpanAttribs() {
    $("select").each(function () {
        $(this).parent().addClass("TextField");
        $(this).parent().css({ position: "relative" });
        $(this).parent().children("span").addClass("emphasis");
    });

    $("input[type='text'],input[type='password'],textarea").each(function () {
        $(this).parent().addClass("TextField");
        $(this).parent().children("span:last-child").addClass("normalsize");
    });
}

function changeControlAttribs() {
    // Save And Update Buttons Change tooltip Values
    $("input[type = 'submit'],input[type = 'button']").each(function () {
        if ($(this).attr("value")) {
            var value = $(this).attr("value");
            $(this).attr("title", value);
        }
        if ($(this).attr("title") === "Save") {
            $(this).parent().attr("class", "btn ico-save");
        }
        if ($(this).attr("title") === "Update") {
            $(this).parent().attr("class", "btn ico-update");
        }
    });

    // Crumbs Design
    //let crumbs = $(".crumbs").html();
    //$(".widget-header h4").after("<div class=crumbs>" + crumbs + "</div>");
    //$(".crumbs").hide();
    //$(".widget-header .crumbs").show();

    // Header Fixed On Scrolling All Tables Headings
    $("table").attr("class", "Grid FixedHeader");
    $("table table").attr("class", " ");
    $("fieldset table").attr("class", " ");

    // Table td hover to tooltip Value
    $("table td,table td  span").each(function () {
        let tdvalue = $(this).text();
        $(this).attr("title", tdvalue);
    });

    // modalPopup Design
    $(".modalPopup").each(function () {
        if ($(this).children().hasClass("divRoated")) {
            console.log($(this).children().attr("class"));
        } else {
            $(this).children().wrapAll("<div class='divRoated'>");
        }
    });

    // Right Align Any Numeric Columns In Table
    $("tr").each(function () {
        $(this)
            .children("td:gt(0)")
            .filter(function () {
                return this.innerHTML.match(/^[0-9\s\.,]+$/);
            })
            .css("text-align", "right");
    });

    // Amount INR Format
    $(".currency-inr").each(function () {
        var monetary_value = $(this).text().split(",").join("") || $(this).val().split(",").join("");
        var i = new Intl.NumberFormat("en-IN", {
            currency: "INR",
            minimumFractionDigits: 2,
        }).format(monetary_value);
        $(this).text(i);
        $(this).val(i);
    });

    $("input[type='text'],textarea,select").attr("title", " ");

    //on off switch Start
    $("div > input[type='checkbox']").each(function () {
        $(this).wrap("<label class='switch'>");
    });
    let slider = document.createElement("span");
    $("label.switch").append(slider);
    $("label.switch span").attr("class", "slider round");
    $("label.switch").wrap("<center>");
    //$("center").parent().children(1).attr("class", "chktext");
    $("center").prev().addClass("chktext");
    //on off switch End
}

 