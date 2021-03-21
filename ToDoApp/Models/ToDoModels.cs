using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace ToDoApp.Models
{
    class ToDoModels : INotifyPropertyChanged
    {
        //Поля
        public string CreationData { get; set; } = DateTime.Now.ToString("f");
        private bool isDone;
        private string text;
        private CategoryEnum category;
        private string finishDate = DateTime.Now.ToString("dd.MM.yyyy");
        private DateTime check;
        //Свойства
        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if (isDone == value)
                {
                    return;
                }
                isDone = value;
                OnPropertyChanged("IsDone");
            }
        }
        public string Text
        {
            get { return text; }
            set
            {
                if (text == value)
                {
                    return;
                }
                text = value;
                OnPropertyChanged("Text");
            }
        }
        public CategoryEnum Category
        {
            get { return category; }
            set
            {
                if (category == value)
                {
                    return;
                }
                category = value;
                OnPropertyChanged("Category");
            }
        }
        public string FinishDate
        {
            get { return finishDate; }
            set
            {
                bool success = DateTime.TryParse(value, out check);
                if (success)
                {
                    if (finishDate == value)
                    {
                        return;
                    }
                    finishDate = value;
                    OnPropertyChanged("FinishDate");
                }
                
            }
        }


        //Событие изменения состояния файла
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

    }
}
