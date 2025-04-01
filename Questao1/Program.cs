using System;
using System.Globalization;

namespace Questao1 {
    class Program {
        static void Main(string[] args) {

            Console.Write("Entre o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Entre o titular da conta: ");
            string titularConta = Console.ReadLine();

            Console.Write("Haverá depósito inicial (s/n)? ");
            char opcaoDeposito = char.Parse(Console.ReadLine().ToLower());

            double depositoInicial = 0.0;
            if (opcaoDeposito == 's')
            {
                Console.Write("Entre o valor de depósito inicial: ");
                depositoInicial = double.Parse(Console.ReadLine());
            }

            ContaBancaria conta = new ContaBancaria(numeroConta, titularConta, depositoInicial);
            conta.MostrarDados();

            Console.Write("Entre um valor para depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            conta.Deposito(valorDeposito);
            conta.MostrarDados();

            Console.Write("Entre um valor para saque: ");
            double valorSaque = double.Parse(Console.ReadLine());
            if (conta.Saque(valorSaque))
            {
                conta.MostrarDados();
            }
            else
            {
                Console.WriteLine("Saque não realizado. Saldo insuficiente.");
                conta.MostrarDados();
            }

            /* Output expected:
            Exemplo 1:

            Entre o número da conta: 5447
            Entre o titular da conta: Milton Gonçalves
            Haverá depósito inicial(s / n) ? s
            Entre o valor de depósito inicial: 350.00

            Dados da conta:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 350.00

            Entre um valor para depósito: 200
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 550.00

            Entre um valor para saque: 199
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 347.50

            Exemplo 2:
            Entre o número da conta: 5139
            Entre o titular da conta: Elza Soares
            Haverá depósito inicial(s / n) ? n

            Dados da conta:
            Conta 5139, Titular: Elza Soares, Saldo: $ 0.00

            Entre um valor para depósito: 300.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ 300.00

            Entre um valor para saque: 298.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ -1.50
            */
        }
    }
}
