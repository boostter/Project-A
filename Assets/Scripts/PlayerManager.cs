using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerDeath))]
public class PlayerManager : TurnManager
{
	// reference to PlayerMover and PlayerInput components
	public PlayerMover playerMover;
    public PlayerInput playerInput;
    public PlayerCompass playerCompass;
    QuestionManager questionManager;
    // reference to Board component
    Board m_board;

    // messages to send when the Player dies
    public UnityEvent deathEvent;

    protected override void Awake()
    {
        base.Awake();

		// cache references to PlayerMover and PlayerInput
		playerMover = GetComponent<PlayerMover>();
        playerInput = GetComponent<PlayerInput>();
        playerCompass = GetComponentInChildren<PlayerCompass>();

        m_board = Object.FindObjectOfType<Board>().GetComponent<Board>();

		// make sure that input is enabled when we begin
		playerInput.InputEnabled = true;

        if (playerMover.faceDestination)
        {
            playerCompass.transform.parent = null;
        }
    }


    private void UpdatePlayerCompass()
    {
        if (playerMover.faceDestination)
        {
            playerCompass.transform.position = transform.position;
        }

    }

    void Update()
    {
		// if the player is currently moving or if it's not the Player's turn, ignore user input
        if (playerMover.isMoving || m_gameManager.CurrentTurn != Turn.Player)
        {
            return;
        }

		// get keyboard input
		playerInput.GetInput();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    PrintDirection(hit.transform.gameObject);
                }
            }
        }
        
    }

    // invoke any UnityActions on the deathEvent
    public void Die()
    {
        if (deathEvent != null)
        {
            deathEvent.Invoke();
        }
    }

    // capture any enemies on the PlayerNode
    void CaptureEnemies()
    {
        if (m_board != null)
        {
            // all enemies on the PlayerNode
            List<EnemyManager> enemies = m_board.FindEnemiesAt(m_board.PlayerNode);

            // if we find at least one enemy...
            if (enemies.Count != 0)
            {
                // ...invoke the Die method on each one
                foreach (EnemyManager enemy in enemies)
                {
                    if (enemy != null)
                    {
                        enemy.Die();
                    }
                }
            }
        }
    }

    // override the TurnManager's FinishTurn
    public override void FinishTurn()
    {
        // capture any enemies standing on the PlayerNode
        CaptureEnemies();

        // tell the GameManager the PlayerTurn is complete
        base.FinishTurn();
    }

    private void PrintDirection(GameObject obj)
    {
        if(obj.name == "Arrow(Clone)"){
            if (obj.transform.eulerAngles.y == 0)
            {
                playerMover.MoveForward();
                playerInput.ClearInput();
            }
            else if (obj.transform.eulerAngles.y == 90)
            {
                playerMover.MoveRight();
                playerInput.ClearInput();
            }
            else if (obj.transform.eulerAngles.y == 270)
            {
                playerMover.MoveLeft();
                playerInput.ClearInput();
            }
            else if (obj.transform.eulerAngles.y == 180)
            {
                playerMover.MoveBackward();
                playerInput.ClearInput();
            }
            
        }
        
    }
}
