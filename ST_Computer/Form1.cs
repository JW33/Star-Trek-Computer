using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ST_Computer
{
    public partial class Form1 : Form
    {
        SpeechListener listener = null;

        string WakeUpWavFile = "computer.wav";

        public Form1()
        {
            InitializeComponent();

            listener = new SpeechListener();
            listener.SpeechRecognized += Listener_SpeechRecognized;

            //Phrases on start up
            txtPhrases.Text = "This is cool \r\n Is it lunch time yet \r\n How are you \r\n Hello there \r\n Open Firefox \r\n Open all info";
            btnStartListening.Click += ListenButton_Click;
        }

        void Listener_SpeechRecognized(object sender, System.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            // When a phrase is recognized
            lblHeard.Text = DateTime.Now.ToLongTimeString() + ": " + e.Result.Text;
            CarryOutCommand(e.Result.Text);
        }

        void ListenButton_Click(object sender, EventArgs e)
        {
            if (btnStartListening.Text == "Start Listening")
            {
                // Use a wake up command for additional accuracy
                if (ckbListenFOrWakeUpCommand.Checked == true)
                    listener.WakeUpOnKeyPhrase(txtWakeUpCommand.Text, true, WakeUpWavFile);

                // Set the phrases to listen for and start listening
                listener.Phrases = txtPhrases.Text;
                listener.StartListening();

                btnStartListening.Text = "Stop Listening";
                btnStartListening.BackColor = Color.Red;
                btnStartListening.ForeColor = Color.White;
            }
            else
            {
                listener.StopListening();

                btnStartListening.Text = "Start Listening";
                lblHeard.Text = "";

                btnStartListening.BackColor = Color.LimeGreen;
                btnStartListening.ForeColor = Color.Black;
            }
        }

        List<string> computerPhrases = new List<string>() { "I'm good, how are you doing?", "It's been another long one", "Still going..." };
        
        public void CarryOutCommand(string command)
        {
            Process process = new Process();
            try
            {
                if (command.Substring(0, 3) == "Open")
                {
                    switch (command)
                    {
                        case "Open Firefox":
                            process.StartInfo.FileName = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                            process.Start();
                            break;
                    }
                }
                else if(command == "How are you")
                {
                    Random random = new Random();
                    int selector = random.Next(2);
                    lblHeard.Text = computerPhrases[selector];
                }
            }
            catch(Win32Exception ex)
            {
                lblHeard.Text = "Program not found. Please check your file path.";
            }
            catch (Exception ex)
            {
                lblHeard.Text = "Unfortunately, this program has had a malfunction. Please try again";
            }
        }

    }
}
