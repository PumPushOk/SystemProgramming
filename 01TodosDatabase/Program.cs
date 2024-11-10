using TodosDatabase;

SqlServerTodoStorage storage = new SqlServerTodoStorage();

//storage.Add("walk in garden", 24);
//storage.Add("play a game", 12);
//storage.Add("buy some milk", 44);
//storage.Add("eat with family", 3);
//storage.Add("go sleep", 1);
//storage.DoneTodo(2);
//storage.DeleteAllCompleted();
foreach (Todo todo in storage.GetAllSortedByDeadline())
{
	Console.WriteLine($"Todo #{todo.Id} | Title: {todo.Title} IsCompleted: {todo.IsCompleted}");
}
//storage.Remove(2);
//Todo? todo = storage.GetById(1);
//if (todo != null)
//	Console.WriteLine($"Todo #{todo.Id} | Title: {todo.Title}");
//else
//	Console.WriteLine("Todo is not found!");