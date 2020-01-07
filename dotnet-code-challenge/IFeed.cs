using System.Collections.Generic;

namespace dotnet_code_challenge
{
    public interface IFeed
    {
        IEnumerable<Market> Markets { get; }
    }
}