using System;
using System.Collections.Generic;

namespace GestionPersonneLib
{
    public interface ITelephone
    {
        int Id { get; set; }
        int Id_proprietaire { get; set; }
        string Initial { get; set; }
        string Numero { get; set; }
        string NumeroComplet { get; }
        int Nouveau();
        void Enregistrer(ITelephone telephone);
        void Supprimer(int id);
        List<ITelephone> Telephones();
        ITelephone OneTelephone(int id);
        List<ITelephone> TelephonesPersonnes(int id_personne);
    }
}
