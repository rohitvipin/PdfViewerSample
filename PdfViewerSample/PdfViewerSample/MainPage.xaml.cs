using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PdfViewerSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            PdfListView.ItemsSource = GetPdfs();
        }

        private static IEnumerable<PdfDocEntity> GetPdfs()
        {
            return new[]
            {
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/pptdemo2.pdf",
                    FileName = "pptdemo2.pdf"
                },
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/pptdemo1.pdf",
                    FileName = "pptdemo1.pdf"
                },
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/xlsdemo2.pdf",
                    FileName = "xlsdemo2.pdf"
                },
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/xlsdemo1.pdf",
                    FileName = "xlsdemo1.pdf"
                },
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/Sample5.PDF",
                    FileName = "Sample5.PDF"
                },
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/Sample4.PDF",
                    FileName = "Sample4.PDF"
                },
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/Sample3.PDF",
                    FileName = "Sample3.PDF"
                },
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/Sample2.PDF",
                    FileName = "Sample2.PDF"
                },
                new PdfDocEntity
                {
                    Url = "http://www.pdfpdf.com/samples/Sample1.PDF",
                    FileName = "Sample1.PDF"
                }
            };
        }

        private void PdfListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e?.SelectedItem == null)
            {
                return;
            }

            var pdfDocEntity = e.SelectedItem as PdfDocEntity;
            if (pdfDocEntity != null)
            {
                Navigation.PushAsync(new PdfDocumentView(pdfDocEntity));
            }

            PdfListView.SelectedItem = null;
        }
    }
}
