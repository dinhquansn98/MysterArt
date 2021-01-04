window.onload = function() {
    loadData();
}



function loadData() {

    $.ajax({
        url: "https://localhost:44373/GetColection",
        method: "get",
        data: "", // tham so truyen vao
        contenttype: "application/json",
        datatype: "",
        success: function(response) {
            var i = 0
            $.each(response, function(index, item) {
                var html = "<button class='colection_box'>" +
                    "<img src='" + item.LinkAvartar + "' class='conlection_img'></img>" +
                    "<h2 style='color: white;'>" + item.Name + "</h2>" +
                    "</button>"

                switch (i) {
                    case 0:
                        $('.colection_column1').append(html);
                        i = i + 1;
                        break;
                    case 1:
                        $('.colection_column2').append(html);
                        i = i + 1;
                        break;
                    case 2:
                        $('.colection_column3').append(html);
                        i = i - 2;
                        break;
                }
            })

        }
    });
}