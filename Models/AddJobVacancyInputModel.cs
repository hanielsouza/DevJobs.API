namespace DevJobs.API.Models
{
    public record AddJobVacancyInputModel(
        string Title,
        string Description,
        string Complany,
        bool IsRemote,
        string SalaryRange)
    {
    }
}
