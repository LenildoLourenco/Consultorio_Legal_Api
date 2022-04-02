namespace CL.Core.Shared.ModelViews.Endereco
{
    public class NovoEndereco
    {
        /// <example>50000000</example>
        public int CEP { get; set; }
        public EstadoView Estado { get; set; }
        /// <example>Recife</example>
        public string Cidade { get; set; }
        /// <example>Rua A</example>
        public string Logradouro { get; set; }
        /// <example>50</example>
        public string Numero { get; set; }
        /// <example>Ao lado da rua b</example>
        public string Complemento { get; set; }
    }
}
