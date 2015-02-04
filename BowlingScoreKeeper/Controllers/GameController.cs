using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http;
using BowlingScoreKeeper.Infrastructure;

namespace BowlingScoreKeeper.Controllers
{
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private static Game game = new Game(new[] {"No name"});
      
        [Route("players")]
        public void PutPlayers(string[] players)
        {
            Contract.Requires(players != null);
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
