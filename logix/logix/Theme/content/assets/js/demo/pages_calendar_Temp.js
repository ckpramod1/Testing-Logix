/*
 * pages_calendar.js
 *
 * Demo JavaScript used on dashboard and calendar-page.
 */

"use strict";

$(document).ready(function () {

   
    //===== Calendar =====//
    var h = {};

    if ($('#calendar').width() <= 400) {
        h = {
            left: 'title',
            center: '',
            right: 'prev,next'
        };
    } else {
        h = {
            left: '',
            center: '',
            right: ''
        };
    }

    $('#calendar').fullCalendar({
        disableDragging: false,
        header: h,
        editable: false,
        allDaySlot: false,
        defaultView: 'agendaWeek',
        year: '2013',
        month: '11',
        date: '1',
        hiddenDays: [3, 4, 5, 6, 7],
        slotEventOverlap: false,
        columnFormat: { week: 'dddd' },
        firstHour: '00',
        eventAfterAllRender: function () {
            $(".myClass").each(function () {
                var divText = $(this).text();
                $(this).text("").append(divText);
            });
        },
        eventClick: function (calEvent, jsEvent, view) {
            if ($("#liClicks").val() != "1") {
                $("#eventPop").show();
            } else {
                $("#liClicks").val("0");
            }

        },
        events: [
            {
                title: 'AM Shift',
                start: new Date("2013", "11", "1", 1, 0),
                end: new Date("2013", "11", "1", 8, 0),
                allDay: false,
                backgroundColor: "#658cb2",
                description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Anthoni Abdul</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Abdul Quadir</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Abdul kalam</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Abubakkar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Kareem</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Akaram</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Anthoni Abdul</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Rehman</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Rafeeq</div></li></ul>'
            },

            {
                title: 'AM Shift',
                start: new Date("2013", "11", "1", 4, 30),
                end: new Date("2013", "11", "1", 11, 30),
                backgroundColor: "#94b86e",
                allDay: false,
                description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
            },
            {
                title: 'New Shift',
                start: new Date("2013", "11", "1", 10, 30),
                end: new Date("2013", "11", "1", 17, 30),
                allDay: false,
                backgroundColor: "#ffb849",
                description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Abdul</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Kalam</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Abubakar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">karrem</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">sayed</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Nazeer</div></li></ul>'
            },
             {
                 title: 'New Shift',
                 start: new Date("2013", "11", "2", 0, 30),
                 end: new Date("2013", "11", "2", 6, 30),
                 allDay: false,
                 backgroundColor: "#ffb849",
                 description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Abdul</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Kalam</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Abubakar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">karrem</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">sayed</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Nazeer</div></li></ul>'
             },
          {
              title: 'AM Shift',
              start: new Date("2013", "11", "2", 4, 0),
              end: new Date("2013", "11", "2", 15, 0),
              backgroundColor: "#94b86e",
              allDay: false,
              description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
          }

            , {
                title: 'New Shift',
                start: new Date("2013", "11", "2", 10, 30),
                end: new Date("2013", "11", "2", 17, 0),
                allDay: false,
                backgroundColor: "#658cb3",
                description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Anthoni Abdul</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Abdul Quadir</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Abdul kalam</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Abubakkar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Kareem</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Akaram</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Anthoni Abdul</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Rehman</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Rafeeq</div></li></ul>'
            },
            {
                title: 'AM Shift',
                start: new Date("2013", "11", "3", 2, 0),
                end: new Date("2013", "11", "3", 10, 0),
                allDay: false,
                backgroundColor: "#658cb3",
                description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Azzarudin</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Umar Kayam</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Amir Khan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Anthoni Abdul</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Rehman</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Rafeeq</div></li></ul>'
            },
            {
                title: 'New Shift',
                start: new Date("2013", "11", "3", 6, 30),
                end: new Date("2013", "11", "3", 17, 30),
                allDay: false,
                backgroundColor: "#ffb849",
                description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Abdul</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Kalam</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Abubakar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">karrem</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">sayed</div></li><li onclick="ProEmp()"><div class="cal_newshift_img darkyellow_bg"></div><div class="cal_shiftfive_txt">Nazeer</div></li></ul>'
            }

           ,
            {
                title: 'New Shift',
                start: new Date("2013", "11", "3", 12, 0),
                end: new Date("2013", "11", "3", 18, 0),
                allDay: false,
                backgroundColor: "#658cb3",
                description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Azzarudin</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Umar Kayam</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Amir Khan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Anthoni Abdul</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Rehman</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img blue_bg"></div><div class="cal_newshift_txt">Rafeeq</div></li></ul>'
            },
            {
                title: 'Shift 5',
                start: new Date("2013", "11", "4", 1, 0),
                end: new Date("2013", "11", "4", 8, 0),
                backgroundColor: "#a460b3",
                allDay: false,

                description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img yellow_bg"></div><div class="cal_shiftfive_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Rehman</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
            },
             {
                 title: 'Shift 5',
                 start: new Date("2013", "11", "4", 10, 0),
                 end: new Date("2013", "11", "4", 18, 0),
                 backgroundColor: "#a460b3",
                 allDay: false,
                 description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
             },
             {
                 title: 'AM Shift',
                 start: new Date("2013", "11", "5", 7, 30),
                 end: new Date("2013", "11", "5", 15, 30),
                 backgroundColor: "#74b86e",
                 allDay: false,
                 description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
             },
              {
                  title: 'AM Shift',
                  start: new Date("2013", "11", "5", 16, 30),
                  end: new Date("2013", "11", "5", 24, 30),
                  backgroundColor: "#74b86e",
                  allDay: false,
                  description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
              },
             {
                 title: 'Shift 5',
                 start: new Date("2013", "11", "6", 1, 0),
                 end: new Date("2013", "11", "6", 8, 0),
                 backgroundColor: "#a460b3",
                 allDay: false,
                 description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-warning"></div><div class="cal_shiftfive_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_shiftfive_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_shiftfive_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-warning"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
             },
              {
                  title: 'AM Shift',
                  start: new Date("2013", "11", "6", 10, 0),
                  end: new Date("2013", "11", "6", 18, 0),
                  backgroundColor: "#a460b3",
                  allDay: false,
                  description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
              },
               {
                   title: 'AM Shift',
                   start: new Date("2013", "11", "7", 14, 0),
                   end: new Date("2013", "11", "7", 22, 0),
                   backgroundColor: "#74b86e",
                   allDay: false,
                   description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
               },
             {
                 title: 'AM Shift',
                 start: new Date("2013", "11", "7", 3, 0),
                 end: new Date("2013", "11", "7", 12, 0),
                 backgroundColor: "#74b86e",
                 allDay: false,
                 description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
             },
              {
                  title: 'AM Shift',
                  start: new Date("2013", "11", "15", 0, 30),
                  end: new Date("2013", "11", "15", 9, 30),
                  backgroundColor: "#94b86e",
                  allDay: false,
                  description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
              },
               {
                   title: 'AM Shift',
                   start: new Date("2013", "11", "17", 2, 0),
                   end: new Date("2013", "11", "17", 11, 0),
                   backgroundColor: "#74b86e",
                   allDay: false,
                   description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
               },
                 {
                     title: 'AM Shift',
                     start: new Date("2013", "11", "29", 2, 30),
                     end: new Date("2013", "11", "29", 11, 30),
                     backgroundColor: "#94b86e",
                     allDay: false,
                     description: '<ul><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Akthar</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Asif</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Ajmal</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Raffiq</div></li> <li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Irfan</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Jaffer</div></li><li onclick="ProEmp()"><div class="cal_newshift_img label-success"></div><div class="cal_amshift_txt">Kamran</div></li></ul>'
                 }
        ]
    });
    $('#calendar .myClass, #calendar .fc-event-title').css("cursor", "pointer");
});

function ProEmp() {

    $("#liClicks").val("1");
    $("#eventPropPop").load("Properties_Employee_Pop_Temp.html");
    $("#eventPropPop").show();
}
