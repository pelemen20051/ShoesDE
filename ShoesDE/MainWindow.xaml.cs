using ShoesDE.DataBase;
using ShoesDE.Helpers;
using ShoesDE.Statics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

// Объявление пространства имён ShoesDE, которое группирует все классы этого приложения
namespace ShoesDE
{
    // Начало тела пространства имён

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    // Это XML-комментарий, описывающий назначение класса MainWindow

    // Объявление частичного класса MainWindow, наследующего от Window (стандартное окно WPF)
    // partial означает, что класс определён в двух файлах: .xaml (разметка) и .xaml.cs (этот код)
    public partial class MainWindow : Window
    {
        // Приватное поле _db — экземпляр контекста базы данных DBSamShoess31Entities
        // Через него выполняются запросы к таблицам БД (например, к таблице User)
        private DBSamShoess31Entities _db = new DBSamShoess31Entities();

        // Приватное поле _mh — экземпляр вспомогательного класса MessageHelper
        // Предположительно, этот класс умеет показывать сообщения (например, ошибки)
        private MessageHelper _mh = new MessageHelper();

        // Конструктор класса MainWindow (вызывается при создании окна)
        public MainWindow()
        {
            // Вызов метода InitializeComponent(), который загружает и инициализирует элементы управления
            // из XAML-разметки (кнопки, поля ввода и т.д.)
            InitializeComponent();
        }

        // Обработчик события Click для кнопки входа (LogInButton)
        // Вызывается, когда пользователь нажимает кнопку "Войти"
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение текста из поля ввода логина (LoginEnter) и сохранение в переменную logins
            string logins = LoginEnter.Text;

            // Получение пароля из поля PasswordEnter (свойство Password хранит пароль в защищённом виде)
            string passwords = PasswordEnter.Password;

            // Запрос к таблице User в БД: найти первого пользователя, у которого login совпадает с введённым
            // и password совпадает с введённым. FirstOrDefault() вернёт null, если такого пользователя нет.
            var user = _db.User.Where(u => u.login == logins && u.password == passwords).FirstOrDefault();

            // Проверка: если пользователь не найден (user == null)
            if (user == null)
            {
                // Вызов метода ShowError у объекта _mh с текстом ошибки (некорректное сообщение, оставлено как в оригинале)
                _mh.ShowError("ты далбаеб");
                return; // Выход из обработчика (дальнейший код не выполняется)
            }
            else // Иначе (пользователь найден)
            {
                // Определение названия роли пользователя:
                // Если у пользователя есть свойство Role (не null) - берём user.Role.nameRole,
                // иначе используем строку "нет роли"
                var NAMErole = user.Role != null ? user.Role.nameRole : "нет роли";

                // Показ стандартного окна сообщения (MessageBox) с текстом "ваша роль ..."
                MessageBox.Show($"ваша роль {NAMErole}");

                // Создание нового окна ProductWindow, передача ему объекта user (текущий пользователь)
                new ProductWindow(user).Show();

                // Закрытие текущего окна (MainWindow)
                Close();
            }
        }

        // Обработчик события Click для кнопки "Войти как гость" (Gosti_Click)
        private void Gosti_Click(object sender, RoutedEventArgs e)
        {
            // Создание нового окна ProductWindow без передачи пользователя (гостевой режим)
            new ProductWindow().Show();

            // Закрытие текущего окна (MainWindow)
            Close();
        }
    }
    // Конец класса MainWindow
}
// Конец пространства имён ShoesDE
