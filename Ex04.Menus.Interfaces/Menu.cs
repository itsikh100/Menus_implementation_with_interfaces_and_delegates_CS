using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Menu : MenuItem
    {
        private List<MenuItem> m_MenuItems;
        private bool m_MenuIsRunning;
        protected string m_ExitMenuDescription;

        public Menu(string i_Description) : base(i_Description)
        {
            m_MenuItems = new List<MenuItem>();
            Description = i_Description;
            m_MenuIsRunning = false;

            SetExitMenuDescription();

            ExitMenuOperation exitOperation = new ExitMenuOperation(this);
            AddOperation(exitOperation, m_ExitMenuDescription);
        }

        public void AddItemToMenu(MenuItem i_MenuItem)
        {
            m_MenuItems.Add(i_MenuItem);
        }

        internal override void Show()
        {
            m_MenuIsRunning = true;
            while (m_MenuIsRunning)
            {
                showMenuItems();
                int userChoice = this.getItemChoice();
                m_MenuItems[userChoice].Show();
            }
        }

        private int getItemChoice()
        {
            bool choiceValid = false;
            string userInput;
            int itemChoice = 0;

            while (!choiceValid)
            {
                Console.WriteLine("Please choose one of the options");
                userInput = Console.ReadLine();
                bool isInteger = int.TryParse(userInput, out itemChoice);
                bool inBound = itemChoice >= 0 && itemChoice < m_MenuItems.Count;

                if (!isInteger || !inBound)
                {
                    Console.WriteLine("Input must be number and between 0 to {0}", m_MenuItems.Count);
                }
                else
                {
                    choiceValid = true;
                }
            }

            return itemChoice;
        }

        private void showMenuItems()
        {
            int indexOfItems = 0;
            Console.Clear();
            Console.WriteLine("{0} :", Description);

            foreach (MenuItem item in m_MenuItems)
            {
                Console.WriteLine("{0}. {1}", indexOfItems, item.Description);
                indexOfItems++;
            }
        }

        public void AddOperation(IMenuOperation i_Operation, string i_OperationDescription)
        {
            MenuOperation newOperation = new MenuOperation(i_Operation, i_OperationDescription);
            AddItemToMenu(newOperation);
        }

        public Menu AddSubMenu(string i_Description)
        {
            Menu newMenu = new Menu(i_Description);
            AddItemToMenu(newMenu);

            return newMenu;
        }

        protected virtual void SetExitMenuDescription()
        {
            m_ExitMenuDescription = "Back";
        }

        internal class ExitMenuOperation : IMenuOperation
        {
            private Menu m_menu;

            internal ExitMenuOperation(Menu i_Menu)
            {
                m_menu = i_Menu;
            }

            public void Operate()
            {
                m_menu.m_MenuIsRunning = false;
            }
        }
    }
}
