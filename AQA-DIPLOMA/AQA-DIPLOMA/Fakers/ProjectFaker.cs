using AQA_DIPLOMA.Models;
using Bogus;

namespace AQA_DIPLOMA.Fakers;

public sealed class ProjectFaker : Faker<Project>
{
    public ProjectFaker(int nameLenght = 10)
    {
        RuleFor(project => project.Name, faker => faker.Random.String2(nameLenght));
        RuleFor(project => project.Description, faker => faker.Company.CatchPhrase());
    }
}
