public class CardInstance
{
    public CardData data;
    public int vidaAtual;

    public CardInstance(CardData card)
    {
        data = card;
        vidaAtual = card.vida;
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;
        if (vidaAtual < 0)
            vidaAtual = 0;
    }

    public bool EstaVivo()
    {
        return vidaAtual > 0;
    }

    public float VidaPercentual()
    {
        if (data.vida <= 0)
            return 0f;

        return (float)vidaAtual / data.vida;
    }
}
