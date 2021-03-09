﻿using System;
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

        #region Выбранная группа карт

        private Group _SelectedGroup;
        public Group SelectedGroup 
        { 
            get => _SelectedGroup; 
            set => Set(ref _SelectedGroup, value); 
        }

        #endregion

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

        public ICommand CreateGroupCommand { get; }

        public bool CanCreateGroupCommandExecute(object p) => true;
        public void OnCreateGroupCommandExecuted(object p)
        {
            var group = new Group()
            {
                Name = "Новая группа",
                Customers = new ObservableCollection<Customer>()
            };

            Groups.Add(group);
        }

        #region DeleteGroupCommand
        public ICommand DeleteGroupCommand { get; }
        public bool CanDeleteGroupCommandExecute(object p) => p is Group group && Groups.Contains(group);
        public void OnDeleteGroupCommandExecuted(object p)
        {
            if (!(p is Group group)) return;

            Groups.Remove(group);
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Создание команд

            CloseApplicationCommand = new ActionCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            CreateGroupCommand = new ActionCommand(OnCreateGroupCommandExecuted, CanCreateGroupCommandExecute);
            DeleteGroupCommand = new ActionCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);

            #endregion

            var index = 1;
            var customers = Enumerable.Range(1, 10).Select(i => new Customer() 
            {
                Name = $"Name {index}",
                Surname = $"Surname {index}",
                Patronymic = $"Patronymic {index++}",
                Birthdate = DateTime.Now,
                PhoneNum = "(099) 235-62-66",
                IsSeize = false,
                isLocked = false
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
