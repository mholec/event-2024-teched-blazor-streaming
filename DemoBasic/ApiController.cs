using Microsoft.AspNetCore.Mvc;
using Streaming.Common;

namespace Streaming.DemoBasic;

[ApiController]
public class ApiController : ControllerBase
{
    [HttpGet("api/fragments")]
    public async IAsyncEnumerable<DataFragment> GetBasicData()
    {
        Bogus.Faker<DataFragment> fakeGen = new();
        fakeGen.RuleFor(x=> x.Id, x => x.IndexFaker);
        fakeGen.RuleFor(x=> x.Name, x => x.Name.FullName());
        fakeGen.RuleFor(x=> x.Title, x => x.Lorem.Sentence());

        var fakeData = fakeGen.Generate(10);

        foreach (var dataFragment in fakeData)
        {
            yield return dataFragment;
            await Task.Delay(1000);
        }
    }
}