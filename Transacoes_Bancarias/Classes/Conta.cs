using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes_Bancarias.Enum;

namespace Transacoes_Bancarias.Classes
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private double ValorPagar { get; set; }
        private string Nome { get; set; }
        private string NomeConta { get; set; }
        private DateTime DataAberturaConta { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome, DateTime dataAberturaConta)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            this.DataAberturaConta = dataAberturaConta;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito + " | ";
            retorno += "Data Abertura de Conta " + this.DataAberturaConta;
            return retorno;
        }

        public void Pagar(string nomeConta, double valorPagar)
        {
            this.NomeConta = nomeConta;
            this.ValorPagar = valorPagar;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nA Conta {this.NomeConta} de valor {this.ValorPagar} será paga");
            Console.ResetColor();
            this.Sacar(valorPagar);
        }

        public bool Sacar(double valorSaque)
        {
            //Verifica se há saldo
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Saldo Insulficiente");
                Console.ResetColor();
                return false;
            }

            this.Saldo -= valorSaque;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nSaldo atual da conta de {this.Nome} é {this.Saldo}");
            Console.ResetColor();

            return true;
        }

        public void Emprestar()
        {
            Console.Write($"\nSaldo anterior da conta de {this.Nome} é {this.Saldo}");
            this.Saldo *= 1.30;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"\nSaldo atual da conta de {this.Nome} é {this.Saldo}");
            Console.ResetColor();
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nSaldo atual da conta de {this.Nome} é {this.Saldo}");
            Console.ResetColor();
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
    }
}
