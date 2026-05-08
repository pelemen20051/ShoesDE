using ShoesDE.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesDE.Statics
{
     public static class CurrentSession // Логически группирует классы, относящиеся к статическим данным (например, глобальные состояния). 
     //Предназначен для хранения глобальных данных, доступных из любого места приложения.
    {
        public static User CurrentUser { get; set; }//Статическое автоматическое свойство. Хранит объект типа User (предположительно, сущность пользователя из базы данных).

//get; set; — можно прочитать (User user = CurrentSession.CurrentUser;) и записать (CurrentSession.CurrentUser = someUser;).

//Поскольку класс статический, свойство существует в единственном экземпляре на всё приложение.
    }
}
