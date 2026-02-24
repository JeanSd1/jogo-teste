using System.Collections.Generic;

public class FormationManager
{
    public List<CardData> formacao = new List<CardData>();

    public bool Adicionar(CardData carta)
    {
        if (carta == null)
            return false;

        if (formacao.Count >= 6)
            return false;

        if (formacao.Contains(carta))
            return false;

        formacao.Add(carta);
        return true;
    }

    public bool Remover(CardData carta)
    {
        return formacao.Remove(carta);
    }
}
