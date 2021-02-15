using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Soul4Christ.Models;

namespace Soul4Christ.Services
{
    public class VerseDataStore : IDataStore<Verse>
    {
        public Task<bool> AddItemAsync(Verse item) => throw new NotImplementedException();
        public Task<bool> DeleteItemAsync(string id) => throw new NotImplementedException();
        public Task<Verse> GetItemAsync(string id) => throw new NotImplementedException();
        public Task<IEnumerable<Verse>> GetItemsAsync(bool forceRefresh = false) => throw new NotImplementedException();
        public Task<bool> UpdateItemAsync(Verse item) => throw new NotImplementedException();
    }
}
