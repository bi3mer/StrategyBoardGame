using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine;

using BGC.StateMachine;

public class MenuState : MonoState
{
    public class StateImplementation : TriggeringState<StateTrigger>
    {
        private readonly GameObject menuObject;

        public StateImplementation(GameObject menuObject)
        {
            Assert.IsNotNull(menuObject);
            this.menuObject = menuObject;
        }

        protected override void OnStateEnter()
        {
            menuObject.SetActive(true);
        }

        protected override void OnStateExit()
        {
            menuObject.SetActive(false);
        }
    }

    [SerializeField]
    private Button startGameButton = null;

    protected override void Awake()
    {
        Assert.IsNotNull(startGameButton);
        State = new StateImplementation(gameObject);
    }
}
