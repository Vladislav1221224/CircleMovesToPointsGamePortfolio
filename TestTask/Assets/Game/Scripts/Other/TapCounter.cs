using TMPro;

using UnityEngine;
using UnityEngine.Events;

namespace Game.Other
{
    public class TapCounter : MonoBehaviour
    {
        #region Properties

        #region Events

        //public UnityEvent<int> OnChangeCount;
        public UnityEvent<string> OnChangeCountString;
        #endregion

        #region Cache

        [SerializeField] int _count = 0;

        #endregion

        #endregion

        #region Methods

        public void Add()
        {
            _count++;
            //OnChangeCount?.Invoke(_count);
            OnChangeCountString?.Invoke(_count.ToString());
        }

        #endregion
    }
}