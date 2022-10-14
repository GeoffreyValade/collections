using System;
using System.Diagnostics;
using System.Collections;



//LES TABLEAUX

// Les + : Stable

// Les - : Valeurs prédéfinies à l'avance. Ajouts impossibles lors de l'exécution.



//LES LISTES

// Les + : Ajouts possibles à l'infini

// Les - : Les recherches sont + lentes sur les grosses bases de données



//LES DICTIONNAIRES

// Les + : Recherches + rapides car elles ciblent directement les clés/valeurs

// Les - : ???



namespace programme_collections
{
    class Program
    {


        // LES TABLEAUX :

        static int SommeTableau(int[] t)
        {

            int somme = 0;

            for (int i = 0; i < t.Length; i++)
            {
                somme += t[i];
            }

            return somme;

        }


        static void AfficherTableau(int[] tableau)
        {

            for (int i = 0; i < tableau.Length; i++)
            {
               Console.WriteLine ("[" + i + "] " + tableau[i]);
            }

        }


        static void AfficherValeurMaximale(int[] t)
        {
            int max = t[0];
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] > max)
                {
                    max = t[i];
                }
            }
            Console.WriteLine("La valeur maximale est : " + max);
        }

        static void Tableaux()
        {
            //int[] t = { 200, 40, 15, 8, 12 };
            const int TAILLE_TABLEAU = 20;

            // LES TABLEAUX :
            // Pour créer un tableau, on écrit : int[] t = | Comme ci-dessous
            int[] t = new int[TAILLE_TABLEAU];
            // Les crochets après le "int" permettent d'indiquer qu'il s'agit d'un tableau.
            // Le "t" est le nom de notre tableau. On indique donc un int, puis que c'est un tableau, puis qu'on le nomme "t"
            // La deuxième partie : "= new int[x]" sert à indiquer la taille de notre tableau. En effet, un tableau est toujours d'une taille prédéfinie et fixe (constante).

            Random r = new Random();
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = r.Next(100);
            }

            // int[] t
            // Initialiser chaque élément valeur aléatoire entre 0 et 100
            
            AfficherTableau(t);
            AfficherValeurMaximale(t);

        }











        // LES LISTES :

        static void AfficherListe(List<string> liste, bool ordreDescendant = false)
        {

            for (int i = liste.Count-1; i >= 0; i--)
            {
                Console.WriteLine(liste[i]);

            }


            // "Le nom le plus long est : "
            string nomLePlusLong = "";
            for (int i = 0; i < liste.Count; i++)
            {
                if (liste[i].Length > nomLePlusLong.Length)
                {
                    nomLePlusLong = liste[i];
                }
            }

            Console.WriteLine("Le nom le plus long est : " + nomLePlusLong);

        }

        static void Listes ()
        {
            List<int> liste = new List<int>();

            //liste.Add(5);
            //liste.Add(8);
            //liste.Add(2);

            List<string> noms = new List<string>();
            while (true)
            {
                Console.Write("Rentrez un nom (ENTER pour finir) : ");
                string nom = Console.ReadLine();

                if (nom == "")
                {
                    break;
                }

                if (noms.Contains(nom))
                {
                    Console.WriteLine("Erreur : ce nom est déjà dans la liste.");
                    Console.WriteLine();
                }
                else
                {
                    noms.Add(nom);
                }
            }


            for (int i = noms.Count - 1; i >= 0; i--)
            {
                string nom = noms[i];
                if (nom[nom.Length-1] == 'e')
                {
                    noms.RemoveAt(i);
                }


                // POURQUOI ON UTILISE UNE BOUCLE QUI DECREMENTE LORSQUE L'ON RETIRE DES ELEMENTS DE LISTE VIA UNE BOUCLE .REMOVEAT

                // Dans le cas de : for (int i = 0 ; i < noms.count; i++)
                // 0        1       2
                // Paul   Emilie  Sophie

                // Count = 0
                // Paul ne finit pas par "e", on le garde

                // Count = 1
                // Emilie finit par e, donc Remove ci-dessous

                // Count = 2
                // Comme Emilie (en position 1) a été retiré, Sophie est passé de la position 2 à 1
                // Or, i (le Count) est égal à 2, comme ci-dessous.
                // La position 2 est donc vide.

                // 0        1       2
                // Paul   Sophie  /////

                // On préfère donc utiliser : (int i = noms.count-1 ; i >= 0; i--)
            }


            //List<string> LesPremiersNoms = noms.GetRange(0, 3);
            //AfficherListe(LesPremiersNoms); //Cette fonction-là ne va afficher que les 3 premiers noms
            AfficherListe(noms); //Cette fonction-là va afficher tous les noms

        }


        static void ListesDeListes()
        {
            // Rogue : Finesse, Assassinat, Combat
            // Mage : Feu, Givre, Arcane
            // Druide : Restauration, Farouche, Equilibre, Gardien
            // Demoniste : Affliction, Destruction, Demonologie
            // Pretre : Ombre, Sacre, Discipline


            var classes = new List<List<string>>();

            classes.Add(new List<string> { "Rogue", "Finesse", "Assassinat", "Combat" });
            classes.Add(new List<string> { "Mage", "Feu", "Givre", "Arcane" });
            classes.Add(new List<string> { "Druide", "Restauration", "Farouche", "Equilibre", "Gardien" });
            classes.Add(new List<string> { "Demoniste", "Affliction", "Destruction", "Demonologie" });
            classes.Add(new List<string> { "Pretre", "Ombre", "Sacre", "Discipline" });



            for (int i = 0; i < classes.Count; i++)
            {

              var c = classes[i];
              Console.WriteLine(c[0] + " - " + (c.Count - 1) + " spés.");

              for (int j = 1; j < c.Count; j++)
              {
                  Console.WriteLine("  " + c[j]);
              }
            }
        }









        // LES DICTIONNAIRES :

        static void Dictionnaire()
        {
            //clé => Valeur
            //Exemple : Nom => Numéro de téléphone

            var d = new Dictionary<string, string>();
            //Pour ajouter de nouvelles données dans le dictionnaire :
            //1ère syntaxe : d.Add("Clé", "Valeur");
            d.Add("Jean", "06 11 11 11 11");
            d.Add("Joël", "06 22 22 22 22");

            //2ème syntaxe : d["Clé"] = "Valeur";
            d["Martin"] = "06 33 33 33 33";
            d["Saucisse"] = "06 44 44 44 44";



            //Lors d'une recherche dans le dictionnaire, on peut utiliser :
            string personneAChercher = "Martin";

            //Puis ajouter du code pour afficher le résultat de la recherche :
            if (d.ContainsKey(personneAChercher))
            {
                Console.WriteLine(d[personneAChercher]);
            }
            
            //Puis on ajoute une ligne pour gérer l'exception :
            else
            {
                Console.WriteLine("Cette personne n'a pas été trouvée");
            }

        }
    











        // LES BOUCLES FOREACH

        static void BoucleForEach()
        {
            //Avec un tableau :
            var nomsTableau = new string[] { "Toto", "Jean", "Pierre" };

            //Avec une liste : 
            var nomsListe = new List<string>() { "Toto", "Jean", "Pierre" };

            //Avec un dictionnaire :
            var d = new Dictionary<string, string>();
            d.Add("Jean", "06 11 11 11 11");
            d.Add("Joël", "06 22 22 22 22");


            //Plutôt que d'utiliser cette boucle for ... :
            /*for (int i = 0; i < noms.Length; i++)
            {
                Console.WriteLine(noms[i]);
            }*/

            // ... On peut utiliser une boucle foreach :

            //Pour une LISTE ou un TABLEAU :
            //foreach (var e in NomDuTableau/Liste)
            foreach (var nom in nomsListe) //ou (var nom in nomsTableau)
            {
                //On réutilise ici le "var nom" pour afficher les éléments du tableau
                Console.WriteLine(nom);
            }

            // Pour un DICTIONNAIRE :
            //foreach (var e in NomDuDictionnaire)
            foreach (var e in d)
            {
                //"e" est suivi de .Key ou .Value en fonction de ce que l'on veut afficher : les clés, ou les valeurs
                Console.WriteLine(e.Key + " -> " + e.Value);
            }

            //NOTES : Parfois, il est nécessaire de connaitre l'index (int i = x), auquel cas la boucle for est préférée plutôt que le foreach

        }












        //LES TRIS

        static void TrisEtLinq()
        {



            //Pour les listes :
            var nomsListe = new List<string>() { "Toto", "Jean", "Pierre", "Emilie", "Sophie", "Martin", "Benoit", "Vincent" };

            //Tri par ordre alphabétique:
            //NomDeLaListe.Sort();
            nomsListe.Sort();


            //Boucle foreach afin d'afficher toutes les valeurs triées :
            foreach (var nom in nomsListe)
            {
                Console.WriteLine(nom);
            }


            //Pour effectuer un tri plus complexe :

            //Ordre alphabétique :
            //var nomsListeTriés = nomsListe.OrderBy(nom => nom);

            //Ordre anti-alphabétique :
            //var nomsListeTriés = nomsListe.OrderByDescending(nom => nom);

            //Ordre croissant nombre de caractères :
            //var nomsListeTriés = nomsListe.OrderBy(nom => nom.Length);

            //Tri en fonction du dernier caractère :
            //var nomsListeTriés = nomsListe.OrderBy(nom => nom[nom.Length-1]);


            //Dans la boucle foreach, on inclut donc bien la variable précédente "nomsListeTriés"
            foreach (var nom in nomsListeTriés)
            {
                Console.WriteLine(nom);
            }




            //Pour les tableaux :
            var nomsTableau = new string[] { "Toto", "Jean", "Pierre" };

            //Tri par ordre alphabétique :
            //Array.Sort(nomsDuTableau);
            Array.Sort(nomsTableau);

            //Boucle foreach afin d'afficher toutes les valeurs triées :
            foreach (var nom in nomsTableau)
            {
                Console.WriteLine(nom);
            }


            //Pour effectuer un tri plus complexe :
            //Ordre alphabétique :
            //var nomsTableauTriés = nomsTableau.OrderBy(nom => nom);

            //Ordre anti-alphabétique :
            //var nomsTableauTriés = nomsTableau.OrderByDescending(nom => nom);

            //Ordre croissant nombre de caractères :
            //var nomsTableauTriés = nomsTableau.OrderBy(nom => nom.Length);

            //Tri en fonction du dernier caractère :
            //var nomsTableauTriés = nomsTableau.OrderBy(nom => nom[nom.Length-1]);


            //Dans la boucle foreach, on inclut donc bien la variable précédente "nomsTableauTriés"
            foreach (var nom in nomsTableauTriés)
            {
                Console.WriteLine(nom);
            }
        }







        // EXECUTION :

    static void Main(string[]   args)
        {
            //Tableaux();
            //Listes();
            //ListesDeListes();
            TrisEtLinq();

        }


    }

}


/*int[] t = new int[3];
t[0] = 2;
t[1] = 4;
t[2] = 6;*/