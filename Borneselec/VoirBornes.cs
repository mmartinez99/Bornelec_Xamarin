using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BornesElec;
using MongoDB.Bson;
using MongoDB.Driver;
using MySql.Data.MySqlClient;
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
    [Activity(Label = "VoirBornes")]
    public class VoirBornes : Activity
    {
        public MongoClient client;


        MySqlConnection conn;
        List<Bornes> listBorne;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_AllBornes);
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


            //client = new MongoClient("mongodb://localhost:27017");
            //var database = client.GetDatabase("djangobornedata2");
            //var collection = database.GetCollection<BsonDocument>("borneelecs");

            //var document = new BsonDocument { { "name", name.Text }, { "adresse", adresse.Text }, { "ville", ville.Text }, { "codepostal", codepostal.Text }, { "latitude", lat.Text }, { "longitude", lng.Text }, { "tarif", tarif.Text } };
            //collection.InsertOne(document);

            //connexion Mysql
            string conString = "Database=borneselec;Data Source=localhost;User Id='root'; Password='';";
            this.conn = new MySqlConnection(conString);

            try
            {
                conn.Open();

                string sql1 = "SELECT * FROM bornes";
                MySqlCommand comm = new MySqlCommand(sql1, conn);
                MySqlDataReader reader = comm.ExecuteReader();
                List<string> items = new List<String>();

            

                reader.Close();

            }

            catch
            {

            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}