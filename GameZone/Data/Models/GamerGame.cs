using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace GameZone.Data.Models
{
    public class GamerGame
    {
        [Required]
        public int GameId { get; set; }
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        [Required]
        public string GamerId { get; set; } = string.Empty;
        [ForeignKey(nameof(GamerId))]
        public IdentityUser Gamer { get; set; } = null!;
    }
}
//•	Has GameId – integer, PrimaryKey, foreign key (required)
//•	Has Game – Game
//•	Has GamerId – string, PrimaryKey, foreign key (required)
//•	Has Gamer – IdentityUser
