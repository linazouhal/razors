using GestionLivres.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivres.Pages
{
    public class NouveauAuteurModel : PageModel
    {
        public void OnGet() { }

        public IActionResult OnPost()
        {
            Auteur Aut = new Auteur();
            Aut.NomAuteur = Request.Form["NomAuteur"];
            Aut.EmailAuteur = Request.Form["EmailAuteur"];
            Aut.telephonAut = Request.Form["telephoneAut"];
            Aut.AdresseAut = Request.Form["AdresseAut"];

            using SqlConnection con = new SqlConnection(Db.ConnectionString);

            string req = "insert into Auteur (NomAuteur,EmailAuteur,telephoneAut,AdresseAut) " +
                         "values (@NomAuteur,@EmailAuteur,@telephoneAut,@AdresseAut)";
            using SqlCommand cmd = new SqlCommand(req, con);
            cmd.Parameters.AddWithValue("@NomAuteur", Aut.NomAuteur);
            cmd.Parameters.AddWithValue("@EmailAuteur", Aut.EmailAuteur);
            cmd.Parameters.AddWithValue("@telephoneAut", Aut.telephonAut);
            cmd.Parameters.AddWithValue("@AdresseAut", Aut.AdresseAut);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return RedirectToPage("ListeAuteur");   // retour à la liste
        }
    }
}