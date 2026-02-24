using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<CardInstance> timeJogador;
    public List<CardInstance> timeInimigo;

    private int turnoAtual = 0;
    private bool batalhaAtiva = false;

    public void IniciarBatalha(List<CardData> jogador, List<CardData> inimigo)
    {
        timeJogador = CriarInstancias(jogador);
        timeInimigo = CriarInstancias(inimigo);

        turnoAtual = 1;
        batalhaAtiva = true;

        Debug.Log($"Batalha iniciada! Jogador: {timeJogador.Count} cartas | Inimigo: {timeInimigo.Count} cartas");
        ComecarTurno();
    }

    List<CardInstance> CriarInstancias(List<CardData> lista)
    {
        List<CardInstance> instancias = new List<CardInstance>();

        foreach (var card in lista)
            instancias.Add(new CardInstance(card));

        return instancias;
    }

    void ComecarTurno()
    {
        if (!batalhaAtiva)
            return;

        Debug.Log($"--- Turno {turnoAtual} ---");

        List<CardInstance> ordemDeAcao = timeJogador
            .Concat(timeInimigo)
            .Where(c => c.EstaVivo())
            .OrderByDescending(c => c.data.velocidade)
            .ToList();

        foreach (var atacante in ordemDeAcao)
        {
            if (!atacante.EstaVivo())
                continue;

            List<CardInstance> alvoPool = timeJogador.Contains(atacante) ? timeInimigo : timeJogador;
            CardInstance alvo = EscolherAlvoVivo(alvoPool);

            if (alvo == null)
                continue;

            RealizarAtaque(atacante, alvo);

            if (VerificarFimDeBatalha())
            {
                batalhaAtiva = false;
                return;
            }
        }

        turnoAtual++;
        ComecarTurno();
    }

    CardInstance EscolherAlvoVivo(List<CardInstance> time)
    {
        return time
            .Where(c => c.EstaVivo())
            .OrderBy(c => c.VidaPercentual())
            .FirstOrDefault();
    }

    void RealizarAtaque(CardInstance atacante, CardInstance alvo)
    {
        int dano = Mathf.Max(1, atacante.data.ataque - alvo.data.defesa);
        alvo.ReceberDano(dano);

        Debug.Log($"{atacante.data.nome} atacou {alvo.data.nome} causando {dano} de dano. Vida restante de {alvo.data.nome}: {alvo.vidaAtual}");
    }

    bool VerificarFimDeBatalha()
    {
        bool jogadorVivo = timeJogador.Any(c => c.EstaVivo());
        bool inimigoVivo = timeInimigo.Any(c => c.EstaVivo());

        if (jogadorVivo && inimigoVivo)
            return false;

        if (jogadorVivo)
            Debug.Log("Vitória do jogador!");
        else if (inimigoVivo)
            Debug.Log("Vitória do inimigo!");
        else
            Debug.Log("Empate!");

        return true;
    }
}
