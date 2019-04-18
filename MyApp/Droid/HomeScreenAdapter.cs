using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.App;
namespace MyApp.Droid
{
    public class HomeScreenAdapter : BaseAdapter<Filme>
    {
        List<Filme> filmes;
        Activity context;
    
    
        public HomeScreenAdapter(Activity context, List<Filme> filmes):base()
        {
            this.context = context;
            this.filmes = filmes;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Filme this[int position]
        {
            get { return filmes[position]; }
        }

        public override int Count
        {
            get { return filmes.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var filme = filmes[position];

            View views = convertView;
            if (views == null)
            {
                views = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);
            }

            //Android.Net.Uri uri = Android.Net.Uri.Parse(filme.Icone);
            views.FindViewById<TextView>(Resource.Id.Text1).Text = filme.Titulo;
            //views.FindViewById<ImageView>(Resource.Id.Image).SetImageURI(uri);

            return views;
        }
    }
}
