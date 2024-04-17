function MuiTextField() {

    //$(".chzn-select").chosen();
    //$(".chzn-select-deselect").chosen({ allow_single_deselect: true });

    $("input[type='text'],textarea").attr("title", " ");

    $("select").each(function () {

        $(this).parent().addClass("TextField");

        $(this).parent().css({ position: "relative" });
        $(this).parent().children("span:first-child").css({
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
    $("input[type='text'],select").attr("title", " ");

    $("select").each(function () {

        $(this).parent().addClass("TextField");

        $(this).parent().css({ position: "relative" });
        $(this).parent().children("span:first-child").css({
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
                margin: "1px 4px 0px",
                width: "90%",
                transformOrigin: "left top",
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

    //new`d

    //.css({ color: "#5e67e4" });
    $(".chzn-select").each(function () {
        $(this).attr("data-placeholder", " ")
    });

    //New 21_Nov_2022
    //let crumbs = $(".crumbs").html();
    //$(".widget-header h4").after("<div class=crumbs>" + crumbs + "</div>");
    //$(".crumbs").hide();
    //$(".widget-header .crumbs").show();

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

 
}