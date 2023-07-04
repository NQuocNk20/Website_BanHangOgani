using System.Xml.Schema;

namespace BanHangOgani.Models
{
    public class CartModel
    {
        private List<Item> _items = new List<Item>();
        public string CartId { get; set; }
        public decimal Total { get; set; }
        public decimal getTotal()
        {
            decimal total = 0;
            foreach (var it in _items)
            {
                total += it.lineTotal;
            }
            return total;
        }
        public int addItem(Item item)
        {
            foreach (var it in _items)
            {
                if(it.Id == item.Id)
                {
                    it.Quantity += item.Quantity;
                    it.lineTotal = it.Quantity * it.Price;
                    return _items.Count;
                }  
            }
            _items.Add(item);
            return _items.Count;
        }
        public void UpdateQuantity(string id, int quantity, string btnCmd)
        {
            foreach(Item item in _items)
            {
                if(item.Id == id)
                {
                    if (btnCmd == "+")
                    {
                        item.Quantity += quantity;
                    }
                    else
                    {
                        item.Quantity -= quantity;
                    }
                    item.lineTotal = item.Quantity * item.Price;
                }
            }
            Total = 0;
            foreach (var item in _items)
            {
                Total += item.lineTotal;
            }
        }
        public List<Item> getAllItems ()
        {
            return _items;
        }
        public void setAllItems(List<Item> items)
        {
            _items = items;
        }

        public void RemoveItem(string id)
        {
            Item itemToRemove = _items.FirstOrDefault(item => item.Id == id);
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
            }
        }
    }


}
