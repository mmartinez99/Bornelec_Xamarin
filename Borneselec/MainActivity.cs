using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace Borneselec
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity

    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.bornesElec);
            
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button_Click;
            //Button button2 = FindViewById<Button>(Resource.Id.button2);
            //button2.Click += Button2_Click;
            ////Button button3 = FindViewById<Button>(Resource.Id.button3);
            ////button3.Click += Button3_Click;
            ////Button button4 = FindViewById<Button>(Resource.Id.button4);
            ////button4.Click += Button4_Click;
            ////Button button5 = FindViewById<Button>(Resource.Id.button5);
            ////button5.Click += Button5_Click;
           
        }
        private void Button_Click(object sender, EventArgs e)
        {

            //SetContentView(Resource.Layout.accueil);
            Intent intent = new Intent(this, typeof(Activity3));
            StartActivity(intent);
        }

        //private void Button2_Click(object sender, EventArgs e)
        //{
        //    Intent intent = new Intent(this, typeof(Activity1));
        //    StartActivity(intent);
        //}
        //private void Button3_Click(object sender, EventArgs e)
        //{

        //    Intent intent = new Intent(this, typeof(AjouterBornes));
        //    StartActivity(intent);
        //}

        //private void Button4_Click(object sender, EventArgs e)
        //{
        //    Intent intent = new Intent(this, typeof(AjouterBornes));
        //    StartActivity(intent);
        //}
        //private void Button5_Click(object sender, EventArgs e)
        //{

        //    Intent intent = new Intent(this, typeof(Activity2));
        //    StartActivity(intent);
        //}

 
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }



    }

  
}
  
    
