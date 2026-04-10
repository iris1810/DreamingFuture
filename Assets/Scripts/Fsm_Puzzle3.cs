using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

using State = Puzzle3_State;

public enum Puzzle3_State
{
    IDLE,
    IN_PROCESS,
    SOLVED
}

public class Fsm_Puzzle3 : MonoBehaviour
{
    public State PuzzleState { get; private set; }

    [Header("Optional")]
    public DoorController door;          
    public string winSceneName = "Win";  
    public float delayBeforeWinScene = 1.5f;

    private bool hasTriggered = false;

    private void Start()
    {
        PuzzleState = State.IDLE;
    }

    private void Update()
    {
        switch (PuzzleState)
        {
            case State.IDLE:
                // waiting for player to click
                break;

            case State.IN_PROCESS:
                // button was pressed, processing win
                break;

            case State.SOLVED:
                // already solved
                break;
        }
    }

    public void ChangeState(State newState)
    {
        PuzzleState = newState;
    }

    // This should be called by your interaction system when player clicks the object
    public void Grab()
    {
        if (PuzzleState == State.SOLVED || hasTriggered)
            return;

        if (PuzzleState == State.IDLE)
        {
            ChangeState(State.IN_PROCESS);
        }

        SolvePuzzle();
    }

    private void SolvePuzzle()
    {
        hasTriggered = true;
        ChangeState(State.SOLVED);

        Debug.Log("Puzzle 3 solved! Player wins.");

        if (door != null)
        {
            door.UnlockDoor();
        }

        // play win sound
        SoundManager1.Play(SoundType1.WIN);

        StartCoroutine(LoadWinSceneAfterDelay());
    }

    private IEnumerator LoadWinSceneAfterDelay()
    {
        yield return new WaitForSeconds(1f); 
        SceneManager.LoadSceneAsync(3);
    }
}