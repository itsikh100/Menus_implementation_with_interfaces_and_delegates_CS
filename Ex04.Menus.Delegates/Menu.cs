using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class Menu
    {
        private readonly List<Menu> r_SubMenusList = new List<Menu>();
        public string m_ExitOrBack;

        public Dictionary<MenuItem, Action> Items { get; }

        private string Description { get; }

        public Menu(string i_Description)
        {
            Description = i_Description;
            Items = new Dictionary<MenuItem, Action>();
            SetFirstItem();
        }

        protected virtual void SetFirstItem()
        {
            m_ExitOrBack = "Back";
        }

        private void printMenu()
        {
            Console.Clear();

            Console.WriteLine(Description + ":");
            string firstLine = "0 : " + m_ExitOrBack;
            Console.WriteLine(firstLine);

            foreach (KeyValuePair<MenuItem, Action> item in Items)
            {
                Console.WriteLine(string.Format("{0} : {1}", item.Key.ItemNumberInMenu, item.Key.Description));
            }
        }

        private bool tryGetChoiceFromUser(out int i_UsersChoice)
        {
            Console.WriteLine("Please choose one of the options");
            string input = Console.ReadLine();
            int currChoice;
            bool choiceValid = true;
            bool isFormatValid = int.TryParse(input, out currChoice);
            if (!isFormatValid || currChoice < 0 || currChoice > Items.Count)
            {
                choiceValid = false;
            }

            i_UsersChoice = currChoice;

            return choiceValid;
        }

        protected void ShowMenu()
        {
            while (true)
            {
                printMenu();
                int userChoice;
                bool validInput;

                do
                {
                    validInput = tryGetChoiceFromUser(out userChoice);
                    if (!validInput)
                    {
                        Console.WriteLine("Input is not valid.");
                    }
                }
                while (!validInput);

                if (userChoice != 0)
                {
                    foreach (KeyValuePair<MenuItem, Action> item in Items)
                    {
                        if (item.Key.ItemNumberInMenu == userChoice)
                        {
                            item.Key.ChooseItem();
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public void AddActionMenuItem(string i_Description, Action i_FunctionToInvoke)
        {
            MenuItem newMenuItem = new MenuItem(i_Description, Items.Count + 1);
            newMenuItem.EventHandlerWhenChosen += menuItem_Chosen;
            Items.Add(newMenuItem, i_FunctionToInvoke);
        }

        public Menu AddSubMenuItem(string i_Description)
        {
            r_SubMenusList.Add(new Menu(i_Description));
            MenuItem newMenuItem = new MenuItem(i_Description, Items.Count + 1);
            newMenuItem.EventHandlerWhenChosen += menuItem_Chosen;
            Items.Add(newMenuItem, r_SubMenusList[r_SubMenusList.Count - 1].ShowMenu);

            return r_SubMenusList[r_SubMenusList.Count - 1];
        }

        private void menuItem_Chosen(MenuItem i_MenuItem)
        {
            Action functionToInvoke;
            Items.TryGetValue(i_MenuItem, out functionToInvoke);
            functionToInvoke.Invoke();
        }
    }
}
