using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace AutoTrainingData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var imagePath = tbImagePath.Text;
            var savePath = tbSavePath.Text;
            EnrollImage();
            SubmitImage(imagePath);
            InsertToDb();

        }

        private void InsertToDb()
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"Server=DESKTOP-A3NO6EJ\SQLEXPRESS;Database=DemoFaceRecognition.Context.FaceRecognitionContext;Trusted_Connection=True;";
            con.Open();

            SqlDataAdapter cmd = new SqlDataAdapter();
            cmd.InsertCommand = new SqlCommand("insert into [Students]([StudentId],[FullName],[Email],[Image])values(@studentId, @fullName, @email, @image)", con);

            cmd.InsertCommand.Parameters.AddWithValue("@studentId", tbStudentId.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@fullName", tbFullName.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@email", tbEmail.Text);
            cmd.InsertCommand.Parameters.AddWithValue("@image", tbSavePath.Text);

            int a = cmd.InsertCommand.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Saved successfully");
            }
            con.Close();
        }

        private async void EnrollImage()
        {
            //send image to recognize on kairos
            var base64string = Utils.ToBase64(tbImagePath.Text);
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                {"image", base64string},
                {"gallery_name", Utils.GetConfig(Constants.Config.GalleryName)}
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("app_id", Utils.GetConfig(Constants.Config.AppId));
            client.DefaultRequestHeaders.Add("app_key", Utils.GetConfig(Constants.Config.AppKey));
            var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Utils.GetConfig(Constants.Config.KairosEnrollEndpoint), content);
        }

        private void SubmitImage(string imagePath)
        {
            //resize image
            Image image = new Bitmap(tbImagePath.Text);
            Bitmap resizedImage = ResizeImage(image, 91, 121);
            SaveJpeg(@"C:\Users\User\Documents\Visual Studio 2015\Projects\AutoTrainingData\resized\cde.jpg", resizedImage, 70);
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.Clamp);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbImagePath.Text = FD.FileName;
            }
        }

        private void btnBrowseSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbSavePath.Text = saveDialog.FileName;
            }
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path"> Path to which the image would be saved. </param> 
        /// <param name="quality"> An integer from 0 to 100, with 100 being the highest quality. </param> 
        public void SaveJpeg(string path, Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            // JPEG image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            var i2 = new Bitmap(img);
            i2.Save(path, jpegCodec, encoderParams);
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }

    }
}
