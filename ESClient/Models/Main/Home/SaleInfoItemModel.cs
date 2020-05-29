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
            //using (Mat mat = new Mat("../../../Resources/ESClient_demo_image.jpg"))
            using (Mat mat = new Mat(@"E:\Users\ユウヤ\Pictures\コメント 2020-05-30 054140.png"))
            {
                double ratio = (double)mat.Width / (double)mat.Height;
                double bairitu;
                // 横長の時
                if (ratio > 2)
                {
                    bairitu = (double)125 / (double)mat.Height;
                }
                else
                {
                    bairitu = (double)250 / (double)mat.Width;
                }
                Mat newMat = new Mat();
                if (bairitu > 1)
                {
                    Cv2.Resize(mat, newMat, OpenCvSharp.Size.Zero, bairitu, bairitu, InterpolationFlags.Cubic);
                }
                else
                {
                    Cv2.Resize(mat, newMat, OpenCvSharp.Size.Zero, bairitu, bairitu, InterpolationFlags.Area);
                }
                Cv2.ImShow("mat", mat);
                Cv2.ImShow("newMat", newMat);
                using (CascadeClassifier cascade = new CascadeClassifier("../../../Resources/lbpcascade_animeface.xml"))
                {
                    var maxSquare = 0;
                    OpenCvSharp.Rect maxRect = new OpenCvSharp.Rect(0,0,0,0);
                    foreach (OpenCvSharp.Rect rectFace in cascade.DetectMultiScale(mat))
                    {
                        System.Diagnostics.Debug.WriteLine(rectFace);
                        System.Diagnostics.Debug.WriteLine(maxSquare < rectFace.Height * rectFace.Width);
                        System.Diagnostics.Debug.WriteLine(maxRect);
                        if (maxSquare < rectFace.Height * rectFace.Width)
                        {
                            maxSquare = rectFace.Height * rectFace.Width;
                            maxRect = rectFace;
                        }
                        Rect rect = new Rect(rectFace.X, rectFace.Y, rectFace.Width, rectFace.Height);
                        Cv2.Rectangle(mat, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);
                    }
                    Cv2.ImShow("face_show", mat);
                    if (maxSquare == 0)
                    {
                        return null;
                    }
                    var centerX = maxRect.X + maxRect.Width / 2;
                    var centerY = maxRect.Y + maxRect.Height / 2;
                    Mat convert_mat = new Mat();
                    // 横長
                    if (ratio >= 2)
                    {
                        // 横長すぎ
                        if (centerX > 125 && newMat.Width - centerX > 125)
                        {
                            convert_mat = newMat.Clone(new Rect(centerX - 125, 0, 250, 125));
                        }
                        else if (centerX < 125)
                        {
                            convert_mat = newMat.Clone(new Rect(0, 0, 250, 125));
                        }
                        else
                        {
                            convert_mat = newMat.Clone(new Rect(newMat.Width - 250, 0, newMat.Width, 125));
                        }
                    }
                    // 縦長
                    else
                    {
                        if (centerY > 63 && newMat.Width - centerY > 63)
                        {
                            convert_mat = newMat.Clone(new Rect(0, centerY - 63, 250, 125));
                        }
                        else if (centerY < 63)
                        {
                            convert_mat = newMat.Clone(new Rect(0, 0, 250, 125));
                        }
                        else
                        {
                            convert_mat = newMat.Clone(new Rect(0, newMat.Height - 125, 250, 125));
                        }
                    }
                    Cv2.ImShow("convert_mat", convert_mat);
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
