using System.IO;
using Xamarin.Forms;
using Windows.Storage;
using CurrencyApplication.UWP;

[assembly: Dependency(typeof(FileHelper))]
namespace CurrencyApplication.UWP
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
