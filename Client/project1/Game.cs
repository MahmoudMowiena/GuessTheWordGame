using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    internal class Game
    {
        public Client player1 {  get; set; }
        public Client player2 { get; set; }
        public string Turn { get; set; }
        public string GuessedWord { get; set; }

        public Game(Client plyr1, Client plyr2, string guessedWord)
        {
            this.player1 = plyr1;
            this.player2 = plyr2;
            this.GuessedWord = guessedWord;
            this.Turn = "player1";
        }
    }
}
