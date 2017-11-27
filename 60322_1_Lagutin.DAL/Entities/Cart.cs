using System.Collections.Generic;
using System.Linq;

namespace _60322_1_Lagutin.DAL.Entities
{
    public class Cart
    {
        private readonly List<CartItem> _items;
        public Cart()
        {
            _items = new List<CartItem>();
        }
        /// <summary>
        /// Добавить в корзину
        /// </summary>
        /// <param name="book">объект для добавления</param>
        public void AddItem(Book book)
        {
            var item = _items.Find(i => i.Book.Id == book.Id);
            if (item == null)
            {
                _items.Add(new CartItem { Book = book, Quantity = 1 });
            }
            else
                item.Quantity += 1;
        }
        /// <summary>
        /// Удалить из корзины
        /// </summary>
        /// <param name="book">Объект для удаления</param>
        public void RemoveItem(Book book)
        {
            var item = _items.Find(i => i.Book.Id == book.Id);
            if (item.Quantity == 1)
                _items.Remove(item);
            else
                item.Quantity -= 1;
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }
        /// <summary>
        /// Получение суммы калорий
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal()
        {
            return _items.Sum(i => i.Book.Price * i.Quantity);
        }
        /// <summary>
        /// Получение содержимого корзины/// </summary>
        /// <returns></returns>
        public IEnumerable<CartItem> GetItems()
        {
            return _items;
        }
    }


    public class CartItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
