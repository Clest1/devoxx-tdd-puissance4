using System;

namespace Puissance4.Core
{
    /// <summary>
    /// Moteur pour le jeu puissance 4.
    /// </summary>
    public interface IPuissance4
    {
        /// <summary>
        ///	Retourne l'état dans lequel est le jeu : EN_COURS, ROUGE_GAGNE, JAUNE_GAGNE, MATCH_NUL
        /// </summary>     
        EtatJeu EtatJeu { get; }

        /// <summary>
        /// Retourne le joueur dont c'est le tour : 'R' pour rouge, 'J' pour jaune.
        /// </summary>
        char Tour { get; }

        /// <summary>
        /// Vide la grille de jeu, et tire au sort le joeur qui commence.
        /// </summary>
        void NouveauJeu();

        /// <summary>
        /// Charge une partie en cours.
        /// </summary>
        /// <param name="grille">
        /// une grille de puissance 4 (6 lignes x 7 colonnes)
        /// *  Une case vide est représentée par le caractère '-',
        /// *  Une case occupée par un jeton rouge, par le caractère 'R'
        /// *  Une case occupée par un jeton jaune, par le caractère 'J'.
        /// </param>
        /// <param name="tour">le joueur dont c'est le tour (J ou R)</param>
        /// <exception cref="ArgumentOutOfRangeException">si la grille est invalide, ou si tour ne vaut ni J ni R.</exception>
        void ChargerJeu(char[][] grille, char tour);

        /// <summary>
        /// Retourne la couleur - R(ouge) ou J(aune) - du jeton occupant la case
        /// aux coordonnées saisies en paramètre(si vide, '-')
        /// </summary>
        /// <param name="ligne">de 0 à 5</param>
        /// <param name="colonne">de 0 à 6</param>
        /// <exception cref="ArgumentOutOfRangeException">si les coordonnées sont invalides.</exception>
        char GetOccupant(int ligne, int colonne);

        /// <summary>
        /// Un "coup" de puissance 4.
        /// </summary>
        /// <param name="colonne">numéro de colonne où le joueur courant fait glisser son jeton (compris entre 0 et 6)</param>
        /// <exception cref="InvalidOperationException">si le jeu est déjà fini, où si la colonne est pleine</exception>
        /// <exception cref="ArgumentOutOfRangeException">si l'entier en paramètre est > 6 ou < 0.</exception>
        void Jouer(int colonne);
    }
}
