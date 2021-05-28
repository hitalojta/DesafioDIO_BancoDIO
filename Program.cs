using System;
using System.Collections.Generic;
using System.Threading;

namespace DIO.Banco
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        //Acima, cria uma nova lista de contas (collection) conforme vai cadastrando
        //vai ficando nessa listagem.
        static void Main(string[] args)
        {         
            System.Console.WriteLine("\nBem-vindo ao sistema do Banco DIO! :)");
            Thread.Sleep(1000);
            string opcaoDoUsuario = ObterOpcaoUsuario();

            while (opcaoDoUsuario != "X")
            { 
                switch (opcaoDoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                       Depositar();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoDoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("\nObrigado por utilizar os nossos serviços!\n\nAtendimento finalizado.\n");

        }

        private static void Transferir()
        {
            System.Console.WriteLine("\nOPERAÇÃO DE TRANSFERÊNCIA");
            Thread.Sleep(500);
            System.Console.Write("\nDigite o número da conta que fará a transferência: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o número da conta que receberá a transferência: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            System.Console.WriteLine("\nOPERAÇÃO DE DEPÓSITO");
            Thread.Sleep(500);
            System.Console.Write("\nDigite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            System.Console.WriteLine("\nOPERAÇÃO DE SAQUE");
            Thread.Sleep(500);
            System.Console.Write("\nDigite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            System.Console.WriteLine("\nListando contas:\n");

            if (listContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma conta registrada até o momento.");
                return; //sai do método
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                System.Console.WriteLine($"\tNúmero da conta: #{i}");
                System.Console.WriteLine(conta+"\n"); //executa o ToString
                Thread.Sleep(500);
            }
        }

        private static void InserirConta()
        {
            System.Console.WriteLine("\nInserindo nova conta:\n");
            System.Console.Write("Digite 1 para Conta Física ou 2 para conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            System.Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            System.Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, //conversão explícita, converte para enum e
                                        saldo: entradaSaldo,                    //nele já relaciona o numero com o nome dentro do enum.
                                        credito: entradaCredito,
                                        nome: entradaNome);
            //acima não é necessário nomear os parametros, mas aí terá que colocar na ordem certa.
            listContas.Add(novaConta); //adiciona o objeto na lista
        }

        private static string ObterOpcaoUsuario()
        {           
            Thread.Sleep(1000);
            System.Console.WriteLine("\n---------------------------------------------------");
            System.Console.WriteLine("Digite o número da operação que deseja realizar:\n");
            System.Console.WriteLine("1- Listar contas\n2- Inserir nova conta");
            System.Console.WriteLine("3- Transferir\n4- Sacar\n5- Depositar");
            System.Console.WriteLine("6- Limpar tela\nX- Sair\n");
            System.Console.Write("Sua opção: ");

            string opcaoDoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine("---------------------------------------------------");
            return opcaoDoUsuario;
        }
    }
}