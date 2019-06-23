using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject1
{
    class admin<User>
    {
        public Boolean createUser(RegNum regNumber,string password, string name, string surname, Email email)
        {
            UserFactory newuser = new UserFactory();
            this.newuser.createUser(name);
            // need to see User Factory Class first
        }
        public Boolean editUser()
        {

        }
        public Boolean deleteUser()
        {

        }
        public Boolean createCourse(string courseid,string coursename, Professor prof, List<Project> projectList, List<Team> teamlist)
        {
            Course newcourse = new Course();
            this.newcourse.setCourseID(courseid);
            this.newcourse.setCourseName(coursename);
            this.newcourse.setProfessor(prof);
            this.newcourse.setProjectList(projectList);
            this.newcourse.setTeamList(teamlist);
        }
        public Boolean editCourse()
        {

        }
        public Boolean deleteCourse()
        {

        }
       
    }
}
