using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour
{
    [SerializeField] private InitSceneUI _initSceneUI;
    [SerializeField] Vector3 _secondPos;
    [SerializeField] Vector3 _secondRotation;
    [SerializeField] public Animator _leftEyeAnimator;
    [SerializeField] public Animator _rightEyeAnimator;


    private void OnEnable()
    {
        _initSceneUI.OnPlayButtonClickedEvent += OnPlayButtonClicked;
    }

    private void OnDisable()
    {
        _initSceneUI.OnPlayButtonClickedEvent -= OnPlayButtonClicked;
    }

    void Update()
    {
        
    }

    private void OnPlayButtonClicked()
    {
        _leftEyeAnimator.SetTrigger("openEye");
        _rightEyeAnimator.SetTrigger("openEye");

        Sequence sequence = DOTween.Sequence();
        Tweener firstRotate = transform.DORotate(Vector3.zero, 0.5f);
        Tweener positionMove = transform.DOMove(_secondPos, 2).OnComplete(BlinkEye);
        Tweener secondRotate = transform.DORotate(_secondRotation, 1).SetDelay(1);

        sequence.Append(firstRotate);
        sequence.Append(positionMove);
        sequence.Append(secondRotate);
    }

    private void BlinkEye()
    {
        _leftEyeAnimator.SetTrigger("blinkEye");
        _rightEyeAnimator.SetTrigger("openEye");
    }

}
