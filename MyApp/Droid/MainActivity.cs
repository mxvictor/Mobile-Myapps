using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;
using System.Collections.Generic;
using System.IO;
using Android.Graphics;

namespace MyApp.Droid
{
    [Activity(Label = "VM Apps", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        public static readonly int PickImageId = 1000;
        private ImageView _imageview;
        public List<Filme> FilmeListas_ { get; set; }
        private EditText textFieldNome;
        private EditText textFieldSinopse;
        private Android.Net.Uri uri;
        private string uriEmString;

        DataAccess db = new DataAccess();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            textFieldNome = FindViewById<EditText>(Resource.Id.TextFieldNome);
            textFieldSinopse = FindViewById<EditText>(Resource.Id.TextFieldSinopse);
            ImageButton buttonPickImage = FindViewById<ImageButton>(Resource.Id.imageButton1);
            Button buttonCadastrar = FindViewById<Button>(Resource.Id.CadastrarButton);
            Button buttonListar = FindViewById<Button>(Resource.Id.ListarButton);
            _imageview = FindViewById<ImageView>(Resource.Id.imageView1);

            db.ConnectData();

            buttonPickImage.Click += ButtonOnClick;

            buttonCadastrar.Click += ButtonCadastrar_Click;

            buttonListar.Click += ButtonListar_Click;
            // Get our button from the layout resource,
            // and attach an event to it

        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Selecione a imagem "), PickImageId);
        }

        void ButtonCadastrar_Click(object sender, EventArgs e)
        {
            FilmeListas_ = new List<Filme>();

            FilmeListas_.Add(new Filme() { Titulo = textFieldNome.Text, Sinopse = textFieldSinopse.Text, Icone = Convert.ToString(uriEmString) });

            db.Cadastrar(FilmeListas_);
        }

        void ButtonListar_Click(object sender, EventArgs e)
        {

            var i = new Intent(this, typeof(CustomViewActivity));
            StartActivity(i);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                 uri = data.Data;
                 uriEmString = Convert.ToString(uri);
                _imageview.SetImageURI(uri);

            }
        }

    }

}

