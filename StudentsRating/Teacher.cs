
namespace StudentsRating
{
    public class Teacher:Person
    {
        public Subject Subject { get; set; }
        public override string ToString()
        {
            return base.ToString() + ", Предмет: [" + Subject +"]";
        }
    }
}
