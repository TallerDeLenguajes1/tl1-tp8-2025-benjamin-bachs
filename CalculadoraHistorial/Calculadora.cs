namespace EspacioCalculadora;

public class Calculadora
{
    private double dato;
    private List<Operacion> historial;

    public Calculadora()
    {
        dato = 0;
        historial = new List<Operacion>();
    }

    public void Sumar(double termino)
    {
        double resultadoAnterior = dato;
        dato += termino;
        historial.Add(new Operacion(resultadoAnterior, termino, TipoOperacion.Suma));
    }

    public void Restar(double termino)
    {
        double resultadoAnterior = dato;
        dato -= termino;
        historial.Add(new Operacion(resultadoAnterior, termino, TipoOperacion.Resta));
    }

    public void Multiplicar(double termino)
    {
        double resultadoAnterior = dato;
        dato *= termino;
        historial.Add(new Operacion(resultadoAnterior, termino, TipoOperacion.Multiplicacion));
    }

    public void Dividir(double termino)
    {
        double resultadoAnterior = dato;
        if (termino != 0)
        {
            dato /= termino;
            historial.Add(new Operacion(resultadoAnterior, termino, TipoOperacion.Division));
        }
        else
        {
            Console.WriteLine("Error: No se puede dividir por cero.");
        }
    }

    public void Limpiar()
    {
        double resultadoAnterior = dato;
        dato = 0;
        historial.Add(new Operacion(resultadoAnterior, 0, TipoOperacion.Limpiar));
    }

    public double Resultado
    {
        get { return dato; }
    }

    // Método para obtener el historial de operaciones
    public List<Operacion> ObtenerHistorial()
    {
        return new List<Operacion>(historial);
    }

    // Método para limpiar el historial
    public void LimpiarHistorial()
    {
        historial.Clear();
    }

    // Método para mostrar el historial
    public void MostrarHistorial()
    {
        if (historial.Count == 0)
        {
            Console.WriteLine("No hay operaciones en el historial.");
            return;
        }

        Console.WriteLine("\n=== HISTORIAL DE OPERACIONES ===");
        for (int i = 0; i < historial.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {historial[i]}");
        }
        Console.WriteLine("================================");
    }
}