namespace StudentsRating
{
    public interface ILists
    {
        public static void ShowList<T>(List<T> list)
        {
            foreach (var type in list)
            {
                Console.WriteLine(type.ToString());
                Console.WriteLine();
            }
        }
    }
}
