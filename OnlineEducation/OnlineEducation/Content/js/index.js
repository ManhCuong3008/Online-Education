let a = $(window).height() - 130 - $("footer").height();
$("body > section").css("min-height", a);
$(document).ready(function () {

    let current_language = localStorage.getItem("language") || "VN";
    $(".language input:checkbox").prop("checked", current_language == "EN");

    let language = $.parseJSON(
        $.ajax({
            url: "https://admin.davidfc.vn/api/en",
            async: false,
        }).responseText
    );
    let languageHeader = $.parseJSON(
        $.ajax({
            url: "https://admin.davidfc.vn/api/header",
            async: false,
        }).responseText
    );

    //

    // console.log(current_language);
    //
    $(".language input:checkbox").change(function () {
        if ($(this).is(":checked")) {
            current_language = "EN";
        } else {
            current_language = "VN";
        }
        updateLanguage();
    });

    updateLanguage();

    function updateLanguage() {
        localStorage.setItem("language", current_language);
        // console.log(current_language);

        $(`[data-language]`).each(function () {
            let id = $(this).data("language");
            let a = language.find((x) => x.id == id);
            if (a) {
                $(this).text(a[current_language == "VN" ? "vie_title" : "eng_title"]);
            }
        });

        $(`[data-language-placeholder]`).each(function () {
            let id = $(this).data("language-placeholder");
            let a = language.find((x) => x.id == id);
            if (a) {
                $(this).attr(
                    "placeholder",
                    a[current_language == "VN" ? "vie_title" : "eng_title"]
                );
            }
        });

        $(`[data-language-header]`).each(function () {
            let id = $(this).data("language-header");
            let a = languageHeader.find((x) => x.id == id);
            if (a) {
                $(this).text(a[current_language == "VN" ? "title" : "title_eng"]);
            }
        });

        $(`[data-language-categories]`).each(function () {
            if (current_language != "VN" && $(this).data("language-categories-eng")) {
                $(this).text($(this).data("language-categories-eng"));
            } else {
                $(this).text($(this).data("language-categories"));
            }
        });
    }

    $("#default_click").each(function () {
        this.click();
    });

    function findAndReplace(source, replace) {
        var text = "/" + source + "/g";
        document.body.innerHTML = document.body.innerHTML.replace(text, replace);
    }

    function myFunction(p1, p2) {
        return p1 * p2; // The function returns the product of p1 and p2
    }
});

//#region NAV
if (document.querySelectorAll("#nav").length > 0) {
    //animation
    window.addEventListener("scroll", function (e) {
        let nav = document.getElementById("nav");
        if (window.pageYOffset < nav.offsetHeight && window.screen.width > 550) {
            nav.classList.add("nav-ul-no-shadow");
        } else {
            nav.classList.remove("nav-ul-no-shadow");
        }
    });
    // collapse
    document
        .getElementById("nav-collapse")
        .addEventListener("click", function (e) {
            document.querySelector("ul.ul.mb").classList.toggle("ul-active");
        });
}

//#endregion NAV

//#region HEADER
if (document.querySelectorAll(".hd-header").length > 0) {
    // collapse
    document
        .getElementById("menu-collapse-btn")
        .addEventListener("click", function (e) {
            document
                .getElementById("all-menu")
                .classList.toggle("hd-active-all-menu");
        });
    document
        .getElementById("menu-collapse-btn")
        .addEventListener("mouseover", function (e) {
            document
                .getElementById("all-menu")
                .classList.add("hd-active-all-menu");
        });
    document
        .getElementById("all-menu")
        .addEventListener("mouseover", function (e) {
            document
                .getElementById("all-menu")
                .classList.add("hd-active-all-menu");
        });
    document
        .getElementById("all-menu")
        .addEventListener("mouseout", function (e) {
            document
                .getElementById("all-menu")
                .classList.remove("hd-active-all-menu");
        });

    // slideshow
    $(".hd-slider-header").slick({
        autoplay: true,
        autoplaySpeed: 1800,
        focusOnSelect: false,
    });

}

