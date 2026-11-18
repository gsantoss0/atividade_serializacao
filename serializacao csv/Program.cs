using System.Globalization;

public class Program{

    public static void Main(string[] args){

    

    List<LoteProducao> lotes = new List<LoteProducao>
    {
        new LoteProducao { NumeroLote = 101, TipoLiga = "Aço Inox 304", PesoTotal = 1500.50m, TemperaturaFundicao = 1450.2m, StatusQualidade = "Aprovado" },
        new LoteProducao { NumeroLote = 102, TipoLiga = "Titânio Grau 5", PesoTotal = 820.00m, TemperaturaFundicao = 1660.8m, StatusQualidade = "Aprovado" },
        new LoteProducao { NumeroLote = 103, TipoLiga = "Aço Carbono 1045", PesoTotal = 2100.75m, TemperaturaFundicao = 1510.0m, StatusQualidade = "Em Análise" },
        new LoteProducao { NumeroLote = 104, TipoLiga = "Liga de Níquel", PesoTotal = 950.30m, TemperaturaFundicao = 1485.5m, StatusQualidade = "Aprovado" },
        new LoteProducao { NumeroLote = 105, TipoLiga = "Aço Ferramenta D2", PesoTotal = 1230.10m, TemperaturaFundicao = 1420.4m, StatusQualidade = "Reprovado" }
    };

    string caminhoArquivo = "producao_turno.csv";

    using (StreamWriter writer = new StreamWriter(caminhoArquivo))
    {
        // 1. Escreve o cabeçalho
        writer.WriteLine("NumeroLote;TipoLiga;PesoTotal;TemperaturaFundicao;StatusQualidade");

        // 2. Escreve cada objeto como uma linha
        foreach (var lote in lotes)
        {
            string linha = string.Join(";",
                lote.NumeroLote,
                lote.TipoLiga,
                lote.PesoTotal.ToString(CultureInfo.InvariantCulture),
                lote.TemperaturaFundicao.ToString(CultureInfo.InvariantCulture),
                lote.StatusQualidade
            );
            writer.WriteLine(linha);
        }
    }

    Console.WriteLine("Arquivo CSV salvo\n");

    List<LoteProducao> lotesLidos = new List<LoteProducao>();

    // Lê todas as linhas do arquivo, ignorando a primeira (cabeçalho) com Skip(1)
    string[] linhas = File.ReadAllLines(caminhoArquivo);

    foreach (string linha in linhas.Skip(1))
    {
        if (string.IsNullOrWhiteSpace(linha)) continue;

        string[] colunas = linha.Split(';');

        LoteProducao lote = new LoteProducao
        {
            NumeroLote = int.Parse(colunas[0]),
            TipoLiga = colunas[1],
            PesoTotal = decimal.Parse(colunas[2], CultureInfo.InvariantCulture),
            TemperaturaFundicao = decimal.Parse(colunas[3], CultureInfo.InvariantCulture),
            StatusQualidade = colunas[4]
        };

        lotesLidos.Add(lote);
    }

    // Exibindo os dados lidos e calculando a média com LINQ
    Console.WriteLine("--- Lotes Lidos do CSV ---");
    foreach (var item in lotesLidos)
    {
        Console.WriteLine($"Lote: {item.NumeroLote} | Liga: {item.TipoLiga} | Temp: {item.TemperaturaFundicao}°C | Status: {item.StatusQualidade}");
    }

    if (lotesLidos.Count > 0)
    {
        decimal mediaTemperatura = lotesLidos.Average(l => l.TemperaturaFundicao);
        Console.WriteLine($"\nMédia de Temperatura de Fundição: {mediaTemperatura:F2}°C");
    }
    }
}