using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String email = "gmail";
                String password = "password";
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(email);
                    mail.To.Add(textBox3.Text);
                    mail.Subject = textBox1.Text;
                    mail.Body = textBox2.Text;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(email, password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        MessageBox.Show("mail sent");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
