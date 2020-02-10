using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCard : MonoBehaviour
{
    public static GameObject selectedCard;

    void Update()
    {
        if(selectedCard != null)
        {
            Vector2 cardPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            selectedCard.transform.position = cardPos;

        }


    }

}
