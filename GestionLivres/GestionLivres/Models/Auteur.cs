using System.Data.SqlClient;

namespace GestionLivres.Models
{
    public class Auteur
    {
        public int IDAuteur { get; set; }
        public string NomAuteur { get; set; } = "";
        public string EmailAuteur { get; set; } = "";
        public string telephonAut { get; set; } = "";
        public string AdresseAut { get; set; } = "";

        public List<Auteur> GetAuteurs(string connectionString)
        {
            var liste = new List<Auteur>();
            using var con = new SqlConnection(connectionString);
            con.Open();
            string selectSQL = "select IDAuteur,NomAuteur,EmailAuteur,telephoneAut,AdresseAut from Auteur";
            using var cmd = new SqlCommand(selectSQL, con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                liste.Add(new Auteur
                {
                    IDAuteur = Convert.ToInt32(dr["IDAuteur"]),
                    NomAuteur = dr["NomAuteur"].ToString()!,
                    EmailAuteur = dr["EmailAuteur"].ToString()!,
                    telephonAut = dr["telephoneAut"].ToString()!,
                    AdresseAut = dr["AdresseAut"].ToString()!
                });
            }
            return liste;
        }
    }
}