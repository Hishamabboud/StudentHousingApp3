using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingApp
{
    class Student
    {
        private string name;
        private int contribution = 0;
        private int id;

        public Student(int id,string name)
        {
            this.id = id;
            this.name = name;
        }
        public Student(int id, string name,int contribution)
        {
            this.id = id;
            this.name = name;
            this.contribution += contribution;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null && value != "")
                    name = value;
            }
        }
        public int Contribution
        {
            get { return contribution; }
            set
            {
                if (value >= 0)
                    contribution += value;
            }
        }
        public string getContribution()
        {
            return $"{name} - {contribution}";
        }
    }
}
