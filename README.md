# NPC
Projeto prático. Andrey e Nathan

## Exercício `NPC`

Implemente a inteligência artificial de um NPC (_Non-player character_ - Personagem não-jogador) para um jogo com combate.

Neste jogo um NPC pode estar em 4 estados diferentes:

| Estado       | Descrição                                             |
| ------------ | ----------------------------------------------------- |
| `Procurando` | Se recupera de seus ferimentos e procura por inimigos |
| `Atacando`   | Entra em combate aberto contra o inimigo              |
| `Fugindo`    | Desiste do combate e foge pela sobrevivência          |
| `Morto`      | Não sobreviveu ao combate e deve ser retirado do jogo |

O estado atual do NPC depende de 3 indicadores:

- `InimigoProximo`: `True` se há um inimigo a vista do NPC;
- `Ferido`: `True` se o NPC está ferido gravemente.
- `Eliminado`: `True` se o NPC foi eliminado do jogo.

A máquina de estados abaixo indica as transições possíveis entre os estados.

![](fsm-npc.png)

Condições para transição:

| De           | Para         | Condição                                       |
| ------------ | ------------ | ---------------------------------------------- |
| `Procurando` | `Procurando` | `!Eliminado` e (`Ferido` ou `!InimigoProximo`) |
| `Procurando` | `Atacando`   | `!Eliminado` e `!Ferido` e `InimigoProximo`    |
| `Atacando`   | `Atacando`   | `!Eliminado` e `!Ferido` e `InimigoProximo`    |
| `Atacando`   | `Procurando` | `!Eliminado` e `!InimigoProximo`               |
| `Atacando`   | `Fugindo`    | `!Eliminado` e `Ferido`                        |
| `Atacando`   | `Morto`      | `Eliminado`                                    |
| `Fugindo`    | `Fugindo`    | `!Eliminado` e `Ferido`                        |
| `Fugindo`    | `Procurando` | `!Eliminado` e `!Ferido`                       |
| `Fugindo`    | `Morto`      | `Eliminado`                                    |

A cada transição, simule os acontecimentos:

- `Procurando`:
  - 50% de chances de curar-se (`Ferido = False`).
  - 50% de chances de encontrar o inimigo (`InimigoProximo = True`).
- `Atacando`:
  - 50% de chances se ferir (`Ferido = True`), e então 50% de chances de morrer com o ferimento (`Eliminado = True`).
  - 50% de chances matar o inimigo ou o inimigo fugir (`InimigoProximo = False`).
- `Fugindo`:
  - 25% de chances de morrer com o ferimento (`Eliminado = True`).
  - 25% de chances de curar-se (`Ferido = False`).
  - 50% de chances do inimigo desistir (`InimigoProximo = False`).
- `Morto`:
  - Finalizar a simulação.

Simule transições partindo de `Procurando` até que o NPC morra. Exiba a quantidade de transições pelas quais o NPC sobreviveu.

Exemplo:

```
--- Simulação de IA de NPC ---

-- #  1 Procurando: Ferido = N, InimigoProximo = S, Eliminado = N => Atacando
-- #  2   Atacando: Ferido = N, InimigoProximo = S, Eliminado = N => Atacando
-- #  3   Atacando: Ferido = N, InimigoProximo = S, Eliminado = N => Atacando
-- #  4   Atacando: Ferido = N, InimigoProximo = S, Eliminado = N => Atacando
-- #  5   Atacando: Ferido = S, InimigoProximo = N, Eliminado = S => Morto

O NPC sobreviveu por 4 transições.
```
