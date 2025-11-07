using Microsoft.VisualBasic;

namespace ApplicationService.Communication.Responses;

public class ResponseErrorMessageJson
{
    public List<string> Errors { get; private set; }

    public ResponseErrorMessageJson(string message)
    {
        Errors = new() { message };
        // Errors = [message] --> a mesma coisa com sintaxe simplificada
    }
    
    public ResponseErrorMessageJson(List<string> messages)
    {
        Errors = messages; 
    }

}