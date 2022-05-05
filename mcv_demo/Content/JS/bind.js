////$(document).ready(function () {
 
////    $('#demo').multiselect({
////        showCheckbox: true,
////    });

////});
////var getHobbies = function () {
////    $.ajax({
////        url: "../Student/gethobbies",
////        method: "post",
////        //data: JSON.stringify(model),
////        contentType: "application/json;charset=utf-8",
////        dataType: "json",
////        async: false,
////        success: function (response) {
////            var html = "";
////            $("#ddlhobbies").empty();
////            $.each(response.model, function (index, elementValue) {
////                html += "<option value='" + elementValue.Hobbies + "'>" + elementValue.Hobbies_name + " </option>"
////            });
////            $("#ddlhobbies").append(html);
////            //$("#ddlhobbies").multiselect;

////        }
////    })
////}