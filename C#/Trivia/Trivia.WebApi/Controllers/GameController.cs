using System;
using System.Collections.Generic;
using System.Web.Http;
using UglyTrivia;

namespace Trivia.WebApi.Controllers
{
    public class GameController : ApiController
    {
        private static Dictionary<string, Game> gamesInProgress = new Dictionary<string, Game>();

        [HttpGet]
        public string New()
        {
            var gameGuid = Guid.NewGuid().ToString();
            gamesInProgress[gameGuid] = new Game(6, new Questions(new [] { "Sports", "Rock", "Science", "Pop"}));
            return gameGuid;
        }

        [HttpPost]
        public void AddPlayer(string id, string name)
        {
            gamesInProgress[id].add(name);
        }

        [HttpPost]
        public string Roll(string id)
        {
            var dice = new Random().Next(1, 6);
            string questionAsked = null;
            Action<string> afficher = x => questionAsked = x;
            gamesInProgress[id].roll(dice, afficher);
            return questionAsked;
        }
    }
}
