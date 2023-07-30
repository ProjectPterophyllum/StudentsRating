using System.Data;

namespace StudentsRating
{
    public class MenuItem
    {
        public string Title { get; }
        public MenuItem(string Name)
        {
            Title = Name;
        }
    }
    public class MenuCategory : MenuItem
    {
        public MenuItem[] Items { get; }
        public MenuCategory(string Name, MenuItem[] Items) : base(Name)
        {
            this.Items = Items;
        }
    }
    public class MenuAction : MenuItem
    {
        public Action<MenuItem> Action { get; }
        public MenuAction(string Name, Action<MenuItem> action) : base(Name)
        {
            Action = action;
        }
        public static void SomeActionMethod(MenuItem menuItem)
        {
            Console.WriteLine($"Вы нажали: {menuItem.Title}");
        }
    }
    public class MenuBack : MenuItem
    {
        public MenuBack(string Name = "Назад") : base(Name) { }
    }
    public class Menu
    {
        private MenuCategory _current;
        public Menu(MenuCategory root)
        {
            _current = root;
        }
        public void RunMenu()
        {
            Stack<MenuCategory> wayBack = new Stack<MenuCategory>();
            var index = 0;
            var left = 0;
            var top = 15;
            while (true)
            {
                DrawMenu(0, 1, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < _current.Items.Length - 1)
                            index++;
                        else
                            index = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        else
                            index = _current.Items.Length - 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (_current.Items[index])
                        {
                            case MenuCategory category:
                                wayBack.Push(_current);
                                index = 0;
                                _current = category;
                                Console.Clear();
                                break;
                            case MenuAction action:
                                Console.Clear();
                                Console.SetCursorPosition(left, top);
                                action.Action(action);
                                break;
                            case MenuBack:
                                if (wayBack.Count == 0)
                                    return;
                                MenuCategory parent = wayBack.Pop();
                                index = Array.IndexOf(parent.Items, _current);
                                _current = parent;
                                Console.Clear();
                                break;
                            default:
                                throw new InvalidCastException("Error, unknown item menu");
                        }
                        break;
                }

            }
        }
        private void DrawMenu(int row, int col, int index)
        {
            Console.SetCursorPosition(row, col);
            Console.WriteLine(_current.Title);
            Console.WriteLine();
            for (int i = 0; i < _current.Items.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(_current.Items[i].Title);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
