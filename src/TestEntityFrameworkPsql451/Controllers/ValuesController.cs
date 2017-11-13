using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestEntityFrameworkPsql451.Domain;
using TestEntityFrameworkPsql451.Infrastructure;
using TestEntityFrameworkPsql451.Models;

namespace TestEntityFrameworkPsql451.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
         [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await _unitOfWork.HubComponentRepository.Get(id).ConfigureAwait(false);
            if (result == null) return NotFound();
            return Ok(result);
        }


        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var result = await _unitOfWork.HubComponentRepository.Get().ConfigureAwait(false);
            if (result == null) return NotFound();
            return Ok(result);
        }

      
      
    }
}
