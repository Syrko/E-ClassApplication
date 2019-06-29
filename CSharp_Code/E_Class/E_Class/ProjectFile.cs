using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Class
{
    class ProjectFile
    {
        byte[] file;
        int grade;
        DateTime uploadDate;

		// Cosntructors
		public ProjectFile(byte[] file, double grade, DateTime uploadDate)
		{
			this.file = file;
			this.grade = grade;
			this.uploadDate = uploadDate;
		}

		// Getters
        public byte[] getFile() { return file; }
        public double getGrade() { return grade; }
        public DateTime getUploadDate() { return uploadDate; }

		// Setters
        public void setFile(byte[] file) { this.file = file; }
        public void setGrade(double grade) { this.grade = grade; }
        public void setUploadDate(DateTime uploadDate) { this.uploadDate = uploadDate; }

    }
}
