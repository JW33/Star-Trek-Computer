using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;


namespace ST_Computer
{
    public class SpeechListener
    {
        public delegate void SpeechRecognizedEventHandler(object sender, SpeechRecognizedEventArgs e);

        public SpeechRecognitionEngine RecognitionEngine = null;
        public event SpeechRecognizedEventHandler WakeUp;
        public event SpeechRecognizedEventHandler SpeechRecognized;

        bool wakeupestablished = false;
        bool playWakeUpFile = false;
        string wakeUpWaveFile = "";
        string wakeUpPhrase = "";
        string[] recognizePhrases = null;

        System.Windows.Threading.DispatcherTimer GetOutOfThisMethodTimer;

        public SpeechListener()
        {
            RecognitionEngine = new SpeechRecognitionEngine();
            RecognitionEngine.SetInputToDefaultAudioDevice();
            RecognitionEngine.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;
            RecognitionEngine.SpeechRecognitionRejected += RecognitionEngine_SpeechRecognitionRejected;

            GetOutOfThisMethodTimer = new System.Windows.Threading.DispatcherTimer();
            GetOutOfThisMethodTimer.Interval = TimeSpan.FromMilliseconds(1);
            GetOutOfThisMethodTimer.Tick += GetOutOfThisMethodTimer_Tick;
        }

        void RecognitionEngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            GetOutOfThisMethodTimer.Tag = null;
            GetOutOfThisMethodTimer.Start();
        }

        void GetOutOfThisMethodTimer_Tick(object sender, EventArgs e)
        {
            GetOutOfThisMethodTimer.Stop();
            var obj = GetOutOfThisMethodTimer.Tag;
            GetOutOfThisMethodTimer.Tag = null;

            if (obj == null)
            {
                StartListening();
                return;
            }

            var args = (SpeechRecognizedEventArgs)obj;

            // NOTE: the file path below needs to be where the "computer.wav" file is located
            SoundPlayer sp = new SoundPlayer(@"C:\Users\JW33\Documents\Visual Studio 2017\Projects\ST_Computer\ST_Computer\computer.wav");
            if (args.Result != null && !IsPartOfSentence(args.Result) && args.Result.Confidence >= minimumConfidenceLevel)
            {
                if (wakeupestablished)
                {
                    if (playWakeUpFile)
                    {
                        // NOTE: the file path below needs to be where the "computer.wav" file is located
                        if (System.IO.File.Exists(@"C:\Users\JW33\Documents\Visual Studio 2017\Projects\ST_Computer\ST_Computer\computer.wav"))
                        {
                            sp.Play();
                        }
                        else
                        {
                            // File not found
                        }
                    }
                    wakeupestablished = false;
                    OnWakeUp(args);
                    ListenForAsync(recognizePhrases, RecognizeMode.Single);
                }
                else
                {
                    // Speech was recognized, fire the event and wake up again
                    OnSpeechRecognized(args);
                    StartListening();
                }
            }
            else
            {
                // Nothing was recognized, start over
                StartListening();
            }
        }

        void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            GetOutOfThisMethodTimer.Tag = e;
            GetOutOfThisMethodTimer.Start();
        }

        protected virtual void OnWakeUp(SpeechRecognizedEventArgs e)
        {
            if (WakeUp != null)
                WakeUp(this, e);
        }

        protected virtual void OnSpeechRecognized(SpeechRecognizedEventArgs e)
        {
            if (SpeechRecognized != null)
                SpeechRecognized(this, e);
        }

        public void WakeUpOnKeyPhrase(string Phrase, bool PlayWaveFileOnWakeUp, string WaveFileName)
        {
            playWakeUpFile = PlayWaveFileOnWakeUp;
            wakeUpWaveFile = WaveFileName;
            wakeUpPhrase = Phrase;
        }

        public void StopListening()
        {
            wakeupestablished = false;
            try
            {
                RecognitionEngine.RecognizeAsyncCancel();
            }
            catch (Exception ex)
            {

            }
        }

        string phrases = "";

        public string Phrases
        {
            get { return phrases; }
            set
            {
                phrases = value;
                if (phrases != "")
                {
                    char[] delim = { (char)10 };
                    recognizePhrases = phrases.Split(delim);
                    for (int i = 0; i < recognizePhrases.Length; i++)
                    {
                        recognizePhrases[i] = recognizePhrases[i].Trim();
                    }
                }

            }
        }

        public void StartListening()
        {
            StopListening();

            RecognitionEngine.UnloadAllGrammars();
            if (wakeUpPhrase != "")
            {
                string[] phrases = { wakeUpPhrase };
                Grammar grammar = CreateGrammar(phrases);
                wakeupestablished = true;
                RecognitionEngine.LoadGrammar(grammar);
                RecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                ListenForAsync(recognizePhrases, RecognizeMode.Single);
            }
        }

        public string Recognize(string[] phrases)
        {
            StopListening();

            RecognitionEngine.UnloadAllGrammars();
            var grammar = CreateGrammar(phrases);
            RecognitionEngine.LoadGrammar(grammar);
            var result = RecognitionEngine.Recognize();
            if (result != null && !IsPartOfSentence(result) && result.Confidence >= minimumConfidenceLevel)
                return result.Text;
            else
                return "";
        }

        void ListenForAsync(string[] phrases, RecognizeMode mode)
        {
            StopListening();

            RecognitionEngine.UnloadAllGrammars();
            var grammar = CreateGrammar(phrases);
            RecognitionEngine.LoadGrammar(grammar);
            RecognitionEngine.RecognizeAsync(mode);
        }

        private float minimumConfidenceLevel = .7f;
        public float MinumumConfidenceLevel
        {
            get { return minimumConfidenceLevel; }
            set { minimumConfidenceLevel = value; }
        }

        public bool IsPartOfSentence(RecognitionResult result)
        {
            foreach (var word in result.Words)
            {
                if (word.Text == "...")
                    return true;
            }
            return false;
        }

        public Grammar CreateGrammar(string[] phrases)
        {
            Grammar g;

            Choices choices = new Choices(phrases);

            GrammarBuilder beforeBuilder = new GrammarBuilder();
            beforeBuilder.AppendWildcard();

            SemanticResultKey beforeKey = new SemanticResultKey("beforeKey", beforeBuilder);

            GrammarBuilder afterBuilder = new GrammarBuilder();
            afterBuilder.AppendWildcard();

            SemanticResultKey afterKey = new SemanticResultKey("afterKey", afterBuilder);

            GrammarBuilder builder = new GrammarBuilder();
            builder.Culture = RecognitionEngine.RecognizerInfo.Culture;
            builder.Append(beforeBuilder);
            builder.Append(choices);
            builder.Append(afterBuilder);
            g = new Grammar(builder);

            return g;
        }
    }
}