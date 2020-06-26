using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingApp
{
    class StudentAdministration
    {
        private List<Student> allStudents = new List<Student>();
        private static int counterID=1;

        public void addStudent(string name)
        {
            allStudents.Add(new Student(counterID, name));
            counterID++;
        }
        public void addContribution(int id,int contribution)
        {
            allStudents[id].Contribution = contribution;
        }
        public int getContribution(int id)
        {
            return allStudents[id].Contribution;
        }
        public Student[] getStudents()
        {
            return allStudents.ToArray();
        }
    }
}
