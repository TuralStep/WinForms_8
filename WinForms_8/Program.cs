using WinForms_8.Presenters;
using WinForms_8.Repositories;
using WinForms_8.Views;

namespace WinForms_8
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IAddUpdateView addView = new AddUpdateView();
            new AddUpdatePresenter(addView);


            IStudentRepository repository = new EfStudentRepository();

            IMainView mainView = new MainView();
            new MainPresenter(mainView,addView,repository);

            Application.Run((Form)mainView);
        }
    }
}