using UnityEngine;

[CreateAssetMenu(fileName = "NovaCarta", menuName = "Cartas/Ninja")]
public class CardData : ScriptableObject
{
    public string nome;
    public Sprite imagem;

    [Header("Stats")]
    public int vida;
    public int ataque;
    public int defesa;
    public int velocidade;

    [Header("Extra")]
    public Raridade raridade;
}

public enum Raridade
{
    Comum,
    Raro,
    Epico,
    Lendario
}
