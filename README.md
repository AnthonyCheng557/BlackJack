# Blackjack Game 

A Razor Pages web application that simulates a Blackjack game. The project demonstrates object-oriented C# programming with models for **Cards, Deck, and Game Logic**, combined with Razor Pages for stateless rendering.

## Technologies Used  

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white) ![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white) ![ASP.NET](https://img.shields.io/badge/asp.net-%231572B6.svg?style=for-the-badge&logo=dotnet&logoColor=white) ![Razor Pages](https://img.shields.io/badge/razor%20pages-512BD4.svg?style=for-the-badge&logo=blazor&logoColor=white) ![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white) ![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)  

## Demo  

### Initial Game Screen  
- Dealer and Player both receive two cards.  
- Player decides whether to **Hit** or **Stand**.  

### Player Hits  
- A new card is drawn.  
- If the player goes over 21, it’s a **Bust**.  

### Dealer Plays  
- Dealer draws until reaching 17 or higher.  
- Game logic decides the winner: **Player**, **Dealer**, or **Tie**.  

*(You can insert screenshots here using GitHub’s image upload just like in your Health Dashboard project.)*  

## Features  

- Full Blackjack game logic implemented in **C#**  
- Deck and Card models with suits, ranks, and values  
- Razor Pages UI with card images rendered dynamically  
- Player actions: **Hit**, **Stand**, and **New Game**  
- Dealer follows house rules (draw until 17 or higher)  
- Results displayed clearly: *Player Wins, Dealer Wins, Tie, or Bust*  
- State management across HTTP requests using **TempData** and JSON serialization  

## Project Structure   

- **Models**
  - `Card.cs` -> Represents a playing card
  - `Deck.cs` -> Manages a deck of 52 cards
  - `BlackjackGame.cs` -> Core game logic  

- **Pages**
  - `Blackjack.cshtml` -> Razor markup for UI
  - `Blackjack.cshtml.cs` -> PageModel: handles game state & actions  

- **wwwroot**
  - `Images/` -> Card images (Hearts, Diamonds, Clubs, Spades)  


## How It Works  

1. **Start Game**  
   - Both player and dealer are dealt two cards.  

2. **Player Turn**  
   - Click **Hit** to draw another card.  
   - Click **Stand** to end your turn.  

3. **Dealer Turn**  
   - Dealer auto-draws until reaching 17 or higher.  

4. **Results**  
   - The winner is decided and displayed.  
   - Option to **Start New Game**. 


