using System;
using System.Collections.Generic;
using System.Data;
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
        private static readonly string connectionVariable = "Server=(LocalDb)\\LocalDbDemo;Database=MvcCrud;Trusted_Connection=true;MultipleActiveResultSets=True";
        SqlConnection sqlConnection = new SqlConnection(connectionVariable);
        public string Add(Student student)
        {
            
            try
            {
                
            SqlCommand sqlCommand = new SqlCommand("SpInsert", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //// sqlCommand.Parameters.AddWithValue("@Id", employeeModel.Id);
                sqlCommand.Parameters.AddWithValue("@name", student.name);
                sqlCommand.Parameters.AddWithValue("@age", student.age);
               
                sqlConnection.Open();
                var respone =  sqlCommand.ExecuteNonQuery();
                return "successfull : "+respone;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool Delete(Student id)
        {
            SqlCommand sqlCommand = new SqlCommand("SpDelete",sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", id.id);
            sqlConnection.Open();
            var results = sqlCommand.ExecuteNonQuery();
            if (results >= -1)
            {
                return true;
            }
            else
                return false;

        }

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

        public bool Update(Student student)
        {
            SqlCommand sqlCommand = new SqlCommand("SpUpdate",sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@id", student.id);
            sqlCommand.Parameters.AddWithValue("@name", student.name);
            sqlCommand.Parameters.AddWithValue("@age", student.age);
            sqlConnection.Open();
            var response = sqlCommand.ExecuteNonQuery();
            if (response > -1)
                return true;
            else
                return false;
        }
    }
}
