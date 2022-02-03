using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// base class for player and enemy game pieces
public class TurnManager : MonoBehaviour
{
    // reference to GameManager
    protected GameManager m_gameManager;

    // have we completed our turn?
    protected bool m_isTurnComplete = false;
    public int turnCount;
    public Text textTurnCount;
    public bool IsTurnComplete { get { return m_isTurnComplete; } set { m_isTurnComplete = value; }}

    // initialize fields
    protected virtual void Awake()
    {
        m_gameManager = Object.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        textTurnCount = GameObject.FindGameObjectWithTag("Count").GetComponent<Text>();
        turnCount = 0;
    }

    // complete the turn and notify the GameManager
    public virtual void FinishTurn()
    {
        m_isTurnComplete = true;

        if (m_gameManager != null)
        {
            m_gameManager.UpdateTurn();
        }
        turnCount++;
        textTurnCount.text = turnCount.ToString();
    }
}
