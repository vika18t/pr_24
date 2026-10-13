using pr_24.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr_24.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static ObservableCollection<Book> Books { get; } = new ObservableCollection<Book>
        {
			new Book { Title = "Война и мир", Author = "Л. Толстой", Year = 1869 },
            new Book { Title = "Анна Каренина", Author = "Л. Толстой",Year = 1877 },
            new Book { Title = "Преступление и наказание", Author = "Ф. Достоевский", Year = 1866 },
            new Book { Title = "Идиот", Author = "Ф. Достоевский", Year = 1869 },
            new Book { Title = "Отцы и дети",  Author = "И. Тургенев", Year = 1862 },
            new Book { Title = "Ревизор",  Author = "Н. Гоголь", Year = 1836 },
            new Book { Title = "Евгений Онегин", Author = "А. Пушкин", Year = 1833 },

		};
        public MainPage()
        {
            InitializeComponent();
            gridBooks.ItemsSource = Books;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var book = new Book();
            var w = new AddBookWindow();
            w.DataContext = book;

            if (w.ShowDialog() == true)
                Books.Add(book);
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (gridBooks.SelectedItem is Book book)
            {
                var w = new EditBookWindow(book);
                w.ShowDialog();
                gridBooks.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите книгу для редактирования");
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (gridBooks.SelectedItem is Book book)
            {
                var result = MessageBox.Show(
                    $"Удалить книгу «{book.Title}»?",
                    "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                    Books.Remove(book);
            }
            else
            {
                MessageBox.Show("Выберите книгу для удаления");
            }
        }
    }
}