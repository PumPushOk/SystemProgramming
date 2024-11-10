namespace TodosDatabase;

public interface ITodoStorage
{
    int Add(string title, int hoursToComplete);
    IEnumerable<Todo> GetAll();
    Todo? GetById(int id);
    int Remove(int id);
}