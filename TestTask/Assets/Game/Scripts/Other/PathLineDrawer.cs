using System.Collections.Generic;

using UnityEngine;

namespace Game.Other
{
    public class PathLineDrawer : MonoBehaviour
    {
        #region Properties

        #region Bindings

        [SerializeField] LineRenderer _lineRenderer;

        #endregion

        #region Cache

        Vector3[] _points3D;

        Vector3 pointCache;

        #endregion

        #endregion

        #region Methods

        #region Unity methods

        private void Start()
        {
            _lineRenderer.positionCount = 0;
        }

        #endregion

        #region Setters
        public void SetPoints(Vector2[] points)
        {
            //Converting to Vector3[]
            _points3D = new Vector3[points.Length + 1];//First point is player

            for (int i = 0; i < points.Length; i++)
            {
                pointCache = points[i];
                _points3D[i + 1] = new Vector3(pointCache.x, pointCache.y, 0f);
            }

            _lineRenderer.positionCount = _points3D.Length;

            _lineRenderer.SetPositions(_points3D);
        }
        public void UpdatePoint(int index, Vector2 point)
        {
            if (_lineRenderer.positionCount > 1)
                _lineRenderer.SetPosition(index, point);
        }

        #endregion

        #endregion
    }
}