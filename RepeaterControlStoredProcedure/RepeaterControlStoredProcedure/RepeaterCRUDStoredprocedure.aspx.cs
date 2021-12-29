using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RepeaterControlStoredProcedure
{
    public partial class RepeaterCRUDStoredprocedure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }
        }
        private void BindRepeater()
        {
            string constr = ConfigurationManager.ConnectionStrings["Vaibhav test dbConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Users_CRUD"))
                {
                    cmd.Parameters.AddWithValue("@Action", "SELECT");
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Repeater1.DataSource = dt;
                            Repeater1.DataBind();
                        }
                    }
                }
            }
        }
        protected void Insert_Data(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string address = TextAddress.Text;
            string email = TextEmail.Text;
            string mobile = Textmobile.Text;
            string password = txtPassword.Text;

            string constr = ConfigurationManager.ConnectionStrings["Vaibhav test dbConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Users_CRUD"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.Parameters.AddWithValue("@UserName", name);
                    cmd.Parameters.AddWithValue("@UserAddress", address);
                    cmd.Parameters.AddWithValue("@UserEmail", email);
                    cmd.Parameters.AddWithValue("@Usermobile", mobile);
                    cmd.Parameters.AddWithValue("@Password", password);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindRepeater();
        }
        protected void OnEdit(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, true);
        }

        private void ToggleElements(RepeaterItem item, bool isEdit)
        {
            //Toggle Buttons.
            item.FindControl("lnkEdit").Visible = !isEdit;
            item.FindControl("lnkUpdate").Visible = isEdit;
            item.FindControl("lnkCancel").Visible = isEdit;
            item.FindControl("lnkDelete").Visible = !isEdit;

            //Toggle Labels.
            item.FindControl("lblUserName").Visible = !isEdit;
            item.FindControl("lblAddress").Visible = !isEdit;
            item.FindControl("Label1").Visible = !isEdit;
            item.FindControl("Label2").Visible = !isEdit;
            item.FindControl("Label3").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("txtUserName").Visible = isEdit;
            item.FindControl("txtAddress").Visible = isEdit;
            item.FindControl("TextBox1").Visible = isEdit;
            item.FindControl("TextBox2").Visible = isEdit;
            item.FindControl("TextBox3").Visible = isEdit;
        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int UserId = int.Parse((item.FindControl("lblUserId") as Label).Text);
            string name = (item.FindControl("txtUserName") as TextBox).Text.Trim();
            string address = (item.FindControl("txtAddress") as TextBox).Text.Trim();
            string email = (item.FindControl("TextBox1") as TextBox).Text.Trim();
            string mobile = (item.FindControl("TextBox2") as TextBox).Text.Trim();
            string password = (item.FindControl("TextBox3") as TextBox).Text.Trim();

            string constr = ConfigurationManager.ConnectionStrings["Vaibhav test dbConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Users_CRUD"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@userName", name);
                    cmd.Parameters.AddWithValue("@UserAddress", address);
                    cmd.Parameters.AddWithValue("@UserEmail", email);
                    cmd.Parameters.AddWithValue("@Usermobile", mobile);
                    cmd.Parameters.AddWithValue("@Password", password);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindRepeater();
        }
        protected void OnCancel(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, false);
        }
        protected void OnDelete(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            int UserId = int.Parse((item.FindControl("lblUserId") as Label).Text);

            string constr = ConfigurationManager.ConnectionStrings["Vaibhav test dbConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Users_CRUD"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindRepeater();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}