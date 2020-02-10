using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIRaycast : MonoBehaviour
{
    GraphicRaycaster handRayCast;
    PointerEventData mouseOverHand;
    EventSystem handAction;

    void Start()
    {
        handRayCast = GetComponent<GraphicRaycaster>();
        handAction = GetComponent<EventSystem>();
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            {
            mouseOverHand = new PointerEventData(handAction);
            mouseOverHand.position = Input.mousePosition;

            List<RaycastResult> cards = new List<RaycastResult>();

            handRayCast.Raycast(mouseOverHand, cards);

            foreach(RaycastResult card in cards)
            {
                if(card.gameObject.tag == "InHand")
                {
                    SelectedCard.selectedCard = card.gameObject;
                }
            }
        }
    }
}
