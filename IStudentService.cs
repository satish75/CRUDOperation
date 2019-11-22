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
    }
}
