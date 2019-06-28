using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Class
{
    class Course
    {
        string courseID;
        string courseName;
		Professor professor;
		List<Project> projectList;
		List<Team> teamList;

		// Constructor
		public Course(string courseID, string courseName, Professor professor, List<Project> projectList, List<Team> teamList)
		{
			this.courseID = courseID;
			this.courseName = courseName;
			this.professor = professor;
			this.projectList = projectList;
			this.teamList = teamList;
		}

        //getters
        public string getCourseID() { return courseID; }
        public string getCourseName() { return courseName; }
        public Professor getProfessor() { return professor; }
        public List<Project> getProjectList() { return projectList; }
        public List<Team> getTeamList() { return teamList; }

        //setters
        public void setCourseID(string courseID) { this.courseID = courseID; }
        public void setCourseName(string courseName) { this.courseName = courseName; }
        public void setProfessor(Professor professor) { this.professor = professor; }
        public void setProjectList(List<Project> projectList) { this.projectList = projectList; }
        public void setTeamList(List<Team> teamList) { this.teamList = teamList; }



    }
}
