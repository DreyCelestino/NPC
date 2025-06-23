# NPC
Projeto prático desenvolvido por **Andrey Celestino** e **Nathan Carvalho**, que implementa a inteligência artificial de um NPC _(Non-player character — Personagem não-jogador)_ para um jogo de combate, simulando diferentes estados e transições conforme o cenário do jogo.

---

### ⚙️ Estado do NPC:
Neste jogo um NPC pode estar em 4 estados diferentes:

| Estado       | Descrição                                             |
| ------------ | ----------------------------------------------------- |
| 🔍 `Procurando` | Se recupera de seus ferimentos e procura por inimigos |
| ⚔️ `Atacando`   | Entra em combate aberto contra o inimigo              |
| 🏃 `Fugindo`    | Desiste do combate e foge pela sobrevivência          |
| ☠️ `Morto`      | Não sobreviveu ao combate e deve ser retirado do jogo |

O estado atual do NPC depende de **3 indicadores:**
-  👁️ `InimigoProximo`: `True` se há um inimigo a vista do NPC.
-  ❤️ `Ferido`: `True` se o NPC está ferido gravemente.
-  ❌ `Eliminado`: `True` se o NPC foi eliminado do jogo.

---

### 🔁 Máquina de estados:
 A máquina de estados abaixo indica as transições possíveis entre os estados:

![](https://github.com/DreyCelestino/NPC/blob/main/assets/fsm-npc.png)

---

### 🗂️ Condições para transição:  

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

---

### Eventos simulados a cada transição:

- 🔍 `Procurando`:
  - 50% de chances de curar-se (`Ferido = False`).
  - 50% de chances de encontrar o inimigo (`InimigoProximo = True`).
- ⚔️ `Atacando`:
  - 50% de chances se ferir (`Ferido = True`), e então 50% de chances de morrer com o ferimento (`Eliminado = True`).
  - 50% de chances matar o inimigo ou o inimigo fugir (`InimigoProximo = False`).
- 🏃 `Fugindo`:
  - 25% de chances de morrer com o ferimento (`Eliminado = True`).
  - 25% de chances de curar-se (`Ferido = False`).
  - 50% de chances do inimigo desistir (`InimigoProximo = False`).
- ☠️ `Morto`:
  - Finalizar a simulação.

---

### 🎯 Objetivo da simulação:
Começando no estado Procurando, simule as transições até que o NPC morra (Morto). Ao final, exiba a quantidade de transições pelas quais o NPC sobreviveu.

#### Exemplo de saída:

```
--- Simulação de IA de NPC ---

-- #  1 Procurando: Ferido = N, InimigoProximo = S, Eliminado = N => Atacando
-- #  2   Atacando: Ferido = N, InimigoProximo = S, Eliminado = N => Atacando
-- #  3   Atacando: Ferido = N, InimigoProximo = S, Eliminado = N => Atacando
-- #  4   Atacando: Ferido = N, InimigoProximo = S, Eliminado = N => Atacando
-- #  5   Atacando: Ferido = S, InimigoProximo = N, Eliminado = S => Morto

O NPC sobreviveu por 4 transições.
```
## 🚀 Como executar o projeto:

### ✅ Opção 1 – Executar pelo Terminal

1. Pré-requisitos:
    - Ter o SDK do .NET 7+ instalado na sua máquina.

2. Download do projeto:
    - Baixe o projeto completo clicando [aqui](https://github.com/DreyCelestino/NPC).

3. Execução:
    - Extraia a pasta.
      
    - Abra o terminal ou prompt de comando na pasta do projeto.
   
    - Execute o comando:

     ```
      dotnet run
     ```

---

### ✅ Opção 2

- Abrir direto o executável do programa.

- Fazer o download clicando [aqui](https://drive.google.com/file/d/10Weu09PLZcJyWuWjxCiMWh4vTb5OeT0n/view?usp=sharing) (google drive) ou [aqui](https://github.com/DreyCelestino/NPC/blob/main/dist.zip) (github)

- Extraia a pasta.

- Dê dois cliques no arquivo NPC.exe para abrir e rodar o programa diretamente.

## 📸 Capturas de tela do programa:

![](https://github.com/DreyCelestino/NPC/blob/main/assets/npc-run.png)
