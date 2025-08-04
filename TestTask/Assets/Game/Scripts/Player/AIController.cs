using Game.Other;

using System.Collections.Generic;

using UnityEngine;

namespace Game.Player
{
    public class AIController : MonoBehaviour
    {
        #region Properties

        #region Bindings

        [Header("Bindings")]
        [SerializeField] MovementController _movable;
        [SerializeField] PathLineDrawer _lineDrawer;
        #endregion

        #region Settings

        [Header("Settings")]
        [SerializeField] float _minDistanceToDestination = 0.05f;

        #endregion

        #region Cache

        bool _isMoving = false;

        Queue<Vector2> _destinationsQueue = new();

        #endregion

        #endregion

        #region Methods

        #region Unity methods

        private void Update()
        {
            MoveUpdate();
        }

        #endregion

        #region AI
        void MoveUpdate()
        {
            if (!_isMoving && _destinationsQueue.Count > 0)
                StartMoveToDestination();

            if (_isMoving)
            {
                PerformMoveToDestination();

                if (_lineDrawer)
                    _lineDrawer.UpdatePoint(0, _movable.transform.position);
            }
        }

        void StartMoveToDestination()
        {
            _isMoving = true;

            _lineDrawer.enabled = true;
        }
        void PerformMoveToDestination()
        {
            if (ReachedDestination())
            {
                EndMoveToDestination();

                return;
            }
            _movable.MoveToDestination(_destinationsQueue.Peek());
        }

        void EndMoveToDestination()
        {
            DequeueDestination();
            _isMoving = false;
            if (_destinationsQueue.Count == 0)
                _lineDrawer.enabled = false;
        }

        #endregion

        #region Destination management

        public void EnqueueDestination(Vector2 destination)
        {
            _destinationsQueue.Enqueue(destination);

            if (_lineDrawer)
                _lineDrawer.SetPoints(_destinationsQueue.ToArray());
        }

        Vector2 DequeueDestination()
        {
            Vector2 destination = _destinationsQueue.Dequeue();

            if (_lineDrawer)
                _lineDrawer.SetPoints(_destinationsQueue.ToArray());

            return destination;
        }

        #endregion

        #region Other

        bool ReachedDestination() => Vector2.Distance(_movable.transform.position, _destinationsQueue.Peek()) < _minDistanceToDestination;

        #endregion

        #endregion
    }
}