using Android.App;
using Android.Views;
using Android.Widget;
using BornesElec;
using Java.Lang;
using System.Collections.Generic;
using System.Linq;

namespace Borneselec
{

    public class ListViewAdapter : BaseAdapter
    {
        private readonly Activity context;
        private readonly List<Bornes> bornes;

        public ListViewAdapter(Activity _context, List<Bornes> _bornes)
        {
            this.context = _context;
            this.bornes = _bornes;
        }

        public override int Count
        {
            get
            {
                return bornes.Count;
            }
        }

        public override Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return bornes[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.ListViewLayout, parent, false);

            var txtView_Adresse = view.FindViewById<TextView>(Resource.Id.txtView_Adresse);
            var txtView_Ville = view.FindViewById<TextView>(Resource.Id.txtView_Ville);
            var txtView_Codepostal = view.FindViewById<TextView>(Resource.Id.txtView_Codepostal);
            var txtView_Tarif= view.FindViewById<TextView>(Resource.Id.txtView_Tarif);
            var txtView_Lat = view.FindViewById<TextView>(Resource.Id.txtView_Lat);
            var txtView_Lng = view.FindViewById<TextView>(Resource.Id.txtView_Lng);
            var txtView_Id = view.FindViewById<TextView>(Resource.Id.txtView_Id);


            return view;
        }


    }
}
