using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<CardInstance> timeJogador;
    public List<CardInstance> timeInimigo;

    private int turnoAtual = 0;

    public void IniciarBatalha(List<CardData> jogador, List<CardData> inimigo)
    {
        timeJogador = CriarInstancias(jogador);
        timeInimigo = CriarInstancias(inimigo);

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
        Debug.Log("Turno iniciado!");
    }
}