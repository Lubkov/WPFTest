using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WPFTest.Infrastructure.Commands;
using WPFTest.Models;
using WPFTest.ViewModels.Base;

namespace WPFTest.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Тестовые данные

        public ObservableCollection<Group> Groups { get; }

        #endregion

        #region Заголовок окна

        private string _title = "Тестовое приложени WPF";

        public string Title
        {
            get => _title;
            //set
            //{
            //if (Equals(_title, value)) return;
            //_title = value;
            //OnPropertyChanged();

            //Set(ref _title, value);
            //}
            set => Set(ref _title, value);
        }
        #endregion

        #region Статус программы

        private string _status = "Ok";

        public string Status 
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion

        #region Команды

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Создание команд

            CloseApplicationCommand = new ActionCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion

            var index = 1;
            var customers = Enumerable.Range(1, 10).Select(i => new Customer 
            {
                Name = $"Name {index}",
                Surname = $"Surname {index}",
                Patronymic = $"Patronymic {index++}",
                Birthdate = DateTime.Now,
                PhoneNum = "(099) 235-62-66"
            });

            var groups = Enumerable.Range(1, 20).Select(i => new Group()
            { 
                Name = $"Группа {i}",
                Customers = new ObservableCollection<Customer>(customers)
            });
            Groups = new ObservableCollection<Group>(groups);
        }
    }
}
