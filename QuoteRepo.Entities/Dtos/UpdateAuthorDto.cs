using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuoteRepo.Entities.Core;

namespace QuoteRepo.Entities.Dtos
{
    public class UpdateAuthorDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
