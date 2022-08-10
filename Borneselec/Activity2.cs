using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using BornesElec;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Borneselec
{
    [Activity(Label = "Activity2", Theme = "@style/AppTheme")]
    public class Activity2 : AppCompatActivity, IOnMapReadyCallback
    {
        HttpClient client;
        List<BorneApi> listBorneApi;
        private GoogleMap m_map;
        private MapView m_mapView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            var uri = "https://opendata.paris.fr/api/records/1.0/search/?dataset=belib-points-de-recharge-pour-vehicules-electriques-disponibilite-temps-reel&q=&facet=statut_pdc&facet=last_updated&facet=arrondissement";

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
           m_mapView = FindViewById<MapView>(Resource.Id.mainactivity_mapView);

            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            recupAPIMarker(uri);
            m_mapView.OnCreate(savedInstanceState);
            m_mapView.GetMapAsync(this);
           
            

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public void OnMapReady(GoogleMap map)
        {
            m_map = map;
            LatLng Paris = new LatLng(48.856614, 2.3522219);
           // m_map.AddMarker(new MarkerOptions().SetPosition(new LatLng(48.856614, 2.3522219)).SetTitle("Mon marker"));

            m_map.MoveCamera(CameraUpdateFactory.NewLatLngZoom(Paris, 13));

            

        }

        protected override void OnPause()
        {
            base.OnPause();
            m_mapView.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
            m_mapView.OnResume();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            m_mapView.OnSaveInstanceState(outState);
        }
        public async void recupAPIMarker(string uri)
        {
            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(content);
                var test = json.Property("records").Value;
                var finaltest = test.ToString();
                listBorneApi = JsonConvert.DeserializeObject<List<BorneApi>>(finaltest);


                foreach (var en in listBorneApi)
                {
                    double lng = en.fields.coordonneesxy[1];
                    double lat = en.fields.coordonneesxy[0];
                    string adresse_station = en.fields.adresse_station;


                    m_map.AddMarker(new MarkerOptions().SetPosition(new LatLng(lat, lng)).SetTitle(adresse_station));
                }


            }
        }
    }
   

}


