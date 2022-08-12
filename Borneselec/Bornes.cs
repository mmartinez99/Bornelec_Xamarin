using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BornesElec
{
    public class Bornes
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string adresse { get; set; }
        public string ville { get; set; }
        public string codepostal { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string tarif { get; set; }

    }
}