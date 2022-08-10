using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using BornesElec;
using Android.Content;

namespace Borneselec
{
    [Activity(Label = "Activity3", Theme = "@style/AppTheme")]
    public class Activity3 : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {


            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.accueil);
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button_Click;
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += Button2_Click;
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            button3.Click += Button3_Click;

            //Button button5 = FindViewById<Button>(Resource.Id.button5);
            //button5.Click += Button5_Click;

        }
        private void Button_Click(object sender, EventArgs e)
        {

            SetContentView(Resource.Layout.accueil);
            Intent intent = new Intent(this, typeof(Activity1));
            StartActivity(intent);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity2));
            StartActivity(intent);
        }
        private void Button3_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(AjouterBornes));
            StartActivity(intent);
        }
        //private void Button5_Click(object sender, EventArgs e)
        //{

        //    Intent intent = new Intent(this, typeof(Crud));
        //    StartActivity(intent);
        //}

    }

    class Activityaccueil
    {
    }
}
