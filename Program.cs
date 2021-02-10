using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        private static List<Conta> _contas = new List<Conta>();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Seja bem vindo!");
            Hub();
        }

        private static void ListarContas()
        {
            if (_contas.Count > 0)
            {
                for (int i=0 ; i < _contas.Count ; i++)
                {
                    Console.WriteLine("Contas cadastradas:");
                    Console.WriteLine($"({i+1}) {_contas[i]}");
                }
            } else Console.WriteLine("Nenhuma conta cadastrada.");
        }

        private static void AbrirConta()
        {
            int tipoConta = 1;
            Console.WriteLine("Tipo da Conta:\n\t1 - Pessoa Fisica (Padrão)\n\t2 - Pessoa Juridica");
            int.TryParse(Console.ReadLine(), out tipoConta);
            tipoConta = (new List<int>() {1, 2}).Contains(tipoConta) ? tipoConta : 1;
            
            Console.Write("Insira seu nome: ");
            string nome = Console.ReadLine();
            
            _contas.Add(new Conta( (TipoConta) tipoConta, nome, 0));
        }

        private static void Transferir()
        {
            ListarContas();
            
            Console.Write("Insira o índice da conta de origem: ");
            int origem = Int32.Parse(Console.ReadLine());

            Console.Write("Insira o índice da conta de destino: ");
            int destino = Int32.Parse(Console.ReadLine());

            Console.Write("Insira o valor a ser transferido: ");
            double valor = Double.Parse(Console.ReadLine());

            _contas[origem-1].Transferir(valor, _contas[destino-1]);
        }

        private static void Sacar()
        {
            ListarContas();
            
            Console.Write("Insira o índice da conta: ");
            int index = Int32.Parse(Console.ReadLine());

            Console.Write("Insira o valor a ser sacado: ");
            double valor = Double.Parse(Console.ReadLine());

            _contas[index-1].Sacar(valor);
        }

        private static void Depositar()
        {
            ListarContas();
            
            Console.Write("Insira o índice da conta: ");
            int index = Int32.Parse(Console.ReadLine());

            Console.Write("Insira o valor a ser depositado: ");
            double valor = Double.Parse(Console.ReadLine());

            _contas[index-1].Depositar(valor);
        }

        private static void Credito()
        {
            ListarContas();

            Console.Write("Insira o índice da conta: ");
            int index = Int32.Parse(Console.ReadLine());

            Console.Write("Insira o limite de crédito: ");
            double limite = Double.Parse(Console.ReadLine());
            
            _contas[index-1].AtualizarCredito(limite);
        }

        private static void Hub()
        {
            string opcao = Menu();

            while (!opcao.Equals("X"))
            {
                switch (opcao)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        AbrirConta();
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
                        Credito();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("A opção fornecida não é válida.");
                        break;
                }
                
                opcao = Menu();
            }

            Console.WriteLine("Obrigado por usar este serviço!");
        }

        private static string Menu()
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("\t1 - Listar contas");
            Console.WriteLine("\t2 - Abrir conta");
            Console.WriteLine("\t3 - Fazer transferência");
            Console.WriteLine("\t4 - Sacar");
            Console.WriteLine("\t5 - Depositar");
            Console.WriteLine("\t6 - Cadastrar limite de cŕedito");
            Console.WriteLine("\tC - Limpar tela");
            Console.WriteLine("\tX - Sair");

            return Console.ReadLine().ToUpper();
        }
    }
}
