using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentService" in both code and config file together.
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        [WebInvoke(
            Method ="GET",RequestFormat =WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json,
            UriTemplate ="/GetAllSTudent"
            )]
        List<Student> GetAllStudents();

        [OperationContract]
        [WebInvoke(
          Method = "POST", RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "/Add"
          )]
        string Add(Student student);

        [OperationContract]
        [WebInvoke(
         Method = "PUT", RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "/Update"
         )]
        bool Update(Student student);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/delete")]

        bool Delete(Student id);
    }
}
