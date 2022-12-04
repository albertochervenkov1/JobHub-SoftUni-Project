using JobHub.Core.Models.Job;

namespace JobHub.Models
{
    public class AllJobsQueryModel
    {
        public const int JobsPerPage = 10;
        public string? Category { get; set; }

        public string? SearchTerm { get; set; }
        public JobSorting Sorting { get; set; }
        public int TotalJobsCount { get; set; }
        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<AllJobsViewModel> Jobs { get; set; } = Enumerable.Empty<AllJobsViewModel>();
    }
}
