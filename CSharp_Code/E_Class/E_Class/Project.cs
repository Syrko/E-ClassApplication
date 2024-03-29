﻿using System;
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
        DateTime due_date;
        
		// Constructors
		public Project(string projectID, string name, string description, int maxGrade, DateTime due_date)
		{
			this.projectID = projectID;
			this.name = name;
			this.description = description;
			this.maxGrade = maxGrade;
            this.due_date = due_date;
		}

        //getters
        public string getProjectID() { return projectID; }
        public string getname() { return name; }
        public string getdescription() { return description; }
        public int getmaxGrade() { return maxGrade; }
        public DateTime getDueDate() { return due_date; }
        //setters
        public void setProjectID(string projectID) { this.projectID = projectID; }
        public void setName(string name) { this.name = name; }
        public void setdescription(string description) { this.description = description; }
        public void setmaxGrade(int maxGrade) { this.maxGrade = maxGrade; }
        public void setDueDate(DateTime due_date) { this.due_date = due_date; }

    }
}
