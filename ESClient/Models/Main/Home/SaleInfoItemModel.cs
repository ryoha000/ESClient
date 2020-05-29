using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace ESClient.Models.Main.Home
{
    class SaleInfoItemModel
    {
        public static BitmapFrame recognizeFace()
        {
            using (Mat mat = new Mat("../../../Resources/ESClient_demo_image.jpg"))
            {
                Mat newMat = new Mat();
                var ratio = mat.Width / mat.Height;
                int bairitu;
                // 横長の時
                if (ratio > 2)
                {
                    bairitu = 125 / mat.Height;
                }
                else
                {
                    bairitu = 250 / mat.Width;
                }
                System.Diagnostics.Debug.WriteLine(bairitu);
                //Cv2.Resize(mat, newMat, new OpenCvSharp.Size(mat.Width * bairitu, mat.Height * bairitu), 0, 0, InterpolationFlags.Cubic);
                Cv2.Resize(mat, newMat, OpenCvSharp.Size.Zero, bairitu, bairitu, InterpolationFlags.Cubic);
                using (CascadeClassifier cascade = new CascadeClassifier("../../../Resources/lbpcascade_animeface.xml"))
                {
                    //foreach (OpenCvSharp.Rect rectFace in cascade.DetectMultiScale(mat))
                    if (cascade.DetectMultiScale(newMat).Length < 1)
                    {
                        return null;
                    }
                    OpenCvSharp.Rect rectFace = cascade.DetectMultiScale(newMat)[0];
                    {

                        var centerX = rectFace.X + rectFace.Width / 2;
                        var centerY = rectFace.Y + rectFace.Height / 2;
                        Mat convert_mat = new Mat();
                        // 横長
                        if (ratio >= 2)
                        {
                            // 横長すぎ
                            if (centerX > 125 && newMat.Width - centerX > 125)
                            {
                                convert_mat = mat.Clone(new Rect(centerX - 125, 0, centerX + 125, 125));
                            }
                            else if (centerX < 125)
                            {
                                convert_mat = mat.Clone(new Rect(0, 0, 250, 125));
                            }
                            else
                            {
                                convert_mat = mat.Clone(new Rect(newMat.Width - 250, 0, newMat.Width, 125));
                            }
                        }
                        // 縦長
                        else
                        {
                            if (centerY > 63 && newMat.Width - centerY > 63)
                            {
                                convert_mat = mat.Clone(new Rect(0, centerY - 63, 250, centerY + 63));
                            }
                            else if (centerY < 63)
                            {
                                convert_mat = mat.Clone(new Rect(0, 0, 250, 125));
                            }
                            else
                            {
                                convert_mat = mat.Clone(new Rect(0, newMat.Height - 125, 250, newMat.Height));
                            }
                        }
                        // 見つかった場所に赤枠を表示
                        var rect = new OpenCvSharp.Rect(rectFace.X, rectFace.Y, rectFace.Width, rectFace.Height);
                        Cv2.Rectangle(mat, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);
                Cv2.ImShow("sample_show", newMat);
                Bitmap bmp = BitmapConverter.ToBitmap(convert_mat);
                using (Stream st = new MemoryStream())
                {
                    bmp.Save(st, ImageFormat.Bmp);
                    st.Seek(0, SeekOrigin.Begin);
                    return BitmapFrame.Create(st, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
                    }
                }
            }

        }
    }
}
