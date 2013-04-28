using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;
using System.Linq;
using System.Text;

namespace HW1___School_People_etc
{
    //
    public class ClassesOfStudents
    {
        private string uniqueName;
        private string comment;
        private List<Students> students;
        private List<Teachers> teachers;
        private string UniqueName
        {
            get
            {
                return this.uniqueName;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Name can not be null");
                }
                this.uniqueName = value;
            }
        }
        private string Comment
        {
            get         
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }
        private List<Students> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }

        }
        private List<Teachers> Teachers
        {
            get
            {
                return this.teachers;
            }
            set
            {
                this.teachers = value;
            }

        }
        public ClassesOfStudents(string uniqueName,List<Students> students,List<Teachers> teachers,string comment = null)
        {
            this.UniqueName = uniqueName;
            this.Students = students;
            this.Teachers = teachers;
            this.Comment = comment;
        }



    }
}