using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class TimeOperation : IMenuOperation
    {
        public void Operate()
        {
            Program.WriteAndClear(DateTime.Now.ToShortTimeString());
        }
    }
}
