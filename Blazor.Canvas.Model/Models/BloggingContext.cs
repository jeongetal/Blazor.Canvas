using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Canvas.Model.Models
{
    public class BloggingContext
    {
        public string DbPath { get; }

        public BloggingContext()
        {
            //var path = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName;
            //var path = Environment.GetFolderPath(folder);
            DbPath = "C:\\git\\Blazor.Canvas\\Data\\notes.sqlite";
        }
        public SqliteConnection GetSqlLiteConnection()
        {
            return new SqliteConnection("Data Source=" + DbPath);
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
    //internal class MyModel
    //{
    //    public string Sequence { get; set; } = string.Empty;
    //    public string Data { get; set; } = string.Empty;
    //    public bool IsDeleted { get; set; } = false;
    //    public DateTime CreatedTime { get; set; } = new();
    //    public DateTime ModifiedTime { get; set; } = new();
    //}
}
