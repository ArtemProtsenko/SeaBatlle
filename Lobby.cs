using System;

namespace SeaBatlle
{
    public class Lobby
    {
        public void SummonLobby()
        {
            Game game = new Game();
            
            while(true)
            {
                Console.WriteLine("This game have 2 types of Player:");
                Console.WriteLine("Human and Bot.");
                Console.WriteLine("Set Player 1:");
                game.playerOneCreature = Console.ReadLine();
                Console.WriteLine("Set Player 2:");
                game.playerTwoCreature = Console.ReadLine();
                if (game.playerOneCreature != "human" && game.playerOneCreature != "Human" && game.playerOneCreature != "bot" &&
                    game.playerOneCreature != "Bot" || game.playerTwoCreature != "human" && game.playerTwoCreature != "Human" &&
                    game.playerTwoCreature != "bot" && game.playerTwoCreature != "Bot")
                {
                    Console.WriteLine("Please enter existing types of player.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
        }
        
    }
}