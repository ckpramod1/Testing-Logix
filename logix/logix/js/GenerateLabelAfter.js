/// <reference path="GenerateLabelAfter.js" />
function GenerateLabelAfter() {
    $("input[type='text'],textarea").each(function () {
        if ($(".chzn-search input")) {
            $(".chzn-search input").attr("placeholder", "");
        }
    });

    $("input[type='text'],textarea").each(function () {

        if ($(this).attr("placeholder")) {
            var placeholder = $(this).attr("placeholder");
            $(this).after("<span>" + placeholder + "</span>");
            $(this).removeAttr("placeholder");
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
            //newLine
            $(this).attr("data-placeholder", " ");
            //newLine
        } else if ($(this).attr("title")) {
            var tooltip = $(this).attr("title");
            $(this).before("<span>" + tooltip + "</span>");
        }
    });

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

    //$(".chzn-select").chosen();
    //$(".chzn-select-deselect").chosen({ allow_single_deselect: true });

    $("input[type='text'],textarea").attr("title", " ");

    $("select").each(function () {

        $(this).parent().addClass("TextField");

        $(this).parent().css({ position: "relative" });
        $(this).parent().children("span").css({
            position: "absolute",
            top: "14px",
            zIndex: 1,
            left: "2px",
            // commented by praveen 2023-May-18 >> left: "5px",
            // commented by praveen 2023-May-10 >> fontSize: "9px",
            fontSize: "10px",
            background: "white",
            padding: "0px 5px",
            marginLeft: 0,
            color: "#06529c",
        });
    });

    //select tag only >> seperated from above - Praveen 2023-May-12 

    $("input[type='text'],textarea,select").attr("title", " ");

    $("select").each(function () {

        $(this).parent().addClass("TextField");

        $(this).parent().css({ position: "relative" });
        $(this).parent().children("span").css({
            position: "absolute",
            top: "9px",
            zIndex: 1,
            left: "2px",
            // commented by praveen 2023-May-18 >> left: "5px",
            // commented by praveen 2023-May-10 >> fontSize: "9px",
            fontSize: "10px",
            background: "white",
            padding: "0px 5px",
            marginLeft: 0,
            color: "#06529c",
        });
    });


    $("input[type='text'],input[type='password'],textarea").each(function () {

        $(this).parent().addClass("TextField");

        if ($(this).val()) {
            $(this).parent().children("span:last-child").css({

                // commented by praveen 2023-May-10 >> top: "10px", 

                top: "4px",
                left: "0px",
                // commented by praveen 2023-May-10 >> fontSize: "9px",
                fontSize: "10px",

                fontFamily: "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
                position: "absolute",
                backgroundColor: "white",
                padding: " 4px 0.3rem 0",
                //margin: "4.4px 0.5rem 0px",
                margin: "1px 4px 0px",
                width: "90%",
                transformOrigin: "left top",
                pointerEvents: "none",
                color: "#06529c",
            });
        }
        else if ($(this).val() == "") {
            $(this).parent().children("span:last-child").css({
                color: "#06529c",
                // commented by praveen 2023-May-10 >> top: "10px", 

                top: "4px",
                left: "0px",
                // commented by praveen 2023-May-10 >> fontSize: "9px",
                fontSize: "10px",

                fontFamily: "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
                position: "absolute",
                backgroundColor: "white",
                padding: " 4px 0.3rem 0",
                //margin: "4.4px 0.5rem 0px",
                margin: "1px 4px 0px",
                width: "90%",

                pointerEvents: "none",
            });
        }

        $(this).focusin(function () {

            $(this).parent().children("span:last-child").css({
                color: "#06529c",
                // commented by praveen 2023-May-10 >> top: "10px", 

                top: "4px",
                left: "0px",
                // commented by praveen 2023-May-10 >> fontSize: "9px",
                fontSize: "10px",

                fontFamily: "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
                position: "absolute",
                backgroundColor: "white",
                padding: " 4px 0.3rem 0",
                //margin: "4.4px 0.5rem 0px",
                margin: "1px 4px 0px",

                width: "90%",

                transformOrigin: "left top",
                pointerEvents: "none",
            });

        });

        $(this).focusout(function () {

            if ($(this).val()) {
                $(this).parent().children("span:last-child").css({

                    // commented by praveen 2023-May-10 >> top: "10px", 

                    top: "4px",
                    left: "0px",
                    // commented by praveen 2023-May-10 >> fontSize: "9px",
                    fontSize: "10px",

                    fontFamily: "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
                    position: "absolute",
                    backgroundColor: "white",
                    padding: " 4px 0.3rem 0",
                    //margin: "4.4px 0.5rem 0px",
                    margin: "1px 4px 0px",

                    width: "90%",

                    transformOrigin: "left top",
                    pointerEvents: "none",
                    color: "#06529c",

                });
            } else if ($(this).val() == "") {
                $(this).parent().children("span:last-child").css({

                    // commented by praveen 2023-May-10 >> top: "10px", 

                    top: "4px",
                    left: "0px",
                    // commented by praveen 2023-May-10 >> fontSize: "9px",
                    fontSize: "10px",

                    fontFamily: "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif",
                    position: "absolute",
                    backgroundColor: "white",
                    padding: " 4px 0.3rem 0",
                    //margin: "4.4px 0.5rem 0px",
                    margin: "1px 4px 0px",
                    width: "90%",
                    transformOrigin: "left top",
                    pointerEvents: "none",
                    color: "#06529c",
                });
            }

        });
    });

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

    //New 14_Mar_2023 Right align any numeric columns
    $("tr").each(function () {
        $(this)
          .children("td:gt(0)")
          .filter(function () {
              return this.innerHTML.match(/^[0-9\s\.,]+$/);
          })
          .css("text-align", "right");

        // New 14_Mar_2023 Right align any date columns in ddmmmyyyy format

        // $(this)
        //   .children("td:gt(0)")
        //   .filter(function () {
        //     return this.innerHTML.match(/\d{1,2}\w{3}\d{2,4}/);
        //   })
        //   .css("text-align", "right");

    });

    //New 23_Dec_2022
    $("table").attr("class", "Grid FixedHeader");
    $("table table").attr("class", " ");
    $("fieldset table").attr("class", " ");

    //New 27_Dec_2022
    $(".modalPopup").each(function () {
        if ($(this).children().hasClass("divRoated")) {
            console.log($(this).children().attr("class"));
        } else {
            $(this).children().wrapAll("<div class='divRoated'>");
        }
    });

    //boxmodalLink Start
    $("a.boxmodalLink").each(function () {
        if ($(this).parent().hasClass("FormGroupContent4")) {
            $(this).wrap("<div class='boxmodalLink_box'>");
        }
        let boxmodalLink = $(this).text();
        const myArray = $(this).text().split("");
        let firstvalue = myArray[0].toUpperCase();
        $(this).attr("title", boxmodalLink);
        // $(this).text(firstvalue);
        $(this).text("Q");
    });
    //boxmodalLink End

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
