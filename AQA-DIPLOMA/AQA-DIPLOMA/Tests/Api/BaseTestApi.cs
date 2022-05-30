using AQA_DIPLOMA.Clients;
using AQA_DIPLOMA.Services.ApiServices;
using NUnit.Framework;

namespace AQA_DIPLOMA.Tests.Api;

public class BaseTestApi
{
    protected ProjectService ProjectService = null!;

    [OneTimeSetUp]
    public void OneTimeSetUpApi()
    {
        var restClient = new RestClientExtended();
        
        ProjectService = new ProjectService(restClient);
    }
}
