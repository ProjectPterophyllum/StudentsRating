namespace StudentsRating
{
    public class Student:Person
    { 
        public string Group {get; set;}
    public override string ToString()
        {
            return base.ToString() + ", Группа: [" + Group + "]";
        }
    }
}
