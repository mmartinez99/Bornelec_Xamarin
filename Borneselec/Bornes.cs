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
    public class Bornes
    {
        public string name { get; set; }
        public string adresse { get; set; }
        public string ville { get; set; }
        public int codepostal { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float tarif { get; set; }

    }
}