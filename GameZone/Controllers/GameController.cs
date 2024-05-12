using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models;
using GameZone.Models.Game;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.Claims;

namespace GameZone.Controllers
{
    public class GameController : Controller
    {
        private readonly GameZoneDbContext context;

        public GameController(GameZoneDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> All()
        {
            var allGames = await context.Games
                .AsNoTracking()
                .Select(g => new GameAllViewModel
                (
                    g.Id,
                    g.Title,
                    g.ImageUrl,
                    g.Publisher,
                    g.Genre.Name,
                    g.ReleasedOn
                   
                )).ToListAsync();
            return View(allGames);
        }

        [HttpGet]
        public  async Task<IActionResult> Add()
        {
            var model = new GameAddViewModel();
            model.Genres = await GetGenre();
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult>Add(GameAddViewModel gameModel)
        {
            if (gameModel == null)
            {
                return View("Error");
            }

            DateTime releasedOn = DateTime.Now;
            if (!DateTime.TryParseExact(gameModel.ReleasedOn,Data.Common.DataConstants.DateFormat,CultureInfo.InvariantCulture,DateTimeStyles.None,out releasedOn))
            {
                ModelState.
                    AddModelError(nameof(gameModel.ReleasedOn), $"Invalid date!Format must be :{GameZone.Data.Common.DataConstants.DateFormat}");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            gameModel.Genres = await GetGenre();
            return View(gameModel);


            Game entity = new Game()
            {
                Title = gameModel.Title,
                ImageUrl = gameModel.ImageUrl,
                Description = gameModel.Description,
                ReleasedOn = releasedOn,
                GenreId = gameModel.GenreId,
                PublisherId = gameModel.PublisherId,
                Publisher= gameModel.Publisher
            };
            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IEnumerable<GenreViewModel>> GetGenre()
        {
            return await context.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name

                }).ToListAsync();
        }

    }
}
