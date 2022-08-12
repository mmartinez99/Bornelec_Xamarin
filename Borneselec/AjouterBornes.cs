using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using BornesElec;
using System.Collections.Generic;
using SQLiteDB.Resources.Helper;
using BornesElec;
using System;

namespace Borneselec
{
    [Activity(Label = "AjouterBornes")]
    public class AjouterBornes : Activity
    {

        ListView ListBornes;
        List<Bornes> listesBornes = new List<Bornes>();
        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.formBornes);
            Createdatabase();

            Liste = FindViewById<ListView>(Resource.Id.listView);

            TextView name = FindViewById<TextView>(Resource.Id.name2);
            TextView id = FindViewById<TextView>(Resource.Id.id);

            TextView adresse = FindViewById<TextView>(Resource.Id.adresse2);
            TextView ville = FindViewById<TextView>(Resource.Id.ville2);
            TextView codepostal = FindViewById<TextView>(Resource.Id.codepostal2);
            TextView lat = FindViewById<TextView>(Resource.Id.lat2);
            TextView lng = FindViewById<TextView>(Resource.Id.lng2);
            TextView tarif = FindViewById<TextView>(Resource.Id.tarif2);

            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += button1_Click;

            Button btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            btnEdit.Click += btnEdit_Click;

            Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnDelete.Click += btnDelete_Click;


            Button btnList = FindViewById<Button>(Resource.Id.btnList);
            btnList.Click += btnList_Click;
        }

        private void Createdatabase()
        {
            db = new Database();
            db.createDatabase();
        }

    
        private void button1_Click(object sender, EventArgs e)
        {
            TextView name = FindViewById<TextView>(Resource.Id.name2);
            TextView id = FindViewById<TextView>(Resource.Id.id);
            TextView erreur = FindViewById<TextView>(Resource.Id.erreur);

            TextView adresse = FindViewById<TextView>(Resource.Id.adresse2);
            TextView ville = FindViewById<TextView>(Resource.Id.ville2);
            TextView codepostal = FindViewById<TextView>(Resource.Id.codepostal2);
            TextView lat = FindViewById<TextView>(Resource.Id.lat2);
            TextView lng = FindViewById<TextView>(Resource.Id.lng2);
            TextView tarif = FindViewById<TextView>(Resource.Id.tarif2);
            Bornes borne = new Bornes()
            {
                name = name.Text,
                id = int.Parse(id.Text),
                adresse = adresse.Text,
                ville = ville.Text,
                codepostal = codepostal.Text,
                tarif = tarif.Text,
                latitude = lat.Text,
                longitude = lng.Text

            };
            db.insertIntoTable(borne);
            erreur.Text=("Ajouter !");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TextView name = FindViewById<TextView>(Resource.Id.name2);
            TextView id = FindViewById<TextView>(Resource.Id.id);
            TextView erreur = FindViewById<TextView>(Resource.Id.erreur);

            TextView adresse = FindViewById<TextView>(Resource.Id.adresse2);
            TextView ville = FindViewById<TextView>(Resource.Id.ville2);
            TextView codepostal = FindViewById<TextView>(Resource.Id.codepostal2);
            TextView lat = FindViewById<TextView>(Resource.Id.lat2);
            TextView lng = FindViewById<TextView>(Resource.Id.lng2);
            TextView tarif = FindViewById<TextView>(Resource.Id.tarif2);
            Bornes borne = new Bornes()
            {
                name = name.Text,
                id = int.Parse(id.Text),
                adresse = adresse.Text,
                ville = ville.Text,
                codepostal = codepostal.Text,
                tarif = tarif.Text,
                latitude = lat.Text,
                longitude = lng.Text
            };
            db.updateTable(borne);
            erreur.Text = ("Modifier !");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TextView name = FindViewById<TextView>(Resource.Id.name2);
            TextView id = FindViewById<TextView>(Resource.Id.id);
            TextView erreur = FindViewById<TextView>(Resource.Id.erreur);

            TextView adresse = FindViewById<TextView>(Resource.Id.adresse2);
            TextView ville = FindViewById<TextView>(Resource.Id.ville2);
            TextView codepostal = FindViewById<TextView>(Resource.Id.codepostal2);
            TextView lat = FindViewById<TextView>(Resource.Id.lat2);
            TextView lng = FindViewById<TextView>(Resource.Id.lng2);
            TextView tarif = FindViewById<TextView>(Resource.Id.tarif2);
            Bornes borne = new Bornes()
            {
                name = name.Text,
                id = int.Parse(id.Text),
                adresse = adresse.Text,
                ville = ville.Text,
                codepostal = codepostal.Text,
                tarif = tarif.Text,
                latitude = lat.Text,
                longitude = lng.Text
            };
            db.removeTable(borne);
            erreur.Text = ("Supprimer !");

        }
        private void btnList_Click(object sender, EventArgs e)
        {
            ListView Liste = FindViewById<ListView>(Resource.Id.listView);


        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
    }
}