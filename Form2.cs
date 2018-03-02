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
    public partial class Form2 : Form
    {
        private SpeechRecognitionEngine _engine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        private SpeechSynthesizer _ss = new SpeechSynthesizer();

        string[] _paths, _files;
        WMPLib.WindowsMediaPlayer _wmp = new WMPLib.WindowsMediaPlayer();
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            playList.Visible = false;
            myPlayer.Width = 680;

            _ss.SpeakAsync("Welcome to music media player. Lets browse some songs and start listening.");


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
            Choices _texts = new Choices();
            string[] _lines = File.ReadAllLines(Environment.CurrentDirectory + "\\MusicPlayer.txt");
            _texts.Add(_lines);
            Grammar g = new Grammar(new GrammarBuilder(_texts));
            _engine.LoadGrammar(g);
        }

        private void sre_Recognized(object sender, SpeechRecognizedEventArgs e)
        {
            string _speech = e.Result.Text;
            switch (_speech)
            {
                case "browse":
                case "browse file":
                case "file browse":
                    _ss.SpeakAsync("Ok sir, filelog is opening.");
                    browseToolStripMenuItem.PerformClick();
                    break;
                case "exit":
                case "close":
                    //_ss.SpeakAsync("Ok sir, music media player closing.");
                    _engine.RecognizeAsyncStop();
                    exitToolStripMenuItem.PerformClick();
                    break;
                case "show playlist":
                case "playlist":
                case "playlist show":
                    showPlaylistToolStripMenuItem.PerformClick();
                    break;
                case "hide playlist":
                case "playlist hide":
                    hidePlaylistToolStripMenuItem.PerformClick();
                    break;
                case "pause":
                    //_wmp.controls.pause();
                    _Pause();
                    break;
                case "play":
                    _Play();
                    break;
                case "stop":
                    _Stop();
                    break;
                case "fullscreen":
                    _Fullscreen();
                    break;
                case "off fullscreen":
                    _OffFullscreen();
                    break;
                case "next":
                    _Next();
                    break;
                case "previous":
                    _Previous();
                    break;
                case "minimize":
                    //FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Minimized;
                    break;
                case "maximize":
                    WindowState = FormWindowState.Maximized;
                    break;
                case "restore down":
                    WindowState = FormWindowState.Normal;
                    break;
                case "forward fast":
                case "fast forward":
                    myPlayer.Ctlcontrols.fastForward();
                    break;
                case "fast reverse":
                case "reverse fast":
                    myPlayer.Ctlcontrols.fastReverse();
                    break;
                case "increase volume":
                case "volume increase":
                    _VolumeIncrease();
                    break;
                case "decrease volume":
                case "volume deccrease":
                    _VolumeDecresase();
                    break;
                case "mute":                 
                    break;
                case "unmute":
                    break;
                    
            }
        }
        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userName = System.Environment.UserName;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = @"C:\Users\" + userName + "\\Documents\\MyMusic";
            ofd.Filter = "(mp3,wav,mp4,mov,wmv,mpg)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg|all files|*.*";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _files = ofd.SafeFileNames;
                _paths = ofd.FileNames;
                for (int i = 0; i < _files.Length; i++)
                {
                    playList.Items.Add(_files[i]);
                }
                playList.Visible = true;
                myPlayer.Width = 519;
                _AutoPlay(0);

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            _engine.RecognizeAsyncStop();
            this.Close();
        }

        private void hidePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playList.Visible = false;
            myPlayer.Width = 680;
        }

        private void showPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playList.Visible = true;
            myPlayer.Width = 519;
        }

        private void playList_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPlayer.URL = _paths[playList.SelectedIndex];
        }
        private void _Fullscreen()
        {
            if (myPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                myPlayer.fullScreen = true;
            }
            else
            {
                myPlayer.fullScreen = false;
            }
        }
        private void _OffFullscreen()
        {
            if (myPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                myPlayer.fullScreen = false;
            }
            else
            {
                myPlayer.fullScreen = true;
            }
        }
        private void _Next()
        {
            if (myPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if (playList.SelectedIndex < (playList.Items.Count - 1))
                {
                    myPlayer.Ctlcontrols.next();
                    playList.SelectedIndex += 1;
                    //.Update();
                    playList.Update();
                }
                else
                {
                    playList.SelectedIndex = 0;
                    playList.Update();
                }
            }
        }
        private void _Previous()
        {
            if (myPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if(playList.SelectedIndex < (playList.Items.Count-1))
                {
                    playList.SelectedIndex = 0;
                    playList.Update();
                }
                else
                {
                    myPlayer.Ctlcontrols.previous();
                    playList.SelectedIndex -= 1;
                    playList.Update();
                   
                }
            }
        }
        private void _Pause()
        {
            if (myPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                myPlayer.Ctlcontrols.pause();
            }
            else
            {
                myPlayer.Ctlcontrols.play();
            }
        }
        private void _Play()
        {
            if (myPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                myPlayer.Ctlcontrols.play();
            }
            else
            {
                myPlayer.Ctlcontrols.pause();
            }
        }
        private void _Stop()
        {
            if (myPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                myPlayer.Ctlcontrols.stop();
            }
        }
        private void _AutoPlay(int _playlistIndex)
        {
            if (playList.Items.Count <= 0)
            {
                return;
            }
            if(_playlistIndex<0)
            {
                return;
            }
            myPlayer.settings.autoStart = true;
            myPlayer.URL=_paths[_playlistIndex];
            myPlayer.Ctlcontrols.next();
            myPlayer.Ctlcontrols.play();
        }
        private void _VolumeIncrease()
        {
            if(myPlayer.settings.mute==false)
            {
                myPlayer.settings.mute = false;
            }
            if (myPlayer.settings.volume < 1)
            {
                myPlayer.settings.volume += 1;
            }
        }
        private void _VolumeDecresase()
        {
            if (myPlayer.settings.volume > 1)
            {
                myPlayer.settings.volume -= 1;
            }
        }
    }
}
