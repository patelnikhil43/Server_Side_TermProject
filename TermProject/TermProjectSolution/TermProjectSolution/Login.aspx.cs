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
    public partial class Login : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //validate textboxes; done!
            //check if valid user; done!
            //check if there is a username and/or password saved in cookies
            //store userAccount in Session so they can't access all pages by typing in URL
            bool allGood = true;
            if(txtEmail.Text == "")
            {
                allGood = false;
                lblMessage.Text = "You must enter a username and password in the boxes below.";
            }
            if(txtPassword.Text == "")
            {
                allGood = false;
                lblMessage.Text = "You must enter a username and password in the boxes below.";
            }
            if (allGood)
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CheckUserAccount";
                objCommand.Parameters.Clear();

                objCommand.Parameters.AddWithValue("@theEmail", txtEmail.Text);
                objCommand.Parameters.AddWithValue("@thePassword", txtPassword.Text);

                DataSet myAccount = objDB.GetDataSetUsingCmdObj(objCommand);

                if (myAccount.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Text = "You logged in good job!";
                    //might need to switch this to a UserAccount Object, not sure tho
                    Session.Add("userEmail", txtEmail.Text);
                }
                else
                {
                    lblMessage.Text = "Error: username or password incorrect";
                }
            }
        }
    }
}