import Swiper from 'https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.esm.browser.min.js'

const swiper = new Swiper('.for-clients__slider', {
    // Стрелки
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev'
    },
    // Навигация
    // Буллеты, текущее положение, прогрессбар
    pagination: {
        el: '.swiper-pagination',
        // Буллеты
        clickable: true,
        // Размер точеу
        //dynamicBullets: false,
    },
    slidesPerView: 2,
    // Отступ между слайдами
    spaceBetween: 41,
    // Подстраиваемая высота
    //autoHeight: true,
})