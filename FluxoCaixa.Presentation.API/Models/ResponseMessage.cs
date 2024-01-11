using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FluxoCaixa.Presentation.API.Models
{
    public class ResponseMessage
    {
        protected ResponseMessage() { }

        public bool sucesso { get; set; }
        public int status_code { get; set; }

        [JsonIgnore]
        public bool RemoverNulls { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings()
            {
                NullValueHandling = RemoverNulls ? NullValueHandling.Ignore : NullValueHandling.Include,
                Formatting = Formatting.Indented
            });
        }

        public static ObjectResult Sucesso<T>(T resultado, int status_code = 200, bool removerNulos = true)
        {
            var responseContent = new ResponseMessage<T>()
            {
                sucesso = true,
                status_code = status_code,
                resultado = resultado,
                RemoverNulls = removerNulos
            };

            var result = new ObjectResult(responseContent.ToString());
            result.StatusCode = status_code;
            return result;
        }

        public static ObjectResult Falha(IEnumerable<string> erros, int status_code = 400)
        {
            var responseContent = new ErrorResponseMessage()
            {
                sucesso = false,
                status_code = status_code,
                erros = erros,
                RemoverNulls = true
            };

            var result = new ObjectResult(responseContent.ToString());
            result.StatusCode = status_code;
            return result;
        }
    }

    public class ResponseMessage<T> : ResponseMessage
    {
        public T resultado { get; set; }
    }

    public class ErrorResponseMessage : ResponseMessage
    {
        public IEnumerable<string>? erros { get; set; }
    }
}
