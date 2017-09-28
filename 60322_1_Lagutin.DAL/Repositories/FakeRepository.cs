using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _60322_1_Lagutin.DAL.Entities;
using _60322_1_Lagutin.DAL.Interfaces;

namespace _60322_1_Lagutin.DAL.Repositories
{
    public class FakeRepository : IRepository<Book>
    {
        public void Create(Book t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
           return new List<Book>
            {
                new Book{Id=1, Author="Лев Толстой", Name="Анна Каренина", Description="«Анна Каренина», один из самых знаменитых романов Льва Толстого, начинается ставшей афоризмом фразой: «Все счастливые семьи похожи друг на друга, каждая несчастливая семья несчастлива по-своему». Это книга о вечных ценностях: о любви, о вере, о семье, о человеческом достоинстве.",
                Genre="Русская классика", Price=3.85m},
                new Book{Id=2, Author="	Энтони Горовиц", Name="Белый пик", Description="Остросюжетный шпионский роман для детей среднего и старшего школьного возраста",
                Genre="Детективы", Price=7.17m},
                new Book{Id=3, Author="Томас Харди", Name="Вдали от обезумевшей толпы", Description="Томас Гарди — английский писатель, для которого характерно определение, выражающее главное призвание литературы: изображать природную и духовную сущность человека. Многогранность проявлений этой человеческой сущности в книгах Томаса Гарди такова, что одни воспринимают его произведения как «шедевры любовного романа», а другие — как памфлеты против сословного неравенства. Известно, что епископ англиканской церкви устроил публичное сожжение одной из его книг, как нарушающей моральное кредо общества, в то время как Максим Горький, поставил Гарди в один ряд с Бальзаком, Золя и Мопасаном…",
                Genre="Классика", Price=14},
                new Book{Id=4, Author="	Мервин Пик", Name="Горменгаст", Description="Старинный замок, погрязший в ритуалах, пробуждается ото сна благодаря тому, кто решился в одиночку нарушить правила. Теперь каждый, кто осмелится пройтись по темным коридорам Горменгаста, окажется во власти его жгучего нетерпения, его жажды бунта. Цикл романов о замке Горменгаст, подобно \"Властелину колец\" Толкина, обрел мировую славу как неоспоримая, бессмертная классика зарубежной литературы.",
                Genre="Фентези", Price=18.23m},
                new Book{Id=5, Author="	Ирвин Уэлш", Name="На игле", Description="Исповедь поколения, на собственной шкуре познавшего страшную справедливость девиза \"НЕТ БУДУЩЕГО\"...",
                Genre="Роман", Price=19.45m}
            };
        }

        public Task<Book> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book t)
        {
            throw new NotImplementedException();
        }
    }
}
