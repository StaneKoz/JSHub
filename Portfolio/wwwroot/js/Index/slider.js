import Swiper from 'https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.esm.browser.min.js'

const swiper = new Swiper('.for-clients__slider', {
    // �������
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev'
    },
    // ���������
    // �������, ������� ���������, �����������
    pagination: {
        el: '.swiper-pagination',
        // �������
        clickable: true,
        // ������ �����
        //dynamicBullets: false,
    },
    slidesPerView: 2,
    // ������ ����� ��������
    spaceBetween: 41,
    // �������������� ������
    //autoHeight: true,
})