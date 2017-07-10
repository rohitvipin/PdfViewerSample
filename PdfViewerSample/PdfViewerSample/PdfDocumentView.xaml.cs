using Xamarin.Forms;

namespace PdfViewerSample
{
    public partial class PdfDocumentView : ContentPage
    {
        private readonly PdfDocEntity _pdfDocEntity;

        public PdfDocumentView(PdfDocEntity pdfDocEntity)
        {
            InitializeComponent();
            _pdfDocEntity = pdfDocEntity;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            SetBusyIndicator(true);

            if (await FileManager.ExistsAsync(_pdfDocEntity.FileName) == false)
            {
                await FileManager.DownloadDocumentsAsync(_pdfDocEntity);
            }
            PdfDocView.Uri = FileManager.GetFilePathFromRoot(_pdfDocEntity.FileName);

            SetBusyIndicator(false);
        }

        private void SetBusyIndicator(bool isBusyIndicatorIsVisible) => BusyIndicator.IsRunning = BusyIndicator.IsVisible = isBusyIndicatorIsVisible;
    }
}