using System.Data.SqlClient;

namespace DiagnosticCenterBillManagementSystem.DAL.Gateway
{
    public class BaseGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        string connectionStr = @"Server=BITM-IT-OFFICER; Database=DCBMS; Integrated Security=True;";

        public BaseGateway()
        {
            Connection = new SqlConnection(connectionStr);
        }
    }
}