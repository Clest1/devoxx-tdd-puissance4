using Puissance4.Core;
using System;

namespace Puissance4.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IPuissance4 jeu = null; // Remplacer par new Puissance4() une fois la classe crée
            Bienvenue();

            while (jeu.EtatJeu == EtatJeu.EN_COURS)
            {
                AfficheGrille(jeu);
                Console.WriteLine();
                AfficheInvite(jeu);

                try
                {
                    int col = int.Parse(Console.ReadLine());
                    jeu.Jouer(col);
                }
                catch (FormatException e)
                {
                    Console.Error.WriteLine("Erreur, veuillez entrer un entier");
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Erreur - " + e.Message);
                }
            }
            AfficherResultat(jeu);
        }

        private static void AfficherResultat(IPuissance4 jeu)
        {
            EtatJeu etat = jeu.EtatJeu;
            if (etat == EtatJeu.MATCH_NUL)
            {
                Console.WriteLine("Match nul !");
                return;
            }
            if (etat == EtatJeu.JAUNE_GAGNE)
            {
                Console.WriteLine("Jaune a gagné !");
                return;
            }
            if (etat == EtatJeu.ROUGE_GAGNE)
            {
                Console.WriteLine("Rouge a gagné !");
                return;
            }
        }

        private static void AfficheInvite(IPuissance4 jeu)
        {
            Console.WriteLine("A votre tour, " + jeu.Tour + " entrez le numéro de colonne où vous voulez jouer : ");
        }

        private static void AfficheGrille(IPuissance4 jeu)
        {
            Console.WriteLine("0123456");
            for (int ligne = 0; ligne < 6; ligne++)
            {
                for (int colonne = 0; colonne < 7; colonne++)
                {
                    Console.Write(jeu.GetOccupant(ligne, colonne));
                }
                Console.WriteLine();
            }
        }

        private static void Bienvenue()
        {
            string msg = "*****************************\n"
                        + "* Bienvenue sur Puissance 4 *\n"
                        + "*****************************";

            Console.WriteLine(msg);
        }
    }
}
