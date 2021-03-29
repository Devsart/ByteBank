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
            List<ContaCorrente> lista = new List<ContaCorrente>();

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
            null,
            new ContaCorrente(874, 5679445),
            new ContaCorrente(874, 5679445),
            new ContaCorrente(874, 5679445),
        };

            lista.AddVarious(contas);

            var contasOrdenadas = lista.Where(x => x != null).OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"{conta.Numero}");
            }


            Console.ReadLine();
        }
    }
}
