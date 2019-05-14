using System;
using System.Collections.Generic;

namespace GestionPersonneLib
{
    public interface IPersonne
    {
        int Id { get; set; }
        string Nom { get; set; }
        string Postnom { get; set; }
        string Prenom { get; set; }
        Sexe Sex { get; set; }
        string NomComplet { get; }
        List<ITelephone> TelephonePersonnes { get; }
        int Nouveau();
        void Enregistrer(IPersonne personne);
        void Supprimer(int id);
        List<IPersonne> Personnes();
        IPersonne OnePersonne(int id);
    }
}
