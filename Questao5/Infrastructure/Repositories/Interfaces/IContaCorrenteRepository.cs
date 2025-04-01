﻿using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Repositories.Interfaces
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> ObterPorId(string id);
    }
}
