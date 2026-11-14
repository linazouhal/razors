using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TP2_razor.Models;

namespace TP2_razor.Pages
{
    public class Index1Model : PageModel
    {
        public string information { get; set; } = "";

        public void OnGet()
        {
        }

      
        public void OnPost(Client c)
        {
            this.information = string.Format("Les informations saisies sont : {0} , {1} , {2} , {3}",
                c.nom, c.prenom, c.telephone, c.adresse);
        }
    }
}
