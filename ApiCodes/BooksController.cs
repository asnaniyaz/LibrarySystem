using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using WebApi.Models;
using System.Configuration;

namespace WebApi.Controllers
{
    public class BooksController : ApiController
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
        DataTable dt = new DataTable();

        // GET api/books
        public IHttpActionResult GetBooks()
        {
            List<Book> books = GetBooksFromDatabase();
            return Ok(books);
        }

        // GET api/books/{id}
        public IHttpActionResult GetBook(int id)
        {
            Book book = GetBookFromDatabase(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        private List<Book> GetBooksFromDatabase()
        {
            List<Book> books = new List<Book>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[GetDataApi]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", DBNull.Value);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int bookId = Convert.ToInt32(reader["BookId"]);
                    string title = reader["Title"].ToString();
                    string author = reader["Author"].ToString();
                    //DateTime publishDate = reader.GetDateTime(reader.GetOrdinal("PublishDate"));
                    //DateTime publishDate;
                    //if (!reader.IsDBNull(reader.GetOrdinal("PublishDate")))
                    //{
                    //    publishDate = reader.GetDateTime(reader.GetOrdinal("PublishDate"));
                    //}
                    //else
                    //{
                    //    // Handle the case when PublishDate is null
                    //    publishDate = DateTime.MinValue; // or any other default value
                    //}
                    string description = reader["Description"].ToString();
                    string availability = reader["Availability"].ToString();

                    Book book = new Book
                    {
                        Id = bookId,
                        Title = title,
                        Author = author,
                        //PublishDate = publishDate,
                        Description = description,
                        Availability = availability
                    };

                    books.Add(book);
                }

                reader.Close();
            }

            return books;
        }

        private Book GetBookFromDatabase(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[GetDataApi]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int bookId = Convert.ToInt32(reader["BookId"]);
                    string title = reader["Title"].ToString();
                    string author = reader["Author"].ToString();
                    //DateTime publishDate = reader.GetDateTime(reader.GetOrdinal("PublishDate"));
                    //DateTime publishDate;
                    //if (!reader.IsDBNull(reader.GetOrdinal("PublishDate")))
                    //{
                    //    publishDate = reader.GetDateTime(reader.GetOrdinal("PublishDate"));
                    //}
                    //else
                    //{
                    //    // Handle the case when PublishDate is null
                    //    publishDate = DateTime.MinValue; // or any other default value
                    //}
                    string description = reader["Description"].ToString();
                    string availability = reader["Availability"].ToString();

                    Book book = new Book
                    {
                        Id = bookId,
                        Title = title,
                        Author = author,
                        //PublishDate = publishDate,
                        Description = description,
                        Availability = availability
                    };

                    reader.Close();
                    return book;
                }
            }

            return null;
        }
    }
}
