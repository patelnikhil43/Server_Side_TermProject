using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

using System.Security.Cryptography;     // needed for the encryption classes
using System.IO;                        // needed for the MemoryStream
using System.Text;                      // needed for the UTF8 encoding
using System.Net;                       // needed for the cookie

namespace TermProjectSolution
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        protected void Page_Load(object sender, EventArgs e)
        {
            // Read encrypted password from cookie
            if (!IsPostBack && Request.Cookies["LoginCookie"] != null)
            {
                HttpCookie myCookie = Request.Cookies["LoginCookie"];
                txtEmail.Text = myCookie.Values["Username"];
                txtPassword.Text = myCookie.Values["Password"];
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //validate textboxes; done!
            //check if valid user; done!
            //check if there is a username and/or password saved in cookies
            //store userAccount in Session so they can't access all pages by typing in URL
            //maybe add radiobuttons to select which type of login??
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