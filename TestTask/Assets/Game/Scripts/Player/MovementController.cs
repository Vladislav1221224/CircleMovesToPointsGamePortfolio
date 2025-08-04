using System.Collections.Generic;

using UnityEngine;

namespace Game.Player
{
    public class MovementController : MonoBehaviour
    {
        #region Properties

        #region Bindings

        [Header("Bindings")]
        [SerializeField] Transform _movable;

        #endregion

        #region Settings

        [Space(5)]
        [Header("Settings")]
        [SerializeField] float _minSpeed = 1f;
        public float MinSpeed => _minSpeed;
        [SerializeField] float _maxSpeed = 10f;
        public float MaxSpeed => _maxSpeed;

        #endregion

        #region Cache

        [Space(5)]
        [Header("Cache")]
        [SerializeField] float _speed = 5f;

        #endregion

        #endregion

        #region Methods

        #region Unity methods

        private void OnValidate()
        {
            _speed = Mathf.Clamp(_speed, _minSpeed, _maxSpeed);
        }

        #endregion

        #region Setters

        public void SetSpeed(float newSpeed)
        {
            _speed = Mathf.Clamp(newSpeed, _minSpeed, _maxSpeed);
        }

        #endregion

        #region Move methods

        public void MoveToDestination(Vector2 destination)
        {
            _movable.transform.position = Vector2.MoveTowards(_movable.transform.position, destination, _speed * Time.deltaTime);
        }

        #endregion

        #endregion
    }
}