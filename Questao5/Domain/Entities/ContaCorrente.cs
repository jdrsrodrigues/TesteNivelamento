namespace Questao5.Domain.Entities
{
    public class ContaCorrente
    {
        public string IdContaCorrente { get; set; }  // ID único da conta corrente
        public int Numero { get; set; }               // Número da conta
        public string Nome { get; set; }              // Nome do titular
        public bool Ativo { get; set; }               // Status da conta (ativa ou inativa)
    }
}
