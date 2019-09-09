using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        public string Description { get; }

        public int ItemNumberInMenu { get; }

        public event Action<MenuItem> EventHandlerWhenChosen;

        public MenuItem(string i_Description, int i_ItemNumberInMenu)
        {
            Description = i_Description;
            ItemNumberInMenu = i_ItemNumberInMenu;
        }

        public void ChooseItem()
        {
            OnItemChosen();
        }

        protected void OnItemChosen()
        {
            if (EventHandlerWhenChosen != null)
            {
                EventHandlerWhenChosen.Invoke(this);
            }
        }
    }
}
