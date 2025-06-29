using System.ComponentModel;

namespace TPToDoList
{
    public class ToDoService
    {
        //---------------
        // Variables
        //----------------
        private List<ToDo> list = new List<ToDo>();

        /// <summary>
        /// Get all 
        /// </summary>
        /// <returns></returns>
        public List<ToDo> GetAll()
        {
            return list;
        }

        // Return active ToDo list (EndTime different to null
        public List<ToDo> GetAllActives()
        {
            return list.FindAll(x => x.EndDate == null);
        }

        /// <summary>
        /// Add object
        /// </summary>
        /// <param name="toDoTitle"></param>
        /// <returns></returns>
        public ToDo Add(string toDoTitle)
        {
            // Cretae object
            int id = 1;
            if (list.Count > 0)
                id = list.Max(a => a.Id) + 1;
            var toDo = new ToDo(toDoTitle, id);

            // Add object
            list.Add(toDo);

            return toDo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            //Check if object exist
            var obj = GetById(id);
            if (obj == null)
                return;

            // Delete object
            list.Remove(obj);
        }

        /// <summary>
        /// Update ToDo object
        /// Set EndTime
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public ToDo Update(int id, string title, DateTime? endDate)
        {
            // Get object
            var toDoItem = GetById(id);
            if (toDoItem == null)
                return null;

            // Update object
            if (endDate == null)
                endDate = DateTime.Now;

            toDoItem.Title = title;
            toDoItem.EndDate = endDate;

            return toDoItem;
        }     

        /// <summary>
        /// Check if object exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ToDo GetById(int id)
        {
            try
            {
                var todoItem = list.Find(a => a.Id == id);
                return todoItem;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
