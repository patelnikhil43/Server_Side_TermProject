using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProjectSolution
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterUserButton_Click(object sender, EventArgs e)
        {
            //Validate

            //Check if email already exist
            String UserEmail = RegisterEmailTxtBox.Text;
          Boolean flag =  CheckIfEmailExist(UserEmail);
            if (flag == true)
            {
                //Alert User that email exist
            }
            else {
                //Register 

            }
        }
        public Boolean CheckIfEmailExist(String Email) {
            DBConnect dbConnection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "CheckIfUserExist"; 
            SqlParameter inputParameter = new SqlParameter("@Email", Email);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            objCommand.Parameters.Add(inputParameter);

            DataSet EmailDataSet = dbConnection.GetDataSetUsingCmdObj(objCommand);
            if (EmailDataSet == null && EmailDataSet.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else {
                return true;
            }
        }
    }
}