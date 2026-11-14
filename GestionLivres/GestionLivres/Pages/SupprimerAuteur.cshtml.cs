using GestionLivres.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GestionLivres.Pages
{
    public class SupprimerAuteurModel : PageModel
    {
        public IActionResult OnGet() => RedirectToPage("ListeAuteur");

        public IActionResult OnPost()
        {
            try
            {
                int id = Convert.ToInt32(Request.Form["id"]);
                using SqlConnection con = new SqlConnection(Db.ConnectionString);
                string req = "delete from Auteur where IDAuteur = @id";
                using SqlCommand cmd = new SqlCommand(req, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                // Ex : l'auteur est référencé par un Livre (clé étrangère)
                Console.WriteLine("Exception " + ex.ToString());
            }
            return RedirectToPage("ListeAuteur");
        }
    }
}