using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using static GameZone.Data.Common.DataConstants;


namespace GameZone.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
//•	Has Id – a unique integer, Primary Key
//•	Has Name – a string with min length 3 and max length 25 (required)
//•	Has Games – a collection of type Game
