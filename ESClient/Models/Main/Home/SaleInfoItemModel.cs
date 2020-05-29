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
        public static BitmapFrame recognizeFace(int width, int height)
        {
            using (Mat mat = new Mat("../../../Resources/ESClient_demo_image.jpg"))
            {
                double ratio = (double)mat.Width / (double)mat.Height;
                double bairitu;
                // 横長の時
                if (ratio > 2)
                {
                    bairitu = (double)height / (double)mat.Height;
                }
                // 縦長の時
                else
                {
                    bairitu = (double)width / (double)mat.Width;
                }

                Mat resizedMat = new Mat();
                // 拡大の時はCubicを使う
                if (bairitu > 1)
                {
                    Cv2.Resize(mat, resizedMat, OpenCvSharp.Size.Zero, bairitu, bairitu, InterpolationFlags.Cubic);
                }
                // 縮小の時はAreaを使う
                else
                {
                    Cv2.Resize(mat, resizedMat, OpenCvSharp.Size.Zero, bairitu, bairitu, InterpolationFlags.Area);
                }
                using (CascadeClassifier cascade = new CascadeClassifier("../../../Resources/lbpcascade_animeface.xml"))
                {
                    // 切り抜き後のmatが代入される
                    Mat convert_mat = new Mat();

                    // 一番大きい顔の情報
                    var maxSquare = 0;
                    OpenCvSharp.Rect maxRect = new OpenCvSharp.Rect(0,0,0,0);

                    // 顔のRect配列の解析
                    foreach (OpenCvSharp.Rect rectFace in cascade.DetectMultiScale(mat))
                    {
                        if (maxSquare < rectFace.Height * rectFace.Width)
                        {
                            maxSquare = rectFace.Height * rectFace.Width;
                            maxRect = rectFace;
                        }
                    }
                    if (maxSquare == 0)
                    {
                        return null;
                    }

                    // 顔の中央の座標
                    var FaceCenter = new OpenCvSharp.Point(maxRect.X * bairitu + maxRect.Width * bairitu / 2, maxRect.Y * bairitu + maxRect.Height * bairitu / 2);
                    
                    // 横長
                    if (ratio >= 2)
                    {
                        // 横長すぎ
                        // 顔の中央を画像の中央にできるとき
                        if (FaceCenter.X > width / 2 && resizedMat.Width - FaceCenter.X > width / 2)
                        {
                            convert_mat = resizedMat.Clone(new Rect(FaceCenter.X - width / 2, 0, width, height));
                        }
                        // 顔の中央が画像の左側になるとき
                        else if (FaceCenter.X < width / 2)
                        {
                            convert_mat = resizedMat.Clone(new Rect(0, 0, width, height));
                        }
                        // 顔の中央が画像の右側になるとき
                        else
                        {
                            convert_mat = resizedMat.Clone(new Rect(resizedMat.Width - width, 0, resizedMat.Width, height));
                        }
                    }
                    // 縦長
                    else
                    {
                        // 顔の中央を画像の中央にできるとき
                        if (FaceCenter.Y > height / 2 && resizedMat.Height - FaceCenter.Y > height / 2)
                        {
                            convert_mat = resizedMat.Clone(new Rect(0, FaceCenter.Y - height / 2, width, height));
                        }
                        // 顔の中央が画像の下部になるとき
                        else if (FaceCenter.Y < height / 2)
                        {
                            convert_mat = resizedMat.Clone(new Rect(0, 0, width, height));
                        }
                        // 顔の中央が画像の上部になるとき
                        else
                        {
                            convert_mat = resizedMat.Clone(new Rect(0, resizedMat.Height - height, width, height));
                        }
                    }
                    Cv2.ImShow("test show", convert_mat);
                    // Imageに表示するため変換
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
