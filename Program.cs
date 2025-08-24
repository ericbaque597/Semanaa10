using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Crear 500 ciudadanos
        List<string> ciudadanos = new List<string>();
        for (int i = 1; i <= 500; i++)
            ciudadanos.Add("Ciudadano " + i);

        Random rnd = new Random();

        // Crear 75 vacunados con Pfizer
        HashSet<string> pfizer = new HashSet<string>();
        while (pfizer.Count < 75)
        {
            int index = rnd.Next(0, 500);
            pfizer.Add(ciudadanos[index]);
        }

        // Crear 75 vacunados con AstraZeneca
        HashSet<string> astra = new HashSet<string>();
        while (astra.Count < 75)
        {
            int index = rnd.Next(0, 500);
            astra.Add(ciudadanos[index]);
        }

        // Calcular intersección y diferencias
        var ambasDosis = pfizer.Intersect(astra).ToList();
        var soloPfizer = pfizer.Except(astra).ToList();
        var soloAstra = astra.Except(pfizer).ToList();
        var noVacunados = ciudadanos.Except(pfizer).Except(astra).ToList();

        // Mostrar resultados de forma resumida
        MostrarGrupo("No vacunados", noVacunados);
        MostrarGrupo("Con ambas dosis (Pfizer y AstraZeneca)", ambasDosis);
        MostrarGrupo("Solo Pfizer", soloPfizer);
        MostrarGrupo("Solo AstraZeneca", soloAstra);

        Console.WriteLine("\nProceso completado.");
        Console.ReadKey();
    }

    static void MostrarGrupo(string titulo, List<string> grupo)
    {
        Console.WriteLine($"\n=== {titulo} ===");
        Console.WriteLine($"Total: {grupo.Count}");
        Console.WriteLine("Ejemplos:");
        foreach (var c in grupo.Take(10))
            Console.WriteLine($"- {c}");
        if (grupo.Count > 10)
            Console.WriteLine("... (y " + (grupo.Count - 10) + " más)");
    }
}
