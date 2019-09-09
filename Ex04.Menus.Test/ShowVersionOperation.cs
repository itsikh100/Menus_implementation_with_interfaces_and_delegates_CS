using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersionOperation : IMenuOperation
    {
        private const string k_CurrentVersion = "Version: 19.2.4.32";

        public void Operate()
        {
            Program.WriteAndClear(k_CurrentVersion);
        }
    }
}
