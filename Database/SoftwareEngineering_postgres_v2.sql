CREATE TABLE "Users" (
	"reg_num" varchar(6) NOT NULL,
	"name" varchar(32) NOT NULL,
	"password" varchar(32) NOT NULL,
	"surname" varchar(32) NOT NULL,
	"email" varchar(40) NOT NULL,
	CONSTRAINT "User_pk" PRIMARY KEY ("reg_num")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Admins" (
	"reg_num" varchar(6) NOT NULL UNIQUE
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Students" (
	"reg_num" varchar(6) NOT NULL UNIQUE
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Professors" (
	"reg_num" varchar(6) NOT NULL UNIQUE
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Teams" (
	"id" varchar(6) NOT NULL UNIQUE,
	CONSTRAINT "Team_pk" PRIMARY KEY ("id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "StudentsTeams" (
	"stu_reg_num" varchar(6) NOT NULL UNIQUE,
	"team_id" varchar(6) NOT NULL,
	"course_id" varchar(6) NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "ProfessorsCourses" (
	"prof_reg_num" varchar(6) NOT NULL UNIQUE,
	"course_id" varchar(6) NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Courses" (
	"id" varchar(6) NOT NULL UNIQUE,
	"name" varchar(32) NOT NULL,
	"project_id" varchar(6) NOT NULL,
	CONSTRAINT "Course_pk" PRIMARY KEY ("id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Projects" (
	"id" varchar(6) NOT NULL UNIQUE,
	"name" varchar(32) NOT NULL,
	"description" varchar(100) NOT NULL,
	"max_grade" integer NOT NULL
) WITH (
  OIDS=FALSE
);



CREATE TABLE "ProjectFiles" (
	"id" varchar NOT NULL UNIQUE,
	"file" bytea NOT NULL,
	"name" varchar(30) NOT NULL,
	CONSTRAINT "ProjectFile_pk" PRIMARY KEY ("id")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "ProjectsOfTeam" (
	"project_id" varchar(6) NOT NULL UNIQUE,
	"project_file_id" varchar NOT NULL,
	"team_id" varchar(6) NOT NULL,
	"grade" integer
) WITH (
  OIDS=FALSE
);




ALTER TABLE "Admins" ADD CONSTRAINT "Admin_fk0" FOREIGN KEY ("reg_num") REFERENCES "Users"("reg_num");

ALTER TABLE "Students" ADD CONSTRAINT "Student_fk0" FOREIGN KEY ("reg_num") REFERENCES "Users"("reg_num");

ALTER TABLE "Professors" ADD CONSTRAINT "Professor_fk0" FOREIGN KEY ("reg_num") REFERENCES "Users"("reg_num");


ALTER TABLE "StudentsTeams" ADD CONSTRAINT "StudentsTeam_fk0" FOREIGN KEY ("stu_reg_num") REFERENCES "Students"("reg_num");
ALTER TABLE "StudentsTeams" ADD CONSTRAINT "StudentsTeam_fk1" FOREIGN KEY ("team_id") REFERENCES "Teams"("id");
ALTER TABLE "StudentsTeams" ADD CONSTRAINT "StudentsTeam_fk2" FOREIGN KEY ("course_id") REFERENCES "Courses"("id");

ALTER TABLE "ProfessorsCourses" ADD CONSTRAINT "ProfessorsCourses_fk0" FOREIGN KEY ("prof_reg_num") REFERENCES "Professors"("reg_num");
ALTER TABLE "ProfessorsCourses" ADD CONSTRAINT "ProfessorsCourses_fk1" FOREIGN KEY ("course_id") REFERENCES "Courses"("id");

ALTER TABLE "Courses" ADD CONSTRAINT "Course_fk0" FOREIGN KEY ("project_id") REFERENCES "Projects"("id");



ALTER TABLE "ProjectsOfTeam" ADD CONSTRAINT "ProjectOfTeam_fk0" FOREIGN KEY ("project_id") REFERENCES "Projects"("id");
ALTER TABLE "ProjectsOfTeam" ADD CONSTRAINT "ProjectOfTeam_fk1" FOREIGN KEY ("project_file_id") REFERENCES "ProjectFiles"("id");
ALTER TABLE "ProjectsOfTeam" ADD CONSTRAINT "ProjectOfTeam_fk2" FOREIGN KEY ("team_id") REFERENCES "Teams"("id");
