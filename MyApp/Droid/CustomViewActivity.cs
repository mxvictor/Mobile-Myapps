
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
    [Activity(Label = "CustomViewActivity")]
    public class CustomViewActivity : Activity
    {

        DataAccess db = new DataAccess();

        private ListView view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.TableView);


            view = FindViewById<ListView>(Resource.Id.listView1);

            List<Filme> FilmeListas_1 = new List<Filme>();
            FilmeListas_1 = db.FilmesLista();

            view.Adapter = new HomeScreenAdapter(this, FilmeListas_1);

            view.ItemClick += OnListItemClick;

        }


        protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var i = new Intent(this, typeof(DescricaoActivity));
            i.PutExtra("position", e.Position);
            StartActivity(i);
        }


    }
}
