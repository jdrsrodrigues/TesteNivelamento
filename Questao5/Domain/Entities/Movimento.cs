namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public string IdMovimento { get; set; }         // ID único da movimentação
        public string IdContaCorrente { get; set; }     // ID da conta corrente
        public DateTime DataMovimento { get; set; }     // Data e hora da movimentação
        public string TipoMovimento { get; set; }       // Tipo: 'C' (Crédito) ou 'D' (Débito)
        public decimal Valor { get; set; }              // Valor da movimentação (positivo)
    }
}
