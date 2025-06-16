// See https://aka.ms/new-console-template for more information
int N = 0;
Random rnd = new();
List<Tarea> tareasPendientes = [];
List<Tarea> tareasRealizadas = [];

Console.Write("Ingrese el N de tareas: ");

for (int i = 0; i < 100; i++)
{
    string entrada = Console.ReadLine();
    if (int.TryParse(entrada, out N))
    {
        break;
    }
    else
    {
        Console.Write("Numero invalido, ingrese nuevamente:");
    }
}

for (int i = 0; i < N; i++)
{
    Tarea tarea = new(i, $"Tarea {i}", rnd.Next(10, 100));
    tareasPendientes.Add(tarea);
}

// Menú principal
bool continuar = true;
while (continuar)
{
    MostrarMenu();
    string opcion = Console.ReadLine();
    
    switch (opcion)
    {
        case "1":
            MoverTareaARealizadas();
            break;
        case "2":
            BuscarTareaPorDescripcion();
            break;
        case "3":
            MostrarTodasLasTareas();
            break;
        case "4":
            MostrarTareasPendientes();
            break;
        case "5":
            MostrarTareasRealizadas();
            break;
        case "6":
            continuar = false;
            Console.WriteLine("¡Gracias por usar el sistema de gestión de tareas!");
            break;
        default:
            Console.WriteLine("Opción inválida. Por favor, seleccione una opción del 1 al 6.");
            break;
    }
    
    if (continuar)
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}

// Funciones del sistema
void MostrarMenu()
{
    Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
    Console.WriteLine("1. Mover tarea a realizadas");
    Console.WriteLine("2. Buscar tarea pendiente por descripción");
    Console.WriteLine("3. Mostrar todas las tareas");
    Console.WriteLine("4. Mostrar tareas pendientes");
    Console.WriteLine("5. Mostrar tareas realizadas");
    Console.WriteLine("6. Salir");
    Console.Write("\nSeleccione una opción (1-6): ");
}

void MoverTareaARealizadas()
{
    Console.WriteLine("\n=== MOVER TAREA A REALIZADAS ===");
    
    if (tareasPendientes.Count == 0)
    {
        Console.WriteLine("No hay tareas pendientes para mover.");
        return;
    }
    
    Console.WriteLine("\nTareas pendientes:");
    MostrarListaTareas(tareasPendientes);
    
    Console.Write("\nIngrese el ID de la tarea a marcar como realizada: ");
    string entrada = Console.ReadLine();
    
    if (int.TryParse(entrada, out int tareaId))
    {
        Tarea tareaEncontrada = tareasPendientes.FirstOrDefault(t => t.TareaID == tareaId);
        
        if (tareaEncontrada != null)
        {
            tareasPendientes.Remove(tareaEncontrada);
            tareasRealizadas.Add(tareaEncontrada);
            Console.WriteLine($"✓ Tarea '{tareaEncontrada.Descripcion}' movida a realizadas exitosamente.");
        }
        else
        {
            Console.WriteLine("No se encontró una tarea pendiente con ese ID.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido. Debe ingresar un número.");
    }
}

void BuscarTareaPorDescripcion()
{
    Console.WriteLine("\n=== BUSCAR TAREA PENDIENTE ===");
    
    if (tareasPendientes.Count == 0)
    {
        Console.WriteLine("No hay tareas pendientes para buscar.");
        return;
    }
    
    Console.Write("Ingrese la descripción o parte de la descripción a buscar: ");
    string busqueda = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(busqueda))
    {
        Console.WriteLine("Debe ingresar una descripción para buscar.");
        return;
    }
    
    var tareasEncontradas = tareasPendientes.Where(t => 
        t.Descripcion.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList();
    
    if (tareasEncontradas.Any())
    {
        Console.WriteLine($"\nSe encontraron {tareasEncontradas.Count} tarea(s) pendiente(s):");
        MostrarListaTareas(tareasEncontradas);
    }
    else
    {
        Console.WriteLine("No se encontraron tareas pendientes que coincidan con la búsqueda.");
    }
}

void MostrarTodasLasTareas()
{
    Console.WriteLine("\n=== TODAS LAS TAREAS ===");
    
    Console.WriteLine($"\n--- TAREAS PENDIENTES ({tareasPendientes.Count}) ---");
    if (tareasPendientes.Count > 0)
    {
        MostrarListaTareas(tareasPendientes);
    }
    else
    {
        Console.WriteLine("No hay tareas pendientes.");
    }
    
    Console.WriteLine($"\n--- TAREAS REALIZADAS ({tareasRealizadas.Count}) ---");
    if (tareasRealizadas.Count > 0)
    {
        MostrarListaTareas(tareasRealizadas);
    }
    else
    {
        Console.WriteLine("No hay tareas realizadas.");
    }
    
    Console.WriteLine($"\nTotal de tareas: {tareasPendientes.Count + tareasRealizadas.Count}");
}

void MostrarTareasPendientes()
{
    Console.WriteLine("\n=== TAREAS PENDIENTES ===");
    
    if (tareasPendientes.Count > 0)
    {
        MostrarListaTareas(tareasPendientes);
        Console.WriteLine($"\nTotal de tareas pendientes: {tareasPendientes.Count}");
    }
    else
    {
        Console.WriteLine("No hay tareas pendientes.");
    }
}

void MostrarTareasRealizadas()
{
    Console.WriteLine("\n=== TAREAS REALIZADAS ===");
    
    if (tareasRealizadas.Count > 0)
    {
        MostrarListaTareas(tareasRealizadas);
        Console.WriteLine($"\nTotal de tareas realizadas: {tareasRealizadas.Count}");
    }
    else
    {
        Console.WriteLine("No hay tareas realizadas.");
    }
}

void MostrarListaTareas(List<Tarea> listaTareas)
{
    Console.WriteLine("┌─────┬──────────────────────────────┬──────────┐");
    Console.WriteLine("│ ID  │ Descripción                  │ Duración │");
    Console.WriteLine("├─────┼──────────────────────────────┼──────────┤");
    
    foreach (var tarea in listaTareas)
    {
        Console.WriteLine($"│ {tarea.TareaID,-3} │ {tarea.Descripcion,-28} │ {tarea.Duracion + " min",-8} │");
    }
    
    Console.WriteLine("└─────┴──────────────────────────────┴──────────┘");
}

public class Tarea
{
    public int TareaID { get; set; }
    public string Descripcion { get; set; }
    public int Duracion { get; set; } // Validar que esté entre 10 y 100

    public Tarea(int id, string descripcion, int duracion)
    {
        TareaID = id;
        Descripcion = descripcion;
        Duracion = duracion;
    }
}