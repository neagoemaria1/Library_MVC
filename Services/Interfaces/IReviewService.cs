using Library.Models;
using System.Collections.Generic;

namespace Library.Services.Interfaces
{
    public interface IReviewService
    {
        List<Review> GetAllReviews();
        void AddReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int id);
    }
}