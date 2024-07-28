using Microsoft.EntityFrameworkCore;
using ReviewApp_InWebApi.Data;
using ReviewApp_InWebApi.Interfaces;
using ReviewApp_InWebApi.Model;

namespace ReviewApp_InWebApi.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;

        public ReviewerRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Review> GetAllReviewsByReviewer(int reviewerId)
        {
            return _context.Reviews.Where(r=>r.Reviewer.Id==reviewerId).ToList();
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _context.Reviewers.Where(r => r.Id == reviewerId).Include(e => e.Reviews).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _context.Reviewers.Any(x => x.Id == reviewerId);
        }
    }
}
