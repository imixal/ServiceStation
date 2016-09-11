
$(document).ready(function () {
    $("#refresh-order").click(function () {
        $("#preloder").show();
        $.get("Home/RefreshOrder").done(function (data) {
            $("#preloder").hide();
            $("#Orders-wrapper").empty().html(data);
            $("button[data-target='#Changelist']").click(function () {
                $("#modal-body-changelist").attr("data-id", $(this).attr("data-id"));
                $("#modal-body-changelist").attr("data-client-Id", $(this).attr("data-client-Id"));
                $("#InputDatelist").val($(this).parent().prev().prev().prev().prev().text());
            });
            $("#changelist-button").click(function () {
                $("#preloder").show();
                $.post("Home/ChangeOrder", { "orderId": $("#modal-body-changelist").attr("data-id"), "orderAmount": $("#InputAmountlist").val(), "status": $("#InputStatuslist").val(), "clientId": $("#modal-body-changelist").attr("data-client-Id") }).done(function (data) {
                    $("#preloder").hide();
                    $(".modal-backdrop").detach();
                    $("body").css("overflowY", "scroll");
                    $("#refresh-order").trigger("click");
                });
            });
        });
    });
    $("#refresh-auto").click(function () {
        $("#preloder").show();
        $.get("Home/RefreshAuto").done(function (data) {
            $("#preloder").hide();
            $("#Automobiles-wrapper").empty().html(data);
            $("#deletelist-button").click(function () {
                $("#preloder").show();
                $.post("Home/DeleteAuto", { "autoId": $("#modal-body-deletelist").attr("data-id"), "clientId": $("#modal-body-deletelist").attr("data-client-Id") }).done(function (data) {
                    $("#preloder").hide();
                    $(".modal-backdrop").detach();
                    $("body").css("overflowY", "scroll");
                    $("#refresh-auto").trigger("click");

                });
            });
            $("button[data-target='#Deletelist']").click(function () {
                var has = $(this).parent().prev().text() == "Yes";
                if (has) {
                    $("#modal-body-deletelist").empty().text("You can't delete car, because  car has order.");
                    $("#deletelist-button").hide();
                }
                else {
                    $("#modal-body-deletelist").attr("data-id", $(this).attr("data-id"));
                    $("#modal-body-deletelist").attr("data-client-Id", $(this).attr("data-client-Id"));
                    $("#modal-body-deletelist").empty().text("Are you sure?");
                    $("#deletelist-button").show();
                }
            });
        });
    });
    $(function () {
        $('#InputDateofBirth').datetimepicker({
            viewMode: 'years',
            format: 'YYYY/MM/DD'
        });
    });
    $("#Register").click(function () {
        $("#Registration-wrapper").empty();
        $("#preloder").show();
        $.get("Home/Register", { "FirstName": $("#InputFName").val(), "LastName": $("#InputLName").val(), "DateOfBirht": $("#InputDateofBirth").val(), "Address": $("#InputAddress").val(), "Phone": $("#InputPhone").val(), "Email": $("#InputEmail").val() })
        .done(function (data) { UserView(data) });
    });
    $("button[data-target='#Changelist']").click(function () {
        $("#modal-body-changelist").attr("data-id", $(this).attr("data-id"));
        $("#modal-body-changelist").attr("data-client-Id", $(this).attr("data-client-Id"));
        $("#InputDatelist").val($(this).parent().prev().prev().prev().prev().text());
    });
    $("#changelist-button").click(function () {
        $("#preloder").show();
        $.post("Home/ChangeOrder", { "orderId": $("#modal-body-changelist").attr("data-id"), "orderAmount": $("#InputAmountlist").val(), "status": $("#InputStatuslist").val(), "clientId": $("#modal-body-changelist").attr("data-client-Id") }).done(function (data) {
            $("#preloder").hide();
            $(".modal-backdrop").detach();
            $("body").css("overflowY", "scroll");
            $("#refresh-order").trigger("click");

        });
    });
    $("#deletelist-button").click(function () {
        $("#preloder").show();
        $.post("Home/DeleteAuto", { "autoId": $("#modal-body-deletelist").attr("data-id"), "clientId": $("#modal-body-deletelist").attr("data-client-Id") }).done(function (data) {
            $("#preloder").hide();
            $(".modal-backdrop").detach();
            $("body").css("overflowY", "scroll");
            $("#refresh-auto").trigger("click");

        });
    });
    $("button[data-target='#Deletelist']").click(function () {
        var has = $(this).parent().prev().text() == "Yes";
        if (has) {
            $("#modal-body-deletelist").empty().text("You can't delete car, because  car has order.");
            $("#deletelist-button").hide();
        }
        else {
            $("#modal-body-deletelist").attr("data-id", $(this).attr("data-id"));
            $("#modal-body-deletelist").attr("data-client-Id", $(this).attr("data-client-Id"));
            $("#modal-body-deletelist").empty().text("Are you sure?");
            $("#deletelist-button").show();
        }
    });
    $("#Check").click(function () {
        var FName = $("#InputName").val();
        var LName = $("#InputSurname").val();
        $("#Registration-wrapper").empty();
        $("#preloder").show();
        $.get("Home/Check", { 'FName': FName, 'LName': LName }).done(function (data) {
        UserView(data)})
    });
});

