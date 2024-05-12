using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static GameZone.Data.Common.DataConstants;

namespace GameZone.Models
{
    public class GameAddViewModel
    {

        [Required(ErrorMessage =RequireErrorMessage)]
        [StringLength(TitileMaxLength,MinimumLength = TitileMinLength,ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(DescriptionMaxLength,MinimumLength =DescriptionMinLength,ErrorMessage =StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;


        [Required(ErrorMessage = RequireErrorMessage)]
        public string ReleasedOn { get; set; } = string.Empty;

        [Required]
        public string PublisherId { get; set; } = string.Empty;

        [Required]
        public IdentityUser Publisher { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; } = new HashSet<GenreViewModel>();

        
    }
}
