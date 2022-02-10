using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class SaldoInsuficienteException : Exception
    {
        public double Saldo { get; }
        public double ValorTransacao { get; }

        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(string mensagem) : base(mensagem)
        {

        }

        public SaldoInsuficienteException(double saldo, double valor) 
            : this("Tentativa de transação no valor de R$" + valor + " com saldo de R$" + saldo  )
        {
            Saldo = saldo;
            ValorTransacao = valor;
        }

    }
}
