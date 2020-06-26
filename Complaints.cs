using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHousingApp
{
    class Complaints
    {
        public string studentName;

        public string complaint;


        public void SetComplaint(string complaint)
        {
            this.complaint = complaint;
        }

        public void SetStudentName(string studentName)
        {
            this.studentName = studentName;
        }

        public string GetComplaint()
        {
            if (studentName == null || studentName == "")
            {
                return $"{complaint}";
            }
            else
            {
                return $"{studentName} : {complaint}";
            }
        }

    }
}
