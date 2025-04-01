using System;
using System.Globalization;

namespace Questao1
{
    public class ContaBancaria {
        public int Numero { get; set; }
        public string Titular { get; set; }
        private double saldo;

        public ContaBancaria(int numero, string titular, double depositoInicial = 0.0)
        {
            Numero = numero;
            Titular = titular;
            saldo = depositoInicial;
        }

        public void AlterarNome(string novoNome)
        {
            Titular = novoNome;
        }

        public void Deposito(double valor)
        {
            saldo += valor;
        }

        public bool Saque(double valor)
        {
            double taxa = 3.50;
            if (valor + taxa <= saldo)
            {
                saldo -= (valor + taxa);
                return true;
            }
            return false;
        }

        public double ObterSaldo()
        {
            return saldo;
        }

        public void MostrarDados()
        {
            Console.WriteLine($"Conta {Numero}, Titular: {Titular}, Saldo: $ {saldo:F2}");
        }
    }
}
