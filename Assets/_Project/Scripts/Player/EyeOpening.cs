using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EyeOpening : MonoBehaviour
{
    [SerializeField] private GameObject _top;
    [SerializeField] private GameObject _bottom;

    private void Awake()
    {
        StartEyeOpening();
    }

    private void StartEyeOpening()
    {
        _top.GetComponent<Image>().enabled = true;
        _bottom.GetComponent<Image>().enabled = true;

        Sequence sequence = DOTween.Sequence();
        Tweener tweener1 = _top.transform.DOLocalMoveY(-300, 1);
        Tweener tweener2 = _bottom.transform.DOLocalMoveY(300, 1);

        Tweener tweener3 = _top.transform.DOLocalMoveY(-450, 1.5f);
        Tweener tweener4 = _bottom.transform.DOLocalMoveY(450, 1.5f);

        Tweener tweener5 = _top.transform.DOLocalMoveY(750, 2);
        Tweener tweener6 = _bottom.transform.DOLocalMoveY(-750, 2);
        sequence.Append(tweener1);
        sequence.Join(tweener2);
        sequence.Append(tweener3);
        sequence.Join(tweener4);
        sequence.Append(tweener5);
        sequence.Join(tweener6);

        sequence.OnComplete(() => { gameObject.SetActive(false); });
    }
}
