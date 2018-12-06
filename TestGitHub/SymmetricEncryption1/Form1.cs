using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {

        string FileEncrypted = @"X:\jo_enc.txt";
        string FileDecrypted = @"X:\jo_dec.txt";
        string Password = @"X:\libvlcnet-0.4.0.0-src (1).zip.niweil1.partial.enb";

        //string FileEncrypted = @"X:\libvlcnet-0.4.0.0-src (1).zip.niweil1.partial.enc";
        //string FileDecrypted = @"X:\libvlcnet-0.4.0.0-src (1).zip.niweil1.partial";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonencrypt_Click(object sender, EventArgs e)
        {
            Crypt.EncryptFile(Password, FileDecrypted, FileEncrypted);
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            Crypt.DecryptFile(Password, FileEncrypted, FileDecrypted);
        }

        private void buttonDecryptString_Click(object sender, EventArgs e)
        {
            string _EncryptedText = textBoxEncryptedString.Text;
            string _PlainText;
          _PlainText =  crypt2.DecryptString(Password, Convert.FromBase64String( _EncryptedText )) ;

            textBoxDecryptedString.Text = _PlainText;
        }

        private void buttonEncryptString_Click(object sender, EventArgs e)
        {
            string _PlainText = textBoxDecryptedString.Text;
          

           byte[] _Cipher =  crypt2.EncryptString(Password, _PlainText);

           //textBoxEncryptedString.Text = BitConverter.ToString(_Cipher);
           textBoxEncryptedString.Text = Convert.ToBase64String(_Cipher); 
        }
    }
}
