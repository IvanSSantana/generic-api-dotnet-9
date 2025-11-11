namespace ApplicationService.Communication.Responses;

public class ResponseAllClientsJson
{
    public List<ResponseShortClientJson> Clients { get; set; } = new(); 
    // public List<ResponseShortClientJson> Clients { get; set; } = []; 
}