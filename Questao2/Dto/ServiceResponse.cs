using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Questao2.Dto
{
    public class ServiceResponse<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T? Retorno { get; set; }
        public ExpandoObject? ErroRetorno { get; set; }
    }
}
