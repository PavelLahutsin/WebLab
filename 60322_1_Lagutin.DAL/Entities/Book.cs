

using System.ComponentModel.DataAnnotations;

namespace _60322_1_Lagutin.DAL.Entities
{
    public class Book
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите автора")]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Введите жанр")]
        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите цену")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; } // данные изображения

        [ScaffoldColumn(false)]
        public string MimeType { get; set; } // Mime - тип данных изображения
    }
}
