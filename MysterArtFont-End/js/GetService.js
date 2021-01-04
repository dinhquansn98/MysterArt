window.onload = function() {
    loadData();
}



function loadData() {

    $.ajax({
        url: "https://localhost:44373/GetService",
        method: "get",
        data: "", // tham so truyen vao
        contenttype: "application/json",
        datatype: "",
        success: function(response) {
            $.each(response, function(index, item) {
                var html = "<button class='box_service" + "'>" +
                    "<div class='service_img' style='background-image: url(" + item.LinkAvartar + "');'>" +
                    "<div class='effect_box'>" +
                    "  <div class='effect_small'></div>" +
                    "</div>" +
                    "</div>" +
                    "</button>"
                $('.service').append(html)

            })

        }
    });
}