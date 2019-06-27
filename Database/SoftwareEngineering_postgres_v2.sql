CREATE TABLE "User" (
	"reg_num" serial(6) NOT NULL,
	"password" varchar(32) NOT NULL,
	"name" varchar(32) NOT NULL,
	"surname" varchar(32) NOT NULL,
	"email" varchar(40) NOT NULL,
	CONSTRAINT "User_pk" PRIMARY KEY ("reg_num")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Admin" (
	"reg_num" varchar(6) NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Student" (
	"reg_num" varchar(6) NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Professor" (
	"reg_num" varchar(6) NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Team" (
	"id" serial(6) NOT NULL UNIQUE,
	CONSTRAINT "Team_pk" PRIMARY KEY ("id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "StudentsTeam" (
	"stu_reg_num" varchar(6) NOT NULL,
	"team_id" serial(6) NOT NULL,
	"course_id" varchar(6) NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "ProfessorsCourses" (
	"prof_reg_num" varchar(6) NOT NULL,
	"course_id" varchar(6) NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Course" (
	"id" serial(6) NOT NULL UNIQUE,
	"name" varchar(32) NOT NULL,
	"project_id" varchar(6) NOT NULL,
	CONSTRAINT "Course_pk" PRIMARY KEY ("id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Project" (
	"id" varchar(6) NOT NULL,
	"name" varchar(32) NOT NULL,
	"description" varchar(100) NOT NULL,
	"max_grade" integer(2) NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "ProjectFile" (
	"id" serial NOT NULL,
	"file" BINARY NOT NULL,
	"name" varchar(30) NOT NULL,
	CONSTRAINT "ProjectFile_pk" PRIMARY KEY ("id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "ProjectOfTeam" (
	"project_id" varchar(6) NOT NULL,
	"project_file_id" integer(6) NOT NULL,
	"team_id" varchar(6) NOT NULL,
	"grade" integer(2)
) WITH (
  OIDS=FALSE
);




ALTER TABLE "Admin" ADD CONSTRAINT "Admin_fk0" FOREIGN KEY ("reg_num") REFERENCES "User"("reg_num");

ALTER TABLE "Student" ADD CONSTRAINT "Student_fk0" FOREIGN KEY ("reg_num") REFERENCES "User"("reg_num");

ALTER TABLE "Professor" ADD CONSTRAINT "Professor_fk0" FOREIGN KEY ("reg_num") REFERENCES "User"("reg_num");


ALTER TABLE "StudentsTeam" ADD CONSTRAINT "StudentsTeam_fk0" FOREIGN KEY ("stu_reg_num") REFERENCES "Student"("reg_num");
ALTER TABLE "StudentsTeam" ADD CONSTRAINT "StudentsTeam_fk1" FOREIGN KEY ("team_id") REFERENCES "Team"("id");
ALTER TABLE "StudentsTeam" ADD CONSTRAINT "StudentsTeam_fk2" FOREIGN KEY ("course_id") REFERENCES "Course"("id");

ALTER TABLE "ProfessorsCourses" ADD CONSTRAINT "ProfessorsCourses_fk0" FOREIGN KEY ("prof_reg_num") REFERENCES "Professor"("reg_num");
ALTER TABLE "ProfessorsCourses" ADD CONSTRAINT "ProfessorsCourses_fk1" FOREIGN KEY ("course_id") REFERENCES "Course"("id");

ALTER TABLE "Course" ADD CONSTRAINT "Course_fk0" FOREIGN KEY ("project_id") REFERENCES "Project"("id");



ALTER TABLE "ProjectOfTeam" ADD CONSTRAINT "ProjectOfTeam_fk0" FOREIGN KEY ("project_id") REFERENCES "Project"("id");
ALTER TABLE "ProjectOfTeam" ADD CONSTRAINT "ProjectOfTeam_fk1" FOREIGN KEY ("project_file_id") REFERENCES "ProjectFile"("id");
ALTER TABLE "ProjectOfTeam" ADD CONSTRAINT "ProjectOfTeam_fk2" FOREIGN KEY ("team_id") REFERENCES "Team"("id");

