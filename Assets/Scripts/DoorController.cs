using UnityEngine;
using State = DoorState;
public enum DoorState
{
    LOCKED,
    UNLOCKED,
    OPEN
}
public class DoorController : MonoBehaviour
{
    public State DoorState {get; private set;}
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Start()
    {
        DoorState = State.LOCKED;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (DoorState)
        {
            case State.LOCKED:
                break;

            case State.UNLOCKED:
                break;

            case State.OPEN:
                break;
        }
    }
    public void UnlockDoor()
    {
        if (DoorState == State.LOCKED)
        {
            ChangeState(State.UNLOCKED);
        }
    }
    public void ChangeState(State newState)
    {
        DoorState = newState;
    }

    private void OnTriggerEnter (Collider other)
    {
        // only working with player
        if (!other.CompareTag("Player")) return;
        if ( DoorState == State.UNLOCKED)
        {
            animator.SetTrigger("Open");
            DoorState = DoorState.OPEN;
        }

    } 

    private void OnTriggerExit (Collider other)
    {
        // only working with player
        if (!other.CompareTag("Player")) return;
        if (DoorState == DoorState.OPEN)
        {
            animator.SetTrigger("Close");
            DoorState = DoorState.UNLOCKED;
        }
    }
}
    
    
