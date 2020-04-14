using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AzureTranslator
{
    public interface  IAzureTranslatorBody
    {

        Task<List<AzureTranslatorModel>> Excecute(List<AzureRequestBody> requestBodies);
    }
}
