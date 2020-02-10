using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public CardBase newcard;

    public Text cardNameText;
    public Text cardAbilityText;
    public Text cardTagText;

    public Text healthText;
    public Image healthImage;
    public Text costText;
    public Text attackText;
    public Image attackImage;

    public Image cardBackground;
    public Image cardArtImage;

    void Start()
    {
        cardNameText.text = newcard.cardName;
        cardAbilityText.text = newcard.cardAbility;
        cardTagText.text = newcard.cardTag;
        healthText.text = newcard.cardHealth.ToString();
        attackText.text = newcard.cardAttack.ToString();
        costText.text = newcard.cardCost.ToString();
        cardBackground.sprite = newcard.cardBack;
        cardArtImage.sprite = newcard.cardArt;
        newcard.cardType.OnSetType(this);
        
    }

}
