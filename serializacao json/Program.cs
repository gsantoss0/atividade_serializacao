using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.IO;

using Drone;
using System.Collections;
public class Program
{
    static void Main()
    {
    int opcao = -1;
    string caminhoArquivo = Path.Combine(AppContext.BaseDirectory, "drone_status.json");
    
    while(opcao != 0)
        {
            Console.WriteLine("1 - Serializar json");
            Console.WriteLine("2 - Ler arquivo json");
            Console.WriteLine("0 - sair");
            Console.WriteLine("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch(opcao){
                case 1:
                    DroneStatus drone = new DroneStatus("0", 66, 40.000, -23.0000, true);
    
                    var opcoes = new JsonSerializerOptions {WriteIndented = true};
                    string jsonString = JsonSerializer.Serialize(drone, opcoes);

                    File.WriteAllText(caminhoArquivo, jsonString);

                    Console.WriteLine($"Arquivo salvo em: {caminhoArquivo}");
                break;

                case 2:
                    Console.WriteLine("Escreva o caminho do arquivo JSON:");
                    string? caminhoLeitura = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(caminhoLeitura) || !File.Exists(caminhoLeitura))
                    {
                        Console.WriteLine("Arquivo não encontrado.");
                        break;
                    }

                    try
                    {
                        string jsonLido = File.ReadAllText(caminhoLeitura);
                        DroneStatus? droneReconstruido = JsonSerializer.Deserialize<DroneStatus>(jsonLido);

                        if (droneReconstruido is null)
                        {
                            Console.WriteLine("O arquivo não contém um status de drone válido.");
                            break;
                        }

                        Console.WriteLine($"ID: {droneReconstruido.codigoIdentificador}");
                        Console.WriteLine($"Bateria: {droneReconstruido.nivelBateria}%");
                        Console.WriteLine($"Latitude: {droneReconstruido.latitude}");
                        Console.WriteLine($"Longitude: {droneReconstruido.longitude}");
                        Console.WriteLine($"Em Missão: {droneReconstruido.emMissao}");
                    }
                    catch (JsonException)
                    {
                        Console.WriteLine("O arquivo não contém um JSON válido.");
                    }
                break;
            }
        }

    }
}


