using UnityEngine.Assertions;
using UnityEngine;

using BGC.StateMachine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private MonoState menuState = null;

    private StateMachine<StateBool, StateTrigger> stateMachine;

    private void Awake()
    {
        Assert.IsNotNull(menuState);
    }

    private void Start()
    {
        //GameState gameState = new GameState();

        stateMachine = new StateMachine<StateBool, StateTrigger>();
        stateMachine.AddEntryState(menuState.State);
        stateMachine.Start();
    }

    private void Update()
    {
        stateMachine.Update();
    }
}