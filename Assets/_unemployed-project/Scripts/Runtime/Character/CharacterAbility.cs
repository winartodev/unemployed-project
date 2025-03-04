using UnityEngine;

namespace UnemployedProject.Runtime
{
    public abstract class CharacterAbility : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        protected CharacterAnimation m_CharacterAnimation;

        #endregion

        #region Methods

        protected virtual void Start()
        {
        }

        protected void Update()
        {
            HandleInput();
        }

        protected virtual void Reset()
        {
        }

        protected abstract void HandleInput();

        #endregion
    }
}