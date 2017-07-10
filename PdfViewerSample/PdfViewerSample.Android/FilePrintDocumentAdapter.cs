using System;
using Android.Print;
using Java.IO;

namespace PdfViewerSample.Droid
{
    public class FilePrintDocumentAdapter : PrintDocumentAdapter
    {
        private readonly string _fileName;
        private readonly string _filePath;

        public FilePrintDocumentAdapter(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        #region implemented abstract members of PrintDocumentAdapter

        public override void OnLayout(PrintAttributes oldAttributes, PrintAttributes newAttributes, Android.OS.CancellationSignal cancellationSignal, LayoutResultCallback callback, Android.OS.Bundle extras)
        {
            if (cancellationSignal.IsCanceled)
            {
                callback.OnLayoutCancelled();
                return;
            }

            callback.OnLayoutFinished(new PrintDocumentInfo.Builder(_fileName)
                .SetContentType(PrintContentType.Document)
                .Build(), true);
        }

        public override void OnWrite(PageRange[] pages, Android.OS.ParcelFileDescriptor destination, Android.OS.CancellationSignal cancellationSignal, WriteResultCallback callback)
        {
            try
            {
                using (InputStream input = new FileInputStream(_filePath))
                {
                    using (OutputStream output = new FileOutputStream(destination.FileDescriptor))
                    {
                        var buf = new byte[1024];
                        int bytesRead;

                        while ((bytesRead = input.Read(buf)) > 0)
                        {
                            output.Write(buf, 0, bytesRead);
                        }
                    }
                }

                callback.OnWriteFinished(new[] { PageRange.AllPages });

            }
            catch (FileNotFoundException fileNotFoundException)
            {
                System.Diagnostics.Debug.WriteLine(fileNotFoundException);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        #endregion
    }
}