using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentHousingApp
{
    public partial class Form1 : Form
    {
        private Complaints complaints;
        private HouseRules HouseRules;

        public List<string> Complaints = new List<string>();
        public List<string> houseRules = new List<string>();


        string[] ToDo = new string[] { "Clean Kitchen", "Clean Living Room", "Clean Bathroom", "Take out Garbage", "Buy Common Items" };

        string[] Rules = new string[] { "No Smoking", "Drugs Are Not Allowed", "Quiet Hours are between 11:00 PM and 8 AM", "Kitchens are open 24 hours a day", "Room cleaning can be arranged weekly", "Guests are welcome", "Damage should be reported ", "No Candles", "No Skating in The lobby", "Bicycles are not allowed", "Be respectful your housemates", "No fan heaters allowed whatsoever" };


        List<string> noteList = new List<string>();
        List<string> studentList = new List<string>();
        List<string> studentNoteList = new List<string>();

        StudentAdministration studentAdministration = new StudentAdministration();
        int minimumContribution;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < ToDo.Length; i++)
            {
                listBox1.Items.Add(ToDo[i].ToString());
            }

            for (int i = 0; i < Rules.Length; i++)
            {
                lbGeneralRules.Items.Add(Rules[i].ToString());
            }


        }
        // TaksManger
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if(cbStudents.SelectedIndex == -1)
            {
                MessageBox.Show("Select A Student");
            }
            if(listBox1.SelectedIndex == -1 && textBox1.Text == "")
            {
                MessageBox.Show("Please Select A Task");
            }
            else if(listBox1.SelectedIndex != -1 && textBox1.Text == "" || textBox1.Text == null)
            {
                if (lbTasks.Items.Contains(cbStudents.SelectedItem + " - " + listBox1.SelectedItem))
                {
                    MessageBox.Show("Task is Already In ToDo");
                    listBox1.ClearSelected();
                }
                else
                {
                    lbTasks.Items.Add(cbStudents.SelectedItem + " - " + listBox1.SelectedItem);
                    listBox1.ClearSelected();
                }
            }
            else if(listBox1.SelectedIndex == -1 && textBox1.Text != "" || textBox1.Text != null)
            {
                if(lbTasks.Items.Contains(cbStudents.SelectedItem + " - " + textBox1.Text))
                {
                    MessageBox.Show("Task is Already In ToDo");
                   
                }
                else
                {
                    lbTasks.Items.Add(cbStudents.SelectedItem + " - " + textBox1.Text);
                }
            }
            
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            // in case the student Didnt Select a task
            if (lbTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Task");
            }

            else
            {
                lbTasks.Items.Remove(lbTasks.SelectedItem);

                lbTasks.ClearSelected();
            }
        }


        // Complaints
        private void btnAddComplaint_Click(object sender, EventArgs e)
        {
            if (radioGeneral.Checked == true && tbComplaint.Text != null && tbComplaint.Text != "")
            {
                if (lbGeneralComplaints.Items.Contains(tbComplaint.Text) || lbGeneralComplaints.Items.Contains(tbStudentComplaint.Text + " : " + tbComplaint.Text))
                {
                    MessageBox.Show("Complaint Received!");
                }
                else
                {
                    complaints = new Complaints();
                    complaints.SetComplaint(tbComplaint.Text);
                    complaints.SetStudentName(tbStudentComplaint.Text);

                    Complaints.Add(tbStudentComplaint.ToString());
                    lbGeneralComplaints.Items.Add(complaints.GetComplaint());
                }
            }

            else if(radioCleaning.Checked == true && tbComplaint.Text != null && tbComplaint.Text != "")
            {
                if (lbCleaningComplaints.Items.Contains(tbComplaint.Text) || lbCleaningComplaints.Items.Contains(tbStudentComplaint.Text + " : " + tbComplaint.Text))
                {
                    MessageBox.Show("Complaint Received!");
                }
                else
                {
                    complaints = new Complaints();
                    complaints.SetComplaint(tbComplaint.Text);
                    complaints.SetStudentName(tbStudentComplaint.Text);


                    Complaints.Add(tbStudentComplaint.ToString());
                    lbCleaningComplaints.Items.Add(complaints.GetComplaint());
                }
                
            }

            else if(radioGarbage.Checked == true && tbComplaint.Text != null && tbComplaint.Text != "")
            {
                if (lbGarbageComplaints.Items.Contains(tbComplaint.Text) || lbGarbageComplaints.Items.Contains(tbStudentComplaint.Text + " : " + tbComplaint.Text))
                {
                    MessageBox.Show("Complaint Received!");
                }
                else
                {
                    complaints = new Complaints();
                    complaints.SetComplaint(tbComplaint.Text);
                    complaints.SetStudentName(tbStudentComplaint.Text);

                    Complaints.Add(tbStudentComplaint.ToString());
                    lbGarbageComplaints.Items.Add(complaints.GetComplaint());
                }
            }
        }
        //Adding House Rule

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            if (lbAgreedRules.Items.Contains(tbAddRule.Text))
            {
                MessageBox.Show("Rule Already Exist");
            }
            else
            {
                HouseRules = new HouseRules();
                HouseRules.setRule(tbAddRule.Text);

                houseRules.Add(tbAddRule.Text);
                lbAgreedRules.Items.Add(HouseRules.getRule());
            }

        }

        private void btnRemoveRule_Click(object sender, EventArgs e)
        {
            if(lbAgreedRules.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select A Rule");
            }
            else
            {
                lbAgreedRules.Items.Remove(lbAgreedRules.SelectedItem);
            }
        }


        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (tbNote.Text != string.Empty && tbNoteStudentName.Text != string.Empty)
            {
                string studentName = tbNoteStudentName.Text;
                tbNoteStudentName.Text = string.Empty;
                studentList.Add(studentName);

                string note = tbNote.Text;
                tbNote.Text = string.Empty;
                noteList.Add(note);

                studentNoteList.Add(studentName + " - " + note);


                lbNotes.Items.Clear();
                foreach (string n in studentNoteList)
                {
                    lbNotes.Items.Add(n);
                }
            }
            else
            {
                MessageBox.Show("Please enter a name and note!");
            }

        }

        private void btnDeleteNote_Click(object sender, EventArgs e)
        {
            int toBeRemoved = lbNotes.SelectedIndex;
            if (toBeRemoved != -1)
            {
                studentNoteList.RemoveAt(toBeRemoved);
                tbOldText.Text = "";                
                noteList.RemoveAt(lbNotes.SelectedIndex);
                lbNotes.Items.Clear();
                foreach (string n in studentNoteList)
                {
                    lbNotes.Items.Add(n);
                }
            }
            else
            {
                MessageBox.Show("Please select a note to delete!");
            }
        }

        private void lbNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int findIndex = lbNotes.SelectedIndex;
                string findNote = noteList[findIndex];
                tbOldText.Text = findNote;
            }
            catch { MessageBox.Show("Plase select note"); }
        }

        private void btnChangeNote_Click(object sender, EventArgs e)
        {
            if (tbNewText.Text != string.Empty && tbOldText.Text != string.Empty)
            {
                int index = lbNotes.SelectedIndex;
                noteList[index] = tbNewText.Text;

                studentNoteList[index] = studentList[index] + " - " + noteList[index];

                tbOldText.Text = string.Empty;
                tbNewText.Text = string.Empty;

                lbNotes.Items.Clear();
                foreach (string n in studentNoteList)
                {
                    lbNotes.Items.Add(n);
                }
            }
            else
            {
                MessageBox.Show("Please select a note and then enter a new one!");
            }
        }


        private void updateListBox()
        {
            lbContributions.Items.Clear();
            foreach (Student student in studentAdministration.getStudents())
            {
                lbContributions.Items.Add(student.getContribution());
            }
        }

        private void BtnViewContributions_Click(object sender, EventArgs e)
        {
            updateListBox();
        }



        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            if (tbAddName.Text != null && tbAddName.Text != "")
            {
                studentAdministration.addStudent(tbAddName.Text);
                cbStudents.Items.Add(tbAddName.Text);
                updateListBox();
            }
            else
                MessageBox.Show("Invalid name");
        }



        private void BtnSetContribution_Click(object sender, EventArgs e)
        {
            try
            {
                int sum = Convert.ToInt32(tbSetMinContribution.Text);
                if (sum >= 0)
                    minimumContribution = sum;
                else
                    MessageBox.Show("Contribution must be pozitive");
            }
            catch { MessageBox.Show("Contribution value not valid"); }

        }



        private void BtnAddContribution_Click(object sender, EventArgs e)
        {
            try
            {
                int contribution = Convert.ToInt32(tbAddContribution.Text);
                if ((contribution + studentAdministration.getContribution(lbContributions.SelectedIndex)) >= minimumContribution)
                {
                    studentAdministration.addContribution(lbContributions.SelectedIndex, contribution);
                    updateListBox();
                }
                else
                    MessageBox.Show("Contribution insufficient");
            }
            catch { MessageBox.Show("Contribution invalid"); }

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void tbNoteStudentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHome;
        }
    }
}