//#endregion HEADER

//#region FOOTER
if (document.querySelectorAll("footer.footer").length > 0) {
    // slideshow
    $(".slider-footer").slick({
        dots: true,
        infinite: false,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        responsive: [
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                },
            },
        ],
    });

    // collapse
    document
        .getElementById("div1__collaspe")
        .addEventListener("click", function (e) {
            document.getElementById("div1__collaspe").classList.toggle("active");
            document.getElementById("wrapper").classList.toggle("active");
        });
}
//#endregion FOOTER

//#region HOMEPAGE
if (document.querySelectorAll("body.homepage").length > 0) {
    // SLIDER
    $(".homepage.slider-content1").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        // autoplay: true,
        // autoplaySpeed: 1800,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".homepage.slider-content2").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        // autoplay: true,
        // autoplaySpeed: 1800,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".homepage.slider-content3").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 4,
        // autoplay: true,
        // autoplaySpeed: 1800,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".homepage.slider-content4").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        // autoplay: true,
        // autoplaySpeed: 1800,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".homepage.slider-content5").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        // autoplay: true,
        // autoplaySpeed: 1800,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".homepage.slider-content6").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        // autoplay: true,
        // autoplaySpeed: 1800,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".homepage.slider-content7").on('init', function (event, slick) {
        function u() {
            let width = slick.slideWidth - 8;
            let track = slick.$slideTrack[0];
            $(track).children("div").each(function (k, v) {
                $(v).css("height", width / 3 * 2);
            });
        }
        setTimeout(u, 1);
    }).on('reInit', function (event, slick) {
        let width = slick.slideWidth - 8;
        let track = slick.$slideTrack[0];
        $(track).children("div").each(function (k, v) {
            $(v).css("height", width / 3 * 2);
        });
    }).on('breakpoint', function (event, slick, breakpoint) {
        let width = slick.slideWidth - 8;
        let track = slick.$slideTrack[0];
        $(track).children("div").each(function (k, v) {
            $(v).css("height", width / 3 * 2);
        });
    }).slick({
        dots: false,
        infinite: true,
        speed: 300,
        slidesToShow: 6,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 1800,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    arrows: false
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    arrows: false
                },
            },
        ],
    });
}
//#endregion HOMEPAGE

