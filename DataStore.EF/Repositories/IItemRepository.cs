using Core.Models;
using System;
using System.Collections.Generic;

namespace DataStore.EF.Repositories
{
    public interface IItemRepository
    {
        void CreateItem(Item item);
        bool DeleteItem(Guid Id);
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        bool UpdateItem(Item item);
       // void UpdateItem(Item item);
    }
}