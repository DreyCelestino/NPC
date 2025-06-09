Console.Clear();

bool procurando = true;
bool atacando = false, fugindo = false, morto = false;
bool ferido = false, inimigoproximo = false, eliminado = false;
bool rodando = true; 
int roll, ciclo = 0;

Console.WriteLine("--- Simulação de IA de NPC ---");
Console.WriteLine(" ");

Random dado = new Random();

while (rodando == true){
    while (morto == false)
    {
        // ---------------------- Procurando ----------------------
        while (procurando == true)
        {
            roll = dado.Next(1, 3);

            if (roll == 1)
            {
                ferido = false; // 50% de chances de curar-se.
            }
            else
            {
                inimigoproximo = true; // 50% de chances de encontrar o inimigo.
            }

            if (eliminado == false && (ferido == true || inimigoproximo == false))
            {
                procurando = true;
                ciclo = ciclo + 1;
                Console.WriteLine($"# {ciclo} — Procurando => Procurando (InimigoProximo = N, Ferido = S)");
            }
            else if (eliminado == false && ferido == false && inimigoproximo == true)
            {
                atacando = true;
                procurando = false;
                ciclo = ciclo + 1;
                Console.WriteLine($"# {ciclo} — Procurando => Atacando (InimigoProximo = S, Eliminado = N, Ferido = N)");
            }
        }

        // ---------------------- Atacando ----------------------
        while (atacando == true)
        {
            roll = dado.Next(1, 3);
            if (roll == 1)
            {
                ferido = true; // 50% de chances de se ferir.

                roll = dado.Next(1, 2);
                if (roll == 2)
                {
                    eliminado = true; // 50% de chances de morrer com o ferimento.
                }
            }
            else
            {
                inimigoproximo = false; // 50% de chances de matar o inimigo ou o inimigo fugir.
            }

            if (eliminado == false && ferido == false && inimigoproximo == true)
            {
                atacando = true;
                ciclo = ciclo + 1;
                Console.WriteLine($"# {ciclo} — Atacando => Atacando (InimigoProximo = S, Eliminado = N, Ferido = N)");
            }
            else if (eliminado == false && inimigoproximo == false)
            {
                procurando = true;
                atacando = false;
                ciclo = ciclo + 1;
                Console.WriteLine($"# {ciclo} — Atacando => Procurando (InimigoProximo = S, Eliminado = N, Ferido = N)");
            }
            else if (eliminado == false && ferido == true)
            {
                fugindo = true;
                atacando = false;
                ciclo = ciclo + 1;
                Console.WriteLine($"# {ciclo} — Atacando => Fugindo (Eliminado = N, Ferido = S)");
            }
            else if (eliminado == true)
            {
                atacando = false;
                morto = true;
                Console.WriteLine($"# {ciclo + 1} — Atacando => Morto (Eliminado = S, Ferido = S)");
            }
        }

        // ---------------------- Fugindo ----------------------
        while (fugindo == true)
        {
            roll = dado.Next(1, 5);
            if (roll == 1)
            {
                eliminado = true; // 25% de chances de morrer com o ferimento.
            }
            else if (roll == 2)
            {
                ferido = false; // 25% de chances de curar-se.
            }
            else
            {
                inimigoproximo = false; // 50% de chances do inimigo desistir.
            }

            if (eliminado == false && ferido == true)
            {
                fugindo = true;
                ciclo = ciclo + 1;
                Console.WriteLine($"# {ciclo} — Fugindo => Fugindo (Eliminado = N, Ferido = S)");
            }
            else if (eliminado == false && ferido == false)
            {
                procurando = true;
                fugindo = false;
                ciclo = ciclo + 1;
                Console.WriteLine($"# {ciclo} — Fugindo => Procurando (Eliminado = N, Ferido = N)");
            }
            else if (eliminado == true)
            {
                morto = true;
                fugindo = false;
                Console.WriteLine($"# {ciclo + 1} — Fugindo => Morto (Eliminado = S, Ferido = S)");
            }
        }
    }

    Console.WriteLine(" ");
    Console.WriteLine($"O NPC sobreviveu por {ciclo} transições.");
    Console.WriteLine(" ");

    Console.WriteLine("Deseja ir novamente? (S/N)");
    string resposta = Console.ReadLine()!.Remove(1).ToUpper();

    while (!(resposta == "S") && !(resposta == "N"))
    {
        Console.WriteLine("\nOpção inválida! Tente novamente.");
        resposta = Console.ReadLine()!.Remove(1).ToUpper();
    }

    switch (resposta)
    {
        case "S":
            resposta = "null";
            morto = false;
            procurando = true;
            atacando = false;
            fugindo = false;
            ferido = false;
            inimigoproximo = false;
            eliminado = false;
            ciclo = 0;
            rodando = true;
            break;

        case "N":
            resposta = "null";
            rodando = false;
            break;
    }
}