//#region CHI TIET KHOA HOC
if (document.querySelectorAll("body.ctkh").length > 0) {
    //Collapse for sidebar
    let barClArr = document.querySelectorAll(".ctkh.bar-1 .bar-content ul li");
    for (let i = 0; i < barClArr.length; i++) {
        barClArr[i].addEventListener("click", function (e) {
            e.currentTarget.lastElementChild.classList.toggle(
                "ctkh-active-list-wrapper"
            );
            e.currentTarget.firstElementChild.lastElementChild.classList.toggle(
                "ctkh-active-collaspe-btn-bar"
            );
        });
    }

    //Collapse for syllabus
    let lstCtr = document.querySelectorAll(
        ".ctkh.ctn-sn-2 .ctr .lst-ctr .syllabus .li"
    );
    for (let i = 0; i < lstCtr.length; i++) {
        const ele = lstCtr[i];
        ele.addEventListener("click", function (e) {
            let currentTarget = e.target;
            while (currentTarget.classList) {
                if (currentTarget.classList.contains("chapter")) {
                    e.currentTarget.classList.toggle("active");
                    break;
                }
                currentTarget = currentTarget.parentNode;
            }
        });
    }

    //Collapse for tab Tình huống
    let lstSituation = document.querySelectorAll(
        ".ctkh.ctn-sn-2 .ctr .lst-ctr .situation .li"
    );
    for (let i = 0; i < lstSituation.length; i++) {
        const ele = lstSituation[i];
        ele.addEventListener("click", function (e) {
            let currentTarget = e.target;
            while (currentTarget.classList) {
                if (currentTarget.classList.contains("chapter")) {
                    e.currentTarget.classList.toggle("active");
                    break;
                }
                currentTarget = currentTarget.parentNode;
            }
        });
    }

    //Chuyển tab Mô tả - bnh lun - nh giá
    let btnsArr = document.querySelectorAll(".ctkh.ctn-sn-2 .mt-bl-dg .btns li");
    for (let i = 0; i < btnsArr.length; i++) {
        const ele = btnsArr[i];
        ele.addEventListener("click", function (e) {
            btnsArr.forEach((e) => {
                e.classList.remove("active");
            });
            e.currentTarget.classList.toggle("active");
            document.querySelectorAll(".para").forEach((e) => {
                e.classList.remove("active");
            });
            document.querySelectorAll(".para")[i].classList.toggle("active");
        });
    }

    //Chuyển tab bài hc - tnh huống - luật mi - tho lun
    let ctrBtnsArr = document.querySelectorAll(".ctn-sn-2 .ctr .btns li");
    for (let i = 0; i < ctrBtnsArr.length; i++) {
        const ele = ctrBtnsArr[i];
        ele.addEventListener("click", function (e) {
            ctrBtnsArr.forEach((e) => {
                e.classList.remove("active");
            });
            e.currentTarget.classList.toggle("active");
            document.querySelectorAll(".lst-ctr").forEach((e) => {
                e.classList.remove("active");
            });
            document.querySelectorAll(".lst-ctr ")[i].classList.toggle("active");
        });
    }

    //Hiu ng khi chọn gi khóa học
    let opsArr = document.querySelectorAll(".op a");
    for (let i = 0; i < opsArr.length; i++) {
        const ele = opsArr[i];
        ele.addEventListener("click", function (e) {
            opsArr.forEach((e) => {
                e.classList.remove("active");
            });
            e.currentTarget.classList.toggle("active");

            // set price for title.
            var main_price = e.currentTarget.getAttribute("data-price-type");
            var virtual_price = e.currentTarget.getAttribute("data-virtual-type");
            $("#main_price").html(main_price);
            $("#virtual_price").html(virtual_price);

            // url resolve here.
            // $("#btn-buy-payment").prop("href", "https://google.com.vn");

            // not.

            document.getElementById("nof-not-choose").style.display = "none";
        });
    }
    if ($("#btn-buy").length > 0) {
        document.getElementById("btn-buy").addEventListener("click", function (e) {
            if (!document.querySelector(".op a.active")) {
                document.getElementById("nof-not-choose").style.display = "block";
            }
        });
    }

    //modal hin ln lc click bình luận nhưng cha đăng nhập

    if ($("#btn-comment").length > 0) {
        let btnComment = document.getElementById("btn-comment");
        btnComment.addEventListener("click", function () {
            //if (!Auth){
            document.getElementById("modal-comment").classList.toggle("active");
            document.querySelector(".layer-modal").classList.toggle("active");
            //}
            //else{}
        });
    }
    if ($("[data-rating-login]").length > 0) {
        $("[data-rating-login]").click(function () {
            //if (!Auth){
            document.getElementById("modal-rating").classList.toggle("active");
            document.querySelector(".layer-modal").classList.toggle("active");
            //}
            //else{}
        });
    }
    //Tt modal bng nt x
    let mdClose = document.getElementById("md-close");
    mdClose.addEventListener("click", function () {
        document.getElementById("modal-comment").classList.toggle("active");
        document.querySelector(".layer-modal").classList.toggle("active");
    });

    //Slider
    $(".ctkh.slider-content1").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        // autoplay: true,
        // autoplaySpeed,: 2000,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".ctkh.slider-content2").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        // autoplay: true,
        // autoplaySpeed,: 2000,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".ctkh.slider-content3").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        // autoplay: true,
        // autoplaySpeed,: 2000,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".ctkh.slider-content4").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 4,
        // autoplay: true,
        // autoplaySpeed,: 2000,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
}
//#endregion CHI TIET KHOA HOC

