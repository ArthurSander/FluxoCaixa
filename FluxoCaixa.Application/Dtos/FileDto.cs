namespace FluxoCaixa.Application.Dtos
{
    public class FileDto
    {
        public byte[] Conteudo { get; set; }
        public string MimeType { get; set; }
        public string Nome { get; set; }
    }
}
