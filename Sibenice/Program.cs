///Hra šibenice (Hangman)
///Jakub Bednář
/// 24.10.2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Sibenice
{
    class Program
    {
        /// <summary>
        /// Hlavní třída (v ní běží program)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //do stisknuto se načíta zmačknutí vstup z klavesnice
            char stisknuto;

            //vypis uvitacího okna
            Console.WriteLine("    ************************    ");
            Console.WriteLine("    *       HANGMAN!       *    ");
            Console.WriteLine("    ************************    ");

            //navod k pouzití
            Console.WriteLine("Mačkejte znaky latinky a třeba to víde :-)");
            Console.WriteLine(" ");

                

                //kontrola zda je jíž slovo kompletně uhodnuto
                bool korekt = false;
                //hádané slovo
                string slovo;
                //List zmačknutích znaku
                List<char> uzZmacknuto = new List<char>();

                //pole se slovi rozdelené do levlu
                string[,] slova = new string[3, 4] {
                                                        { "m,o,d,r,a", "b,i,l,a", "z,e,l,e,n,a", "c,e,r,n,a" },
                                                        { "s,c,v,r,n,k", "r,o,d,o,d,e,n,d,r,o,n", "p,o,p,o,k,a,t,e,p,e,t,l", "d,a,l,a,j,l,a,m,a" },
                                                        { "l,e,o,p,a,r,d", "g,e,k,o,n", "k,a,l,a,f,u,n,a", "n,e,j,k,u,l,a,t,o,u,l,i,n,k,a,t,e,j,s,i" }
                                                   };


                //jeden ciklus jeden levl
                for (int levl = 0; levl < 3; levl++)
                {
                    //nastaví kurzor na vychozí pozicy
                    Console.SetCursorPosition(17, 5);

                    //vygeneruje nahodne číslo
                    Random rnd = new Random();
                    int poradi = rnd.Next(1, 4);

                    //na zaklade nahodneho čísla vybere slovopro hru
                    slovo = slova[levl, poradi];

                    //obnovení životu
                    int zivoty = 5;
                    //obnovení korekt na vychozí false
                    korekt = false;
                    //vyčistí zmačknuté znaky
                    uzZmacknuto.Clear();

                    //smička pro uhodnutí slova
                    do
                    {
                        //když dojdou životy -> prohra
                        if (zivoty <= 0)
                        {
                            //vypis hlašky prohra na třetí řadek 3
                            Console.SetCursorPosition(0, 3);

                            Console.WriteLine("PROHRA :-(   PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(");
                            Console.WriteLine("PROHRA :-(   PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(");
                            Console.WriteLine("PROHRA :-(   PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(");
                            Console.WriteLine("PROHRA :-(   PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(");
                            Console.WriteLine("PROHRA :-(   PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(  PROHRA :-(");
                            Console.ReadKey();
                        }
                        //když má hráč ješte životy
                        else
                        {
                            //přenastaví korekt na true (když tak zustane tak bylo slovo uhadnuto)
                            korekt = true;
                            //načtení vstupu z klavesnice do stiskuto
                            try
                            {
                                ConsoleKeyInfo vst = Console.ReadKey();
                                stisknuto = Char.ToLower(vst.KeyChar);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("PROBLEM :-(");
                                throw;
                            }

                            //když znak ješte není obsažen v poly
                            if (uzZmacknuto.Contains(stisknuto) == false)
                            {
                                //zapsaní stisknuteho do pole uzZmacknuto
                                uzZmacknuto.Add(stisknuto);
                            }
                            //jiinak uber živt
                            else
                            {
                                zivoty--;
                            }

                            //rozdelí vybrané slovo na pismena pomocí parse
                            string[] parse = slovo.Split(',');//rozdelení

                            //smazaní posledniho řadku
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            
                            //vypis hlašky "Tohle zatim maš"
                            Console.Write("Tohle zatim mas: ");

                            
                            foreach (string pismena in parse)
                            {
                                //převod string pismena na char ->charpismena
                                char charpismena = Convert.ToChar(pismena);

                                //porovnaní pole stisknutích znaku se znaky obsaženimy ve slove
                                if (uzZmacknuto.Contains(charpismena) == true)
                                {
                                    //vypiše pismeno
                                    Console.Write(pismena);
                                }
                                else
                                {
                                    //vypiše pomlčku
                                    Console.Write("-");
                                    //přepnutím korekt na false se bude smička se slovem opakovat jelikož není vše uhodnuto
                                    korekt = false;
                                }
                            }
                            //vypis info pro hrače
                            Console.Write("         ");
                            Console.SetCursorPosition(0, 5);
                            Console.Write("Ted jsi dal:     ");
                            Console.SetCursorPosition(0, 6);
                            Console.Write("Levl:            ");
                            Console.Write(levl);
                            Console.SetCursorPosition(0, 7);
                            Console.Write("Zivoty:          ");
                            Console.Write(zivoty);
                            Console.SetCursorPosition(17, 5); 
                        }
                        //konec smičky pro hádání
                        } while (korekt == false); 
                }
            
            // vypis vyhra
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("   \\         /     \\     /    |            |     |¨\\           /\\           ");
            Console.WriteLine("    \\       /       \\   /     |            |     |  \\         /  \\          ");
            Console.WriteLine("     \\     /         \\ /      |———---------|     | ./        /    \\         ");
            Console.WriteLine("      \\  /            \\       |            |     |\\         /-——---\\        ");
            Console.WriteLine("       \\/              \\      |            |     | \\       /        \\       ");

            Console.ReadKey();


        }

            

                
            


        
    }
}
