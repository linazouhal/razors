using GestionLivres.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionLivres.Pages
{
    public class ListeAuteurModel : PageModel
    {
        public List<Auteur> Auteurs = new List<Auteur>();

        public void OnGet()
        {
            Auteurs = new Auteur().GetAuteurs(Db.ConnectionString);
        }
    }
}