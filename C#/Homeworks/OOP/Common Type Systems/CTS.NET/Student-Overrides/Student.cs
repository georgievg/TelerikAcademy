using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Overrides
{
    public class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public int SSN { get; private set; }
        public string PermanentAddress { get; private set; }
        public int MobilePhone { get; private set; }
        public string Email { get; private set; }
        public int Course { get; private set; }
        public Specialty Specialty { get; private set; }
        public University Univesity { get; private set; }
        public Faculties Faculty { get; private set; }
        public Student(string fname, string mname, string lname, int SSN, string Address,int phone,string email,int course,Specialty spec,
            University university,Faculties faculty)
        {
            this.FirstName = fname;
            this.MiddleName = mname;
            this.LastName = lname;
            this.SSN = SSN;
            this.PermanentAddress = Address;
            this.MobilePhone = phone;
            this.Email = email;
            this.Course = course;
            this.Specialty = spec;
            this.Univesity = university;
            this.Faculty = faculty;
        }
        private Student()
        {
        }
        public override string ToString()
        {
            string data = string.Format("Student data : Name : {0}, MiddleName {1}, LastName {2}, SSN {3}, Address {4}, Phone {5}, Email {6}, Course {7}, Specialty {8}, University {9}, Faculty {10}",
                FirstName, MiddleName, LastName, SSN, PermanentAddress, MobilePhone, Email, Course, Specialty, Univesity, Faculty);

            return data.ToString();
        }
        public override bool Equals(object obj)
        {
            Student stud = obj as Student;
            if (stud == null)
            {
                return false;
            }
            if (!Object.Equals(this.FirstName, stud.FirstName))
            {
               return false; 
            }
            if (stud.SSN != this.SSN)
            {
                return false;
            }
            return true;
        }
        public static bool operator ==(Student stud1, Student stud2)
        {
            return Student.Equals(stud1, stud2);
        }
        public static bool operator !=(Student stud1, Student stud2)
        {
            return !(Student.Equals(stud1, stud2));
        }
        public override int GetHashCode()
        {
            string name = this.FirstName;
            int ssn = this.SSN;
            return name.GetHashCode() ^ ssn.GetHashCode();
        }

        public object Clone()
        {
            Student newStudent = new Student();
            newStudent.FirstName = String.Copy(this.FirstName);
            newStudent.MiddleName = String.Copy(this.MiddleName);
            newStudent.LastName = string.Copy(this.LastName);
            newStudent.SSN = this.SSN;
            newStudent.MobilePhone = this.MobilePhone;
            newStudent.Email = string.Copy(this.Email);
            newStudent.PermanentAddress = string.Copy(this.PermanentAddress);
            newStudent.Course = this.Course;
            newStudent.Specialty = this.Specialty;
            newStudent.Univesity = this.Univesity;
            newStudent.Faculty = this.Faculty;
            return newStudent;
        }

        public int CompareTo(Student other)
        {
            if (string.Compare(this.FirstName,other.FirstName) < 0)
            {
                return -1;
            }
            if (string.Compare(this.FirstName,other.FirstName) > 0)
            {
                if (this.SSN > other.SSN)
                {
                    return 1;
                }
                return -1;
            }
            return 0;
        }
    }
   
    

    public enum Specialty
    {
        Engineer,
        Vodoprovodchik,
        Hlebar,
        Kominochistach,
        Peralnq,
        Pechka
    }
    public enum University
    {
        PGIM,
        EG,
        FMI,
        TeCh,
        Telerik
    }
    public enum Faculties
    {
        IdontKnow,
        WhatTheFuck,
        ThisWOuldMean,
    }

}