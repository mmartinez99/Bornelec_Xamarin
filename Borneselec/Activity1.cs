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

namespace Borneselec
{
    [Activity(Label = "Liste Bornes API", Theme = "@style/AppTheme")]
    public class Activity1 : AppCompatActivity
    {
        HttpClient client;
        List<BorneApi> listBorneApi;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            var uri = "https://opendata.paris.fr/api/records/1.0/search/?dataset=belib-points-de-recharge-pour-vehicules-electriques-disponibilite-temps-reel&q=&facet=statut_pdc&facet=last_updated&facet=arrondissement";

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity1);
            Button btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.Click += (object sender, EventArgs e) =>
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(uri);
                recupAPI(uri);
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public async void recupAPI(string uri)
        {
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(content);
                var test = json.Property("records").Value;
                var finaltest = test.ToString();

                //foreach (var e in test)
                //{
                //    Console.WriteLine(e);
                //}
                ListView lst1 = FindViewById<ListView>(Resource.Id.listView1);
                listBorneApi = JsonConvert.DeserializeObject<List<BorneApi>>(finaltest);
                List<string> items = new List<String>();
                

                foreach (var en in listBorneApi)
                {
                    items.Add(en.fields.adresse_station);
                    items.Add(en.fields.code_insee_commune.ToString());
                    items.Add(string.Join(", ", en.fields.coordonneesxy));
                }
                var ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
                lst1.SetAdapter(ListAdapter);
            }
        }
    }
}