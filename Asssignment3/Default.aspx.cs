using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        //initialize the loginClass and pass it the user and password
        LoginClass lc = new LoginClass(UserTextBox.Text, PasswordTextBox.Text);
        int key = lc.ValidateLogin(); //call the validation method
        if (key != 0)
        {
            //if the login is good save the key to a session variable
            Session["userKey"] = key;
            //redirect to the other page
            Response.Redirect("GrantRquests.aspx");

        }
        else
        {
            ResultLabel.Text = "Invalid Login";
        }
    }


}