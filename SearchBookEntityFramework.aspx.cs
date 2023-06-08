using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Library
{
    public partial class SearchBookEntityFramework : System.Web.UI.Page
    {
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
            using (var context = new LibraryDBContext())
            {
                var query = context.Books.Include("Author").AsQueryable();

                if (dlSearch.SelectedValue == "7")
                {
                    if (dlSubCat.SelectedItem.Text != "All")
                    {
                        int subCategoryId = int.Parse(dlSubCat.SelectedValue);
                        query = query.Where(b => b.AuthorId == subCategoryId);
                    }
                }
                else
                {
                    int categoryId = int.Parse(dlSearch.SelectedValue);
                    if (dlSubCat.SelectedItem.Text != "All")
                    {
                        int subCategoryId = int.Parse(dlSubCat.SelectedValue);
                        query = query.Where(b => b.AuthorId == subCategoryId && b.CategoryID == categoryId);
                    }
                    else
                    {
                        query = query.Where(b => b.CategoryID == categoryId);
                    }
                }

                var results = query.ToList();

                gvSearch.DataSource = results;
                gvSearch.DataBind();
            }
        }

        public void BindCategory()
        {
            using (var context = new LibraryDBContext())
            {
                var categories = context.Categories.ToList();
                dlSearch.DataSource = categories;
                dlSearch.DataTextField = "CategoryName";
                dlSearch.DataValueField = "CategoryID";
                dlSearch.DataBind();
                dlSearch.Items.Insert(0, "Select");
            }
        }

        public void BindSubCategory()
        {
            if (dlSearch.SelectedIndex > 0)
            {
                int categoryId = int.Parse(dlSearch.SelectedValue);
                using (var context = new LibraryDBContext())
                {
                    var subCategories = context.SubCategories.Where(s => s.CategoryID == categoryId).ToList();
                    dlSubCat.DataSource = subCategories;
                    dlSubCat.DataTextField = "SubCategoryName";
                    dlSubCat.DataValueField = "SubCategoryID";
                    dlSubCat.DataBind();
                    dlSubCat.Items.Insert(0, "All");
                }
            }
            else
            {
                dlSubCat.Items.Clear();
            }
        }

        public class Author
        {
            public int AuthorId { get; set; }
            public string AuthorName { get; set; }
        }

        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public int AuthorId { get; set; }
            public Author Author { get; set; }
            public int CategoryID { get; set; } // Add CategoryID property
            public int SubCategoryId { get; set; }
        }

        public class Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
        }

        public class SubCategory
        {
            public int SubCategoryID { get; set; }
            public string SubCategoryName { get; set; }
            public int CategoryID { get; set; }
        }
        public class LibraryDBContext : DbContext
        {
            public LibraryDBContext() : base("name=DbConn")
            {
            }
            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<SubCategory> SubCategories { get; set; }



        }
    }
}
