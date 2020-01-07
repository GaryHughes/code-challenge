using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace dotnet_code_challenge
{
    public class XmlFeed : IFeed
    {
        public XmlFeed(string path)
        {
            LoadFile(path);
        }

        public void LoadFile(string path)
        {
            using var reader = File.OpenText(path);
            var document = XDocument.Load(reader);

            var races = from race in document.Root.Descendants("race")
                        select new {
                            Name = race.Attribute("name").Value,   
                            Prices = from price in race.Element("prices").Descendants("horse")                                     
                                     select new { 
                                        Id = price.Attribute("number").Value, 
                                        Price = Convert.ToDecimal(price.Attribute("Price").Value) 
                                     },
                            Horses = from horse in race.Element("horses").Elements("horse")
                                     select new {
                                        Id = horse.Element("number").Value,
                                        Name = horse.Attribute("name").Value
                                     }
                        };

            var markets = from race in races
                          let prices = race.Prices.ToDictionary(price => price.Id, price => price.Price)
                          let participants = from horse in race.Horses select new Participant(horse.Id, horse.Name)
                          let entries = from participant in participants select new Entry(participant, prices[participant.Id])
                          select new Market(race.Name, entries); 
                         

            _markets.AddRange(markets);
        }

        public IEnumerable<Market> Markets => _markets; 

        readonly List<Market> _markets = new List<Market>();

    }    
}