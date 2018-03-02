using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace PersonalAsistance01
{
    public partial class Form3 : Form
    {
        private SpeechRecognitionEngine _engine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        private SpeechSynthesizer _ss = new SpeechSynthesizer();
        private Choices _text = new Choices();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                string[] _lines = File.ReadAllLines(Environment.CurrentDirectory+"\\Command.txt");
                string[] _lines2 = File.ReadAllLines(Environment.CurrentDirectory+"\\MusicPlayer.txt");

                for (int i = 0; i < _lines.Length; i++)
                {
                    Commands.Items.Add(_lines[i]);
                }
                for (int x = 0; x < _lines2.Length; x++)
                {
                    MusicCommand.Items.Add(_lines2[x]);
                }
                    //foreach(string c in _lines)
                    //{
                    //    Commands.Items.Add(c);
                    //}
                    //foreach (string c in _lines2)
                    //{
                    //    MusicCommand.Items.Add(c);
                    //}

                    _text.Add(_lines);
                Grammar _g = new Grammar(new GrammarBuilder(_text));
                _engine.LoadGrammar(_g);
                _engine.SetInputToDefaultAudioDevice();
                _engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Rec);
                _engine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Rec(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "close all commands window":
                    _ss.SpeakAsync("Ok sir.");
                    _engine.RecognizeAsyncStop();
                    this.Close();
                    break;
                case "maximize":
                    WindowState = FormWindowState.Maximized;
                    break;
                case "window normal":
                    WindowState = FormWindowState.Normal;
                    break;
                case "minimize":
                    WindowState = FormWindowState.Minimized;
                    break;
            }
        }
    }
}
