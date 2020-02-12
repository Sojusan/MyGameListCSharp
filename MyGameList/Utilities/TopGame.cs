using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary;

namespace MyGameList.Utilities
{
    public class TopGame : Game
    {
        public double score { get; set; }
        public TopGame (Game game)
        {
            this.Id = game.Id;
            this.Title = game.Title;
            this.Studio_Id = game.Studio_Id;
            this.Publisher = game.Publisher;
            this.Image = game.Image;
            this.Premiere = game.Premiere;
            this.Description = game.Description;
            this.DateOfAddiction = game.DateOfAddiction;
            this.IsAccepted = game.IsAccepted;
            this.score = MainWindow.client.GetGameScore(game.Id);
        }
    }
}
