List<string> TaskList = new List<string>(); //Auto property inicializer


int menuSelected = 0;
do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);


/// <summary>
/// Show the main menu 
/// </summary>
/// <returns>Returns option indicated by user</returns>
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    // Read line
    string lineRead = Console.ReadLine();
    return Convert.ToInt32(lineRead);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        // Show current taks
        ShowAllTasks(); ;

        string ItemTaskToDeleteSelected = Console.ReadLine();
        // Remove one position
        int ItemTaskSelectedConvertedInt = Convert.ToInt32(ItemTaskToDeleteSelected) - 1;

        if (ItemTaskSelectedConvertedInt > (TaskList.Count - 1) || ItemTaskSelectedConvertedInt < 0)
        {
            Console.WriteLine("Numero de tarea fuera de rango");
        }
        else
        {
            if (ItemTaskSelectedConvertedInt > -1 && TaskList.Count > 0)
            {
                string TaskToDelete = TaskList[ItemTaskSelectedConvertedInt];
                TaskList.RemoveAt(ItemTaskSelectedConvertedInt);
                Console.WriteLine($"Tarea {TaskToDelete} eliminada");
            }
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea");

    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string TaskNametoAdd = Console.ReadLine();
        if (TaskNametoAdd == "")
        {
            Console.WriteLine("Campo vacio, debe ingresar una tarea valida");
        }
        else
        {
            TaskList.Add(TaskNametoAdd);
            Console.WriteLine("Tarea registrada");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Error inesperado en registro tarea");
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0) // Null conditional operator
    {
        ShowAllTasks();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}
void ShowAllTasks()
{
    Console.WriteLine("----------------------------------------");
    var indexTask = 0;
    TaskList.ForEach(p => Console.WriteLine($"{++indexTask} . {p}"));  // String interpolation                        
    Console.WriteLine("----------------------------------------");
}


public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}

