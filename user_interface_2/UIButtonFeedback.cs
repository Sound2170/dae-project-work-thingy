using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(AudioSource))]
public class UIButtonFeedback : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    [Header("Visual")]
    public Color normalColor  = Color.white;
    public Color hoverColor   = Color.cyan;
    public Color pressedColor = Color.gray;
    public Vector3 normalScale = Vector3.one;
    public Vector3 hoverScale  = Vector3.one * 1.05f;
    public float   tweenTime   = 0.1f;

    [Header("Audio")]
    public AudioClip hoverSound;
    public AudioClip clickSound;

    Image       img;
    AudioSource src;
    bool        isPointerOver;

    void Awake()
    {
        img = GetComponent<Image>();
        src = GetComponent<AudioSource>();
        img.color = normalColor;
        transform.localScale = normalScale;
    }

    public void OnPointerEnter(PointerEventData e)
    {
        isPointerOver = true;
        img.color = hoverColor;
        StopAllCoroutines();
        StartCoroutine(ScaleTo(hoverScale));
        if (hoverSound) src.PlayOneShot(hoverSound);
    }

    public void OnPointerExit(PointerEventData e)
    {
        isPointerOver = false;
        img.color = normalColor;
        StopAllCoroutines();
        StartCoroutine(ScaleTo(normalScale));
    }

    public void OnPointerDown(PointerEventData e)
    {
        img.color = pressedColor;
        StopAllCoroutines();
        StartCoroutine(ScaleTo(normalScale * 0.95f));
        if (clickSound) src.PlayOneShot(clickSound);
    }

    public void OnPointerUp(PointerEventData e)
    {
        img.color = isPointerOver ? hoverColor : normalColor;
        StopAllCoroutines();
        StartCoroutine(ScaleTo(isPointerOver ? hoverScale : normalScale));
    }

    System.Collections.IEnumerator ScaleTo(Vector3 target)
    {
        var start = transform.localScale;
        float t = 0;
        while (t < tweenTime)
        {
            transform.localScale = Vector3.Lerp(start, target, t / tweenTime);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localScale = target;
    }
}
