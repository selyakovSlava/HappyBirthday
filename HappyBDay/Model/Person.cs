using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HappyBDay.Model
{
    /// <summary>
    /// Модель персоны.
    /// </summary>
    public class Person : INotifyPropertyChanged
    {
        private int _id; // Идентификационный номер.
        private string _surname; // Фамилия.
        private string _name; // Имя.
        private string _patronymic; // Отчество.
        private DateTime _bDay; // Дата рождения.

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Person() { }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="patronymic"></param>
        /// <param name="date"></param>
        public Person(int id, string surname, string name, string patronymic, DateTime date)
        {
            this.ID = id;
            this.Surname = surname;
            this.Name = name;
            this.Patronymic = patronymic;
            this.BDay = date;
        }

        /// <summary>
        /// Номер.
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("ID"); }
        }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged("Surname"); }
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic
        {
            get { return _patronymic; }
            set { _patronymic = value; OnPropertyChanged("Patronymic"); }
        }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BDay
        {
            get { return _bDay; }
            set { _bDay = value; OnPropertyChanged("BDay"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
