using UnityEngine;
using DG.Tweening;

public class CreditsUI : MonoBehaviour
{
    public static CreditsUI Instance { get; set; }

    public static bool showCredits = false;

    //Game Name
    public RectTransform objectToScale;
    public Vector3 targetScale = new Vector3(2f, 2f, 2f);
    public float gameNameDuration = 1.0f;

    //
    public RectTransform objectToSlide;
    public float slideDistance = -900f;
    public float duration = 3.0f;

    public AudioClip creditsMusic;

    private void Start()
    {
        if (showCredits)
        {
            SlideDown();
        }
        ShowCredits();
    }

    public void ShowCredits()
    {
        BackgroundMusic.instance.MusicDegistir(creditsMusic);
        ShrinkObject();
        SlideDown();
    }

    private void ShrinkObject()
    {
        objectToScale.DOScale(targetScale, gameNameDuration);
    }

    private void SlideDown()
    {
        Vector3 startPos = objectToSlide.anchoredPosition3D;
        Vector3 endPos = startPos - new Vector3(0f, slideDistance, 0f);
        objectToSlide.DOAnchorPos3D(endPos, duration).SetEase(Ease.OutQuad);
    }
}
