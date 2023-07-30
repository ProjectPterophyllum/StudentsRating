namespace StudentsRating
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; } 
        public string FullName => $"{LastName} {FirstName}";

        public override string ToString()
        {
            return Id +"." + FullName + ", Возраст: [" + Age + "]"; 
        }
    }
}
