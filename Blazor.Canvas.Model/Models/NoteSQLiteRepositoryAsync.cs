using System.Data;
using System.Data.SQLite;
using Blazor.Canvas.Model.Interfaces;
using Dapper;

namespace Blazor.Canvas.Model.Models
{
    /// <summary>
    /// [4][2][2] 리포지토리 클래스(비동기 방식): Micro ORM인 Dapper를 사용하여 CRUD 구현
    /// </summary>
    public class NoteSQLiteRepositoryAsync : IRepositoryAsync<Note>
    {
        private readonly SQLiteConnection db;
        public NoteSQLiteRepositoryAsync()
        {
            db = new SQLiteConnection("Data Source=C:\\git\\Blazor.Canvas\\Data\\notes.db;Version=3");
        }
        public NoteSQLiteRepositoryAsync(string connectionString)
        {
            db = new SQLiteConnection(connectionString);
        }

        // 입력
        public async Task<Note> AddAsync(Note model)
        {
            const string query =
            "Insert Into Notes(Id, Title, Url, Name, Company, CreatedBy) Values(@Id, @Title, @Url, @Name, @Company, @CreatedBy);";

            await db.ExecuteAsync(query, model);
            return model;

        }

        // 출력
        public async Task<List<Note>> GetAsync()
        {
            const string query = "Select * From Notes;";

            var notes = await db.QueryAsync<Note>(query);

            return notes.ToList();
        }

        public async Task<int> GetMaxIdAsync()
        {
            const string query = "Select MAX(Id) From Notes;";

            return await db.QueryFirstOrDefaultAsync<int>(query);
        }
        // 삭제
        public async Task RemoveVideoAsync(int id)
        {
            const string query = "Delete FROM Notes Where Id = @Id";

            await db.ExecuteAsync(query, new { id }, commandType: CommandType.Text);
        }

        // 수정
        public async Task<Note> UpdateAsync(Note model)
        {
            const string query = @"
                    Update Notes 
                    Set 
                        Title = @Title, 
                        Url = @Url, 
                        Name = @Name, 
                        Company = @Company, 
                        ModifiedBy = @ModifiedBy 
                    Where Id = @Id";

            await db.ExecuteAsync(query, model);

            return model;
        }
    }
}