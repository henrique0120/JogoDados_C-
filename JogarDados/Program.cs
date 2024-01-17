class program
{
    public static string Jogador1;
    public static string Jogador2;

    public static byte pontosJogador1;
    public static byte pontosJogador2;

    public static byte rodadaAtual;

    static void Main(string[] args)
    {
        Console.Clear();
        configurarJogo();
        iniciarRodadas();
    }

    public static void iniciarRodadas()
    {
        atualizarPlacar();
        if(rodadaAtual == 3)
        {
            finalizarJogo();
            return;
        }

        rodadaAtual++;

        Console.WriteLine($"Jogador {Jogador1}, pressione ENTER para fazer sua jogada...");
        Console.ReadLine();
        byte valorTiradoJogador1 = 1;
        Console.WriteLine($"Valor do dado jogado pelo {Jogador1}: {valorTiradoJogador1}");

        Console.WriteLine($"Jogador {Jogador2}, pressione ENTER para fazer sua jogada...");
        Console.ReadLine();
        byte valorTiradoJogador2 = 1;
        Console.WriteLine($"Valor do dado jogado pelo {Jogador2}: {valorTiradoJogador2}");

        if (valorTiradoJogador1 == valorTiradoJogador2)
        {
            Console.WriteLine($"\n{Jogador1} tirou o número {valorTiradoJogador1} e {Jogador2} o número {valorTiradoJogador2}. Empate!");
            Console.WriteLine("Pressione ENTER para continuar com o jogo...");
            Console.ReadLine();
        }
        else
        {
            string vencedor;

            if (valorTiradoJogador1 > valorTiradoJogador2)
            {
                vencedor = Jogador1;
                pontosJogador1++;
            }
            else
            {
                vencedor = Jogador2;
                pontosJogador2++;
            }

            Console.WriteLine($"\n{Jogador1} tirou o número {valorTiradoJogador1} e {Jogador2} o número {valorTiradoJogador2}. {vencedor} venceu a rodada {rodadaAtual}");
            Console.WriteLine("Pressione ENTER para continuar com o jogo...");
            Console.ReadLine();
        }

        iniciarRodadas();
    }


    public static void configurarJogo()
    {
        criarJogadores();
        atualizarPlacar();

        Console.WriteLine("Jogadores criados!\nPressione qualquer tecla para iniciar jogo.");
        Console.ReadKey();  
    }

    public static void atualizarPlacar()
    {
        Console.Clear();
        Console.WriteLine($"Pontos do jogador {Jogador1}: {pontosJogador1}");
        Console.WriteLine($"Pontos do jogador {Jogador2}: {pontosJogador2}\n");
    }


    public static void criarJogadores()
        {
            Console.WriteLine("Informe o nome do primeiro jogador:");
            Jogador1 = Console.ReadLine();
            pontosJogador1 = 0;
            Console.WriteLine("Informe o nome do segundo jogador:");
            Jogador2 = Console.ReadLine();
            pontosJogador2 = 0;
        }

    public static byte jogarDado()
    {
        Random random = new Random();
        return Convert.ToByte(random.Next(1, 7));
    }

    public static void finalizarJogo()
    {
        atualizarPlacar();

        if (pontosJogador1 == pontosJogador2)
        {
            prorrogacao();
            return;
        }
        else if (pontosJogador1 > pontosJogador2)
        {
            Console.WriteLine("Jogo finalizado!!!");
            Console.WriteLine($"O jogador {Jogador1} venceu com {pontosJogador1} pontos!");
        }
        else
        {
            Console.WriteLine("Jogo finalizado!!!");
            Console.WriteLine($"O jogador {Jogador2} venceu com {pontosJogador2} pontos!");
        }
    }

    public static void prorrogacao() 
    {
        Console.Clear();
        atualizarPlacar();
        //Console.WriteLine("\nEmpate!");
        Console.WriteLine("O primeiro a pontuar, vence!\n");

        Console.WriteLine($"Jogador {Jogador1}, pressione ENTER para fazer sua jogada...");
        Console.ReadLine();
        byte valorTiradoJogador1 = jogarDado();
        Console.WriteLine($"Valor do dado jogado pelo {Jogador1}: {valorTiradoJogador1}");

        Console.WriteLine($"Jogador {Jogador2}, pressione ENTER para fazer sua jogada...");
        Console.ReadLine();
        byte valorTiradoJogador2 = jogarDado();
        Console.WriteLine($"Valor do dado jogado pelo {Jogador2}: {valorTiradoJogador2}");
        Console.WriteLine("Pressione ENTER para continuar.\n");
        Console.ReadKey();


        if (valorTiradoJogador1 == valorTiradoJogador2)
        {
            prorrogacao();
        }
        else if(valorTiradoJogador1 > valorTiradoJogador2)
        {
            Console.Clear();
            pontosJogador1++;
            atualizarPlacar();
            Console.WriteLine("Jogo finalizado!!!");
            Console.WriteLine($"O jogador {Jogador1} venceu com {pontosJogador1} pontos!");
        }
        else
        {
            Console.Clear();
            pontosJogador2++;
            atualizarPlacar();
            Console.WriteLine("Jogo finalizado!!!");
            Console.WriteLine($"O jogador {Jogador2} venceu com {pontosJogador2} pontos!");
        }

    }

}