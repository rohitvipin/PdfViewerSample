using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PdfViewerSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
