using GameStore.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Web.Controllers
{
    public class GameGroupController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IGameGroupService _gameGroupService;

        public GameGroupController(IGameService gameService, IGameGroupService gameGroupService)
        {
            _gameService = gameService;
            _gameGroupService = gameGroupService;
        }

        [Route("games/{id}/{title}")]
        public async Task<IActionResult> Index(int id, string title, int page)
        {
            return View(Tuple.Create(
                await _gameGroupService.FindAsync(id),
                _gameService.GetGamesByGroupId(id, page)
                ));
        }

        public IActionResult LoadProductDetail(int id)
        {
            return PartialView("GameDetail", _gameService.GetGameDetail(id));
        }
    }
}
