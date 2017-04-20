using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;
using System.Net.Http;
using Android.Speech.Tts;
using static Android.Speech.Tts.TextToSpeech;
using Android.Speech;
using Android.Provider;
using Android.Runtime;

namespace NativeSampleAn
{
    [Activity(Label = "NativeSampleAn", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnInitListener
    {
        const int VOICE = 100;
        const int CAMERA = 101;

        TextView txtView;
        ScrollView scrollView;

        Button btnCallHome;
        Button btnNotify;
        Button btnDownload;
        Button btnViewMap;
        Button btnSpeak;
        Button btnListen;
        Button btnCamera;
        TextToSpeech ttsClient;
        ImageView imgResult;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            btnCallHome = FindViewById<Button>(Resource.Id.btnCallHome);
            btnNotify = FindViewById<Button>(Resource.Id.btnNotify);
            btnDownload = FindViewById<Button>(Resource.Id.btnDownloadWeb);
            txtView = FindViewById<TextView>(Resource.Id.textView);
            scrollView = FindViewById<ScrollView>(Resource.Id.scrollView1);
            btnViewMap = FindViewById<Button>(Resource.Id.btnViewMap);
            btnSpeak = FindViewById<Button>(Resource.Id.btnSpeak);
            btnListen = FindViewById<Button>(Resource.Id.btnListen);
            btnCamera = FindViewById<Button>(Resource.Id.btnCamera);
            imgResult = FindViewById<ImageView>(Resource.Id.imgResult);
            ttsClient = new TextToSpeech(this, this);

            btnViewMap.Click += BtnViewMap_Click;
            btnSpeak.Click += BtnSpeak_Click;
            btnListen.Click += BtnListen_Click;
            btnCamera.Click += BtnCamera_Click;
            btnCallHome.Click += Button_Click;
            btnNotify.Click += BtnNotify_Click;
            btnDownload.Click += BtnDownload_Click;
        }

        private async void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                txtView.Text = await client.GetStringAsync("http://m.google.com");
            }
            catch (Exception ex)
            {
                throw ex; // new Exception(ex.ToString());
            }
        }

        private void BtnNotify_Click(object sender, EventArgs e)
        {
            //Intent intent = new Intent(this, typeof(MainActivity));
            //const int pendingIntentId = 0;
            //PendingIntent pendingIntent =
            //    PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.OneShot);

            Notification.Builder builder = new Notification.Builder(this);
            //builder.SetContentIntent(pendingIntent);
            builder.SetPriority((int)NotificationPriority.High);
            builder.SetContentTitle("알려드립니다!!");
            builder.SetContentText("Hello World! This is my first notification!");
            builder.SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate | NotificationDefaults.Lights);
            builder.SetSmallIcon(Resource.Drawable.Icon);
            Notification noti = builder.Build();

            // Build the notification:
            Notification notification = builder.Build();
            NotificationManager manager = GetSystemService(Context.NotificationService) as NotificationManager;
            manager.Notify(101, noti);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Intent callIntent = new Intent(Intent.ActionCall);
            callIntent.SetData(Android.Net.Uri.Parse("tel:02-123-4567"));
            StartActivity(callIntent);
        }


        private void BtnViewMap_Click(object sender, EventArgs e)
        {
            //map
            //var mapUri = Android.Net.Uri.Parse("geo:37.2485813,127.4828382");

            //street view
            var mapUri = Android.Net.Uri.Parse("google.streetview:cbll=37.575118,126.977069&cbp=1,90,,0,1.0&mz=20");

            Intent mapIntent = new Intent(Intent.ActionView, mapUri);
            StartActivity(mapIntent);

        }

        private void BtnSpeak_Click(object sender, EventArgs e)
        {

            ttsClient.Speak("아이 러브 유", QueueMode.Add, null);
            ttsClient.Speak("I love you", QueueMode.Add, null);


            //Thread.Sleep(8000);
            ttsClient.SetLanguage(Java.Util.Locale.English);
            ttsClient.Speak("It is time to go Xamarin", QueueMode.Add, null);
            ttsClient.Speak("What time is it?", QueueMode.Add, null);
            //Thread.Sleep(5000);

            ttsClient.SetLanguage(Java.Util.Locale.China);
            ttsClient.Speak("我永远只爱你一个人.", QueueMode.Add, null);

            ttsClient.SetLanguage(Java.Util.Locale.Japan);
            ttsClient.Speak("あなたを愛しています。", QueueMode.Add, null);
            //Thread.Sleep(3000);

            ttsClient.SetLanguage(Java.Util.Locale.Germany);
            ttsClient.Speak("Ich liebe dich nur für immer.", QueueMode.Add, null);

        }

        private void BtnListen_Click(object sender, EventArgs e)
        {
            var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            //voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "말씀하세요");
            //voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
            //voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
            //voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
            //voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
            //voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
            StartActivityForResult(voiceIntent, VOICE);
        }

        private void BtnCamera_Click(object sender, EventArgs e)
        {
            //Intent cameraIntent = new Intent(MediaStore.ActionImageCapture);
            Intent cameraIntent = new Intent(MediaStore.ActionImageCapture);

            if(cameraIntent.ResolveActivity(PackageManager) != null)
            StartActivityForResult(cameraIntent, CAMERA);
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {

        }

        protected override void OnActivityResult(int requestCode, Result resultVal, Intent data)
        {
            switch (requestCode)
            {
                case VOICE:
                    #region voice
                    if (resultVal == Result.Ok)
                    {
                        var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                        if (matches.Count != 0)
                        {
                            txtView.Text = string.Empty;
                            foreach (var item in matches)
                            {
                                txtView.Text += item + "\n\r";
                            }

                        }
                        else
                            txtView.Text = "..해석 불가..";

                    }
                    #endregion
                    break;
                case CAMERA:
                    #region camera
                    if (resultVal == Result.Ok)
                    {
                        imgResult.SetImageURI(data.Data);

                    }
                    #endregion
                    break;
                default:
                    break;
            }

        }
    }
}

