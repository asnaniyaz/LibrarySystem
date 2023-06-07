using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library
{
    public partial class SearchBook : System.Web.UI.Page
    {

        string ConnectionString = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategory();
            }
        }
        protected void dlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubCategory();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataAccess dataAccess = new DataAccess(ConnectionString);
            if (dlSearch.SelectedItem.Text == "Author Names")
            {
                if (dlSubCat.SelectedItem.Text == "All")
                {
                    dataAccess.GetData(dt, dlSearch.SelectedValue, "All");
                }
                else
                {
                    dataAccess.GetData(dt, dlSearch.SelectedValue, dlSubCat.SelectedValue);
                }
            }

            else
            {
                if (dlSubCat.SelectedItem.Text == "All")
                {
                    dataAccess.GetData(dt, dlSearch.SelectedValue, "All");
                }
                else
                {
                    dataAccess.GetData(dt, dlSearch.SelectedValue, dlSubCat.SelectedValue);
                }
            }

            //dlSearch.DataSource = dt;
            //dlSearch.DataTextField = "CategoryName";
            //dlSearch.DataValueField = "CategoryID";
            //dlSearch.DataBind();
            //dlSearch.Items.Insert(0, "Select");

            gvSearch.DataSource = dt;
            gvSearch.DataBind();

        }

        public void BindCategory()
        {
            DataAccess dataAccess = new DataAccess(ConnectionString);
            dataAccess.BindCat(dt);

            dlSearch.DataSource = dt;
            dlSearch.DataTextField = "CategoryName";
            dlSearch.DataValueField = "CategoryID";
            dlSearch.DataBind();
            dlSearch.Items.Insert(0, "Select");
        }

        public void BindSubCategory()
        {
            DataAccess dataAccess = new DataAccess(ConnectionString);
            dataAccess.BindSubCat(dt, dlSearch.SelectedValue);

            dlSubCat.DataSource = dt;
            dlSubCat.DataTextField = "SubCategoryName";
            dlSubCat.DataValueField = "SubCategoryID";
            dlSubCat.DataBind();
            dlSubCat.Items.Insert(0, "All");
        }
    }
}