using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EnterWorldPopupManager : MonoBehaviour
{
    // GameObject button;

    SoundManager soundManager;

    string clickSoundString = "click";

    EnterWorldEvent enterWorldEvent = new EnterWorldEvent();
    ZoomCameraEvent zoomCameraEvent = new ZoomCameraEvent();

    BoxCollider2D boxCollider;
    TMPro.TMP_Text textMeshPro;
    SpriteRenderer spriteRenderer;

    WorldRevealer worldRevealer;

    void Start()
    {
        // EventManager.AddEnterWorldInvoker(this);
        // EventManager.AddZoomCameraInvoker(this);
        soundManager = GameObject.FindGameObjectWithTag("generalSound").GetComponent<SoundManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        worldRevealer = transform.parent.parent.GetComponent<WorldRevealer>();

    }

    // Update is called once per frame

    /*
    /// <summary>
    /// add enter world event listener
    /// </summary>
    /// <param name="listener"></param>
    public void AddEnterWorldEvent(UnityAction<DestinationList.Worlds> listener)
    {
        enterWorldEvent.AddListener(listener);
    }

    /// <summary>
    /// add Zoom camera Event listener
    /// </summary>
    /// <param name="listener"></param>
    public void AddZoomCameraEvent(UnityAction<float> listener)
    {
        zoomCameraEvent.AddListener(listener);
    }
    */
    public void OnMouseDown()
    {
        PlaySoundViaBang(clickSoundString);
        print("clicked using OnMouseDown");
        worldRevealer.EnterWorld();
    }

    public bool SetButtonText(string text)
    {
        textMeshPro = transform.GetChild(0).GetChild(0).GetComponent<TMPro.TMP_Text>();
        textMeshPro.text = text;
        return true;
    }


    public void PlaySoundViaBang(string soundName)
    {
        soundManager.PlayClick();
    }
}
