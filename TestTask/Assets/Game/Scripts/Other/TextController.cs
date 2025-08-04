using System.Collections;

using TMPro;

using UnityEngine;

namespace Game.UI.Other
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextController : MonoBehaviour
    {
        #region Properties

        #region Settings

        [Header("SETTINGS")]
        [SerializeField] string _format = "Text: {0}";

        #endregion

        #region Cache

        TextMeshProUGUI _text;

        #endregion

        #endregion

        #region Methods

        #region Unity methods

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {

        }

        private void Update()
        {

        }

        #endregion

        #region Setters

        public void SetText(string text)
        {
            _text.text = string.Format(_format, text);
        }

        #endregion

        #endregion
    }
}