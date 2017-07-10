using System.IO;
using System.Threading.Tasks;
using PCLStorage;

namespace PdfViewerSample
{
    public static class FileManager
    {
        public static async Task<Stream> GetFileStreamAsync(string filePath)
        {
            var openAsync = (await FileSystem.Current.GetFileFromPathAsync(filePath))?.OpenAsync(FileAccess.Read);
            if (openAsync == null)
            {
                return null;
            }
            return await openAsync;
        }

        public static async Task SaveFileAsync(string fileName, MemoryStream inputStream)
        {
            var file = await FileSystem.Current.LocalStorage.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            using (var stream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                inputStream.WriteTo(stream);
            }
        }

        public static string GetFilePathFromRoot(string fileName) => Path.Combine(FileSystem.Current.LocalStorage.Path, fileName);

        public static async Task<bool> ExistsAsync(string fileName) => await FileSystem.Current.LocalStorage.CheckExistsAsync(fileName) == ExistenceCheckResult.FileExists;

        public static async Task DownloadDocumentsAsync(PdfDocEntity pdfDocEntity)
        {
            var stream = await RestApiHelper.DownloadFileAsync(pdfDocEntity.Url);
            if (stream == null)
            {
                return;
            }
            await SaveFileAsync(pdfDocEntity.FileName, stream);
        }
    }
}