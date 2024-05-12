using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Data.Common.DataConstants;

namespace GameZone.Data.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitileMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = null!;

        [Required]
        public string PublisherId { get; set; } = string.Empty;
        [Required]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        public DateTime ReleasedOn { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public ICollection<GamerGame> GamersGames { get; set; } = new List<GamerGame>();

    }
}
//•	Has Id – a unique integer, Primary Key
//•	Has Title – a string with min length 2 and max length 50 (required)
//•	Has Description – string with min length 10 and max length 500 (required)
//•	Has ImageUrl – nullable string
//•	Has PublisherId – string (required)
//•	Has Publisher – IdentityUser (required)
//•	Has ReleasedOn– DateTime with format " yyyy-MM-dd" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//•	Has GenreId – integer, foreign key (required)
//•	Has Genre – Genre (required)
//•	Has GamersGames – a collection of type GamerGame
