using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms
{
	public class MockDataStore : IDataStore<Item>
	{
		bool isInitialized;
		List<Item> items;

		public MockDataStore()
		{
            Init();
		}

        void Init()
        {
            if (items != null)
                return;

            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Twitter", Description="@JamesMontemagno"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Blog", Description="motzcod.es"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Podcast: Merge Conflict", Description="mergeconflict.fm"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Podcast: Coffeehouse Blunders", Description="blunders.fm"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Xamarin", Description="xamarin.com"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "This is amazing", Description="Miguel is the Best!"},
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }
        }

		public async Task<bool> AddItemAsync(Item item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}

        public IEnumerable<Item> GetItems()
        {
            return new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is a nice description"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is a nice description"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is a nice description"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is a nice description"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is a nice description"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is a nice description"},
            };
        }
    }
}
