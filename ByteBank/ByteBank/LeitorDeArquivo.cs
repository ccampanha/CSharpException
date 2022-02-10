using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class LeitorDeArquivo : IDisposable
    {
        public string Arquivo { get; }

        public LeitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;

            //throw new FileNotFoundException();

            Console.WriteLine("Abrindo arquivo " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha . . .");

            //throw new IOException();

            return "Linha do arquivo";
        }

        //public void fechar()
        //{
        //    Console.WriteLine("Fechando Arquivo.");
        //}

        public void Dispose()
        {
            // o método para liberar recurso/fechar deve ficar dentro do Dispose
            Console.WriteLine("fechando arquivo.");
        }
    }
}
