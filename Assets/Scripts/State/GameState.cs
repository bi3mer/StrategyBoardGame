using BGC.StateMachine;
using UnityEngine;

public class GameState : MonoState
{
    private class StateImplementation : CoordinatingState<StateBool, StateTrigger>
    {
        private StateMachine<GameTrigger, GameBool> gameSM = null;

        protected override void OnStateEnter()
        {
            if (gameSM == null)
            {
                gameSM = new StateMachine<GameTrigger, GameBool>();

            }

            gameSM.Reset(restartStateMachine: true);
        }

        public override void Update()
        {
            gameSM.Update();
        }
    }

    protected override void Awake()
    {
    }
}