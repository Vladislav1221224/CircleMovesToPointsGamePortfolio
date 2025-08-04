using Game.Player;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public class InputController : MonoBehaviour
    {
        #region Properties

        #region Options

        [Header("Options")]
        [SerializeField] int _targetFPS = 90;

        #endregion

        #region Events

        [Header("Input events")]
        public UnityEvent<Vector2> OnTapEvent;
        public UnityEvent<float> OnChangeSliderValueEvent;

        #endregion

        #region Input

        InputSystem_Actions _input;

        #endregion



        #endregion

        #region Methods

        #region Unity methods

        private void Awake()
        {
            _input = new InputSystem_Actions();

            _input.Player.MoveTo.canceled += ctx => OnTap();

            Application.targetFrameRate = _targetFPS;
        }

        private void OnEnable()
        {
            _input.Enable();
        }
        private void OnDisable()
        {
            _input.Disable();
        }
        #endregion

        #region Actions

        void OnTap()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Vector2 touch = Touchscreen.current.primaryTouch.position.ReadValue();

            Debug.Log("Touch = " + touch.ToString());

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(touch);

            OnTapEvent?.Invoke(worldPos);
        }

        public void OnChangeSliderValue(float value)
        {
            OnChangeSliderValueEvent?.Invoke(value);
        }

        #endregion

        #endregion
    }
}