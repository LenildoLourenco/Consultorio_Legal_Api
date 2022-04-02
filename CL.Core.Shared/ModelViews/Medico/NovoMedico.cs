using System.Collections.Generic;
using CL.Core.Shared.ModelViews.Especialidade;

namespace CL.Core.Shared.ModelViews.Medico
{
    /// <summary>
    /// Objeto utilizado para inserção de um novo médico
    /// </summary>
    public class NovoMedico
    {
        /// <summary>
        /// Nome do Médico
        /// </summary>
        /// <example>Bob Esponja Calça Quadrada</example>
        public string Nome { get; set; }

        /// <summary>
        /// CRM do Médico
        /// </summary>
        /// <example>28815</example>
        public int CRM { get; set; }

        /// <summary>
        /// Especialidade do Médico
        /// </summary>
        /// <example>Clínico Geral</example>
        public ICollection<ReferenciaEspecialidade> Especialidades { get; set; }
    }
}
