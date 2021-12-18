using System;
using System.IO;
using System.Collections;

namespace CryptoSoft
{
    class Program
    {
        static int Main(string[] args)
        {
            int Taille_Argument = args.Length;
            string source = args[0];
            string destination = args[1];
            DateTime Debut_Temps_Fichier = DateTime.Now;


            for (int i = 0; i < Taille_Argument; i++)
            {
                if (args[i] == "source" && i + 1 < Taille_Argument)
                {
                    source = args[i + 1];
                    i++;
                }
                else if (args[i] == "destination" && i + 1 < Taille_Argument)
                {
                    destination = args[i + 1];
                    i++;
                }
            }

            try
            {
                //Déclaration du tableau d'octets à crypter
                byte[] Octet_A_Crypter = File.ReadAllBytes(source);
                BitArray Bit_A_Crypter = new BitArray(Octet_A_Crypter);

                //Déclaration du tableau de clé cryptage
                byte[] Cle_En_Octet = new byte[8] { 7, 26, 106, 14, 143, 254, 112, 32 };
                BitArray Cle_Par_Bit = new BitArray(Cle_En_Octet);

                //Déclaration du tableau d'octets cryptés
                byte[] Octet_Crypte = new byte[Octet_A_Crypter.Length];
                BitArray Bit_Crypte = new BitArray(Bit_A_Crypter.Length);
                int j = 0;

                for (int i = 0; i < Bit_A_Crypter.Length; i++)
                {
                    j = i % Cle_En_Octet.Length;
                    Bit_Crypte[i] = Bit_A_Crypter[i] ^ Cle_Par_Bit[j];
                }

                Bit_Crypte.CopyTo(Octet_Crypte, 0);

                File.WriteAllBytes(destination, Octet_Crypte);
                TimeSpan Temps_De_Cryptage = DateTime.Now - Debut_Temps_Fichier;
                return (int)Temps_De_Cryptage.TotalMilliseconds;
            }
            catch
            {
                Console.WriteLine("Le fichier ne peut etre crypte");
                return -1;
            }
        }
    }
}