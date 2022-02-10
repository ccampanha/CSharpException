using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
               // Console.WriteLine("Cath no main");
            }

            Console.WriteLine("Tecle enter para sair.");
            Console.ReadLine();

        }

        private static void CarregarContas()
        {
           //using é o equivalente a using + finnaly liberando o recurso no Dispose

            using (LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt"))
            {
                leitor.LerProximaLinha();
            }

           
            
            //LeitorDeArquivo leitor = null;

            //try
            //{
            //    leitor = new LeitorDeArquivo("contas.txt");

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //}
           
            //// Finally é executado ocorrendo exception ou não
            //finally
            //{
            //    if (leitor != null)
            //        leitor.fechar();
            //}

        }

        private static void TestesExceptionEInnerEceptions()
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(514, 874150);
                ContaCorrente conta2 = new ContaCorrente(510, 235824);

                conta.Transferir(10000, conta2);

                conta.Depositar(50);
                Console.WriteLine(conta.Saldo);

                conta.Sacar(500);
                Console.WriteLine(conta.Saldo);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);   
            }

            catch (OperacaoFinanceiraException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                // Console.WriteLine("Message Inner exception: " + ex.InnerException.Message); ;
            }

        }
    }
}

