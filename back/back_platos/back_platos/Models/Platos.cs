using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_platos.Models
{
    public class Platos
    {
        public int id_plato { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set;}
        public string descripcion { get; set;}


        public Platos()
        {

        }

        public Platos(int id, string nom, string cat, string desc)
        {
            id_plato = id;
            nombre = nom;
            categoria = cat;
            descripcion = desc;
        }

        public Platos (string nom, string cat, string desc)
        {
            nombre= nom;
            categoria = cat;
            descripcion = desc;
        }

    }
}