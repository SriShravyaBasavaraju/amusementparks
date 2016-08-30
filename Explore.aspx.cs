using AmusementParks.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmusementParks
{
    public partial class Explore : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AmusementParks"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                populateStates();

                ListItem stateli = new ListItem("Select State", "-1");
                statesDropDown.Items.Insert(0, stateli);

                ListItem parkli = new ListItem("Select Park", "-1");
                parksDropDown.Items.Insert(0, parkli);

                parksDropDown.Enabled = false;
            }
        }

        private void populateStates()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select distinct State from dbo.Location",con);
                con.Open();
                statesDropDown.DataSource =  cmd.ExecuteReader();
                statesDropDown.DataTextField = "State";
                statesDropDown.DataValueField = "State";

                statesDropDown.DataBind();
            }
        }

        protected void statesDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statesDropDown.SelectedIndex == 0)
            {
                parksDropDown.SelectedIndex = 0;
                parksDropDown.Enabled = false;
            }
            else
            {
                parksDropDown.Enabled = true;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select Name from dbo.Park where LocationID in (select ID from dbo.Location where State='" +
                        statesDropDown.SelectedValue + "')", con);
                    con.Open();
                    parksDropDown.DataSource = cmd.ExecuteReader();
                    parksDropDown.DataTextField = "Name";
                    parksDropDown.DataValueField = "Name";

                    parksDropDown.DataBind();

                    ListItem parkli = new ListItem("Select Park", "-1");
                    parksDropDown.Items.Insert(0, parkli);
                }
            }
        }

        protected void btnDirections_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select ID from dbo.Park where Name='" + parksDropDown.SelectedValue + "'",con);
                con.Open();
                int parkID = (int)cmd.ExecuteScalar();

                SqlCommand cmd1 = new SqlCommand("select Description from dbo.DrivingDirection where ParkID='" + parkID + "'", con);
                SqlDataReader reader = cmd1.ExecuteReader();
                if(reader.Read())
                {
                    gmap.Src = reader.GetString(0);
                }
            }
        }
    }
}