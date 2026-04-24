using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp26
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Teacher AssignedTeacher { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();

        public Course (int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        //method to assign teacher to the course
        public bool AssignTeacher(Teacher teacherToAssign)
        {
            {
                if (AssignedTeacher != null)
                {
                    return false;   //teacher already assigned 
                }
                AssignedTeacher = teacherToAssign;
                return true;
            }
        }
        //method to remove teacher from a course 
        public bool RemoveTeacher()
        {
            AssignedTeacher = null;
            return true;
        }
        //method to enroll a student in the course
        public bool EnrollStudent(Student studentToEnroll)
        {
            //check if the student is already enrolled and return false
            foreach (Student student in EnrolledStudents)
            {
                if (student.Id == studentToEnroll.Id) //student already enrolled
                {
                    return false;
                }
            }
            //enroll the student and return true
            EnrolledStudents.Add(studentToEnroll);
            return true;
            
        }
        //method to uneroll a student from the course
        public bool UnEnrollStudent(Student studentToEnroll)
        {
            //check if the student is enrolled, unenroll student and return true
            foreach (Student student in EnrolledStudents)
            {
                if(student.Id == studentToEnroll.Id)
                {
                    EnrolledStudents.Remove(student);
                    return true;  //student unenrolled
                }
            }
            //retun false if the student is not enrolled
            return false;
        }
    }



}
