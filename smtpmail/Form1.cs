using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace smtpmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            MailMessage smtp_message = new MailMessage("aliaazaki126@gmail.com", txt_mail.Text, txt_sub.Text, txt_msg.Text); smtp_message.IsBodyHtml = true;
            smtp_message.Attachments.Add(new Attachment(txt_attach.Text));
            SmtpClient smtp_client = new SmtpClient("smtp.gmail.com", 587);//client.Host = "smtp.gmail.com" ,client.Port = 587
            smtp_client.UseDefaultCredentials = false;
            NetworkCredential network_cre = new System.Net.NetworkCredential("aliaazaki126@gmail.com", txt_pass.Text);//mail.pas
            smtp_client.Credentials = network_cre;
            smtp_client.EnableSsl = true;
            smtp_client.Send(smtp_message);
            MessageBox.Show("Mail Send :D");
        }

        private void btn_attach_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName.ToString();
                txt_attach.Text = path;
            }
        }
    }
}
