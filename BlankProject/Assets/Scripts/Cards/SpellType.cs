using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Spell", menuName ="Card/Type/Spell")]
public class SpellType : CardType
{
    public override void OnSetType(CardDisplay visuals)
    {
        base.OnSetType(visuals);
        visuals.healthText.enabled = false;
        visuals.healthImage.enabled = false;
        visuals.attackText.enabled = false;
        visuals.attackImage.enabled = false;
        visuals.cardTagText.enabled = false;
    }
}
