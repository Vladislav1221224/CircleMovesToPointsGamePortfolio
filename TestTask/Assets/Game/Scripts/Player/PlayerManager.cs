using UnityEngine;


namespace Game.Player
{
    public class PlayerManager : MonoBehaviour
    {
        #region Properties

        #region Bindings

        [Header("Bindings")]
        [SerializeField] MovementController _movementController;

        [SerializeField] AIController _AIController;

        #endregion

        #endregion

        #region Methods

        #region Actions

        public void OnMoveToDestination(Vector2 destination)
        {
            _AIController.EnqueueDestination(destination);
        }

        public void OnChangeSpeedSlider(float value)
        {
            float speed = Mathf.Lerp(_movementController.MinSpeed, _movementController.MaxSpeed, value);

            _movementController.SetSpeed(speed);
        }

        #endregion

        #endregion
    }
}