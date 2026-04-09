using UnityEngine;
using State = panelState;

public enum panelState
{
        IDLE,
        ACTIVATED,
        DISABLED
}
public class PanelClick_P1 : MonoBehaviour
{
    public State currentPanelState {get; private set;}
    public int panelID;
    public Fsm_Puzzle_1 manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentPanelState = State.IDLE;
    }

    // Update is called once per frame
    private void Update()
    {
        switch (currentPanelState)
        {   
            // not touch the picture
            case State.IDLE:
                break;
            // the correct order
            case State.ACTIVATED:
                break;
            // puzzle 1 solved -> no more touch 
            case State.DISABLED:
                break;
        }
    }

    public void ChangeState(State newState)
    {
        currentPanelState = newState;
    }

    // when click on the picture, call Grab function in the CustomCursor
    public void Grab()
    {
        // if already solved, ignore it
        if (currentPanelState == State.DISABLED) return;
        //
        if (manager == null) return; 

        SoundManager1.Play(SoundType1.CLICK_ON); 

        manager.PressPanel(this); // follow the panel that player just click 
    }
    public void SetActivated()
    {
         ChangeState(State.ACTIVATED);
    }

    public void Resetpanel()
    {
        ChangeState(State.IDLE);
    }

    public void SetDisabled()
    {
        ChangeState(State.DISABLED);
    }
}
