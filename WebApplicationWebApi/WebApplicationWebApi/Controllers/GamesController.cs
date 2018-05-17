using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationWebApi.Models;

namespace WebApplicationWebApi.Controllers
{
    public class GamesController : ApiController
    {
        ApplicationContext context = new ApplicationContext();
        
        //get
        //api/player/2/games
        [Route("api/player/{playerId}/games")]
        public IHttpActionResult GetGamesByPlayerId(int playerId) {
            List<Game> games = 
                context
                .Games
                .Where(g => g.PlayerId == playerId)
                .ToList();
            if (games == null)
                return NotFound();
            return Ok(games);
        }

        //post
        public IHttpActionResult Post(Game game) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            context.Games.Add(game);

            context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = game.Id }, game);
        }
    }
}
