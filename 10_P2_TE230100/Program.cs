Console.WriteLine("Registro de motores");
Console.WriteLine();

string continuar = "SI";

// Ciclo while: permite registrar una cantidad desconocida de motores
while (continuar == "SI")
{
    // Crear objeto de la clase
    Motor motor1 = new Motor();

    // Capturar el identificador
    Console.Write("Ingrese el identificador del motor: ");
    motor1.Identificador = Console.ReadLine() ?? "Sin ID";

    // Capturar las cuatro mediciones mediante ciclo for
    for (int i = 0; i < 4; i++)
    {
        Console.Write($"Ingrese la medición {i + 1} de corriente (A): ");
        motor1.Mediciones[i] = Convert.ToDouble(Console.ReadLine());
    }

    // Calcular el promedio de corriente
    motor1.CalcularPromedio();

    Console.WriteLine();

    // Mostrar los resultados
    motor1.MostrarDatos();

    Console.WriteLine();

    // Preguntar si se desea registrar otro motor
    Console.Write("¿Desea registrar otro motor? (SI/NO): ");
    continuar = (Console.ReadLine() ?? "NO").ToUpper();

    Console.WriteLine();
}

// Clase Motor
class Motor
{
    // Propiedades
    public string Identificador { get; set; } = "";
    public double[] Mediciones { get; set; } = new double[4];
    public double Promedio { get; set; }

    // Método para calcular el promedio
    public void CalcularPromedio()
    {
        double suma = 0;

        for (int i = 0; i < Mediciones.Length; i++)
        {
            suma += Mediciones[i];
        }

        Promedio = suma / Mediciones.Length;
    }

    // Método para determinar el diagnóstico
    public string EvaluarDiagnostico()
    {
        if (Promedio <= 5)
        {
            return "NORMAL";
        }
        else
        {
            return "REQUIERE MANTENIMIENTO";
        }
    }

    // Mostrar los datos
    public void MostrarDatos()
    {
        Console.WriteLine("----- DIAGNÓSTICO DEL MOTOR -----");
        Console.WriteLine($"Identificador: {Identificador}");
        Console.WriteLine($"Promedio de corriente: {Promedio:F2} A");
        Console.WriteLine($"Diagnóstico: {EvaluarDiagnostico()}");
    }
}