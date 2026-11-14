using Microsoft.AspNetCore.Mvc;

namespace TP2_razor.Models
{
    public class Client
    {
        [BindProperty]
        public string nom { get; set; } = "";

        [BindProperty]
        public string prenom { get; set; } = "";

        [BindProperty]
        public int telephone { get; set; }

        [BindProperty]
        public string adresse { get; set; } = "";
    }
}
