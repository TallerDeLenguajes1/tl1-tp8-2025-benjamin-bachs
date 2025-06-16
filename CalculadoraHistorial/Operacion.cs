namespace EspacioCalculadora;

public class Operacion
{
    private double resultadoAnterior; // Almacena el resultado previo al cálculo actual
    private double nuevoValor; // El valor con el que se opera sobre el resultadoAnterior
    private TipoOperacion operacion; // El tipo de operación realizada

    public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion)
    {
        this.resultadoAnterior = resultadoAnterior;
        this.nuevoValor = nuevoValor;
        this.operacion = operacion;
    }

    // Propiedad para calcular o devolver el resultado
    public double Resultado
    {
        get
        {
            switch (operacion)
            {
                case TipoOperacion.Suma:
                    return resultadoAnterior + nuevoValor;
                case TipoOperacion.Resta:
                    return resultadoAnterior - nuevoValor;
                case TipoOperacion.Multiplicacion:
                    return resultadoAnterior * nuevoValor;
                case TipoOperacion.Division:
                    return nuevoValor != 0 ? resultadoAnterior / nuevoValor : resultadoAnterior;
                case TipoOperacion.Limpiar:
                    return 0;
                default:
                    return resultadoAnterior;
            }
        }
    }

    // Propiedad pública para acceder al nuevo valor utilizado en la operación
    public double NuevoValor
    {
        get { return nuevoValor; }
    }

    // Propiedad para acceder al resultado anterior
    public double ResultadoAnterior
    {
        get { return resultadoAnterior; }
    }

    // Propiedad para acceder al tipo de operación
    public TipoOperacion TipoOperacion
    {
        get { return operacion; }
    }

    // Método para obtener una representación en string de la operación
    public override string ToString()
    {
        string simbolo = operacion switch
        {
            TipoOperacion.Suma => "+",
            TipoOperacion.Resta => "-",
            TipoOperacion.Multiplicacion => "*",
            TipoOperacion.Division => "/",
            TipoOperacion.Limpiar => "C",
            _ => "?"
        };

        if (operacion == TipoOperacion.Limpiar)
        {
            return $"Limpiar -> {Resultado}";
        }

        return $"{resultadoAnterior} {simbolo} {nuevoValor} = {Resultado}";
    }
}