function UserView  (data) {
    $("#preloder").hide();
    $("#Registration-wrapper").html(data);
    $(".Go-Account").click(function () {
        var id = $(this).attr("data-id");
        var name = $(this).attr("data-name");
        var surname = $(this).attr("data-surname");
        $("#preloder").show();
        $.get("Home/GetAccount", { "Id": id }).done(function (data) {
            $("#Registration").removeClass("active").removeClass("in");
            $("#Registration-tab").removeClass("active");
            $("#Account-tab").addClass("active");
            $("#Account-tab a").text("Account " + name + " " + surname);
            $("#Account").addClass("in").addClass("active");
            $("#preloder").hide();
            $("#Account-wrapper").empty().append(data);
            UpdateUser()
            $("#refresh-auto").trigger("click");
        });
    });
};
function UpdateUser() {
    $('#InputNewDate').datetimepicker({
            viewMode: 'years',
            format: 'YYYY/MM/DD'
        });
    $("button[data-target='#Delete']").click(function () {
        var has = $(this).parent().parent().next().next().hasClass("order");
        if (has) {
            $("#modal-body-delete").empty().text("You can't delete car, because  car has order.");
            $("#delete-button").hide();
        }
        else {
            $("#modal-body-delete").attr("data-id", $(this).attr("data-id"));
            $("#modal-body-delete").empty().text("Are you sure?");
            $("#delete-button").show();
        }
    });
    $("button[data-target='#Change']").click(function () {
        $("#modal-body-change").attr("data-id", $(this).attr("data-id"));
        $("#InputDate").val($(this).parent().prev().prev().prev().text());
    });
    $("button[data-target='#DeleteOrder']").click(function () {
        $("#modal-body-delete-order").attr("data-id", $(this).attr("data-id"));
        $("#InputDate").val($(this).parent().prev().prev().prev().text());
    });
    $("button[data-target='#AddOrder']").click(function () {
        $("#modal-body-addOrder").attr("data-id", $(this).attr("data-id"));
    });
    $("#AddCar-button").click(function () {
        if ($.isNumeric($("#InputYear").val())){
        $("#preloder").show();
        $.post("Home/AddAuto", { "Make": $("#InputMake").val(), "Model": $("#InputModel").val(), "Year": $("#InputYear").val(), "VIN": $("#InputVIN").val(), "clientId": $("table").attr("data-Id") }).done(function (data) {
            $("#preloder").hide();
            $(".modal-backdrop").detach();
            $("body").css("overflowY","scroll");
            $("#Account-wrapper").empty().append(data);
            UpdateUser();
       
        });
        }
        else alert("Year must be Number")
    });
    $("#delete-button").click(function () {
        $("#preloder").show();
        $.post("Home/DeleteAuto", { "autoId": $("#modal-body-delete").attr("data-id"), "clientId": $("table").attr("data-Id") }).done(function (data) {
            $("#preloder").hide();
            $(".modal-backdrop").detach();
            $("body").css("overflowY", "scroll");
            $("#Account-wrapper").empty().append(data);
            UpdateUser();
        });
    });
    $("#change-button").click(function () {
        $("#preloder").show();
        $.post("Home/ChangeOrder", { "orderId":$("#modal-body-change").attr("data-id"),"orderAmount": $("#InputAmount").val(), "status": $("#InputStatus").val(), "clientId": $("table").attr("data-Id") }).done(function (data) {
            $("#preloder").hide();
            $(".modal-backdrop").detach();
            $("body").css("overflowY", "scroll");
            $("#Account-wrapper").empty().append(data);
            UpdateUser();
        });
    });
    $("#delete-order-button").click(function () {
        $("#preloder").show();
        $.post("Home/DeleteOrder", { "orderId": $("#modal-body-delete-order").attr("data-id"), "clientId": $("table").attr("data-Id") }).done(function (data) {
            $("#preloder").hide();
            $(".modal-backdrop").detach();
            $("body").css("overflowY", "scroll");
            $("#Account-wrapper").empty().append(data);
            UpdateUser();
            $(".closer").trigger('click');

        });
    });
    $("#addOrder-button").click(function () {
        $("#preloder").show();
        $.post("Home/AddOrder", { "date": $("#InputNewDate").val(), "amount": $("#InputNewAmount").val(), "status": $("#InputNewStatus").val(), "clientId": $("table").attr("data-Id"), "autoId": $("#modal-body-addOrder").attr("data-id") }).done(function (data) {
            $("#preloder").hide();
            $(".modal-backdrop").detach();
            $("body").css("overflowY", "scroll");
            $("#Account-wrapper").empty().append(data);
            UpdateUser();
        });
    });

};