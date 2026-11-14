using GestionLivres.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivres.Pages
{
    public class AfficherAuteurModel : PageModel
    {
        public Auteur Aut = new Auteur();

      
        public void OnGet()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
            using SqlConnection con = new SqlConnection(Db.ConnectionString);
            string selectSQL = "select * from Auteur where IDAuteur = @id";
            using SqlCommand cmd = new SqlCommand(selectSQL, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Aut.IDAuteur = Convert.ToInt32(dr["IDAuteur"]);
                Aut.NomAuteur = dr["NomAuteur"].ToString()!;
                Aut.EmailAuteur = dr["EmailAuteur"].ToString()!;
                Aut.telephonAut = dr["telephoneAut"].ToString()!;
                Aut.AdresseAut = dr["AdresseAut"].ToString()!;
            }
        }

       
        public IActionResult OnPost()
        {
            Auteur a = new Auteur();
            int id = Convert.ToInt32(Request.Form["IDAuteur"]);
            a.NomAuteur = Request.Form["NomAuteur"];
            a.EmailAuteur = Request.Form["EmailAuteur"];
            a.telephonAut = Request.Form["telephoneAut"];
            a.AdresseAut = Request.Form["AdresseAut"];

            using SqlConnection con = new SqlConnection(Db.ConnectionString);
            string req = "update Auteur set NomAuteur=@NomAuteur, EmailAuteur=@EmailAuteur, " +
                         "telephoneAut=@telephoneAut, AdresseAut=@AdresseAut where IDAuteur=@id";
            using SqlCommand cmd = new SqlCommand(req, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@NomAuteur", a.NomAuteur);
            cmd.Parameters.AddWithValue("@EmailAuteur", a.EmailAuteur);
            cmd.Parameters.AddWithValue("@telephoneAut", a.telephonAut);
            cmd.Parameters.AddWithValue("@AdresseAut", a.AdresseAut);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return RedirectToPage("ListeAuteur");
        }
    }
}