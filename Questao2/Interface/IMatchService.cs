using Questao2.Dto;
using Questao2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Questao2.Interface
{
    public interface IMatchService
    {
        Task<ServiceResponse<List<MatchResponse>>> Goals(int year, string teamName);

    }
}
