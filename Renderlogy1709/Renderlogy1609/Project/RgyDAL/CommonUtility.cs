using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace RgyDAL
{
   public class CommonUtility
    {

     
        public bool InsertRole(int SignUp,int RoleId)
        {
            bool flag = false;
            // if (!IsUserEmlExist(EmailId))
            {
                SqlConnection connection = new SqlConnection
               (System.Configuration.ConfigurationManager.ConnectionStrings["ConRenderLogyNew"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("insert into UserRoles values('" + SignUp + "','" + RoleId + "')", connection);
                flag = Convert.ToBoolean(command.ExecuteNonQuery());
                connection.Close();
                return flag;
            }
            //return flag;
        }
        public bool IsUserEmlExist(string emailid)
        {
            bool flag = false;
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConRenderLogyNew"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select count(*) from SignUps where EmailId= '" + emailid + "'", connection);
            flag = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();
            return flag;
        }
        public bool ActiveAccount(int Id, string EmailId)
        {
            bool flag = false;
            // if (!IsUserEmlExist(EmailId))
            {
                SqlConnection connection = new SqlConnection
               (System.Configuration.ConfigurationManager.ConnectionStrings["ConRenderLogyNew"].ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("update SignUps SET IsActive=1 where SignUpId='" + Id + "' and Emailid= '" + EmailId + "'", connection);

                flag = Convert.ToBoolean(cmd.ExecuteNonQuery());
                connection.Close();
                return flag;
            }
            //return flag;
        }
        public bool ActiveAccount(string EmailId)
        {
            bool flag = false;
            // if (!IsUserEmlExist(EmailId))
            {
                SqlConnection connection = new SqlConnection
               (System.Configuration.ConfigurationManager.ConnectionStrings["ConRenderLogyNew"].ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("update SignUps SET IsActive=1 where Emailid= '" + EmailId + "'", connection);

                flag = Convert.ToBoolean(cmd.ExecuteNonQuery());
                connection.Close();
                return flag;
            }
            //return flag;
        }
        public bool ChangeRole(int Id, string RoleName)
        {
            bool flag = false;
           
            {
                SqlConnection connection = new SqlConnection
               (System.Configuration.ConfigurationManager.ConnectionStrings["ConRenderLogyNew"].ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("update UserRoles SET RoleId=(select RoleId from  Roles where Name='" + RoleName + "') where SignUpId='" + Id + "'", connection);

                flag = Convert.ToBoolean(cmd.ExecuteNonQuery());
                connection.Close();
                return flag;
            }
           
        }

        public bool DisableAccount(int Id)
        {
            bool flag = false;
            
                SqlConnection connection = new SqlConnection
               (System.Configuration.ConfigurationManager.ConnectionStrings["ConRenderLogyNew"].ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("update SignUps SET IsActive=0 where SignUpId='" + Id + "'", connection);
                
                flag = Convert.ToBoolean(cmd.ExecuteNonQuery());
                connection.Close();
                return flag;
            
           
        }

    


    }
}
