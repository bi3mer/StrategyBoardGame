using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine;

using BGC.StateMachine;

public class MenuState : MonoState
{
    public class StateImplementation : TriggeringState<StateTrigger>
    {
        private readonly GameObject menuObject;
        private readonly Button startGameButton;

        public StateImplementation(GameObject menuObject, Button startGameButton)
        {
            Assert.IsNotNull(startGameButton);
            Assert.IsNotNull(menuObject);

            this.startGameButton = startGameButton;
            this.menuObject = menuObject;
        }

        protected override void OnStateEnter()
        {
            startGameButton.onClick.AddListener(OnStartGameButtonClick);
            menuObject.SetActive(true);
        }

        protected override void OnStateExit()
        {
            startGameButton.onClick.RemoveListener(OnStartGameButtonClick);
            menuObject.SetActive(false);
        }

        private void OnStartGameButtonClick()
        {
            Debug.Log("oh hai world");
        }
    }

    [SerializeField]
    private Button startGameButton = null;

    protected override void Awake()
    {
        State = new StateImplementation(gameObject, startGameButton);
    }
}
