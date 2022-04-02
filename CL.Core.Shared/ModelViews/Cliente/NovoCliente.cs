using System;
using System.Collections.Generic;
using CL.Core.Shared.ModelViews.Endereco;
using CL.Core.Shared.ModelViews.Telefone;

namespace CL.Core.Shared.ModelViews.Cliente
{
    /// <summary>
    /// Objeto utilizado para inserção de um novo cliente
    /// </summary>
    public class NovoCliente
    {
        /// <summary>
        /// Nome do Cliente
        /// </summary>
        /// <example>Bob Esponja Calça Quadrada</example>
        public string Nome { get; set; }
        
        /// <summary>
        /// Data de Nascimento do Cliente
        /// </summary>
        /// <example>1980-01-01</example>
        public DateTime DataNascimento { get; set; }
        
        /// <summary>
        /// Sexo do Cliente
        /// </summary>
        /// <example>M</example>
        public SexoView Sexo { get; set; }
       
        /// <summary>
        /// Documento do Cliente: CNH, CPF, RG
        /// </summary>
        /// <example>1234567890</example>
        public string Documento { get; set; }
        public NovoEndereco Endereco { get; set; }
        public ICollection<NovoTelefone> Telefones { get; set; }
    }
}
