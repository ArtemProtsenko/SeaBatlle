using System;

namespace SeaBatlle
{
    public class Game
    {
        private static int height = 9;
        private static int width = 9;
        public string[,] playerOneField = new string[width,height]; 
        public string[,] playerTwoField = new string[width,height];

        private int playerOneShipsLeft = 20;
        private int playerTwoShipsLeft = 20;
        
        Random Rand = new Random();
        
        int playerOneShootX = 1;
        int playerOneShootY = 1;
        int playerTwoShootX = 1;
        int playerTwoShootY = 1;

        public string playerOneCreature;
        public string playerTwoCreature;

        private int playerOneWins = 0;
        private int playerTwoWins = 0;

        public void GamingProcess()
        {
            SetPlayers();
            while(true)
            {
                if (playerOneWins != 3 || playerTwoWins != 3)
                {
                    Round(); 
                }
                else
                {
                    break;
                }
            }
        }

        void Round()
        {
            do
            {
                Turn(playerOneCreature, playerOneShootX, playerOneShootY, playerTwoField, playerTwoShipsLeft);
                Console.ReadLine();
                Turn(playerTwoCreature, playerTwoShootX, playerTwoShootY, playerOneField, playerOneShipsLeft);
                Console.ReadLine();
            } while (playerTwoShipsLeft > 0 && playerOneShipsLeft > 0);
            RoundEnd();
        }

        void SetPlayers()
        {
            SetField(playerOneField);
            SetField(playerTwoField);
            SetPlayerOneShips(playerOneField);
            SetPlayerTwoShips(playerTwoField);
        }

        void DrawGameTurn()
        {
            Instructions();
            Console.WriteLine("");
            DrawField(playerOneField, playerOneCreature);
            Console.WriteLine("");
            DrawField(playerTwoField, playerTwoCreature);
        }

        void Turn(string playerCreature, int playerShootX, int playerShootY, string[,] enemyField, int playerShipsLeft)
        {
            DrawGameTurn();
            PlayerInput(playerCreature, ref playerShootX, ref playerShootY);
            Shoot(playerShootX, playerShootY, enemyField, ref playerShipsLeft);
            Console.Clear();
        }
        
        void Instructions()
        {
            Console.Clear();
            Console.WriteLine("This is Sea Battle. there are 2 axis: x & y.");
            Console.WriteLine("x - horizontal, y - vertical.");
            Console.WriteLine("Write first coordinate x from 1 to 9, then press enter and write y.");
            Console.WriteLine("# - you hit ship, ^ - miss.");
            Console.WriteLine("Good luck!");
        }

