using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BornesElec
{
    public class BorneApi
    {
        public string datasetid { get; set; }
        public string recordid { get; set; }
        public Fields fields { get; set; }
        public Geometry geometry { get; set; }
        public DateTime record_timestamp { get; set; }

        public class Fields
        {
            public string adresse_station { get; set; }
            public string arrondissement { get; set; }
            public string url_description_pdc { get; set; }
            public int code_insee_commune { get; set; }
            public List<double> coordonneesxy { get; set; }
            public DateTime last_updated { get; set; }
            public string statut_pdc { get; set; }
            public string id_pdc { get; set; }
           
        }

        public class Geometry
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
        }

    }
}