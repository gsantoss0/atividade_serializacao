using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BioGeneticsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminhoArquivo = "relatorio_amostra.xml";

            var relatorio = new RelatorioAnalise
            {
                Amostra = new DadosAmostra
                {
                    IdAmostra = "BIO-2026-8849-X",
                    TipoMaterial = "Tecido arterial",
                    DataColeta = new DateTime()
                },
                Responsavel = new ResponsavelTecnico
                {
                    NomeCientista = "Dr. Nero",
                    RegistroProfissional = "12345"
                },
                Resultados = new List<string>
                {
                    "Proteína X (Concentração: 14.2 mg/mL)",
                    "Enzima Y (Atividade Catalítica Normal)",
                    "Marcador Genético BRCA1-Mut",
                    "Sequência Viral Negativa"
                }
            };

            //
            XmlSerializer serializer = new XmlSerializer(typeof(RelatorioAnalise));

            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                serializer.Serialize(writer, relatorio);
            }

            Console.WriteLine($"[SUCESSO] Arquivo '{caminhoArquivo}' salvo\n");

            //
            Console.WriteLine("=== AUDITORIA DO ÓRGÃO REGULADOR ===");

            RelatorioAnalise relatorioAuditado;

            using (StreamReader reader = new StreamReader(caminhoArquivo))
            {
                relatorioAuditado = (RelatorioAnalise)serializer.Deserialize(reader);
            }

            Console.WriteLine($"ID da Amostra:      {relatorioAuditado.Amostra.IdAmostra}");
            Console.WriteLine($"Tipo de Material:   {relatorioAuditado.Amostra.TipoMaterial}");
            Console.WriteLine($"Data da Coleta:     {relatorioAuditado.Amostra.DataColeta:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Cientista Resp.:    {relatorioAuditado.Responsavel.NomeCientista}");
            Console.WriteLine($"Registro Prof.:     {relatorioAuditado.Responsavel.RegistroProfissional}");
            
            Console.WriteLine("\nComponentes Identificados na Análise:");
            foreach (var componente in relatorioAuditado.Resultados)
            {
                Console.WriteLine($"- {componente}");
            }
            
        }
    }
}