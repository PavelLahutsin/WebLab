namespace _60322_1_Lagutin.Models
{
    public class MenuItem
    {
        public string Name { set; get; } // Текст надписи
        public string Controller { set; get; } // Имя контроллера
        public string Action { set; get; } // Имя метода
        public string Active { set; get; } // Текущий пункт
    }
}
