using EspacioCalculadora;
using System;

class Program
{
    static void Main(string[] args)
    {
        Calculadora calc = new Calculadora();
        string comando;
        
        Console.WriteLine("=== CALCULADORA CON ENCADENAMIENTO E HISTORIAL ===");
        Console.WriteLine("Comandos disponibles:");
        Console.WriteLine("+ [número] - Sumar");
        Console.WriteLine("- [número] - Restar");
        Console.WriteLine("* [número] - Multiplicar");
        Console.WriteLine("/ [número] - Dividir");
        Console.WriteLine("= - Mostrar resultado");
        Console.WriteLine("c - Limpiar (reiniciar a 0)");
        Console.WriteLine("h - Mostrar historial");
        Console.WriteLine("ch - Limpiar historial");
        Console.WriteLine("salir - Terminar programa");
        Console.WriteLine("===================================================");
        Console.WriteLine($"Resultado actual: {calc.Resultado}");

        do
        {
            Console.Write("\nIngrese comando: ");
            comando = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(comando))
                continue;

            try
            {
                if (comando == "salir")
                {
                    Console.WriteLine("¡Hasta luego!");
                    break;
                }
                else if (comando == "=")
                {
                    Console.WriteLine($"Resultado: {calc.Resultado}");
                }
                else if (comando == "c")
                {
                    calc.Limpiar();
                    Console.WriteLine($"Calculadora limpiada. Resultado: {calc.Resultado}");
                }
                else if (comando == "h")
                {
                    calc.MostrarHistorial();
                }
                else if (comando == "ch")
                {
                    calc.LimpiarHistorial();
                    Console.WriteLine("Historial limpiado.");
                }
                else if (comando.StartsWith("+"))
                {
                    string numeroStr = comando.Substring(1).Trim();
                    if (double.TryParse(numeroStr, out double numero))
                    {
                        calc.Sumar(numero);
                        Console.WriteLine($"Sumado {numero}. Resultado: {calc.Resultado}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Número inválido.");
                    }
                }
                else if (comando.StartsWith("-"))
                {
                    string numeroStr = comando.Substring(1).Trim();
                    if (double.TryParse(numeroStr, out double numero))
                    {
                        calc.Restar(numero);
                        Console.WriteLine($"Restado {numero}. Resultado: {calc.Resultado}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Número inválido.");
                    }
                }
                else if (comando.StartsWith("*"))
                {
                    string numeroStr = comando.Substring(1).Trim();
                    if (double.TryParse(numeroStr, out double numero))
                    {
                        calc.Multiplicar(numero);
                        Console.WriteLine($"Multiplicado por {numero}. Resultado: {calc.Resultado}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Número inválido.");
                    }
                }
                else if (comando.StartsWith("/"))
                {
                    string numeroStr = comando.Substring(1).Trim();
                    if (double.TryParse(numeroStr, out double numero))
                    {
                        double resultadoAnterior = calc.Resultado;
                        calc.Dividir(numero);
                        if (numero != 0)
                        {
                            Console.WriteLine($"Dividido por {numero}. Resultado: {calc.Resultado}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Número inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Comando no reconocido. Use +, -, *, /, =, c, h, ch o 'salir'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        } while (comando != "salir");
    }
}