        public void SetField(string[,] Field)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (Field[j, i] == "@") {}
                        else
                        {
                            Field[j, i] = "Y";
                        }
                    }
                }
            }
        
        public void SetPlayerOneShips(string[,] Field)
            {
                SetPlayerOneCarrier(Field);
                SetPlayerOneCruiser(Field);
                SetPlayerOneBattleShip(Field);
                SetPlayerOneDestroyer(Field);
            }

        public void SetPlayerTwoShips(string[,] Field)
            {
                SetPlayerTwoCarrier(Field);
                SetPlayerTwoCruiser(Field);
                SetPlayerTwoBattleShip(Field);
                SetPlayerTwoDestroyer(Field);
            }

        void SetPlayerOneCarrier(string[,] Field)
        {
            Field[0, 1] = "@";
            Field[1, 1] = "@";
            Field[2, 1] = "@";
            Field[3, 1] = "@";
        }

        void SetPlayerOneCruiser(string[,] Field)
        {
            Field[5, 0] = "@";
            Field[6, 0] = "@";
            Field[7, 0] = "@";
            
            Field[6, 8] = "@";
            Field[7, 8] = "@";
            Field[8, 8] = "@";
        }

        void SetPlayerOneBattleShip(string[,] Field)
        {
            Field[0, 7] = "@";
            Field[0, 8] = "@";
            
            Field[8, 2] = "@";
            Field[8, 3] = "@";
            
            Field[1, 5] = "@";
            Field[2, 5] = "@";
        }

        void SetPlayerOneDestroyer(string[,] Field)
        {
            Field[1, 3] = "@";
            
            Field[5, 2] = "@";
            
            Field[6, 4] = "@";
            
            Field[7, 6] = "@";
        }
        

        void SetPlayerTwoCarrier(string[,] Field)
        {
            Field[1, 0] = "@";
            Field[1, 1] = "@";
            Field[1, 2] = "@";
            Field[1, 3] = "@";
        }
        

        void SetPlayerTwoCruiser(string[,] Field)
        {
            Field[0, 5] = "@";
            Field[0, 6] = "@";
            Field[0, 7] = "@";
            
            Field[8, 6] = "@";
            Field[8, 7] = "@";
            Field[8, 8] = "@";
        }
        

        void SetPlayerTwoBattleShip(string[,] Field)
        {
            Field[7, 0] = "@";
            Field[8, 0] = "@";
            
            Field[2, 8] = "@";
            Field[3, 8] = "@";
            
            Field[5, 1] = "@";
            Field[5, 2] = "@";
        }
        

        void SetPlayerTwoDestroyer(string[,] Field)
        {
            Field[3, 1] = "@";
            
            Field[2, 5] = "@";
            
            Field[4, 6] = "@";
            
            Field[6, 7] = "@";
        }

        void DrawField(string[,] Field, string playerCreature)
        {
            if (playerOneCreature == "human" || playerOneCreature == "Human" && playerTwoCreature == "human" || playerTwoCreature == "Human")
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (Field[j, i] == "#" || Field[j, i] == "^")
                        {
                            Console.Write(Field[j, i]);
                        }
                        else
                        {
                            Console.Write("Y");
                        }
                    }
                    Console.WriteLine("");
                }
            }
            else if (playerOneCreature == "bot" || playerOneCreature == "Bot" && playerTwoCreature == "bot" || playerTwoCreature == "Bot")
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Console.Write(Field[j, i]);
                    }
                    Console.WriteLine("");
                }
            }
            else if (playerCreature == "human" || playerCreature == "Human")
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Console.Write(Field[j, i]);
                    }
                    Console.WriteLine("");
                }
            }
            else
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (Field[j, i] == "#" || Field[j, i] == "^")
                        {
                            Console.Write(Field[j, i]);
                        }
                        else
                        {
                            Console.Write("Y");
                        }
                    }
                    Console.WriteLine("");
                }
            }
            
        }

        void PlayerInput(string playerCreature, ref int playerShootX, ref int playerShootY)
        {
            if (playerCreature == "human" || playerCreature == "Human")
            {
                playerShootX = Convert.ToInt32(Console.ReadLine()) - 1;
                playerShootY = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            else
            {
                playerShootX = Rand.Next(0, width);
                playerShootY = Rand.Next(0, height);
            }
        }

        void Shoot(int x, int y, string[,] Field, ref int shipsLeft)
        {
            if (Field[x, y] == "@")
            {
                Field[x, y] = "#";
                shipsLeft--;
            }
            else if (Field[x, y] == "Y")
            {
                Field[x, y] = "^";
            }
        }

        void RoundEnd()
        {
            if (playerTwoShipsLeft <= 0)
            {
                Console.Clear();
                Console.WriteLine("Player 1 won that round!!!");
                playerOneWins++;
            }
            else if (playerOneShipsLeft <= 0)
            {
                Console.Clear();
                Console.WriteLine("Player 2 won that round!!!");
                playerTwoWins++;
            }

            Console.ReadLine();
        }

        public void GameEnd()
        {
            if (playerOneWins == 3)
            {
                Console.Clear();
                Console.WriteLine("Player 1 won the game!!!");
            }
            else if (playerTwoWins == 3)
            {
                Console.Clear();
                Console.WriteLine("Player 2 won the game!!!");
            }
        }
        
    }
}