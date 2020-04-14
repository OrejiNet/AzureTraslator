using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.AzureTranslator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureTranslator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureTranslatorController : ControllerBase
    {
        private IAzureTranslatorBody _translatorBody;
        public AzureTranslatorController(IAzureTranslatorBody translatorBody)
        {
            _translatorBody = translatorBody;   
        }

        [HttpPost("text")]


        public async Task<ActionResult> TranslatorText([FromBody] List<AzureRequestBody> body)
        {


            var result = await _translatorBody.Excecute(body);
            return Ok(result);


        }

    }
}