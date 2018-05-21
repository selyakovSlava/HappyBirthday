

namespace HappyBDay.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с диалоговыми окнами.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Показать сообщение.
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);

        /// <summary>
        /// Путь к выбранному файлу.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Открыть файл.
        /// </summary>
        /// <returns></returns>
        bool OpenFileDialog();

        /// <summary>
        /// Сохранить файл.
        /// </summary>
        /// <returns></returns>
        bool SaveFileDialog();
    }
}
