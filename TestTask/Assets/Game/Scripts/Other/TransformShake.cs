using System.Collections;

using UnityEngine;

/// <summary>
/// Автор: Твоє Ім'я
/// Дата створення: #DATE#
/// </summary>
public class TransformShake : MonoBehaviour
{
    #region Properties

    #region Animations

    [SerializeField] float _duration = 1f;
    [Space(10)]
    [Header("ANIMATIONS")]

    [Header("---Scale---")]
    [SerializeField] AnimationCurve _scaleAnimation;
    [SerializeField] Vector2 _strength = new();
    #endregion

    #endregion

    #region Methods

    #region Unity methods

    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    #endregion

    #region Animations

    public void ScaleShake()
    {
        StartCoroutine(ScaleAnimationCoroutine(_scaleAnimation, _strength, _duration));
    }

    IEnumerator ScaleAnimationCoroutine(AnimationCurve curve, Vector3 _strength = new(), float duration = 1f)
    {
        WaitForEndOfFrame wait = new();
        float time = 0;
        float value = 0;
        while (value <= 1f)
        {
            value = time / duration;

            transform.localScale = curve.Evaluate(value) * _strength;

            yield return wait;
            time += Time.deltaTime;
        }
    }

    #endregion
    #endregion
}