//#region HOC ONLINE
if (document.querySelectorAll("body.hoconline").length > 0) {
    //Collapse Cau hoi tinh huong
    let lstSituation = document.querySelectorAll(
        ".hoconline.lst-ctr .situation .li"
    );
    for (let i = 0; i < lstSituation.length; i++) {
        const ele = lstSituation[i];
        ele.addEventListener("click", function (e) {
            let currentTarget = e.target;
            while (currentTarget.classList) {
                if (currentTarget.classList.contains("chapter")) {
                    e.currentTarget.classList.toggle("active");
                    break;
                }
                currentTarget = currentTarget.parentNode;
            }
        });
    }
    //Switch Tab
    let btnsArr = document.querySelectorAll(".hoconline.sn--right .tabs .tab");
    for (let i = 0; i < btnsArr.length; i++) {
        const ele = btnsArr[i];
        ele.addEventListener("click", function (e) {
            btnsArr.forEach((e) => {
                e.classList.remove("active");
            });
            e.currentTarget.classList.toggle("active");
            document.querySelectorAll(".hoconline.tab-ct").forEach((e) => {
                e.classList.remove("active");
            });
            document
                .querySelectorAll(".hoconline.tab-ct")
            [i].classList.toggle("active");
        });
    }
}
//#endregion HOC ONLINE

//#region TRANG CA NHAN VA CAI DAT
if (document.querySelectorAll("body.tcnvcd").length > 0) {
    // Slider
    // $(".tcnvcd.slider-content1").slick({
    //   dots: true,
    //   speed: 500,
    //   slidesToShow: 3,
    //   slidesToScroll: 3,
    //   rows: 2,
    //   responsive: [
    //     {
    //       breakpoint: 815,
    //       settings: {
    //         rows: 1,
    //         slidesToShow: 2,
    //         slidesToScroll: 1,
    //       },
    //     },
    //     {
    //       breakpoint: 480,
    //       settings: {
    //         rows: 3,
    //         slidesToShow: 1,
    //         slidesToScroll: 1,
    //         slidesPerRow: 1,
    //       },
    //     },
    //   ],
    // });
    $(".tcnvcd.slider-content2").slick({
        dots: true,
        speed: 500,
        slidesToShow: 3,
        slidesToScroll: 3,
        autoplay: true,
        autoplaySpeed: 2000,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
}
//#endregion TRANG CA NHAN VA CAI DAT

//#region DANH SACH TIN TUC
if (document.querySelectorAll("body.dstt").length > 0) {
    //SLIDER
    $(".dstt.slider-content4").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        autoplay: true,
        autoplaySpeed: 2500,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".dstt.slider-1").slick({
        dots: true,
        infinite: false,
        speed: 300,
        slidesToShow: 3.5,
        slidesToScroll: 3,
        centerMode: false,
    });

    $(".dstt.slider-2").slick({
        dots: true,
        infinite: false,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 4,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                },
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                },
            },
        ],
    });
    if (window.screen.width <= 600) {
        $(".bar-1").slick({
            dots: true,
            infinite: true,
            speed: 300,
            responsive: [
                {
                    breakpoint: 601,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 3,
                    },
                },
            ],
        });
    }
}
//#endregion DANH SACH TIN TUC


//#region KHOA HOC
if (document.querySelectorAll("body.khoahoc").length > 0) {
    //SLIDER
    if (window.screen.width <= 600) {
        $(".bar-1").slick({
            dots: false,
            infinite: true,
            speed: 300,
            responsive: [
                {
                    breakpoint: 601,
                    settings: {
                        slidesToShow: 3.05,
                        slidesToScroll: 3,
                    },
                },
            ],
        });
    }
    $(".khoahoc.slider-content1").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
}
//#endregion KHOA HOC


