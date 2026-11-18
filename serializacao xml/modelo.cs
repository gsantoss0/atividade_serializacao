using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BioGeneticsLab
{
    [XmlRoot("RelatorioAnalise")]
    public class RelatorioAnalise
    {
        [XmlElement("amostra")]
        public DadosAmostra Amostra { get; set; }

        [XmlElement("responsavel")]
        public ResponsavelTecnico Responsavel { get; set; }

        [XmlArray("resultados")]
        [XmlArrayItem("componente")]
        public List<string> Resultados { get; set; }
    }

    public class DadosAmostra
    {
        [XmlElement("idAmostra")]
        public string IdAmostra { get; set; }

        [XmlElement("tipoMaterial")]
        public string TipoMaterial { get; set; }

        [XmlElement("dataColeta")]
        public DateTime DataColeta { get; set; }
    }

    public class ResponsavelTecnico
    {
        [XmlElement("nomeCientista")]
        public string NomeCientista { get; set; }

        [XmlElement("registroProfissional")]
        public string RegistroProfissional { get; set; }
    }
}