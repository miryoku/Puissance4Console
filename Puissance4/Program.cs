using System;

namespace Puissance4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int y = 7, x = 6;
            char[,] map = new char[x, y];
            int cologne, nbTour = 0;
            bool flag = true, win;
           
            do
            {
                nbTour = 0;
                win = false;
                PeupleMap(map, x, y);
                AffichageMap(map, x, y);
                while (!win && map.Length != nbTour)
                {
                    cologne = InputCologne(nbTour % 2, map);
                    Played(map, cologne, flag, x, nbTour % 2);
                    Console.Clear();
                    AffichageMap(map, x, y);
                    win = checkWin(map, (char)((nbTour % 2) + 49), x, y);
                    nbTour++;
                    Console.WriteLine("nbTour : " + nbTour + "    " + map.Length);
                }
                if (win)
                {
                    Console.WriteLine("Le gagnant est le joueur " + (((nbTour - 1) % 2) + 1));
                }
                else
                {
                    Console.WriteLine("imposible de gagne ");
                }



            } while (toBeContinue());

            Console.WriteLine("Au Revoir");
        }

        public static bool toBeContinue()
        {
            bool flag = true, retour = true;
            char val;

            while (flag)
            {
                Console.WriteLine("voulais vous continuer? o/n");
                while (!char.TryParse(Console.ReadLine(), out val))
                {
                    Console.WriteLine("voulais vous continuer? o/n");
                }
                Console.WriteLine(val);
                if (val == 'o')
                {
                    retour = true;
                    flag = false;
                }
                else if (val == 'n')
                {
                    retour = false;
                    flag = false;
                }
            }

            Console.Clear ();

            return retour;
        }


        public static bool checkWin(char[,] map, char player, int x, int y)
        {
            int cpt;
            bool flag = false;
            for (int i = 0; i <= x - 1; i++)
            {
                for (int j = 0; j <= y - 1; j++)
                {
                    if (map[i, j] == player)
                    {
                        cpt = 1;
                        if (j + 4 <= y)
                        {
                            for (int k = 1; k < 4; k++)
                            {

                                if (map[i, j + k] == player)
                                {
                                    cpt++;
                                }
                            }
                        }
                        if (cpt != 4)
                        {

                            cpt = 1;
                            if (i + 4 <= x)
                            {
                                for (int k = 1; k < 4; k++)
                                {

                                    if (map[i + k, j] == player)
                                    {
                                        cpt++;
                                    }
                                }

                            }

                        }
                        if (cpt != 4)
                        {
                            cpt = 1;
                            if (i + 4 <= x && j + 4 <= y)
                            {
                                for (int k = 1; k < 4; k++)
                                {

                                    if (map[i + k, j + k] == player)
                                    {
                                        cpt++;
                                    }
                                }

                            }
                            if (cpt != 4)
                            {
                                cpt = 1;
                                if (i + 4 <= x && j - 4 >= -1)
                                {
                                    for (int k = 1; k < 4; k++)
                                    {

                                        if (map[i + k, j - k] == player)
                                        {
                                            cpt++;
                                        }
                                    }
                                }

                            }

                        }

                        if (cpt == 4)
                        {
                            flag = true;
                        }


                    }
                }
            }


            return flag;
        }


        public static void Played(char[,] map, int cologne, bool flag, int x, int player)
        {
            for (int i = 0; i <= x - 1 && flag; i++)
            {
                if (i == x - 1)
                {
                    map[i, cologne - 1] = (char)(49 + player);
                    flag = false;
                }
                else if (map[i + 1, cologne - 1] != '0')
                {
                    map[i, cologne - 1] = (char)(49 + player);
                    flag = false;
                }
            }
        }

        public static int InputCologne(int Player, char[,] map)
        {
            int val;
            bool flag = false;

            do
            {

                Console.WriteLine("Le jouer " + (Player + 1) + " rentre la cologne  : ");


                while (!int.TryParse(Console.ReadLine(), out val))
                {
                    Console.WriteLine("erreur");
                    Console.WriteLine("Rentre la cologne  : ");

                }
                if (!(val <= 7 && val >= 1))
                {
                    Console.WriteLine("Vous l'avez mis a cote");
                }
                else if (map[0, val - 1] != '0')
                {
                    Console.WriteLine("il a plus de palce dans cette cologne");
                }
                else { flag = true; }
            } while (!flag);

            return val;
        }


        public static void PeupleMap(char[,] map, int x, int y)
        {
            for (int i = 0; i <= x - 1; i++)
            {
                for (int j = 0; j <= y - 1; j++)
                {
                    map[i, j] = '0';
                }
            }
        }

        public static void AffichageMap(char[,] map, int x, int y)
        {
            for (int i = 0; i <= x - 1; i++)
            {
                for (int j = 0; j <= y - 1; j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
        }



    }
}
