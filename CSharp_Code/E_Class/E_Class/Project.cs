using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Class
{
    class Project
    {
        string projectID;
        string name;
        string description;
        int maxGrade;
        
		// Constructors
		public Project(string projectID, string name, string description, double maxGrade)
		{
			this.projectID = projectID;
			this.name = name;
			this.description = description;
			this.maxGrade = maxGrade;
		}

        //getters
        public string getProjectID() { return projectID; }
        public string getname() { return name; }
        public string getdescription() { return description; }
        public double getmaxGrade() { return maxGrade; }
        //setters
        public void setProjectID(string projectID) { this.projectID = projectID; }
        public void setName(string name) { this.name = name; }
        public void setdescription(string description) { this.description = description; }
        public void setmaxGrade(double maxGrade) { this.maxGrade = maxGrade; }

    }
}
