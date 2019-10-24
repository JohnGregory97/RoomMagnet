using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class CreateAccount : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RoomMagnetAWS"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            

        }
        catch (Exception)
        {
            OutputLabel.Text = "Error connecting to Database";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        sc.Open();

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;

        System.Data.SqlClient.SqlCommand setPass = new System.Data.SqlClient.SqlCommand();
        setPass.Connection = sc;

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
        select.Connection = sc;
        
            if (HostTenantButtons.SelectedValue == "T")
            {
                Tenant tempTenant = new Tenant();

                tempTenant.SetFirstName(FirstNameBox.Text);
                tempTenant.SetLastName(LastNameBox.Text);
                tempTenant.SetEmail(EmailBox.Text);
                if (dobBox.Text.Length == 10)
                    tempTenant.SetBirthDate(Convert.ToDateTime(dobBox.Text));

                if (PasswordBox.Text == ConfirmPasswordBox.Text && PasswordBox.Text.Length > 0)
                {
                    try
                    {
                        tempTenant.SetPassword(PasswordBox.Text);

                        insert.CommandText = "INSERT INTO [dbo].[Tenant] (firstName, lastName, email, birthDate, gender) VALUES " +
                            "(@firstName, @lastName, @email, @dob, @gender)";

                        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@firstName", tempTenant.GetFirstName()));
                        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastName", tempTenant.GetLastName()));
                        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", tempTenant.GetEmail()));
                        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dob", tempTenant.GetBirthDate()));
                        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@gender", DropDownList1.SelectedValue));

                        insert.ExecuteNonQuery();

                        setPass.CommandText = "INSERT INTO [dbo].[Passwords] (email, password, userType) VALUES " +
                            "(@email, @password, @userType)";

                        setPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", tempTenant.GetEmail()));
                        setPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@password", PasswordHash.HashPassword(tempTenant.GetPassword())));
                        setPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@userType", "T"));

                        setPass.ExecuteNonQuery();

                        OutputLabel.Text = "Account created.";

                        select.CommandText = "Select userType from Passwords where email = @email2";
                        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email2", tempTenant.GetEmail()));

                        Session["userType"] = Convert.ToString(select.ExecuteScalar());

                        select.CommandText = "Select email from Passwords where email = @email3";
                        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email3", tempTenant.GetEmail()));

                        Session["userEmail"] = Convert.ToString(select.ExecuteScalar());

                        Response.Redirect("Dashboard.aspx");
                    }
                    catch
                    {
                        if (FirstNameBox.Text.Length > 0 && LastNameBox.Text.Length > 0 && EmailBox.Text.Length > 0
                            && dobBox.MaxLength == 10 && PasswordBox.Text.Length > 0 && ConfirmPasswordBox.Text.Length > 0)
                        {
                            OutputLabel.Text = "An account with this email already exists.";
                        }
                    }
                }
                else
                {
                    OutputLabel.Text = "Passwords do not match.";
                }
            }
            else
            {
                Host tempHost = new Host();

                tempHost.SetFirstName(FirstNameBox.Text);
                tempHost.SetLastName(LastNameBox.Text);
                tempHost.SetHostEmail(EmailBox.Text);
                if (dobBox.Text.Length == 10)
                    tempHost.SetBirthDate(Convert.ToDateTime(dobBox.Text));

                if (PasswordBox.Text == ConfirmPasswordBox.Text && PasswordBox.Text.Length > 0)
                {
                    try
                    {
                        tempHost.SetPassword(PasswordBox.Text);

                        insert.CommandText = "INSERT INTO [dbo].[Host] (firstName, lastName, email, birthDate, gender) VALUES " +
                            "(@firstName, @lastName, @email, @dob, @gender)";

                        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@firstName", tempHost.GetFistName()));
                        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lastName", tempHost.GetLastName()));
                        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", tempHost.GetHostEmail()));
                        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dob", tempHost.GetBirthDate()));
                        insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@gender", DropDownList1.SelectedValue));

                        insert.ExecuteNonQuery();

                        setPass.CommandText = "INSERT INTO [dbo].[Passwords] (email, password, userType) VALUES " +
                            "(@email, @password, @userType)";

                        setPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", tempHost.GetHostEmail()));
                        setPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@password", PasswordHash.HashPassword(tempHost.GetPassword())));
                        setPass.Parameters.Add(new System.Data.SqlClient.SqlParameter("@userType", "H"));

                        setPass.ExecuteNonQuery();

                        OutputLabel.Text = "Account created.";

                        select.CommandText = "Select userType from Passwords where email = @email2";
                        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email2", tempHost.GetHostEmail()));

                        Session["userType"] = Convert.ToString(select.ExecuteScalar());

                        select.CommandText = "Select email from Passwords where email = @email3";
                        select.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email3", tempHost.GetHostEmail()));

                        Session["userEmail"] = Convert.ToString(select.ExecuteScalar());

                        Response.Redirect("Dashboard.aspx");
                    }
                    catch
                    {
                        if (FirstNameBox.Text.Length > 0 && LastNameBox.Text.Length > 0 && EmailBox.Text.Length > 0
                            && dobBox.MaxLength == 10 && PasswordBox.Text.Length > 0 && ConfirmPasswordBox.Text.Length > 0)
                        {
                            OutputLabel.Text = "An account with this email already exists.";
                        }
                }
                }
                else
                {
                    OutputLabel.Text = "Passwords do not match.";
                }
            }
        
    }



    protected void ConfirmPasswordBox_TextChanged(object sender, EventArgs e)
    {
        if (PasswordBox.Text != ConfirmPasswordBox.Text)
        {
            OutputLabel.Text = "Passwords do not match.";
        }
        else
        {
            OutputLabel.Text = "";
        }
    }


    protected void PasswordBox_TextChanged(object sender, EventArgs e)
    {

    }

    //protected Boolean dateChecker(DateTime input)
    //{

    //    String dob = input.ToString("MM/DD/YYYY");
    //    if (dob.Length == 10 && Char.IsNumber(dob[0]) && Char.IsNumber(dob[1]) && Char.IsNumber(dob[3]) && Char.IsNumber(dob[4]) &&
    //            Char.IsNumber(dob[6]) && Char.IsNumber(dob[7]) && Char.IsNumber(dob[8]) && Char.IsNumber(dob[9]))
    //    {
    //        if (dob.IndexOf('/') == 2 && dob.IndexOf('/', 4) == 5)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
}