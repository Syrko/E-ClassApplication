using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject1
{
    class professor<User>
    {
        List<Course> courseList;

        private void createProject(string id,string name, string description,double maxgrade)
        {
            Project project = new Project();
            this.project.setProjectID(id);
            this.project.setName(name);
            this.project.setdescreption(descritpion);
            this.project.setmaxGrade(maxgrade);
        }
        private void editProject()
        {
            //difference in edit and create
            //project class set functions for create, edit or delete?
        }
        private void deleteProject()
        {

        }
        private void createTeam(string id, List<Course> stdntList, Dictionary<SharedProject1,ProjectFile> prAssignments)
        {
            Team team = new Team();
            this.team.setTeamID(id);
            this.team.setStudentList(stdntList);
            this.createTeam.setProjectAssignments(prAssignments);
        }
        private void editTeam()
        {

        }
        private void deleteTeam()
        {

        }
        private void gradeProject(double grade)
        {
            ProjectFile prjctFile = new ProjectFile();
            this.prjctFile.setGrade(grade);
        }
        private List<Course> getCourseList()
        {
            return this.courseList;
        }
        private void setCourseList(List<Course> courselist)
        {
            this.courseList = courselist;
        }
    }
}
