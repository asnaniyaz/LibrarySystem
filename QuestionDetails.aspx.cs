using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using Newtonsoft.Json;

namespace Library
{
    public partial class QuestionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int questionId;
                if (int.TryParse(Request.QueryString["id"], out questionId))
                {
                    try
                    {
                        string apiUrl = "https://api.stackexchange.com/2.3/questions/" + questionId + "/answers?order=desc&sort=votes&site=stackoverflow";
                        using (WebClient client = new WebClient())
                        {
                            client.Headers.Add("Accept-Encoding", "gzip, deflate");

                            byte[] compressedData = client.DownloadData(apiUrl);

                            using (var stream = new MemoryStream(compressedData))
                            {
                                using (var gzip = new GZipStream(stream, CompressionMode.Decompress))
                                {
                                    using (var reader = new StreamReader(gzip))
                                    {
                                        string json = reader.ReadToEnd();

                                        RootObject response = JsonConvert.DeserializeObject<RootObject>(json);

                                        if (response.Items != null && response.Items.Count > 0)
                                        {
                                            List<Answer> answers = new List<Answer>();

                                            foreach (var item in response.Items)
                                            {
                                                if (item.Answers != null && item.Answers.Count > 0)
                                                {
                                                    answers.AddRange(item.Answers);
                                                }
                                            }

                                            if (answers.Count > 0)
                                            {
                                                answersGridView.DataSource = answers;
                                                answersGridView.DataBind();
                                            }
                                            else
                                            {
                                                // No answers available
                                                answersGridView.Visible = false;
                                                noAnswersLabel.Visible = true;
                                            }
                                        }
                                        else
                                        {
                                            // No answers available
                                            answersGridView.Visible = false;
                                            noAnswersLabel.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("An error occurred while retrieving answers: " + ex.Message);
                    }
                }
            }
        }

        public class RootObject
        {
            public List<Item> Items { get; set; }
            public bool HasMore { get; set; }
            public int QuotaMax { get; set; }
            public int QuotaRemaining { get; set; }
        }

        public class Item
        {
            [JsonProperty("answers")]
            public List<Answer> Answers { get; set; }
        }

        public class Answer
        {
            public int AnswerId { get; set; }
            public int QuestionId { get; set; }
            public string Text { get; set; }
        }
    }
}
