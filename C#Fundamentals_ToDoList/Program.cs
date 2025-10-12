// See https://aka.ms/new-console-template for more information
ConsoleWriteMessage("1. Go To Library");
ConsoleWriteMessage("2. Bay the birthday cake ");
ConsoleWriteMessage(" ");
//Console.ReadKey();

//List<string> ToDoList = new List<string>();
List<string> ToDoList = new List<string> { "Apple", "Banana", "Cherry", "Date" };

bool isRunning = true;

do
{

    ConsoleWriteMessage("What Do You Want To Do? ");
    ConsoleWriteMessage("[S]ee all todos");
    ConsoleWriteMessage("[A]dd a todo");
    ConsoleWriteMessage("[R]emove a todo");
    ConsoleWriteMessage("[E]xit");

    string ReadKe = Console.ReadLine().ToUpper();

    switch (ReadKe)
    {
        case "S":
            SeeAll();
            break;
        case "A":
            AddItemToDoList();
            break;
        case "R":
            RemoveToDoListItemByIndex();
            break;
        case "E":
            ConsoleWriteMessage("Exiting To-Do List...");
            isRunning = false;
            break;
        default:
            ConsoleWriteMessage("Invalid option. Use S (See), A (Add), R (Remove), or E (Exit).");
            break;
    }
}
while (isRunning);

void SeeAll()
{
    ConsoleWriteMessage("\n--- To-Do List ---");
    if (ToDoList.Count == 0)
    {
        ConsoleWriteMessage("No tasks yet!");
        return;
    }
    for (int i = 0; i < ToDoList.Count; i++)
    {
        ConsoleWriteMessage($"{i + 1} -> : {ToDoList[i]}");
    }
    ConsoleWriteMessage("------------------\n");
}

void AddItemToDoList()
{
    ConsoleWriteMessage("Enter a new task: ");
    string newItem = Console.ReadLine();

    if (checkIsItemExist(newItem))
    {
        ConsoleWriteMessage($"{newItem} Is Exists ");
    }
    if (!string.IsNullOrWhiteSpace(newItem))
    {
        ToDoList.Add(newItem);
        ConsoleWriteMessage($"Added: {newItem}");
        SeeAll();
    }
    else
    {
        ConsoleWriteMessage("Cannot add empty task.");
    }
}


bool checkIsItemExist(string itemName)
{
    return ToDoList.Contains(itemName);
}

void RemoveToDoListItemByIndex()
{
    ConsoleWriteMessage("Enter the index of the task to remove: ");
    string input = Console.ReadLine();
    if (int.TryParse(input, out int itemIndex))
    {
        if (itemIndex >= 0 && itemIndex < ToDoList.Count)
        {
            string item = ToDoList[itemIndex - 1]; // Find item by index
            ToDoList.RemoveAt(itemIndex - 1);      // Remove by index
            ConsoleWriteMessage($"Removed: {item}");
            SeeAll();
        }
        else
        {
            ConsoleWriteMessage("Index out of range.");
        }
    }
    else
    {
        ConsoleWriteMessage("Invalid number. Please enter a valid index.");
    }

}

void ConsoleWriteMessage(string message)
{
    Console.WriteLine($"{message} ", Console.ForegroundColor);
}

Console.ReadKey();