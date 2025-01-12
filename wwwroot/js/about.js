const carouselItems = document.querySelectorAll('.carousel-item');
let currentIndex = 0;

function showNextItem() {
    carouselItems[currentIndex].classList.remove('active');
    currentIndex = (currentIndex + 1) % carouselItems.length;
    carouselItems[currentIndex].classList.add('active');
}

// Check if it is the first element
if (currentIndex === 0) {
    carouselItems[0].classList.add('active');
}

setInterval(showNextItem, 7000); // Change the element every 7 seconds
