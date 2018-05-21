using System.Collections.Generic;

namespace HappyBDay.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Открытие файла.
        /// </summary>
        /// <param name="filename">Путь к файлу.</param>
        /// <returns>Возвращает список объектов.</returns>
        List<Model.Person> Open(string filename);

        /// <summary>
        /// Сохранение данных из списка.
        /// </summary>
        /// <param name="filename">Путь к файлу.</param>
        /// <param name="people">Список персон.</param>
        void Save(string filename, List<Model.Person> people);
    }
}
