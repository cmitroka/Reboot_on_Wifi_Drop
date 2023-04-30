using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace NoInternetReboot
{
    public partial class FormMain : Form
    {
        int iCntr = 0;
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoAction();
        }
        private void DoAction()
        {
            string result;
            try
            {
                using (WebClient client = new WebClient())
                {
                    string downloadString = client.DownloadString("http://www.gooogle.com");
                    result = downloadString;
                }

            }
            catch (Exception)
            {
                result = "";
                Shutdown.Restart();
                throw;
            }
        }
        protected override void SetVisibleCore(bool value)
        {
            if (!IsHandleCreated && value)
            {
                value = false;
                CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            iCntr++;
            if (iCntr>300)
            {
                iCntr = 0;
                DoAction();
            }
        }
    }
}
