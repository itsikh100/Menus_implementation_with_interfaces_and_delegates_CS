using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class DateOperation : IMenuOperation
    {
        public void Operate()
        {
            Program.WriteAndClear(DateTime.Today.ToShortDateString());
        }
    }
}
