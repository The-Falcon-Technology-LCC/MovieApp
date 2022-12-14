#nullable disable
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Model
{
    public class Director
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string DobString => DOB.ToString("dd. MM. yyyy.");
    }
}
