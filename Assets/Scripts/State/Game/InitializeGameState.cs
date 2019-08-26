using UnityEngine.Assertions;
using UnityEngine;
using BGC.StateMachine;

public class InitializeGameState : MonoState
{
    private class StateImplementation : TriggeringState<GameTrigger>
    {
        private Transform parent;

        public StateImplementation(Transform parent)
        {
            Assert.IsNotNull(parent);
            this.parent = parent;
        }

        protected override void OnStateEnter()
        {
            int levelToLoad = PlayerPrefs.GetInt(Keys.SaveData.MaxLevel, 0);
            GameObject level = Instantiate(Resources.Load<GameObject>($"Levels/{levelToLoad}"));
            level.transform.SetParent(parent);
        }
    }

    protected override void Awake()
    {
        State = new StateImplementation(transform);
    }
}
