using CxSpec.Core.Specs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CxSpec.Demo
{
    public class ArquivoExample: CxFile
    {
        [CxColSpec("A", "Identificador")]
        public int Id { get; set; }
        [CxColSpec("B")]
        public string Nome { get; set; }
        [CxColSpec("C", "Dt Nasc", true, CxTipoCol.d_m_yyyy)]
        public DateTime DtNasc { get; set; }
        [CxColSpec("D", "Hora", false, CxTipoCol.h_mm)]
        public string Hora { get; set; }
        [CxColSpec("E", "Peso", true, CxTipoCol.Number)]
        public int Peso { get; set; }
    }
}
