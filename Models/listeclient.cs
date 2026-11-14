using TP2_razor.Models;

public class listeclient
{
    public List<Client> GetListeclients()
    {
        List<Client> liste = new List<Client>()
            {
                new Client { nom = "idrissi",  prenom = "salwa",  telephone = 0554545425, adresse = "idriss@yahoo.com" },
                new Client { nom = "semmar",   prenom = "amal",   telephone = 0657894432, adresse = "semmar@gmail.ma" },
                new Client { nom = "safi",     prenom = "adil",   telephone = 0765453421, adresse = "safi1@hotmail.com" },
                new Client { nom = "benkirane",prenom = "mehdi",  telephone = 0546789654, adresse = "benkirane123@yahoo.com" }
            };
        return liste;
    }

}
 