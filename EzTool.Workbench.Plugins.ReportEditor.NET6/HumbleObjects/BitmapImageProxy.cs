using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.IO;

namespace EzTool.Workbench.Plugins.ReportEditor.NET6.HumbleObjects
{
    public class BitmapImageProxy :
       IBitMapImageProxy,
       IDiskFile
    {
        #region -- 變數宣告 ( Declarations ) --   

        private readonly BitmapImage l_objImage;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public BitmapImageProxy(string pi_sImagePath)
        {
            FilePath = pi_sImagePath;
            var photoFile = File.ReadAllBytes(pi_sImagePath);
            var photo = new BitmapImage();

            using (var stream = new MemoryStream(photoFile))
            {
                photo.BeginInit();
                photo.CacheOption = BitmapCacheOption.OnLoad;
                photo.StreamSource = stream;
                photo.EndInit();
                l_objImage = photo;
            }
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IBitMapImageProxy Initial(string pi_sImagePath)
        {
            return new BitmapImageProxy(pi_sImagePath);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IBitMapProxy] --

        public string FilePath { get; private set; }

        #endregion

        #region -- 介面實做 ( Implements ) - [IBitMapProxy] --

        public InlineUIContainer ToContainer()
        {
            var objReturn = new InlineUIContainer(new Image()
            {
                Width = 120,
                Height = 120,
                Stretch = Stretch.None,
                Source = l_objImage
            });

            return objReturn;
        }

        #endregion

    }

    public interface IDiskFile
    {
        string FilePath { get; }
    }

    public interface IBitMapImageProxy
    {
        InlineUIContainer ToContainer();
    }
}
