using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    internal class Room
    {
        Client player1;
        Client player2;
        Game game;
        int numberOfPlayers;
        string roomID;

        public Client Player1 { get { return player1; } }
        public Client Player2 { get { return player2; } }
        
        public Game GameProperty { get { return game; } }
        public int NumberOfPlayers { get { return numberOfPlayers; } }
        public string RoomID { get { return roomID; } }

        public static Room RoomInstance { get; set; }

        public Room(Client player, string ID)
        {
            this.player1 = player;
            this.roomID = ID;
            this.numberOfPlayers = 1;
        }

        public Room(Client player1, Client player2, string ID, string guessedWord)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.roomID = ID;
            this.numberOfPlayers = 2;
            StartGame(guessedWord);
        }

        public void AddPlayer(Client player, string guessedWord)
        {
            this.player2 = player;
            this.numberOfPlayers++;
            if (numberOfPlayers == 2)
            {
                StartGame(guessedWord);
            }
        }

        public void RemovePlayer(Client player)
        {
            this.player2 = null;
        }
        private void StartGame(string guessedWord)
        {
            game = new Game(player1, player2, guessedWord);
        }
    }
}
