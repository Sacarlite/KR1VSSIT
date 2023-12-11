using System.ComponentModel.DataAnnotations;

namespace KR1VSSIT
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MainForm mainForm = new MainForm();
            Algoritms algoritms = new Algoritms();
            FileManager fileManager = new FileManager();
            MessageService messageService = new MessageService();
            MainformPresenter presenter = new MainformPresenter(mainForm, algoritms, fileManager, messageService);
            Application.Run(mainForm);
        }
    }
}