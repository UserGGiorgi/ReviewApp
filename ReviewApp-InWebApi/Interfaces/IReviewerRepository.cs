﻿using ReviewApp_InWebApi.Model;

namespace ReviewApp_InWebApi.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetAllReviewsByReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);
    }
}
