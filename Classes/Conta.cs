using System;

namespace Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta(TipoConta tipoConta, string nome, double credito)
        {
            TipoConta = tipoConta;
            Nome = nome;
            Credito = credito;
            Saldo = 0;
        }

        public void AtualizarCredito(double limite)
        {
            Credito = limite;
        }
        
        public bool Sacar(double valor)
        {
            bool sucesso = Saldo - valor >= 0;
            if (sucesso)
            {
                Saldo -= valor;
                Console.WriteLine($"Valor retirado com sucesso.\nSaldo atual: R${Saldo}");
            }
            else Console.WriteLine("Saldo insuficiente.");
 
            return sucesso;
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
            Console.WriteLine($"Valor depositado com sucesso.\nSaldo atual: R${Saldo}");
        }

        public bool Transferir(double valor, Conta destino)
        {
            bool saldoSuficiente = Sacar(valor);
            if(saldoSuficiente) destino.Depositar(valor);
            return saldoSuficiente;
        }

        public override string ToString()
        {
            return $"{Nome} - {TipoConta}\nCredito: R${Credito}\nSaldo: R${Saldo}\n";
        }
    }
}