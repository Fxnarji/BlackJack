using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BlackJack
{
    public class Player
    {
        public event Action<GameEndState, Player> LostGame;
        
        protected List<Card> cards { get; set; }
        public int CardCount;
        public int PlayerNumber;


        public Player(int i)
        {
            PlayerNumber = i;
        }
        public void Draw(Generator g)
        {
            Card cardPulled = g.Draw();
            if(cardPulled._face == CardFace.Ace)
                CardCount += 11;
            else
                CardCount += (int)cardPulled._face;

            if (CardCount >= 21)
            {
                LostGame.Invoke(GameEndState.PlayerLost, this);
            }

            Console.WriteLine(cardPulled.ToString());
        }

        public override string ToString()
        {
            return PlayerNumber.ToString();
        }
    }

}