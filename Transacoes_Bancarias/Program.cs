using System;
using System.Collections.Generic;
using System.Linq;
using Transacoes_Bancarias.Classes;
using Transacoes_Bancarias.Enum;

namespace Transacoes_Bancarias
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterMenu();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        //ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        //Tranferir();
                        break;
                    case "4":
                        //Sacar();
                        break;
                    case "5":
                        //Depositar();
                        break;
                    case "6":
                        //Emprestar();
                        break;
                    case "7":
                        //PagarContar();
                        break;
                    case "8":
                        //DeletarConta();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterMenu();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
        }

        private static void InserirConta()
        {
            int entradaTipoConta = OpcaoTipoPessoa();
            while (entradaTipoConta > 2 || entradaTipoConta < 1)
            {
                Console.WriteLine("\nOpção inválida!");
                Console.WriteLine("Informe uma opção válida");
                entradaTipoConta = OpcaoTipoPessoa();
            }

            Console.Write("\nDigite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine();
            
            double saldo = SaldoConta();
            while (saldo < 0)
            {
                Console.WriteLine("\nInforme um valor válido");
                saldo = SaldoConta();
            }

            double credito = CreditoConta();
            while (credito < 0)
            {
                Console.WriteLine("\nInforme um valor de crédito válido");
                credito = CreditoConta();
            }

            DateTime dataAberturaConta = new DateTime();
            dataAberturaConta.GetDateTimeFormats();

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: saldo,
                                        credito: credito,
                                        nome: entradaNome,
                                        dataAberturaConta: dataAberturaConta);

        }

        private static string ObterMenu()
        {
            Console.WriteLine();
            Console.WriteLine("BR - Banco Rendimento, seu dinheiro rende muito mais conosco!!!");            
            Console.WriteLine("---------------------------");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Empréstimo");
            Console.WriteLine("7- Pagar conta");
            Console.WriteLine("8- Deletar conta");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.Write("Informe a operação desejada: ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }

        private static int OpcaoTipoPessoa()
        {
            Console.WriteLine("\nInserir nova conta");
            Console.WriteLine("------------------");
            Console.WriteLine("1 - Conta Pessoa Física");
            Console.WriteLine("2 - Conta Pessoa Juridica");
            Console.Write("Informe sua opção: ");

            int entradaTipoConta = 0;
            int.TryParse(Console.ReadLine(), out entradaTipoConta);

            return entradaTipoConta;
        }

        private static double SaldoConta()
        {
            double saldo = 0;
            Console.Write("Digite o saldo inicial: ");
            string entradaSaldo = Console.ReadLine();
            if (entradaSaldo.All(char.IsDigit))
            {
                double.TryParse(entradaSaldo, out saldo);
                return saldo;
            }
            else
            {
                return saldo = -1;
            }    
        }

        private static double CreditoConta()
        {
            double credito = 0;
            Console.Write("\nDigite o valor do credito: ");
            string entradaCredito = Console.ReadLine();
            if (entradaCredito.All(char.IsDigit))
            {
                double.TryParse(entradaCredito, out credito);
                return credito;
            }
            else
            {
                return credito = -1;
            }
        }
    }
}
