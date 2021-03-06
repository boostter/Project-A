using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Mover
{
    // reference to visual arrows
    PlayerCompass m_playerCompass;
    



    GameManager gameManager;
    // invoke the base class Awake method and setup the PlayerMover
    protected override void Awake()
    {
        base.Awake();
        m_playerCompass = Object.FindObjectOfType<PlayerCompass>().GetComponent<PlayerCompass>();
    }

    protected override void Start()
    {
        base.Start();
		UpdateBoard();

        if (faceDestination && m_playerCompass != null)
        {
            m_playerCompass.transform.parent = null;
        }
        
    }
    

    // update the Board's PlayerNode
    public void UpdateBoard()
    {
        if (m_board != null)
        {
            m_board.UpdatePlayerNode();
            
            
        }
        
    }

    protected override IEnumerator MoveRoutine(Vector3 destinationPos, float delayTime)
    {
        // disable PlayerCompass arrows
		if (m_playerCompass != null)
		{
			m_playerCompass.ShowArrows(false);
		}

        // run the parent class MoveRoutine
        yield return StartCoroutine(base.MoveRoutine(destinationPos, delayTime));

        // update the Board's PlayerNode
		UpdateBoard();

        // enable PlayerCompass arrows
		if (m_playerCompass != null)
		{

            if (faceDestination)
            {
                m_playerCompass.transform.position = transform.position;
            }

			m_playerCompass.ShowArrows(true);
		}

        // broadcast message at the end of movement
        base.finishMovementEvent.Invoke();
    }
    
}
