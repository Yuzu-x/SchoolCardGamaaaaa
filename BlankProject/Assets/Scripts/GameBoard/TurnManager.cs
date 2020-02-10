using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnManager : MonoBehaviour
{
    public Text turnCountText;
    public static float turnCount = 0f;

    static Dictionary<string, List<PlayAreaHandler>> players = new Dictionary<string, List<PlayAreaHandler>>();
    static Queue<string> turnKey = new Queue<string>();
    static Queue<PlayAreaHandler> playerTurn = new Queue<PlayAreaHandler>();

    void Start()
    {
        TurnCountUpdate();
    }

    void Update()
    {
        if(playerTurn.Count == 0)
        {
            InitPlayerTurnQueue();
        }

        TurnCountUpdate();
    }

    void TurnCountUpdate()
    {
        turnCountText.text = "Turn " + turnCount;
    }

    static void InitPlayerTurnQueue()
    {
        List<PlayAreaHandler> thisPlayer = players[turnKey.Peek()];

        foreach(PlayAreaHandler player in thisPlayer)
        {
            playerTurn.Enqueue(player);
        }

        turnCount = turnCount + 1f;
        StartTurn();
    }

    static void StartTurn()
    {
        if(playerTurn.Count > 0)
        {
            playerTurn.Peek().TurnBegin();

        }
    }

    public static void FinishTurn()
    {
        PlayAreaHandler player = playerTurn.Dequeue();
        player.TurnEnd();

        string side = turnKey.Dequeue();
        turnKey.Enqueue(side);
        InitPlayerTurnQueue();

    }

    public static void AddUnit(PlayAreaHandler player)
    {
        List<PlayAreaHandler> list;

        if(!players.ContainsKey(player.tag))
        {
            list = new List<PlayAreaHandler>();
            players[player.tag] = list;

            if(!turnKey.Contains(player.tag))
            {
                turnKey.Enqueue(player.tag);

            }
        }
        else
        {
            list = players[player.tag];

        }
        list.Add(player);
    }
}
