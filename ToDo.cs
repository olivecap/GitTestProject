namespace TPToDoList
{
    public class ToDo
    {
        //---------------
        // Variables
        //----------------
        // Title
        public string Title { get; set; }

        // Id
        public int Id { get; set; }

        // Start date
        public DateTime StartDate { get; }

        // End date
        public DateTime? EndDate { get; set;  }

        //---------------
        // Constructor
        //----------------
        public ToDo(string title, int id)
        {
            Title = title;
            Id = id;
            StartDate = DateTime.Now;
            EndDate = null;
        }
    }
}
