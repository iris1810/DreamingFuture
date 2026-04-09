using UnityEngine;
using State = Puzzle1_State;

public enum Puzzle1_State {
  IDLE,
  IN_PROCESS,
  SOLVED,
  
}

public class Fsm_Puzzle_1 : MonoBehaviour {
  public State PuzzleState { get; private set; }

  public PanelClick_P1[] panels;
  public int[] correctOrders = {0,1,2,3};
  public DoorController door;
  private int currentStep = 0; // keep track the current input in the order
  
  private void Start() {
    PuzzleState = State.IDLE;

    //keep track connect between panel and manager
    foreach (var panel in panels)
    {
      panel.manager = this; // assign each panel undercontrol by this puzzlefsm
    }
  }

  private void Update() {
    switch (PuzzleState) {
      case State.IDLE:
        //do idle things
        break;

      case State.IN_PROCESS:
        // IN_PROCESS solving puzzle
        break;

      case State.SOLVED:
        // solved state stuff
        break;
    }
  }

  public void ChangeState(State newState) {
    PuzzleState = newState;
  }

  // when player click on panel
  public void PressPanel (PanelClick_P1 panel)
  {
    // if already solved -> return
    if (PuzzleState == State.SOLVED) return;

    // if puzzle in idle -> in process
    if (PuzzleState == State.IDLE)
    {
      ChangeState(State.IN_PROCESS);
      
    }

    //check for in order input panel
    if (panel.panelID == correctOrders[currentStep])
    {
      panel.SetActivated();
      currentStep++;

      //when the puzzle done solving
      if (currentStep >= correctOrders.Length)
      {
        SolvePuzzle();
      }
    }
    else
    {
      ResetPuzzle();
    }
  }

  //for done SLOVED the puzzle
  private void SolvePuzzle()
  {
    ChangeState(State.SOLVED);

    SoundManager1.Play(SoundType1.CORRECT);

    //disable for each panel
    foreach(var panel in panels)
    {
      panel.SetDisabled();
    }
    if (door != null)
    {
      door.UnlockDoor();
    }
  }

  // Answer is wrong, reset the puzzle
  private void ResetPuzzle()
  {
   currentStep =0;
   ChangeState(State.IDLE);
   SoundManager1.Play(SoundType1.WRONG);

   foreach(var panel in panels)
    {
      panel.Resetpanel();
    } 
  }
}
