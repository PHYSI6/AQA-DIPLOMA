using AQA_DIPLOMA.Models;
using Bogus;

namespace AQA_DIPLOMA.Fakers;

public sealed class ProjectFaker : Faker<Project>
{
    public ProjectFaker(int nameLenght = 10)
    {
        RuleFor(b => b.Name, f => f.Random.String2(nameLenght));
        RuleFor(b => b.Description, f => f.Company.CatchPhrase());
    }
}
