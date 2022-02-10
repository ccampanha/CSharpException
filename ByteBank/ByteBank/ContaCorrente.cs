using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        // retirando o setter as propiedades Numero e Agencia apenas serão alteradas no construtor
        public int Numero { get; } 
        public int Agencia { get;}

        private double _saldo = 100;

        public int ContadorSaquesNaoPermitidos { get; private set; }

        public int ContadorTransferenciasNaoPermitidos { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }

        public static double TaxaOperacao { get; private set; }

        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
                throw new ArgumentException("O número da agencia deve ser maior que zero.", nameof(agencia) );

            if (numero <= 0)
                throw new ArgumentException("O número da conta deve ser maior que zero.", nameof(numero));
            
            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;

            TaxaOperacao = 30 / TotalDeContasCriadas;
        }
     
        public double Saldo
        {
            get { return _saldo; }

            set
            {
                if (value < 0)
                    return;
                _saldo = value;

            }
        }

        public void Sacar(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor invalido para o saque.", nameof (valor));
                
            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo,valor);
            }
            else
            {
                _saldo -= valor;
    
            }
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor de depósito deve ser maior que zero.", nameof(valor));

            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor para a transferencia deve ser maior que zero.", nameof(valor));

            try
            {
                Sacar(valor);

            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidos++;
                throw new OperacaoFinanceiraException("Operacao não realizada", ex);
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
        }
    }
}
