
namespace StudentsRating
{
    public class Mark
    {
        public int Value { get; set; }
        private DateTime Date = DateTime.Now;
        public Teacher? Teacher { get; set; }
        public override string ToString()
        {
            return "Оценка: [" + Value.ToString() + "], Дата оценки: [" + Date.ToString() + "], Преподаватель: [" + Teacher.FullName.ToString() + "] ";
        }
    }
}