//#region TIN TUC CHI TIET
if (document.querySelectorAll("body.ttct").length > 0) {
    $(".ttct.slider-content4").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        autoplay: true,
        autoplaySpeed: 2500,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".ttct.slider-1").slick({
        dots: true,
        infinite: false,
        speed: 300,
        slidesToShow: 3.5,
        slidesToScroll: 3,
        centerMode: false,
    });

    $(".ttct.slider-2").slick({
        dots: true,
        infinite: false,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                },
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1.2,
                    slidesToScroll: 1,
                },
            },
        ],
    });
}
//#endregion TIN TUC CHI TIET

//#region TIN TUC THEO DANH MUC
if (document.querySelectorAll("body.tttdm").length > 0) {
    //SLIDER
    $(".tttdm.slider-content4").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        autoplay: true,
        autoplaySpeed: 2500,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".tttdm.slider-1").slick({
        dots: true,
        infinite: false,
        speed: 300,
        slidesToShow: 3.5,
        slidesToScroll: 3,
        centerMode: false,
    });

    $(".tttdm.slider-2").slick({
        dots: true,
        infinite: false,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                },
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1.2,
                    slidesToScroll: 1,
                },
            },
        ],
    });
}
//#endregion TIN TUC THEO DANH MUC

//#region DANG KY KHOA HOC
if (document.querySelectorAll("body.dkkh").length > 0) {
    //SCROLL TO DIV AFTER PAGE LOAD
    $(document).ready(function () {
        // Handler for .ready() called.
        $('html, body').animate({
            scrollTop: $('.form-ctn').offset().top - 60
        }, 'fast');
    });
    //SLIDER
    $(".dkkh.slider-content1").slick({
        dots: true,
        infinite: false,
        speed: 300,
        slidesToShow: 1,
        slidesToScroll: 1,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    //
    let opsArr = document.querySelectorAll(".op a");
    var package_input = 0;
    for (let i = 0; i < opsArr.length; i++) {
        const ele = opsArr[i];
        ele.addEventListener("click", function (e) {
            opsArr.forEach((e) => {
                e.classList.remove("active");
            });
            e.currentTarget.classList.toggle("active");
            var main_price = e.currentTarget.getAttribute("data-price-type");
            var package = e.currentTarget.getAttribute("data-package-type");
            package_input = package;
            $("#main_price").html(main_price);

            document.getElementById("nof-not-choose").style.display = "none";
        });
    }

    $("#btn-buy").click(function () {
        // console.log(package_input);

        let _token = $('meta[name="csrf-token"]').attr("content");

        $.ajax({
            url: route("confirmCourse"),
            type: "POST",
            data: {
                package: package_input,
                _token: _token,
            },
            beforeSend: function () {
                if ($('#nof-not-choose:visible').length == 0) {
                    let timerInterval
                    Swal.fire({
                        title: 'Đang tiến hành đăng ký!',
                        html: 'Bạn vui lòng đợi  <b></b> giây.',
                        timer: 10000,
                        timerProgressBar: true,
                        didOpen: () => {
                            Swal.showLoading()
                            timerInterval = setInterval(() => {
                                const content = Swal.getContent()
                                if (content) {
                                    const b = content.querySelector('b')
                                    if (b) {
                                        b.textContent = (Swal.getTimerLeft() / 1000).toFixed(0)
                                    }
                                }
                            }, 100)
                        },
                        willClose: () => {
                            clearInterval(timerInterval)
                        }
                    }).then((result) => {
                        /* Read more about handling dismissals below */
                        if (result.dismiss === Swal.DismissReason.timer) {
                            console.log('Đã đóng!')
                        }
                    })

                }
            },
            success: function (response) {
                // console.log(response);
                if (response) {
                    // refresh browser.
                    var url = window.location.href;
                    window.location.href = url; //Will take you to alert box.
                }
            },
        });
    });

    document.getElementById("btn-buy").addEventListener("click", function (e) {
        e.preventDefault();
        if (!document.querySelector(".op a.active")) {
            document.getElementById("nof-not-choose").style.display = "block";
        } else {
        }
    });
}
//#endregion DANG KY KHOA HOC

//#region KHOA HOC MEMBER
if (document.querySelectorAll("body.khmb").length > 0) {
    let btnsArr = document.querySelectorAll(".khmb.sn--right .tabs .tab");
    for (let i = 0; i < btnsArr.length; i++) {
        const ele = btnsArr[i];
        ele.addEventListener("click", function (e) {
            btnsArr.forEach((e) => {
                e.classList.remove("active");
            });
            e.currentTarget.classList.toggle("active");
            document.querySelectorAll(".khmb.tab-ct").forEach((e) => {
                e.classList.remove("active");
            });
            document.querySelectorAll(".khmb.tab-ct")[i].classList.toggle("active");
        });
    }

    document
        .getElementById("btn-sidebar")
        .addEventListener("click", function (e) {
            document.querySelector(".khmb.sn.sn--right").classList.toggle("active");
            document.getElementById("btn-sidebar").classList.toggle("active");
        });

    //Collapse
    let lstSituation = document.querySelectorAll(".lst-ctr .situation .li");
    for (let i = 0; i < lstSituation.length; i++) {
        const ele = lstSituation[i];
        ele.addEventListener("click", function (e) {
            let currentTarget = e.target;
            while (currentTarget.classList) {
                if (currentTarget.classList.contains("chapter")) {
                    e.currentTarget.classList.toggle("active");
                    break;
                }
                currentTarget = currentTarget.parentNode;
            }
        });
    }
    //SLIDER
    $(".slider-content1").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        autoplay: true,
        autoplaySpeed: 2000,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
    $(".slider-content2").slick({
        dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        autoplay: true,
        autoplaySpeed: 2000,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1.05,
                    slidesToScroll: 1,
                },
            },
        ],
    });
}
//#endregion KHOA HOC MEMBER

