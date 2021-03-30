using System;
using System.IO;
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
            var ArquivoContas = "../../../contas.txt";
            var file_path = "../../../contasExportadas.csv";
            
            using(var fluxoArquivo = new FileStream(ArquivoContas, FileMode.Open))
            using(var reader = new StreamReader(fluxoArquivo))
            using(var fluxoDeArquivo2 = new FileStream(file_path, FileMode.Create))
            using(var writer = new StreamWriter(fluxoDeArquivo2, Encoding.UTF8))
            {
                writer.WriteLine("Agencia,Conta-Corrente,Saldo,Titular");
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var line2 = line.Replace(' ', ',');
                    writer.WriteLine(line2);
                    var contaCorrente = ConvertTextToAcc(line);

                    Console.WriteLine($"Conta Corrente do {contaCorrente.Titular.Nome}: Ag: {contaCorrente.Agencia}, Numero: {contaCorrente.Numero}, Saldo(R$): {contaCorrente.Saldo}");
                }
            }

            Console.ReadLine();
        }

        static ContaCorrente ConvertTextToAcc(string line)
        {
            var fields = line.Split(' ');
            var agencia = int.Parse(fields[0]);
            var numero = int.Parse(fields[1]);
            var saldo = double.Parse(fields[2].Replace('.',','));
            var name = fields[3];
            var titular = new Cliente();
            titular.Nome = name;

            var result = new ContaCorrente(agencia,numero);
            result.Depositar(saldo);
            result.Titular = titular;

            return result;
        }

        static void FileCreator(string line)
        {
            var file_path = "../../../contasExportadas.csv";
            using(var fluxoDeArquivo = new FileStream(file_path, FileMode.Create))
            using(var writer = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            {

                writer.WriteLine(line);
                writer.Flush();
            }
        }

        static void Reader(string arquivo)
        {
            using (var fluxoArquivo = new FileStream(arquivo, FileMode.Open))
            {
                var buffer = new byte[1024];
                var readyBytes = -1;
                while (readyBytes != 0)
                {
                    readyBytes = fluxoArquivo.Read(buffer, 0, 1024);
                    WriteBuffer(buffer, readyBytes);
                }

            }
        }
        static void WriteBuffer(byte[] buffer, int readyBytes)
        {
            foreach(var myByte in buffer)
            {
                var utf8 = new UTF8Encoding();
                var texto = utf8.GetString(buffer,0,readyBytes);
                Console.Write(texto);
            }
        }
    }
}
