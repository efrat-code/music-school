using static MusicSchoole.Service.Program;

namespace MusicSchoole
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
            Application.Run(new Form1());
            //List<string> wordsList = new List<string> { "apple", "banana", "cherry" };

            //string result = mystring(wordsList);
            //MessageBox.Show(result);

        }
    }
}