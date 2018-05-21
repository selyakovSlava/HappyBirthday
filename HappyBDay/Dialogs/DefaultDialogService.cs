using System.Windows;
using HappyBDay.Interfaces;
using Microsoft.Win32;

namespace HappyBDay.Dialogs
{
    public class DefaultDialogService : IDialogService
    {
        /// <summary>
        /// Путь к файлу.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Диалог на открытие файла.
        /// </summary>
        /// <returns></returns>
        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Диалог на сохранение файла.
        /// </summary>
        /// <returns></returns>
        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Показать сообщение.
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
