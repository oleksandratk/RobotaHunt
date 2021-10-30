using System.Collections.Generic;

namespace RobotaHunt.Core.Models
{
    public class Company
    {
        private ICollection<Vacancy> _vacancies = new List<Vacancy>();
        public int Id { get; set; }
        public string Title { get; set; }
        public int VacanciesCount => Vacancies.Count;

        public ICollection<Vacancy> Vacancies
        {
            get => _vacancies;
            set => _vacancies = value;
        }
    }
}