// #region LIEN HE
if (document.querySelectorAll("body.lienhe").length > 0) {
    $(".slider-content1").slick({
        dots: true,
        infinite: false,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 4,
        responsive: [
            {
                breakpoint: 815,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                },
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                },
            },
        ],
    });
}

//#endregion LIEN HE

//#region KHOA HOC OFFLINE
if (document.querySelectorAll("body.khoff").length > 0) {
    const btnDetailArr = document.querySelectorAll("td > button.khoff.btn.btn-primary");
    btnDetailArr.forEach(b => {
        b.addEventListener("click", function (e) {
            document.getElementById("ngaytochuc").value = b.dataset.date;
            document.getElementById("hinhthuc").value = b.dataset.type;
            document.getElementById("diadiem").value = b.dataset.location;
            document.getElementById("giangvien").value = b.dataset.customertype;
            document.getElementById("chitiet").innerText = b.dataset.description;
            document.getElementById("giave").value = b.dataset.price;
        })
    })
}

//#endregion KHOA HOC OFFLINE

//#region AN/HIEN NAV-TOP
if ($("#nav .nav-top").length > 0) {
    //$("#nav .nav-top").addClass("hidden");
    let current_position = $(window).scrollTop();
    $(document).scroll(function () {
        var scroll = $(window).scrollTop();
        if (scroll <= current_position) {
            // Scrolling up
            $("#nav .nav-top").removeClass("hidden");
        } else {
            // Scrolling down
            $("#nav .nav-top").addClass("hidden");
        }
        current_position = scroll;
    });
}
//#endregion AN/HIEN NAV-TOP

$("[data-target-dropdown]").click(function (e) {
    // e.preventDefault();
    // let target = $(this).data("target-dropdown");
    // $(target).toggleClass("show");
    // $(`.hd-menu__li_dropdown:not(${target})`).removeClass("show");

});