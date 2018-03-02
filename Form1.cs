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
using System.Diagnostics;

namespace PersonalAsistance01
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine _engine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        private SpeechSynthesizer _synthesis = new SpeechSynthesizer();
        int _ext=0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _synthesis.SpeakAsync("Welcome, to voice recognize personal asistance system.");

            try
            {
                my_Grammaer();
                _engine.SetInputToDefaultAudioDevice();
                _engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_Recognized);
                _engine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void my_Grammaer()
        {
            Choices texts = new Choices();
            string[] lines = File.ReadAllLines(Environment.CurrentDirectory + "\\Command.txt");
            texts.Add(lines);
            Grammar g = new Grammar(new GrammarBuilder(texts));
            _engine.LoadGrammar(g);
        }

        private void Say(string h)
        {
            _synthesis.SpeakAsync(h);
            Bottext.Text =  h;
        }

        private void sre_Recognized(object sender, SpeechRecognizedEventArgs e)
        {
            UserText.Text = e.Result.Text;
            string speech = e.Result.Text;
            switch (speech)
            {
                case "Hi":
                    Say("Hello,How are you?");
                    break;
                case "Hello":
                    Say("Hi,how are you?");
                    break;
                case "Fine":
                //case "good":
                case "Ok":
                case "Great":
                    Say("Nice to hear you.");
                    break;
                case "How are you":
                case "How you are":
                case "How you doing":
                    Say("I am ok. how are you?");
                    break;
                case "what you are doing":
                case "what are you doing":
                case "what you doing":
                    Say("i am doing nothing, just waiting for you commands.");
                    break;
                case "hey":
                    Say("Yeah!");
                    break;
                case "are you there":
                    Say("Yes sir,I am listening your voice.");
                    break;
                case "are you listening":
                    Say("Yes sir.");
                    break;
                case "who you":
                case "who you are":
                case "who are you":
                case "tell me about yourself":
                case "tell  me about you":
                    Say("I am Katherine. I am your personal asistant.");
                    break;
                case "what is your name":
                case "whats your name":
                case "your name?":
                case "tell me your name":
                case "tell your name":
                case "tell me what your name":
                    Say("My name is Katherine.");
                    break;
                case "close":
                case "close yourself":
                case "katherine shutdown":
                case "shut down katherine":
                    Say("Are you sure sir?");
                    _ext = 1;
                    break;
                case "Yes":
                    if (_ext == 1)
                    {
                        this.Close();
                    }
                    break;
                case "browser open":
                case "open browser":
                    Say("Ok sir, Browser is opening.");
                    Process.Start("IExplore.exe");
                    break;
                case "open firefox":
                case "open mozila firefox":
                case "open mozila":
                    Say("Ok sir, firefox is loading.");
                    Process.Start("firefox.exe");
                    break;
                case "open chrome":
                case "open google chrome":
                    Process.Start("chrome.exe");
                    break;
                case "open music player":
                    //Say("Ok sir, music player is loading.");
                    Form2 frm = new Form2();
                    frm.Show();
                    _engine.RecognizeAsyncStop();
                    this.Hide();
                    break;
                case "Katherine what time it is":
                case "what time it is":
                case "Katherine what is the time":
                case "what is the time":
                    Say(DateTime.Now.ToString("hh-mm tt"));
                    break;
                case "what date it is today":
                case "what is the date today":
                    Say(DateTime.Now.ToString("MM-dd-yyyy"));
                    break;
                case "show all commands":
                    Say("Ok sir.");
                    Form3 frm1 = new Form3();
                    frm1.Show();
                    break;
                case "open notepad":
                    Say("Ok sir.");
                    Notepad note = new Notepad();
                    note.Show();
                    _engine.RecognizeAsyncStop();
                    this.Hide();
                    break;
            }

            Process[] _ie = Process.GetProcessesByName("explorer");
            if(_ie.Length!=0)
            {
                switch(speech)
                {
                    case "new tab":
                        SendKeys.Send("^t");
                        break;
                    case "new window":
                        SendKeys.Send("^n");
                        break;
                    case "close tab":
                        SendKeys.Send("^w");
                        break;
                    case "close browser":
                        for (int i = 0; i < _ie.Length; i++)
                        {
                            _ie[i].Kill();
                            
                        }
                        break;
                    case "fullscreen":
                        SendKeys.Send("{f11}");
                        break;
                    case "move to address bar":
                        SendKeys.Send("%d");
                        break;
                }
            }
            Process[] _firefox = Process.GetProcessesByName("firefox");
            if(_firefox.Length!=0)
            {
                switch (speech)
                {
                    case "new tab":
                        SendKeys.Send("^t");
                        break;
                    case "new window":
                        SendKeys.Send("^n");
                        break;
                    case "close tab":
                        SendKeys.Send("^w");
                        break;
                    case "close mozila firefox":
                    case "close mozila":
                    case "close firefox":
                        for (int x = 0; x < _firefox.Length; x++)
                        {
                            _firefox[x].Kill();
                            
                        }
                        break;
                    case "fullscreen":
                        SendKeys.Send("{f11}");
                        break;
                    case "move to address bar":
                        SendKeys.Send("^l");
                        break;
                }
            }
            Process[] _chrome = Process.GetProcessesByName("chrome");
            if(_chrome.Length!=0)
            {
                switch (speech)
                {
                    case "new tab":
                        SendKeys.Send("^t");
                        break;
                    case "new window":
                        SendKeys.Send("^n");
                        break;
                    case "close tab":
                        SendKeys.Send("^w");
                        break;
                    case "close chrome":
                    case "close google chrome":
                        for (int y = 0; y < _firefox.Length; y++)
                        {
                            _chrome[y].Kill();

                        }
                        break;
                    case "fullscreen":
                        SendKeys.Send("{f11}");
                        break;
                    case "move to address bar":
                        SendKeys.Send("^l");
                        break;
                }
            }
        }
        
    }
}
