using Microsoft.Data.SqlClient;
using System.Data;

namespace TodosDatabase;

public class SqlServerTodoStorage : ITodoStorage
{
    private readonly string _connectionString =
		@"Server=DESKTOP-9L5BAUH\SQLEXPRESS; Database=itstepDB; Trusted_Connection=True; Encrypt=False";
    private readonly SqlConnection _connection;
    private readonly SqlCommand _command;
    public SqlServerTodoStorage()
    {
        _connection = new SqlConnection(_connectionString);
        _connection.Open();

        _command = _connection.CreateCommand();
    }
    public int Add(string title, int hoursToComplete)
    {
        //Добавляємо тудушку і повертаємо кількість змінених рядків
        _command.CommandText = $"INSERT INTO todos VALUES('{title}', 0, '{DateTime.Now}', '{DateTime.Now.AddHours(hoursToComplete)}');";
        return _command.ExecuteNonQuery();
    }
    public IEnumerable<Todo> GetAll()
    {
        // Получаємо всі тудушки
        _command.CommandText = "SELECT * FROM todos;";
        var reader = _command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Todo
            {
                Id = reader.GetInt32("id"),
                Title = reader.GetString("title"),
                IsCompleted = reader.GetBoolean("is_completed"),
                CreatedAt = reader.GetDateTime("created_at"),
                DeadlineAt = reader.GetDateTime("deadline_at")
            };
        }
        reader.Close();
    }
    public Todo? GetById(int id)
    {
        // Шукаємо тудушку по айді і повертаємо, інакше повертаємо null
        _command.CommandText = $"SELECT TOP 1 * FROM todos WHERE id = {id};";
        var reader = _command.ExecuteReader();
        if (reader.Read())
        {
            return new Todo
            {
                Id = reader.GetInt32("id"),
                Title = reader.GetString("title"),
                IsCompleted = reader.GetBoolean("is_completed"),
                CreatedAt = reader.GetDateTime("created_at"),
                DeadlineAt = reader.GetDateTime("deadline_at")
            };
        }
        return null;
	}
    public int Remove(int id)
    {
		// Видаляємо тудушку по айді і повертаємо кількість змінених рядків
		_command.CommandText = $"DELETE FROM todos WHERE id = {id};";
		return _command.ExecuteNonQuery();
	}
	public int DoneTodo(int id)
	{
		// Міняємо статуc виконанння на true і повертаємо кількість змінених рядків
		_command.CommandText = $"UPDATE todos SET is_completed = 1 WHERE id = {id};";
		return _command.ExecuteNonQuery();
	}
    public IEnumerable<Todo> GetAllSortedByDeadline()
    {
		// Получаємо всі тудушки посортовані за дедлайном
		_command.CommandText = "SELECT * FROM todos ORDER BY deadline_at;";
		var reader = _command.ExecuteReader();

		while (reader.Read())
		{
			yield return new Todo
			{
				Id = reader.GetInt32("id"),
				Title = reader.GetString("title"),
				IsCompleted = reader.GetBoolean("is_completed"),
				CreatedAt = reader.GetDateTime("created_at"),
				DeadlineAt = reader.GetDateTime("deadline_at")
			};
		}
		reader.Close();
	}
    public int DeleteAllCompleted()
    {
        _command.CommandText = "DELETE FROM todos WHERE is_completed = 1;";
        return _command.ExecuteNonQuery();
    }
}
