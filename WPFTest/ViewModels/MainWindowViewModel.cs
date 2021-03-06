using System;
using System.Collections.Generic;
using System.Text;
using WPFTest.ViewModels.Base;

namespace WPFTest.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Тестовое приложени WPF";
        
        #region Заголовок окна
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
    }
}
