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


        Button btnCallMe;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            btnCallMe = FindViewById<Button>(Resource.Id.btnCallMe);


        }



        public void OnInit([GeneratedEnum] OperationResult status)
        {

        }

        protected override void OnActivityResult(int requestCode, Result resultVal, Intent data)
        {
  

        }
    }
}

