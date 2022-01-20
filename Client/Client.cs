using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;
using System.ServiceModel;

namespace Client
{
    public partial class Client : Form
    {
        IexcService _dataSrv;
        Callback _callback;

        public Client()
        {
            InitializeComponent();
            try
            {
                _callback = new Callback(this);

                DuplexChannelFactory<IexcService> factory = new DuplexChannelFactory<IexcService>(
                    _callback,
                    new NetNamedPipeBinding(),
                    new EndpointAddress("net.pipe://localhost/DataExchangeSrv"));

                _dataSrv = factory.CreateChannel();
                bool res = _dataSrv.Subcribe();

            }
            catch (Exception ex)
            {

            }
        }

        private void bSendMsg_Click(object sender, EventArgs e)
        {
            LogUserMessage("You say " + Environment.NewLine + tbMessage.Text);
            try
            {
                string msg = tbMessage.Text;
                tbMessage.Text = string.Empty;

                _dataSrv.SendMessage(tbUser.Text, msg);
              
            }
            catch(Exception ex)
            {
                LogErrorMessage(ex.Message);
            }

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                bool res = _dataSrv.UnSubcribe();
            }
            catch (Exception ex)
            {

            }
        }

        void LogErrorMessage(string msg)
        {
            LogMessage(
               msg,
               new Font("Microsoft San Serif", 10, FontStyle.Italic),
               Color.Red);
        }

        void LogUserMessage(string msg)
        {
            LogMessage(
               msg,
               new Font("Microsoft San Serif", 10),
               Color.Black);
        }

        public void LogPeerMessage(string msg)
        {
            LogMessage(
                msg,
                new Font("Microsoft San Serif", 10, FontStyle.Italic),
                Color.Blue);
        }

        void LogMessage(string msg, Font font, Color color)
        {
            string newMsg =
                System.Environment.NewLine +
                DateTime.Now.ToLongTimeString().ToString() + " - " +
                msg +
                System.Environment.NewLine;

            logger.AppendText(newMsg, font, color);
        }

        void CloseMessage()
        {
            logger.Text = string.Empty;
        }

        private void tbUser_TextChanged(object sender, EventArgs e)
        {
            bSendMsg.Enabled =
                (tbUser.Text.Length != 0) &&
                (tbMessage.Text.Length != 0);
        }

        private void tbMessage_TextChanged(object sender, EventArgs e)
        {
            bSendMsg.Enabled =
                (tbUser.Text.Length != 0) &&
                (tbMessage.Text.Length != 0);
        }
    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(
           this RichTextBox box,
           string text,
           Font font,
           Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.SelectionFont = font;

            box.AppendText(text);

            box.SelectionColor = box.ForeColor;
        }
    }
}
