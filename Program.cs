Console.Clear();

bool procurando = true;
bool atacando = false, fugindo = false, morto = false;
bool ferido = false, inimigoproximo = false, eliminado = false;

Random dado = new Random();

while (eliminado == false)
{
    while (procurando == true)
    {

            if (dado.Next(1, 4) > 2)
            {
                ferido = false;
            }
            if (dado.Next(1, 4) > 2)
            {
                inimigoproximo = true;
            }

        if (eliminado == false && (ferido == true || inimigoproximo == false))
        {
            procurando = true;
        }
        else if (eliminado == false && ferido == false && inimigoproximo == true)
        {
            atacando = true;
            procurando = false;
        }
    }

    while (atacando == true)
    {
        if (dado.Next(1, 4) > 2)
        {
            ferido = true;
        }
        if (dado.Next(1, 4) > 2 && ferido == true)
        {
            eliminado = true;
        }
        if (dado.Next(1, 4) > 2)
        {
            inimigoproximo = false;
        }

        if(eliminado == false &&)
    }
    


}