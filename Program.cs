Console.Clear();

bool procurando = true;
bool atacando = false, fugindo = false, morto = false;
bool ferido = false, inimigoproximo = false, eliminado = false;
bool rodando = false, fechar = false;
int roll, ciclo = 0;

Random dado = new Random();

rodando = true;
while (fechar == false){

while (rodando == true){

while (morto == false)
{
    while (procurando == true)
    {
        roll = dado.Next(1, 3);

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
            Console.WriteLine("Procurando > Procurando");
        }
        else if (eliminado == false && ferido == false && inimigoproximo == true)
        {
            atacando = true;
            procurando = false;
            ciclo = ciclo + 1;
            Console.WriteLine("Procurando > Atacando");
        }
    }


    while (atacando == true)
    {
        roll = dado.Next(1, 3);
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
            Console.WriteLine("Atacando > Atacando");
        }
        else if (eliminado == false && inimigoproximo == false)
        {
            procurando = true;
            atacando = false;
            ciclo = ciclo + 1;
            Console.WriteLine("Atacando > Procurando");
        }
        else if (eliminado == false && ferido == true)
        {
            fugindo = true;
            atacando = false;
            ciclo = ciclo + 1;
            Console.WriteLine("Atacando > Fugindo");
        }
        else if (eliminado == true)
        {
            atacando = false;
            morto = true;
        }
    }

    while (fugindo == true)
    {
        roll = dado.Next(1, 5);
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
            Console.WriteLine("Fugindo > Fugindo");
        }
        else if (eliminado == false && ferido == false)
        {
            procurando = true;
            fugindo = false;
            ciclo = ciclo + 1;
            Console.WriteLine("Fugindo > Procurando");
        }
        else if (eliminado == true)
        {
            morto = true;
            fugindo = false;
        }

    }

}

Console.WriteLine($"O NPC sobreviveu por {ciclo} transições.");
rodando = false;
}


Console.WriteLine("Deseja ir novamente? (S/N)");
string resposta = Console.ReadLine()!.Remove(1).ToUpper();

while (!(resposta == "S") && !(resposta == "N"))
{
    Console.WriteLine("\nOpção inválida! Tente novamente.");
    resposta = Console.ReadLine()!.Remove(1).ToUpper();
}

switch(resposta){
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
    fechar = true;
    break;
}
}
