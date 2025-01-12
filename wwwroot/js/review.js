document.addEventListener("DOMContentLoaded", function () {
    // Select all elements with class 'review'
    const reviews = document.querySelectorAll(".review");

    reviews.forEach(review => {
        const rating = parseInt(review.querySelector(".rating").getAttribute("data-rating"));
        const stars = review.querySelectorAll(".rating i");

        stars.forEach((star, index) => {
            if (index < rating) {
                star.classList.add("bx", "bxs-star-filled");
            } else {
                star.classList.add("bx", "bxs-star");
            }
        });
    });
});

// Select all stars used for rating input
const allStar = document.querySelectorAll('.rating .star');
const ratingValue = document.querySelector('.rating input');

// Add a click event to each star
allStar.forEach((item, idx) => {
    item.addEventListener('click', function () {
        let click = 0;
        ratingValue.value = idx + 1;

        allStar.forEach(i => {
            i.classList.replace('bxs-star', 'bx-star');
            i.classList.remove('active');
        });

        // Iterate through the stars again and color them up to the pressed star
        for (let i = 0; i < allStar.length; i++) {
            if (i <= idx) {
                allStar[i].classList.replace('bx-star', 'bxs-star');
                allStar[i].classList.add('active');
            } else {
                allStar[i].style.setProperty('--i', click);
                click++;
            }
        }
    });
});