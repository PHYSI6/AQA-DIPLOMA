using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace AQA_DIPLOMA.Clients;

public class TestLodgeApiAuthentication : IAuthenticator
{
    private string? Token { get; }

    public TestLodgeApiAuthentication(string? token)
    {
        Token = token;
    }

    public ValueTask Authenticate(RestClient client, RestRequest request)
    {
        if (Token != null) request.AddHeader("Token", Token);
        return ValueTask.CompletedTask;
    }
}
