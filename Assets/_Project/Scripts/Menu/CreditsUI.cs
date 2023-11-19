using UnityEngine;
using DG.Tweening;

public class CreditsUI : MonoBehaviour
{
    //Game Name
    public RectTransform objectToScale;
    public Vector3 targetScale = new Vector3(2f, 2f, 2f);
    public float gameNameDuration = 1.0f;

    //
    public RectTransform objectToSlide;
    public float slideDistance = 900f;
    public float duration = 1.0f;


    private void Start()
    {
        SlideDown();
    }

    private void Update()
    {
        ShrinkObject();
    }

    public void ShrinkObject()
    {
        objectToScale.DOScale(targetScale, gameNameDuration);
    }

    public void SlideDown()
    {
        Vector3 startPos = objectToSlide.anchoredPosition3D;
        Vector3 endPos = startPos - new Vector3(0f, slideDistance, 0f);
        objectToSlide.DOAnchorPos3D(endPos, duration).SetEase(Ease.OutQuad);
    }
}
