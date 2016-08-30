using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmusementParks
{
    public partial class Directions : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AmusementParks"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateStates();

                ListItem stateli = new ListItem("Select State", "-1");
                statesDropDown.Items.Insert(0, stateli);
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select dbo.Attraction.ID as AttractionID, dbo.Park.ID as ParkID, dbo.Park.Name as ParkName, dbo.Park.Description as ParkDescription, dbo.Park.Timings as ParkTimings, dbo.Attraction.Name as AttractionName, dbo.Attraction.Description as AttractionDescription, dbo.Attraction.ImageUrl as AttractionImage from dbo.Park join dbo.Attraction on dbo.Park.ID = dbo.Attraction.ParkID", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void populateStates()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select distinct State from dbo.Location", con);
                con.Open();
                statesDropDown.DataSource = cmd.ExecuteReader();
                statesDropDown.DataTextField = "State";
                statesDropDown.DataValueField = "State";

                statesDropDown.DataBind();
            }
        }

        //    public string GenerateParksContent()
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            SqlDataAdapter da = new SqlDataAdapter("select dbo.Attraction.ID as AttractionID, dbo.Park.ID as ParkID, dbo.Park.Name as ParkName, dbo.Park.Description as ParkDescription, dbo.Park.Timings as ParkTimings, dbo.Attraction.Name as AttractionName, dbo.Attraction.Description as AttractionDescription, dbo.Attraction.ImageUrl as AttractionImage from dbo.Park join dbo.Attraction on dbo.Park.ID = dbo.Attraction.ParkID", con);
        //            DataSet ds = new DataSet();
        //            da.Fill(ds);

        //            parkContent.DataSource = ds.Tables[0];
        //            parkContent.DataBind();

        //        }
        //        string htmlContent = string.Empty;
        //        foreach (DataTable table in ds.Tables)
        //        {
        //            htmlContent += "<table style='text-align:center'>";
        //            foreach (DataRow row in table.Rows)
        //            {
        //                htmlContent += "<tr>";
        //                htmlContent += "<td><img style='margin: 15px' class='boxImage' src='" + row["AttractionImage"] + "' width='300px' height='250px' /></td>";
        //                //htmlContent += "&nbsp;&nbsp;";
        //                htmlContent += "<td><h3>" + row["ParkName"] + "</h3>";
        //                htmlContent += "<p>" + row["AttractionName"] + "</p></td>";
        //                htmlContent += "</tr>";
        //                htmlContent += "<tr><td colspan='2'><button style='width:150px' type='button' class='btn btn-info' onclick='location.href='Tickets.aspx?parkId='" + row["ParkID"] + "'&attractionId='" + row["AttractionId"] + "'> Buy Tickets </button></td></tr>";
        //            }
        //            htmlContent += "</table>";
        //        }


        //        return htmlContent;
        //    }
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            string htmlContent = string.Empty;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select dbo.Attraction.ID as AttractionID, dbo.Park.ID as ParkID, dbo.Park.Name as ParkName, dbo.Park.Description as ParkDescription, dbo.Park.Timings as ParkTimings, dbo.Attraction.Name as AttractionName, dbo.Attraction.Description as AttractionDescription, dbo.Attraction.ImageUrl as AttractionImage from dbo.Park join dbo.Attraction on dbo.Park.ID = dbo.Attraction.ParkID where dbo.Park.ID in (select ParkId from dbo.Location where dbo.Location.State = '" + statesDropDown.SelectedValue + "')", con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                parkContent.DataSource = ds.Tables[0];
                parkContent.DataBind();
            }
        }

        protected void btnTckts_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tickets.aspx?");
        }
    }
}

