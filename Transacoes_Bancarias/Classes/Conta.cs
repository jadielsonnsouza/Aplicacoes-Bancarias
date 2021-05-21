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
        private string Nome { get; set; }
        private DateTime DataAberturaConta { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome, DateTime dataAberturaConta)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            this.DataAberturaConta = dataAberturaConta;
        }
    }
}
