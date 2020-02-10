using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Empty")]
public class CardBase : ScriptableObject
{
    public CardType cardType;
    public string cardName;
    public string cardAbility;
    public string cardTag;
    public int cardCost;
    public int cardAttack;
    public int cardHealth;
    public Sprite cardArt;
    public Sprite cardBack;

}
