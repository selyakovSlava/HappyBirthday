using HappyBDay.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HappyBDay.ViewModel
{
    public class Persons : INotifyPropertyChanged
    {
        private Model.Person _selectedPerson;
        
        /// <summary>
        /// Список людей.
        /// </summary>
        public ObservableCollection<Model.Person> People { get; set; }

        /// <summary>
        /// Выбранная персона.
        /// </summary>
        public Model.Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; OnPropertyChanged("SelectedPerson"); }
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Persons()
        {
            People = new ObservableCollection<Model.Person>();
            LoadPersons();
        }

        /// <summary>
        /// Загрузка списка людей.
        /// </summary>
        public void LoadPersons()
        {
            People.Add(new Model.Person(1, "Иванов", "Иван", "Иванович", new DateTime(1992, 4, 23)));
            People.Add(new Model.Person(2, "Петров", "Петя", "Петрович", new DateTime(1991, 6, 6)));
            People.Add(new Model.Person(3, "Сидоров", "Сидр", "Сидорович", new DateTime(1993, 5, 25)));
        }

        
        private RelayCommand _addCommand; // команда добавления нового объекта
        /// <summary>
        /// Команда на добавление.
        /// </summary>
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                  (_addCommand = new RelayCommand(obj =>
                  {
                      Model.Person person = new Model.Person();
                      People.Insert(0, person);
                      SelectedPerson = person;
                  }));
            }
        }

        private RelayCommand _removeCommand;
        /// <summary>
        /// Команда на удаление.
        /// </summary>
        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                    (_removeCommand = new RelayCommand(obj =>
                    {
                        Model.Person person = obj as Model.Person;
                        if (person != null)
                        {
                            People.Remove(person);
                        }
                    },
                    (obj) => People.Count > 0));
            }
        }

        private RelayCommand doubleCommand;
        /// <summary>
        /// Команда на дублирование.
        /// </summary>
        public RelayCommand DoubleCommand
        {
            get
            {
                return doubleCommand ??
                    (doubleCommand = new RelayCommand(obj =>
                    {
                        Model.Person person = obj as Model.Person;
                        if (person != null)
                        {
                            Model.Person personCopy = new Model.Person
                            {
                                ID = People.Count + 1,
                                Name = person.Name,
                                Patronymic = person.Patronymic,
                                Surname = person.Surname,
                                BDay = person.BDay
                            };
                            People.Insert(0, personCopy);
                        }
                    }));
            }
        }

        public Persons(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            People = new ObservableCollection<Model.Person>();
            LoadPersons();
        }

        IFileService fileService;
        IDialogService dialogService;

        // команда сохранения файла
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, People.ToList());
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        // команда открытия файла
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var phones = fileService.Open(dialogService.FilePath);
                              People.Clear();
                              foreach (var p in phones)
                                  People.Add(p);
                              dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
