$(document).ready(function () {
    getstudentList();
    //getclass();
    //getHobbies();
    //$('.selectBox').SumoSelect({
    //});
    });
var Addstudent = function () {
    var Name = $("#txtname").val();
    var City = $("#txtdob").val();
    var Address = $("#ddlhobbie").val();
    debugger;
    var Id = $("#txtid").val();
    alert(Id);
    //var class_id = $("#ddlclass").val();
    //var Hobbies = 0;
    //var Hobbies_id = "";
    //var selectedVal = $("#ddlhobbies option:selected");

    //selectedVal.each(function () {
    //    debugger;
    //    if (Hobbies_id == 0) {
    //    Hobbies_id += $(ddlhobbies).val() + ",";}
    // else {return false}   
    //});

    //Hobbies_id = Hobbies_id.substring(0, Hobbies_id.length - 1);
    //if (Hobbies_id == "") {
    //    Hobbies_id = 0;
    //}
    //alert(Hobbies_id);
    var smodel = {
        Name: Name,City: City,Address:Address,Id:Id
    };
    //if (Hobbies == "") {
    //    Hobbies = 0;
    //}
    //if (Student_Name == "") {
    //    alert("Please enter Name");
    //    return false;
    //}
    //else if (class_id == "0") {
    //    alert("Please enter Class ");
    //    return false;
    //} 
    //else if (Hobbies == "") {
    //    alert("Please enter hobbies");
    //    return false;
    //}
  
    $.ajax({
        url: "/Student/AddStudent",
        method: "post",
        data: JSON.stringify(smodel),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        success: function (response) {
                getstudentList();
        }
    });
}
var getstudentList = function () {
    $.ajax({
        url: "/Student/liststudent",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblstudent tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id + "</td> <td>" + elementValue.Name + "</td> <td>" + elementValue.City + "</td><td>" + elementValue.Address + "</td><td><input type = 'submit' value = 'Edit' onClick ='Editdata(" + elementValue.Id + ")' /></td ></tr >";
            });
            $("#tblstudent").append(html);
            }
    })
}
//var getclass = function () {
//    $.ajax({
//        url: "../Student/getclasses",
//        method: "post",       
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        async: false,
//        success: function (response) {
//            var html = "";
//            $("#ddlclass").empty();
//            $.each(response.model, function (index, elementValue) {
//                html += "<option value='" + elementValue.class_id + "'>" + elementValue.Class_Name + " </option>"
//            });
//            $("#ddlclass").append(html);
//        }
//    })
//}
//var getHobbies = function () {
//    $.ajax({
//        url: "../Student/gethobbies",
//        method: "post",  
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        async: false,
//        success: function (response) {
//            var html = "";
//            $("#ddlhobbies").empty();
//            $.each(response.model, function (index, elementValue) {
//                html += "<option value='" + elementValue.Hobbies + "'>" + elementValue.Hobbies_name + " </option>"
//            });
//            $("#ddlhobbies").append(html);
//            $('.selectBox').SumoSelect();
            
//        }
//    })
//}
var Editdata = function (id) {
    var model = { Id: id};
    debugger;
    $.ajax({
        url: "../Student/GetEditData",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            $("#txtid").val(response.model.Id);
            $("#txtname").val(response.model.Name);
            $("#txtdob").val(response.model.City);
            $("#ddlhobbie").val(response.model.Address);
        }
    });
}