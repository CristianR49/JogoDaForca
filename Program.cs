
namespace JogoDaForca
{
    class Program
    {
        static string[] palavras = new string[29] {"ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJÁ",
             "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA",
             "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"};
        static string desenhoDaForca = "_____________\n|/           |\n|            |\n|            \n|            \n|            \n|\n|\n|\n|____\n";
        static Random numeroAleatorio;
        static int chances;
        static string palavraAleatoria;
        static string[] letrasMisteriosas;
        static string letrasErradas;
        static int acertos;
        static bool acerto;
        static bool venceu;
        static string chute;
        static int i;
        static void Main(string[] args)
        {

            ResetarAsVariaveis();

            while (true)
            {
                Console.Clear();

                MostrarLobbyDoJogo();

                if (venceu == true || chances == 0)
                {
                    Console.ReadLine();
                    ResetarAsVariaveis();
                    continue;
                }

                InputarChute();

                ProcessarAcertosEVitoriaOuErrosEDerrota();

            }
            #region
            //comparar cada linha do array da palavra misteriosa com o valor do chute: for, palavra[]
            //se for igual, substitui na posição certa a letra da palavra, no array de string da palavra misteriosa definido como _____
            #endregion
        }
        private static void MostrarLobbyDoJogo()
        {
            Console.WriteLine("------------------Jogo da forca: Frutas------------------");
            Console.WriteLine(desenhoDaForca);
            for (i = 0; i < letrasMisteriosas.Length; i++)
            {
                Console.Write(letrasMisteriosas[i]);
            }
            Console.WriteLine($"\n\nLetras Erradas:{letrasErradas}");
        }
        private static void ResetarAsVariaveis()
        {
            numeroAleatorio = new Random();
            palavraAleatoria = palavras[numeroAleatorio.Next(0, 28)];
            letrasMisteriosas = new string[palavraAleatoria.Length];
            for (i = 0; i < letrasMisteriosas.Length; i++)
            {
                letrasMisteriosas[i] = "_";
            }
            letrasErradas = "";
            desenhoDaForca = "_____________\n|/           |\n|            |\n|            \n|            \n|            \n|\n|\n|\n|____\n";
            chances = 5;
            venceu = false;
            acertos = 0;
        }

        private static void InputarChute()
        {
            Console.WriteLine("\nDe seu chute: ");
            chute = Console.ReadLine().ToUpper();
        }
        private static void ProcessarAcertosEVitoriaOuErrosEDerrota()
        {
            acerto = false;
            for (i = 0; i < palavraAleatoria.Length; i++)
            {
                if (chute == Convert.ToString(palavraAleatoria[i]) && letrasMisteriosas[i] == "_")
                {
                    AcertosEVitoria();
                }
                else if (i == palavraAleatoria.Length - 1 && acerto == false)
                {
                    letrasErradas = letrasErradas + " " + chute;
                    DesenharNaForcaOsPontosPerdidosEDerrota();
                }
            }
        }
        private static void AcertosEVitoria()
        {
            letrasMisteriosas[i] = Convert.ToString(palavraAleatoria[i]);
            acerto = true;
            acertos++;

            if (acertos == palavraAleatoria.Length)
            {
                desenhoDaForca = desenhoDaForca + "\nParabéns, você acertou!!";
                venceu = true;
            }
        }

        static void DesenharNaForcaOsPontosPerdidosEDerrota()
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
                desenhoDaForca = "_____________\n|/           |\n|            |\n|            o\n|           /|\\ \n|            \n|\n|\n|\n|____\n";
            }
            if (chances == 0)
            {
                desenhoDaForca = "_____________\n|/           |\n|            |\n|            o\n|           /|\\ \n|            |\n|\n|    Voce Perdeu!\n|\n|____\n\nPalavra Misteriosa: " + palavraAleatoria;
            }
        }
    }
}
