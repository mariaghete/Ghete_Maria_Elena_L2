using System.ComponentModel.DataAnnotations;

namespace Ghete_Maria_Elena_L2.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Navigation property pentru cărțile asociate
        public ICollection<Book>? Books { get; set; }
    }
}
