using System;
using System.Linq;

namespace PicasYFijas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generar número secreto
            int numeroSecreto = GenerarNumeroSecreto();

            // Bucle principal del juego
            while (true)
            {
                // Pedir al jugador que ingrese un número
                Console.WriteLine("Ingrese un número de 4 dígitos: ");
                string numeroIngresado = Console.ReadLine();

                // Validar el número ingresado
                if (!ValidarNumero(numeroIngresado))
                {
                    Console.WriteLine("Número inválido. Intente de nuevo.");
                    continue;
                }

                // Calcular picas y fijas
                int picas = CalcularPicas(numeroSecreto, numeroIngresado);
                int fijas = CalcularFijas(numeroSecreto, numeroIngresado);

                // Mostrar resultado al jugador
                Console.WriteLine($"Picas: {picas}");
                Console.WriteLine($"Fijas: {fijas}");

                // Si hay 4 fijas, el jugador gana
                if (fijas == 4)
                {
                    Console.WriteLine("¡Felicidades! Ha adivinado el número secreto.");
                    break;
                }
            }
        }

        // Función para generar un número secreto aleatorio de 4 dígitos
        static int GenerarNumeroSecreto()
        {
            Random random = new Random();
            int numeroSecreto = 0;
            for (int i = 0; i < 4; i++)
            {
                numeroSecreto = numeroSecreto * 10 + random.Next(10);
            }
            return numeroSecreto;
        }

        // Función para validar que el número ingresado sea válido
        static bool ValidarNumero(string numero)
        {
            if (numero.Length != 4)
            {
                return false;
            }

            foreach (char caracter in numero)
            {
                if (!char.IsDigit(caracter))
                {
                    return false;
                }
            }

            return true;
        }

        // Función para calcular el número de picas
        static int CalcularPicas(int numeroSecreto, string numeroIngresado)
        {
            int picas = 0;
            for (int i = 0; i < 4; i++)
            {
                if (numeroSecreto.ToString().Contains(numeroIngresado[i]) && numeroSecreto.ToString()[i] != numeroIngresado[i])
                {
                    picas++;
                }
            }
            return picas;
        }

        // Función para calcular el número de fijas
        static int CalcularFijas(int numeroSecreto, string numeroIngresado)
        {
            int fijas = 0;
            for (int i = 0; i < 4; i++)
            {
                if (numeroSecreto.ToString()[i] == numeroIngresado[i])
                {
                    fijas++;
                }
            }
            return fijas;
        }
    }
}