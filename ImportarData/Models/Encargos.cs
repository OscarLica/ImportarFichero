using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImportarData.Models
{
    public class Encargos
    {
        /// <summary>
        /// LLave Primaria
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// alabaran
        /// </summary>
        [MaxLength ( 10)]
        public string albaran { get; set; }
        /// <summary>
        /// destinatario
        /// </summary>
        [MaxLength(28)]
        public string destinatario { get; set; }
        /// <summary>
        /// direccion
        /// </summary>
        [MaxLength(250)]
        public string direccion { get; set; }
        /// <summary>
        /// poblacion
        /// </summary>
        [MaxLength(10)]
        public string poblacion { get; set; }
        /// <summary>
        /// cp
        /// </summary>
        [MaxLength(5)]
        public string  cp { get; set; }
        /// <summary>
        /// provincia
        /// </summary>
        [MaxLength(20)]
        public string provincia { get; set; }
        /// <summary>
        ///telefono
        /// </summary>
        [MaxLength(10)]
        public string telefono { get; set; }
        /// <summary>
        /// observaciones
        /// </summary>
        [MaxLength(500)]
        public string  observacviones { get; set; }
        /// <summary>
        /// fecha
        /// </summary>
        public string fecha { get; set; }
        /// <summary>
        /// Cantidad de Registros Buenos
        /// </summary>
        public int registroBuenos { get; set; }
        /// <summary>
        /// Cantidad de Registros Malos
        /// </summary>
        public int registrosMalos { get; set; }
    }
}