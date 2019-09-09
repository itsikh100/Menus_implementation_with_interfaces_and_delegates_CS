using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountDigitsOperation : IMenuOperation
    {
        public void Operate()
        {
            int numOfDigits = 0;
            string senteceFromUser = Program.getSentenceFromUser();

            foreach(char ch in senteceFromUser)
            {
                if(char.IsDigit(ch))
                {
                    numOfDigits++;
                }
            }

            string AnswerFoeUser = string.Format("The numbers of Digits in your sentence is {0}", numOfDigits);
            Program.WriteAndClear(AnswerFoeUser);
        }
    }
}
