using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BornesElec;
using MongoDB.Bson;
using MongoDB.Driver;
using MySqlConnector;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Borneselec
{
    [Activity(Label = "Activity1")]
    public class AjouterBornes : Activity
    {
        public MongoClient client;


        MySqlConnection conn;
        List<Bornes> listBorne;
     

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_ajout);
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button_Click;



        }
        private void Button_Click(object sender, EventArgs e)
        {
            TextView name = FindViewById<TextView>(Resource.Id.name2);

            TextView adresse = FindViewById<TextView>(Resource.Id.adresse2);
            TextView ville = FindViewById<TextView>(Resource.Id.ville2);
            TextView codepostal = FindViewById<TextView>(Resource.Id.codepostal2);
            TextView lat = FindViewById<TextView>(Resource.Id.lat2);
            TextView lng = FindViewById<TextView>(Resource.Id.lng2);
            TextView tarif = FindViewById<TextView>(Resource.Id.tarif2);


            string conString = "Database=borneselec;Data Source=localhost;User Id='root'; Password='';";
            this.conn = new MySqlConnection(conString);

            try
            {
                conn.Open();

                string sql1 = "insert into borne (Adresse,Ville,CodePostal,Latitude,Longitude,name) values ('" + adresse.Text + "','" + ville.Text + "','" + codepostal.Text + "','" + tarif.Text + "','" + lat.Text + "','" + lng.Text + "','" + name.Text + "')'";
                MySqlCommand comm = new MySqlCommand(sql1, conn);
                var reader = comm.ExecuteReaderAsync();

               
                conn.Close();

                TextView erreur = FindViewById<TextView>(Resource.Id.erreur);
                erreur.Text = "Borne";
            }

            catch
            {
                TextView erreur = FindViewById<TextView>(Resource.Id.erreur);
                erreur.Text = "ERREUR";
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
    }
}