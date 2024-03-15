namespace CadastroPessoa_API.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }

        public String Mensagem { get; set; } = String.Empty;

        public bool Sucesso { get; set; } = true;
    }
}
