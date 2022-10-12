using WinForms_8.Presenters;
using WinForms_8.Views;

namespace WinForms_8
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IMainView mainView = new MainView();
            IAddView addView = new AddView();

            new MainPresenter(mainView,addView);

            Application.Run((Form)mainView);
        }
    }
}