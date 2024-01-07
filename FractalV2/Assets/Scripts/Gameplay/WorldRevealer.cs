using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WorldRevealer : MonoBehaviour
{
    [SerializeField]
    private GameObject hiddenWorld;

    [SerializeField]
    private DestinationList.Worlds destinationWorld;

    EnterWorldEvent enterWorldEvent = new EnterWorldEvent();
    ZoomCameraEvent zoomCameraEvent = new ZoomCameraEvent();

    SpriteRenderer hiderRenderer;
    SpriteRenderer worldRenderer;

    bool readyToVisit = true;
    
    Color visible = new Color(255, 255, 255, 255);
    Color invisible = new Color(255, 255, 255, 0);

    float worldAlpha = 0.0f;
    public float alphaDuration = 1.0f;

    [SerializeField]
    private WorldState state;

    GameObject enterWorldPopup;

    private enum WorldState {
        hidden,
        hiding,
        revealing,
        revealed,
        notReadyToVisit
    }
    // Start is called before the first frame update
    void Start()
    {
        hiddenWorld = this.transform.GetChild(0).gameObject;
        hiderRenderer = GetComponent<SpriteRenderer>();
        worldRenderer = hiddenWorld.GetComponent<SpriteRenderer>();
        hiderRenderer.color = visible;
        worldRenderer.color = invisible;

        // enterWorldPopup = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        // enterWorldPopup.SetActive(false);
        EventManager.AddEnterWorldInvoker(this);
        EventManager.AddZoomCameraInvoker(this);
    }

    // Update is called once per frame
    void Update()
    { 

    }

    IEnumerator FadeWorld(WorldState wState, float aTime)
    {
        // enterWorldPopup.SetActive(wState == WorldState.revealed);
        if(wState != WorldState.revealed) {
            //enterWorldPopup = (GameObject)Instantiate(Resources.Load("EnterWorldPopup"),this.transform,instantiateInWorldSpace:false);
            //if( enterWorldPopup.GetComponent<EnterWorldPopupManager>().SetButtonText("enter world?"))
            //{
              //  print("should have updated text");
           // }
            // enterWorldPopup.GetComponent<EnterWorldPopupManager>().SetText("Enter World?");
            // enterWorldPopup.SetActive(false);
        } else
        {
            Destroy(enterWorldPopup);
        }
        float aValue = 0f;
        WorldState endState = WorldState.hidden;

        if(wState == WorldState.revealing) {
            aValue = 1f;
            endState = WorldState.revealed;
        }
        
        print("Fading to " + wState);

       // float alpha = transform.renderer.material.color.a;
        float alpha = worldRenderer.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            float newAlpha = Mathf.Lerp(alpha,aValue,t);
            Color newWorldColor = new Color(1, 1, 1, newAlpha);
            Color newHiderColor = new Color(1, 1, 1, 1-newAlpha);
            worldRenderer.color = newWorldColor;
            // hiderRenderer.color = newHiderColor; // leaving hider renderer always visible for now
            
            yield return null;
        }
        state = endState;
        // enterWorldPopup.SetActive(state == WorldState.revealed);
        if(state != WorldState.revealed) {
            Destroy(enterWorldPopup);
        }
        else
        {
            enterWorldPopup = (GameObject)Instantiate(Resources.Load("EnterWorldPopup"), this.transform, instantiateInWorldSpace: false);
            if (enterWorldPopup.GetComponent<EnterWorldPopupManager>().SetButtonText("enter world?"))
            {
                print("should have updated text");
            }
        }
    }

    public void EnterWorld()
    {
        print("in enterWorld");
        if(destinationWorld != DestinationList.Worlds.NULL){
            print("should be entering");
            enterWorldEvent.Invoke(destinationWorld);
            zoomCameraEvent.Invoke(0.95f);
        }
    }

    IEnumerator EnterWorld(WorldState wState, float aTime)
    {

    //     float aValue = 0f;
    //     WorldState endState = WorldState.hidden;

    //     if(wState == WorldState.revealing) {
    //         aValue = 1f;
    //         endState = WorldState.revealed;
    //     }
        
    //     print("Fading to " + wState);

    //    // float alpha = transform.renderer.material.color.a;
    //     float alpha = worldRenderer.color.a;
    //     for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
    //     {
    //         float newAlpha = Mathf.Lerp(alpha,aValue,t);
    //         Color newWorldColor = new Color(1, 1, 1, newAlpha);
    //         Color newHiderColor = new Color(1, 1, 1, 1-newAlpha);
    //         worldRenderer.color = newWorldColor;
    //         // hiderRenderer.color = newHiderColor; // leaving hider renderer always visible for now
            
    //         yield return null;
    //     }
    //     state = endState;
        if(destinationWorld != DestinationList.Worlds.NULL){
            enterWorldEvent.Invoke(destinationWorld);
            zoomCameraEvent.Invoke(0.95f);
        }
        yield return null;
    }
    IEnumerator FadeWorldOld(WorldState wState, float aTime)
    {

        float aValue = 0f;
        WorldState endState = WorldState.hidden;

        if(wState == WorldState.revealing) {
            aValue = 1f;
            endState = WorldState.revealed;
        }
        
        print("Fading to " + wState);

       // float alpha = transform.renderer.material.color.a;
        float alpha = worldRenderer.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            float newAlpha = Mathf.Lerp(alpha,aValue,t);
            Color newWorldColor = new Color(1, 1, 1, newAlpha);
            Color newHiderColor = new Color(1, 1, 1, 1-newAlpha);
            worldRenderer.color = newWorldColor;
            // hiderRenderer.color = newHiderColor; // leaving hider renderer always visible for now
            
            yield return null;
        }
        state = endState;
        if(destinationWorld != DestinationList.Worlds.NULL){
            enterWorldEvent.Invoke(destinationWorld);
            zoomCameraEvent.Invoke(0.95f);
        }
    }
    private void OnMouseDown() {
        //if(state == WorldState.hidden || state == WorldState.hiding){
        //    state = WorldState.revealing; 
        //} else {
        //    state = WorldState.hiding;
        //}
        //updateDisplay();
    }

    /// <summary>
    /// When Player flies over object hiding a world, 
    /// this toggles whether its world is revealed
    /// </summary>
    /// <param name="coll"></param>
    private void OnTriggerEnter2D(Collider2D coll) {
        if (readyToVisit)
        {
            if (state == WorldState.hidden || state == WorldState.hiding)
            {
                state = WorldState.revealing;
            }
            updateDisplay();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!(state == WorldState.hidden || state == WorldState.hiding))
        {
            state = WorldState.hiding;
        }
        updateDisplay();
    }
    private void updateDisplay() {
        StartCoroutine(FadeWorld(state,alphaDuration));
    }

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

}
