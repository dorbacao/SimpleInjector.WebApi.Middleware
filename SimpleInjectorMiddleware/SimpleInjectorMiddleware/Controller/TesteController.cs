using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleInjectorMiddleware
{
    [RoutePrefix("teste")]
    public class TesteController : ApiController
    {
        public IInterface Interface { get; set; }
        public TesteController(IInterface _interface)
        {
            Interface = _interface;
        }

        [HttpGet]
        [Route("nome")]
        public string GetNome()
        {
            return "Marcus";
        }

    }
}
