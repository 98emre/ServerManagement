namespace ToDoApp.Models
{
    public static class ItemRepository
    {
        private static List<ToDoItem> items = new List<ToDoItem>()
        {
            new ToDoItem {  Id = 1, Name = "Item 1" },
            new ToDoItem {  Id = 2, Name = "Item 2" },
            new ToDoItem {  Id = 3, Name = "Item 3" },
            new ToDoItem {  Id = 4, Name = "Item 4" }
        };

        public static List<ToDoItem> GetItems()
        {
            var sortedItmes = items
                .OrderBy(item => item.IsCompleted)
                .ThenByDescending(item => item.Id)
                .ToList();

            return sortedItmes;
        }

        public static List<ToDoItem> GetItemsByName(string name)
        {
            return items.Where(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static void AddItem(ToDoItem item)
        {
            if(items.Count > 0)
            {
                var maxId = items.Max(i => i.Id);
                item.Id = maxId + 1;
                items.Add(item);
            }

            else
            {
                item.Id = 1;
                items.Add(item);
            }
        }

        public static ToDoItem? GetItemById(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                return new ToDoItem
                {
                    Id = item.Id,
                    Name = item.Name,
                    IsCompleted = item.IsCompleted,
                    DateCompleted = item.DateCompleted,
                };
            }

            return null;
        }

        public static void UpdateItem(int id, ToDoItem item)
        {
            if (id != item.Id) return;

            var ItemToUpdate = items.FirstOrDefault(i => i.Id == id);

            if (ItemToUpdate != null)
            {
                ItemToUpdate.IsCompleted = item.IsCompleted;
                ItemToUpdate.Name = item.Name;
                ItemToUpdate.DateCompleted = item.DateCompleted;
            }
        }

        public static void DeleteItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            
            if (item != null)
            {
                items.Remove(item);
            }
        }
    
        public static List<ToDoItem> SearchItemFilters(string itemFilters)
        {
            return items.Where(i => i.Name.Contains(itemFilters,StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
