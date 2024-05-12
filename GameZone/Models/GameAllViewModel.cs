using Microsoft.AspNetCore.Identity;

namespace GameZone.Models.Game
{
    public class GameAllViewModel
    {
        public GameAllViewModel(int id, string title, string imageUrl, IdentityUser publisher, string genre, DateTime releasedOn)
        {
            Id = id;
            Title = title;
            ImageUrl = imageUrl;
            Publisher = publisher.ToString();
            Genre = genre;
            ReleasedOn = releasedOn.ToString(Data.Common.DataConstants.DateFormat);
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Publisher { get; set; }

        public string Genre { get; set; }
        public string ReleasedOn { get; set; }


    }
}
