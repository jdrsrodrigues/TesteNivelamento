using Questao2.Dto;
using Questao2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2.Interface
{
    public interface IMatchApiService
    {
        Task<ServiceResponse<List<MatchResponse>>> GetMatches(int yaer, string teamName);
    }
}
