using BowlingScoreKeeper.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BowlingScoreKeeper.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private static Game game = new Game(new[] {"fdfdfd", "gd  ljk"});
      
        [Route("players")]
        public void PutPlayers(string[] players)
        {
            game = new Game(players);
        }

        [Route("players")]
        public IEnumerable<string> GetPlayers(string[] players)
        {            
            return game.Players;
        }
        
        [Route("score")]
        public void PutScore(int frameIndex, RollRecord[] records)
        {
            Contract.Requires(frameIndex >= 0 && frameIndex <= Constants.FramesTotal);
            Contract.Requires(records != null);
            game.UpdateRollRecord(frameIndex, records);
        }        
    }
}
