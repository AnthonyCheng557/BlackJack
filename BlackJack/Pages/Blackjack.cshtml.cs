using Microsoft.AspNetCore.Mvc.RazorPages;
using BlackjackApp.Models;

namespace BlackjackApp.Pages
{
    /// PageModel for the Blackjack Razor Page.
    /// Handles game state, player actions, and results.
    /// Extend the PageModel, it allows the HTTPs Requests
    public class BlackjackModel : PageModel
    {
        // Initialized the Blackjack game (deck, hands, etc.).
        public BlackjackGame Game { get; set; } = new BlackjackGame();
        //Store the result of the game
        public string Result { get; set; }
        //Upon recieving a Get request, start the game
        public void OnGet()
        {
            Game.Start();
        }
        //Upon recieving a Post request, handle logic
        public void OnPost(string action)
        {
            if (TempData.ContainsKey("GameState"))
            {
                //Needed to continue the game without restarting, HTTP is statless, every reload require data from past requests
                Game = System.Text.Json.JsonSerializer.Deserialize<BlackjackGame>((string)TempData["GameState"]);
            }
            else
            {
                Game.Start();
            }

            if (action == "hit")
            {
                Game.PlayerHit();
            }
            else if (action == "stand")
            {
                Game.DealerPlay();
            }
            else if (action == "new")
            {
                Game.Start();
            }

            //Start here, create a dictionary to store the results, for the next outcome
            TempData["GameState"] = System.Text.Json.JsonSerializer.Serialize(Game);
        }
    }
}

