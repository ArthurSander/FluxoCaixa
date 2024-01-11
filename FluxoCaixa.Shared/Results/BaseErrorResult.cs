using FluentResults;
using Newtonsoft.Json;

namespace FluxoCaixa.Shared.Results
{
    public abstract class BaseErrorResult : Error
    {
        public BaseErrorResult(string message) : base(message) { }
        public BaseErrorResult(string message, IError causedBy) : base(message, causedBy) { }

        public override string ToString()
        {
            var result = new Dictionary<string, object>
            {
                { "Message", Message }
            };

            foreach(var metadataInfo in Metadata)
                result.Add(metadataInfo.Key, metadataInfo.Value);

            return JsonConvert.SerializeObject(result);
        }
    }
}
