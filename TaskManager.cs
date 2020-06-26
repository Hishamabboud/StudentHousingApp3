using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingApp
{
    class TaskManager
    {

        private string Task;

        private List<string> Tasks = new List<string>();


         public void task(string Task)
           {
            this.Task = Task;
           }

        // Adding A task to the list
        public void AddTask(string Task)
        {
            Tasks.Add(Task);
        }
    }
}
