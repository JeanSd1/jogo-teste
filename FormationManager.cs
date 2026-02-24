using System.Collections.Generic;

public class FormationManager
{
    public List<CardData> formacao = new List<CardData>();

    public void Adicionar(CardData carta)
    {
        if (formacao.Count < 6)
            formacao.Add(carta);
    }

    public void Remover(CardData carta)
    {
        formacao.Remove(carta);
    }
}