using System.Collections.Generic;

namespace dotnet_code_challenge
{
    public class JsonFeed : IFeed
    {
        public JsonFeed(string path)
        {

        }
        
        public IEnumerable<Market> Markets { get { yield break; } }
    }
}