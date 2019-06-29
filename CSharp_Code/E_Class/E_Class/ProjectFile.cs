using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Class
{
    class ProjectFile
    {
        string id;
        byte[] file;
        int grade;
        DateTime uploadDate;

		// Constructors
		public ProjectFile(string id, byte[] file, int grade, DateTime uploadDate)
		{
			this.file = file;
			this.grade = grade;
			this.uploadDate = uploadDate;
		}

        // Getters
        public string getProjectFileID() { return id; }
        public byte[] getFile() { return file; }
        public int getGrade() { return grade; }
        public DateTime getUploadDate() { return uploadDate; }

		// Setters
        public void setProjectFileID(string id) { this.id = id; }
        public void setFile(byte[] file) { this.file = file; }
        public void setGrade(int grade) { this.grade = grade; }
        public void setUploadDate(DateTime uploadDate) { this.uploadDate = uploadDate; }

    }
}
