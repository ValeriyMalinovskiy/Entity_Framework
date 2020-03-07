namespace StudentLibrary.DAL.Model
{
    public class Book
    {
        public virtual int Id { get; set; }

        public virtual string Titile { get; set; }

        public virtual string Author { get; set; }

        public virtual int Year { get; set; }

        public virtual int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
