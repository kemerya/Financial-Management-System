﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Financial_Managment_System
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from  SignUp_Table Where Email='" + TextBox2.Text.Trim() + "' AND Password='" + TextBox1.Text.Trim() + "' AND Username='" + TextBox3.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Login Successful');</script>");
                        Session["Email"] = dr.GetValue(2).ToString();
                        Session["Password"] = dr.GetValue(4).ToString();
                        Session["Username"] = dr.GetValue(3).ToString();
                        
                        Session["Role"] = "Admin";
                    }
                         Response.Redirect("tips.aspx");



                }
                else
                {
                    Response.Write("<script>alert('Invalid Credential');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");



            }

        }
    }
}