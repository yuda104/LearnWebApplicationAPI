using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.EF.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public BugsContext _db;
        public ItemRepository(BugsContext db)
        {
            _db = db;
        }

        public IEnumerable<Item> GetItems()
        {
            return _db.Item.ToList();
        }

        public Item GetItem(Guid id)
        {
            return _db.Item.SingleOrDefault(x => x.Id == id);
        }
        public void CreateItem(Item item)
        {
            _db.Item.Add(item);
            _db.SaveChanges();
        }

        //public bool UpdateItem(Item item)
        //{
        //    var exist = GetItem(item.Id);

        //    if (exist == null)
        //        return false;

        //    //_db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    //_db.SaveChanges();

        //    _db.Item.Attach(exist);
        //    exist.Name = item.Name;
        //    exist.Price = item.Price;
        //    _db.SaveChanges();

        //    return true;
        //}

        public bool UpdateItem(Item item)
        {
            _db.Item.Update(item);

            var updated =  _db.SaveChanges();

            return true;
        }

        public bool DeleteItem(Guid Id)
        {
            var exist = GetItem(Id);

            if (exist == null)
                return false;

            _db.Item.Remove(exist);
            _db.SaveChanges();

            return true;
        }
    }
}
