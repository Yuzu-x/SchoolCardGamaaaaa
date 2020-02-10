using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayAreaHandler : MonoBehaviour
{
    public Transform playSlot1;
    GameObject heldCard;
    GameObject[] myHand;
    public GameObject[] cardSlot;
    Transform emptySlot;
    CardInteraction home;

    public Image playCard;
    public bool overPlayArea = false;
    public bool overCard = false;

    List<Transform> playSlots = new List<Transform>();
    List<GameObject> cardInHand = new List<GameObject>();

    public Image hand;
    Transform handPos;

    public bool myTurn = false;

    public float maxActions = 10f;
    public float thisTurnActions = 0f;
    public float currentActions = 0f;

    public void Start()
    {
        heldCard = GameObject.FindGameObjectWithTag("InHand");
        myHand = GameObject.FindGameObjectsWithTag("InHand");
        Debug.Log("My cards in hand are  " + myHand);
        handPos = hand.transform;

        cardSlot = GameObject.FindGameObjectsWithTag("InPlay");
        foreach (GameObject cs in cardSlot)
        {
            emptySlot = cs.GetComponent<Transform>();
            playSlots.Add(emptySlot);
        }


    }

    public void Update()
    {
        PointerEventData mouse = new PointerEventData(EventSystem.current);
        mouse.position = Input.mousePosition;
        List<RaycastResult> findPA = new List<RaycastResult>();
        EventSystem.current.RaycastAll(mouse, findPA);
        int count = findPA.Count;

        foreach (GameObject card in myHand)
        {
            heldCard = card;
            cardInHand.Add(heldCard);
        }

        foreach (RaycastResult p in findPA)
        {
            if (p.gameObject.tag == "InPlay")
            {
                overPlayArea = true;
            }
            else if (p.gameObject.tag == "InHand")
            {
                overCard = true;
            }
            else
            {
                overPlayArea = false;
                overCard = false;
            }

            if (SelectedCard.selectedCard)

            {
                foreach (Transform es in playSlots)
                {
                    if (Input.GetMouseButtonUp(0) && overPlayArea)
                    {
                        SelectedCard.selectedCard.transform.SetParent(es);
                        SelectedCard.selectedCard.gameObject.tag = "InPlay";
                        playSlots.Remove(es);

                        SelectedCard.selectedCard.transform.position = es.position;
                        SelectedCard.selectedCard.transform.rotation = es.rotation;

                        SelectedCard.selectedCard = null;

                        return;
                    }
                    else if(Input.GetMouseButtonUp(0) && overPlayArea == false)
                    {
                        SelectedCard.selectedCard.transform.SetParent(handPos);
                        SelectedCard.selectedCard.transform.position = handPos.position;
                        SelectedCard.selectedCard = null;
                    }
                }
            }
        }
    }

    public void TurnBegin()
    {
        myTurn = true;
        thisTurnActions = thisTurnActions + 1f;
        currentActions = thisTurnActions;

    }

    public void TurnEnd()
    {
        myTurn = false;
    }
}
