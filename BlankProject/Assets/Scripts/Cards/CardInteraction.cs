using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardInteraction : MonoBehaviour
{
    public float interestTime = 0f;
    public Image cardBack;
    public Vector2 startPos;
    public bool isPlayed;
    GameObject cardInHand;


    void Start()
    {
        startPos = transform.position;

    }

}
    

