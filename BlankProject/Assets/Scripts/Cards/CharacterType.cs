using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Card/Type/Character")]
public class CharacterType : CardType
{
    public override void OnSetType(CardDisplay visuals)
    {
        base.OnSetType(visuals);
        visuals.healthText.enabled = true;
        visuals.healthImage.enabled = true;
        visuals.attackText.enabled = true;
        visuals.attackImage.enabled = true;

    }
}
