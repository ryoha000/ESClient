using Microsoft.WindowsAPICodePack.Shell;

namespace ESClient.Models.Navigation
{
    class GameListItemModel
    {
        public static System.Windows.Media.ImageSource ShowIcon()
        {
            using (var file = ShellFile.FromFilePath(@"E:\Users\ユウヤ\Desktop\美少女万華鏡 理と迷宮の少女.lnk"))
            {
                file.Thumbnail.FormatOption = ShellThumbnailFormatOption.IconOnly;
                return file.Thumbnail.MediumBitmapSource;

                // IconImage.Source = file.Thumbnail.SmallBitmapSource;      // 16x16
                // IconImage.Source = file.Thumbnail.MediumBitmapSource;     // 32x32
                // IconImage.Source = file.Thumbnail.LargeBitmapSource;      // 48x48
                // IconImage.Source = file.Thumbnail.ExtraLargeBitmapSource; // 256x256
            }
        }
    }
}
