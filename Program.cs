using System;
using System.Reflection.Metadata;

namespace SeaBatlle
{
    class Program
    {
        static void Main()
        {
            Lobby lobby = new Lobby();
            Game game = new Game();
            lobby.SummonLobby();
            game.GamingProcess();
            game.GameEnd();
        }
    }
}