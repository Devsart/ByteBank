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
            
            using(var fluxoArquivo = new FileStream(ArquivoContas, FileMode.Open))
            {
                var reader = new StreamReader(fluxoArquivo);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }

            Console.ReadLine();
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
