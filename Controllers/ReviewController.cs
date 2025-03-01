﻿using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Authorize(Roles = "Admin,Basic")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IBookService _bookService;

        public ReviewController(IReviewService reviewService, IUserService userService, UserManager<User> userManager, IBookService bookService)
        {
            _reviewService = reviewService;
            _userService = userService;
            _userManager = userManager;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index(string isbn)
        {
            var reviews = _reviewService.GetReviewsByBookISBN(isbn);
            var reviewViewModels = new List<ReviewViewModel>();

            foreach (var review in reviews)
            {
                var user = await _userManager.FindByIdAsync(review.IdUser);
                var reviewViewModel = new ReviewViewModel
                {
                    Review = review,
                    UserName = user.UserName
                };
                reviewViewModels.Add(reviewViewModel);
            }

            ViewData["ISBN"] = isbn;
            var book = _bookService.GetBookByISBN(isbn);
            ViewBag.BookTitle = book.Title;

            return View(reviewViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(Review review, string isbn)
        {
            try
            { // Validate if the review content is empty or if the rating is less than 1 star
                if (string.IsNullOrWhiteSpace(review.Content) || review.Rating < 1)
                {
                    ModelState.AddModelError("", "The review must contain a description and at least one star.");
                    return RedirectToAction("Index", new { isbn });
                }

                var currentUser = _userService.GetCurrentUser();

                // Assign the current user to the review object
                review.User = currentUser;
                review.IdUser = currentUser.Id;
                review.BookISBN = isbn;
                _reviewService.AddReview(review);
                return RedirectToAction("Index", new { isbn });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { isbn });
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteReview(int id, string isbn)
        {
            try
            {
                _reviewService.DeleteReview(id);
                return RedirectToAction("Index", new { isbn });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { isbn });
            }
        }
    }

    public class ReviewViewModel
    {
        public Review Review { get; set; }
        public string UserName { get; set; }
    }
}
