window.onload = function() {

    var x = document.getElementsByClassName(".effect_box");
    var y = document.getElementsByClassName(".effect_small");
    var z = document.getElementsByClassName(".service_img");
    var i;
    $('.box_service').hover(function() {

        for (i = 0; i < x.length; i++) {
            x[i].style.border = "2px solid rgba(255, 255, 255, 0.3)";
            x[i].style.transition = " 0.5s";
            x[i].style.width = "99%";
            x[i].style.height = "99%";
            y[i].style.transition = "0.5s";
            y[i].style.border = "0px solid rgba(255, 255, 255, 0.1)";
            y[i].style.width = "99%";
            y[i].style.height = "99%";
            // z[i].style.transition = "1s all";
            // z[i].style.backgroundSize = "cover";
            // z[i].style.transition = "background 1s ";
        }

    }, function() {

        for (i = 0; i < x.length; i++) {
            x[i].style.border = "30px solid rgba(255, 255, 255, 0.3)";
            x[i].style.transition = " 0.5s";
            x[i].style.width = "85.5%";
            x[i].style.height = "80%";
            y[i].style.transition = "0.5";
            y[i].style.border = "10px solid white";
            y[i].style.width = "93.7%";
            y[i].style.height = "91%";
            // z[i].style.transition = "2s all";
            // z[i].style.backgroundSize = "450px auto";
            // z[i].style.transition = "background 1s";

        }
    });
};