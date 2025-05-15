document.addEventListener("DOMContentLoaded", function () {
    const swiper = new Swiper(".swiper", {
        direction: "horizontal",
        loop: true,
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        scrollbar: {
            el: ".swiper-scrollbar",
        },
    });
});


function toggleMobileMenu() {
    document.querySelector(".mobile-menu").classList.toggle("open");
}


console.log(document.querySelector(".teesstt"));


document
    .querySelector(".teesstt")
    .addEventListener("click", toggleMobileMenu);

document
    .querySelector(".teesstt")
    .addEventListener("click", () => {

        console.log("clicked")
    });