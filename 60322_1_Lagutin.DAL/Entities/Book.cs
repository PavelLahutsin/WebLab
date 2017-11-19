

namespace _60322_1_Lagutin.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; } // данные изображения
        public string MimeType { get; set; } // Mime - тип данных изображения
    }
}
