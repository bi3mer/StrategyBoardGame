using UnityEngine.Assertions;
using UnityEngine;

namespace BGC.StateMachine
{
    public abstract class MonoState : MonoBehaviour
    {
        private State state;
        public State State
        {
            get
            {
                if (state == null)
                {
                    Awake();
                }

                Assert.IsNotNull(state, "Looks like Awake isn't initializing the state variable.");
                return state;
            }
            protected set
            {
                state = value;
            }
        }

        protected abstract void Awake();
    }
}
