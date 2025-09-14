using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace QuickWA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            string message = Uri.EscapeDataString(txtMessage.Text.Trim());

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter your phone number.");
                return;
            }

            string waLink = $"https://wa.me/{phone}?text={message}";
            txtResult.Text = waLink;

          
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(waLink, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            picQRCode.Image = qrCodeImage;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtResult.Text))
            {
                Clipboard.SetText(txtResult.Text);
                MessageBox.Show("Link copied.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
