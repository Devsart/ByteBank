using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista<ContaCorrente> lista = new Lista<ContaCorrente>();

            ContaCorrente contaDoGui = new ContaCorrente(546, 1234976);

            ContaCorrente[] contas = new ContaCorrente[]
            {
            new ContaCorrente(874, 5679787),
            new ContaCorrente(874, 5679754),
            new ContaCorrente(874, 5679445),
            new ContaCorrente(874, 5679445),
            new ContaCorrente(874, 5679445),
            new ContaCorrente(874, 5679445),
            (contaDoGui),
            new ContaCorrente(874, 5679445),
            new ContaCorrente(874, 5679445),
            new ContaCorrente(874, 5679445),
            new ContaCorrente(874, 5679445),
            new ContaCorrente(874, 5679445),
        };

            lista.AdicionarVarios(contas);

            var numeros = new List<int> { 1, 2, 3, 4 };

            numeros.AddVarious(5, 6, 7, 8);

            numeros.Remove(3);

            for(int i=0; i < numeros.Count; i++)
            {
                Console.WriteLine($"{numeros[i]}");
            }


            Console.ReadLine();
        }
    }
}
