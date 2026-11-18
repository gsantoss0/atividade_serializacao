namespace Drone;
public class DroneStatus
{
    public string codigoIdentificador {get; set;} = "";
    public int nivelBateria {get;set;}
    public double latitude {get;set;}
    public double longitude {get;set;}
    public bool emMissao {get;set;}

    public DroneStatus(string codigoIdentificador, int nivelBateria, double latitude, double longitude, bool emMissao)
    {
        this.codigoIdentificador = codigoIdentificador;
        this.nivelBateria = nivelBateria;
        this.latitude = latitude;
        this.longitude = longitude;
        this.emMissao = emMissao;
    }

}