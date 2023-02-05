using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]

        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
