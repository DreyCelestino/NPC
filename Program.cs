Console.Clear();

bool procurando = true;
bool atacando = false, fugindo = false, morto = false;
bool ferido = false, inimigoproximo = false, eliminado = false;
int roll, ciclo = 0;

Random dado = new Random();

while (morto == false)
{
    while (procurando == true)
    {
        roll = dado.Next(1, 2);

        if (roll == 1)
        {
            ferido = false;
        }
        else
        {
            inimigoproximo = true;
        }

        if (eliminado == false && (ferido == true || inimigoproximo == false))
        {
            procurando = true;
            ciclo = ciclo + 1;
        }
        else if (eliminado == false && ferido == false && inimigoproximo == true)
        {
            atacando = true;
            procurando = false;
            ciclo = ciclo + 1;
        }
    }


    while (atacando == true)
    {
        roll = dado.Next(1, 2);
        if (roll == 1)
        {
            ferido = true;
            roll = dado.Next(1, 2);
            if (roll == 2)
            {
                eliminado = true;
            }
        }
        else
        {
            inimigoproximo = false;
        }


        if (eliminado == false && ferido == false && inimigoproximo == true)
        {
            atacando = true;
            ciclo = ciclo + 1;
        }
        else if (eliminado == false && inimigoproximo == false)
        {
            procurando = true;
            atacando = false;
            ciclo = ciclo + 1;
        }
        else if (eliminado == false && ferido == true)
        {
            fugindo = true;
            atacando = false;
            ciclo = ciclo + 1;
        }
        else if (eliminado == true)
        {
            atacando = false;
            morto = true;
        }
    }

    while (fugindo == true)
    {
        roll = dado.Next(1, 4);
        if (roll == 1)
        {
            eliminado = true;
        }
        else if (roll == 2)
        {
            ferido = false;
        }
        else
        {
            inimigoproximo = false;
        }

        if (eliminado == false && ferido == true)
        {
            fugindo = true;
            ciclo = ciclo + 1;
        }
        else if (eliminado == false && ferido == false)
        {
            procurando = true;
            fugindo = false;
            ciclo = ciclo + 1;
        }
        else if (eliminado == true)
        {
            morto = true;
            fugindo = false;
        }

    }

}

Console.WriteLine($"O NPC sobreviveu por {ciclo} transições.");
