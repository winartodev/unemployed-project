using Sirenix.OdinInspector;

using UnityEngine;
using UnityEngine.InputSystem;

namespace UnemployedProject.Runtime
{
    public abstract class CharacterAbility : MonoBehaviour
    {
        #region Constants

        protected const string InputActionRun = "Run";
        protected const string InputActionMove = "Move";

        protected const string ConfigGrp = "Config";

        #endregion

        #region Fields

        #if UNITY_EDITOR && ODIN_INSPECTOR
        [TitleGroup(ConfigGrp)]
        [Required]
        #endif
        [SerializeField]
        protected CharacterAnimation m_CharacterAnimation;

        #endregion

        #region Protected

        protected PlayerInput PlayerInput;

        #endregion

        #region Methods

        protected virtual void OnEnable()
        {
            SubscribeInput();
        }

        protected virtual void OnDisable()
        {
            UnsubscribeInput();
        }

        protected virtual void Start()
        {
            PlayerInput = FindObjectOfType<PlayerInput>();
            if (PlayerInput == null)
            {
                Logger.Show.LogError("No player input detected!");
                return;
            }

            SubscribeInput();
        }

        protected virtual void Update()
        {
            HandleInput();
        }

        protected virtual void Reset()
        {
            if (m_CharacterAnimation == null)
            {
                m_CharacterAnimation = GetComponent<CharacterAnimation>();
            }
        }

        protected abstract void SubscribeInput();
        protected abstract void UnsubscribeInput();

        protected abstract void HandleInput();

        protected abstract void OnPerformedAction(InputAction.CallbackContext ctx);

        #endregion
    }
}