using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public sealed class MainMenu : Menu
    {
        public string Description { get; }

        public MainMenu(string i_Description) : base(i_Description)
        {
            Description = i_Description;
        }

        protected override void SetFirstItem()
        {
            m_ExitOrBack = "Exit";
        }

        public new void ShowMenu()
        {
            base.ShowMenu();
        }
    }
}
