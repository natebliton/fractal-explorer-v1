using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WorldRevealer : MonoBehaviour
{
    [SerializeField]
    private GameObject hiddenWorld;

    [SerializeField]
    private WorldList.Worlds destinationWorld;

    EnterWorldEvent enterWorldEvent = new EnterWorldEvent();

    SpriteRenderer hiderRenderer;
    SpriteRenderer worldRenderer;

    bool hiding = true;
    
    Color visible = new Color(255, 255, 255, 255);
    Color invisible = new Color(255, 255, 255, 0);

    float worldAlpha = 0.0f;
    public float alphaDuration = 1.0f;

    WorldState state = WorldState.hidden;

    enum WorldState {
        hidden,
        hiding,
        revealing,
        revealed
    }
    // Start is called before the first frame update
    void Start()
    {
        hiderRenderer = GetComponent<SpriteRenderer>();
        worldRenderer = hiddenWorld.GetComponent<SpriteRenderer>();
        hiderRenderer.color = visible;
        worldRenderer.color = invisible;

        EventManager.AddEnterWorldInvoker(this);
    }

    // Update is called once per frame
    void Update()
    { 

    }

    IEnumerator FadeWorld(WorldState wState, float aTime)
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
            hiderRenderer.color = newHiderColor;
            
            yield return null;
        }
        state = endState;

        enterWorldEvent.Invoke(destinationWorld);
    }
    private void OnMouseDown() {
        if(state == WorldState.hidden || state == WorldState.hiding){
            state = WorldState.revealing; 
        } else {
            state = WorldState.hiding;
        }
        updateDisplay();
    }

    /// <summary>
    /// When Player flies over object hiding a world, 
    /// this toggles whether its world is revealed
    /// </summary>
    /// <param name="coll"></param>
    private void OnTriggerEnter2D(Collider2D coll) {
        if(state == WorldState.hidden || state == WorldState.hiding){
            state = WorldState.revealing; 
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
    public void AddEnterWorldEvent(UnityAction<WorldList.Worlds> listener)
    {
        enterWorldEvent.AddListener(listener);
    }

}
