using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StudentService.svc or StudentService.svc.cs at the Solution Explorer and start debugging.
    public class StudentService : IStudentService
    {    
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student", new SqlConnection("server=(LocalDb)\\LocalDbDemo;Database=MvcCrud;Trusted_Connection=true; MultipleActiveResultSets = true"));
            cmd.Connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                Student student = new Student();
                student.id = int.Parse(sdr["id"].ToString());
                student.age = int.Parse(sdr["age"].ToString());
                student.name = sdr["name"].ToString();
                students.Add(student);
            }
            sdr.Close();
            cmd.Connection.Close();
            return students;
        }
    }
}
