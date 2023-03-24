
namespace JogoDaForca
{
    class Program
    {
        static string[] palavras = new string[29] {"ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJÁ",
             "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA",
             "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"};
        static string desenhoDaForca = "_____________\n|/           |\n|            |\n|            \n|            \n|            \n|\n|\n|\n|____\n";
        static Random numeroAleatorio;
        static int chances = 5;
        static string palavraAleatoria;
        static string[] letrasAcertadas;
        static string letrasErradas;
        static int acertos = 0;
        static bool venceu;
        static void Main(string[] args)
        {

            ResetDasVariaveis();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("------------------Jogo da forca: Frutas------------------");
                Console.WriteLine(desenhoDaForca);
                for (int i = 0; i < letrasAcertadas.Length; i++)
                {
                    Console.Write(letrasAcertadas[i]);
                }
                Console.WriteLine($"\n\nLetras Erradas:{letrasErradas}");

                if (venceu == true)
                {
                    Console.ReadLine();
                    ResetDasVariaveis();
                    continue;
                }

                if (chances == 0)
                {
                    ResetDasVariaveis();
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine("\n\nDe seu chute: ");
                string chute = Console.ReadLine().ToUpper();

                bool acerto = false;
                for (int i = 0; i < palavraAleatoria.Length; i++)
                {
                    if (chute == Convert.ToString(palavraAleatoria[i]) && letrasAcertadas[i] == "_")
                    {
                        letrasAcertadas[i] = Convert.ToString(palavraAleatoria[i]);
                        acerto = true;
                        acertos++;
                        if (acertos == palavraAleatoria.Length)
                        {
                            desenhoDaForca = desenhoDaForca + "\nParabéns, você acertou!!";
                            venceu = true;
                        }
                    }
                    else if (i == palavraAleatoria.Length - 1 && acerto == false)
                    {
                        letrasErradas = letrasErradas + " " + chute;
                        DesenharNaForcaOsPontosPerdidosEPerder();
                    }

                }

            }

            //comparar cada linha de array com o valor do chute: for, palavra[]
            //se =, substitui no valor pos do array de string definido como _____
        }

        private static void ResetDasVariaveis()
        {
            numeroAleatorio = new Random();
            palavraAleatoria = palavras[numeroAleatorio.Next(0, 28)];
            letrasAcertadas = new string[palavraAleatoria.Length];
            for (int i = 0; i < letrasAcertadas.Length; i++)
            {
                letrasAcertadas[i] = "_";
            }
            letrasErradas = "";
            desenhoDaForca = "_____________\n|/           |\n|            |\n|            \n|            \n|            \n|\n|\n|\n|____\n";
            chances = 5;
            venceu = false;
            acertos = 0;
        }

        static void DesenharNaForcaOsPontosPerdidosEPerder()
        {
            chances--;
            if (chances == 4)
            {
                desenhoDaForca = "_____________\n|/           |\n|            |\n|            o\n|            \n|            \n|\n|\n|\n|____\n";
            }
            if (chances == 3)
            {
                desenhoDaForca = "_____________\n|/           |\n|            |\n|            o\n|            |\n|            \n|\n|\n|\n|____\n";
            }
            if (chances == 2)
            {
                desenhoDaForca = "_____________\n|/           |\n|            |\n|            o\n|           /|\n|            \n|\n|\n|\n|____\n";
            }
            if (chances == 1)
            {
                desenhoDaForca = "_____________\n|/           |\n|            |\n|            o\n|           /|/\n|            \n|\n|\n|\n|____\n";
            }
            if (chances == 0)
            {
                desenhoDaForca = "_____________\n|/           |\n|            |\n|            o\n|           /|/\n|            |\n|\n|    Voce Perdeu!\n|\n|____\n\nPalavra Misteriosa: " + palavraAleatoria;
            }
        }
    }
}
