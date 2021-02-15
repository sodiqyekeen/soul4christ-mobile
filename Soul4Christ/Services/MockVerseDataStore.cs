using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Soul4Christ.Models;
using System.Linq;

namespace Soul4Christ.Services
{
    public class MockVerseDataStore : IDataStore<Verse>
    {
         readonly List<Verse> verses;

        public MockVerseDataStore() => verses = new List<Verse>
            {
                new Verse{
                   VerseId= "1",
                    Book="Proverbs 3:7 AMP",
                    Content="Do not be wise in your own eyes; Fear the Lord [with reverent awe and obedience] and turn [entirely] away from evil.",
                    Date= DateTime.Parse("2019-05-19T00:00:00") ,
                    Comment=null
                  },
                  new Verse{
                   VerseId= "2",
                    Book="Proverbs 26:12 AMP",
                    Content="Do you see a man [who is unteachable and] wise in his own eyes and full of self-conceit? There is more hope for a fool than for him.",
                    Date=DateTime.Parse("2019-05-20T00:00:00"),
                    Comment=null
                  },
                  new Verse{
                   VerseId= "3",
                    Book="Psalms 34:12‭-‬14 GNB",
                    Content="Would you like to enjoy life? Do you want long life and happiness? Then hold back from speaking evil and from telling lies. Turn away from evil and do good; strive for peace with all your heart.",
                    Date=DateTime.Parse("2019-05-21T00:00:00"),
                    Comment=null
                  },
                  new Verse
                  {
                   VerseId= "4",
                    Book="Matthew 12:35‭-‬37 GNB",
                    Content="A good person brings good things out of a treasure of good things; a bad person brings bad things out of a treasure of bad things. “You can be sure that on Judgement Day everyone will have to give account of every useless word he has ever spoken. Your words will be used to judge you — to declare you either innocent or guilty.”",
                    Date=DateTime.Parse("2019-05-23T00:00:00"),
                    Comment=null
                  },
                  new Verse
                  {
                   VerseId= "5",
                    Book="Ecclesiastes 12:14 GNB",
                    Content="God is going to judge everything we do, whether good or bad, even things done in secret. ",
                    Date=DateTime.Parse("2019-05-24T00:00:00"),
                    Comment=null
                  }
            };

        public async Task<bool> AddItemAsync(Verse item)
        {
            verses.Add(item);
            return await Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id) => throw new NotImplementedException();
        public async Task<Verse> GetItemAsync(string id) =>
            await Task.FromResult(verses.Where(v => v.VerseId == id).FirstOrDefault());
        public async Task<IEnumerable<Verse>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(verses);
        public Task<bool> UpdateItemAsync(Verse item) => throw new NotImplementedException();
    }
}
