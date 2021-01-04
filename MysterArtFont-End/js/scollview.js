document.addEventListener("DOMContentLoaded", function() {
    // var avatar = document.querySelectorAll('img.avatar');
    // var avatar = avatar[0];
    var avatar = document.getElementById('avatar');
    var text_avatar = document.getElementById('text_avatar');

    //Truy xuất div menu
    var trangthai = "duoi800";
    window.addEventListener("scroll", function() {
        var x = pageYOffset;
        if (x > 800) {
            if (trangthai == "duoi800") {
                trangthai = "tren800";
                avatar.style.width = '12%';
                avatar.style.height = 'auto';
                avatar.style.transition = 'all 0.5s';
                text_avatar.style.display = 'none';
            }
        } else {
            if (trangthai == "tren800") {
                avatar.style = 'avatar';
                text_avatar.style.display = 'block';
                trangthai = "duoi800";
            }
        }

    })
})