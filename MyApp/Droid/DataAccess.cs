using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
namespace MyApp.Droid
{

    [Table("Filmes")]
    public class Filme
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Titulo { get; set; }

        public string Icone { get; set; }

        [MaxLength(1000)]
        public string Sinopse { get; set; }
    }

    public class DataAccess
    {
        public SQLiteConnection db;
        public List<Filme> FilmesListas { get; set; }

        public DataAccess()
        {
            db = null;
        }

        public void ConnectData()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AppFilmes.db3");

            if (db == null)
            {
                db = new SQLiteConnection(dbPath);
                db.CreateTable<Filme>();
            }

        }

        public void Cadastrar(List<Filme> FilmeListas)
        {
            db.InsertAll(FilmeListas);
        }

        public List<Filme> FilmesLista()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AppFilmes.db3");
            if (db == null)
            {
                db = new SQLiteConnection(dbPath);
            }

            return db.Query<Filme>("SELECT * FROM [Filmes]") as List<Filme>;
        }
    }
}
