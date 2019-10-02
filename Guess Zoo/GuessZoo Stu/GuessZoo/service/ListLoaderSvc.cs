using System.Collections.Generic;
using System.IO;
using GuessZoo.domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GuessZoo.service
{
    public interface IListLoaderSvc
    {
        IEnumerable<Card> GetCards();
    }

    public class ListLoaderSvc : IListLoaderSvc
    {
        public IEnumerable<Card> GetCards()
        {
            JArray o = JArray.Parse(File.ReadAllText(@"Cards.json"));
            return o.ToObject<Card[]>();
        }
    }
}