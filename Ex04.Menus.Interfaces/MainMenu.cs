using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public sealed class MainMenu : Menu
    {
        public MainMenu(string i_Description)
            : base(i_Description)
        {
        }

        public new void Show()
        {
            base.Show();
        }

        protected override void SetExitMenuDescription()
        {
            m_ExitMenuDescription = "Exit";
        }
    }
}
