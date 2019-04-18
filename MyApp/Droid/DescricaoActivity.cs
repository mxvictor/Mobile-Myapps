
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyApp.Droid
{
    [Activity(Label = "DescricaoActivity")]
    public class DescricaoActivity : Activity
    {

        public int pos { get; set; }
        public DescricaoActivity()
        {

        }
        DataAccess db = new DataAccess();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Descricao);

            pos = Intent.GetIntExtra("position", -1);

            List<Filme> FilmeListas_1 = new List<Filme>();
            FilmeListas_1 = db.FilmesLista();

            TextView titulo = FindViewById<TextView>(Resource.Id.textViewDescNome);
            TextView sinopse = FindViewById<TextView>(Resource.Id.textViewDescSinopse);
            ImageView icone = FindViewById<ImageView>(Resource.Id.imageViewdesc);

            titulo.Text = FilmeListas_1[pos].Titulo;
            sinopse.Text = FilmeListas_1[pos].Sinopse;
            //icone.SetImageURI(Android.Net.Uri.Parse(FilmeListas_1[pos].Icone));


        }
    }
}
