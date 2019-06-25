using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Class
{
    class Team
    {
        string teamID;
        List<Student> studentList = new List<Student>();
        Dictionary<Project, ProjectFile> projectAssignments = new Dictionary<Project, ProjectFile>();

        //getters
        public string getTeamID() { return teamID; }
        public List<Student> getStudentList() { return studentList; }
        public Dictionary<Project, ProjectFile> getProjectAssignmentsD() { return projectAssignments; }
        //setters
        public void setTeamID(string teamID) { this.teamID = teamID; }
        public void setStudentList(List<Student> studentList) { this.studentList = studentList; }
        public void setProjectAssignments(Dictionary<Project, ProjectFile> projectAssignments) { this.projectAssignments = projectAssignments; }



    }
}
