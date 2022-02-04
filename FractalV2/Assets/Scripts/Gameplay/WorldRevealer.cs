using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRevealer : MonoBehaviour
{
    public GameObject worldHider;
    public GameObject hiddenWorld;

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
        hiderRenderer = worldHider.GetComponent<SpriteRenderer>();
        worldRenderer = hiddenWorld.GetComponent<SpriteRenderer>();
        hiderRenderer.color = visible;
        worldRenderer.color = invisible;
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
    }
    private void OnMouseDown() {
        
        if(state == WorldState.hidden || state == WorldState.hiding){
            state = WorldState.revealing;
            StartCoroutine(FadeWorld(state,alphaDuration));
        } else {
            state = WorldState.hiding;
            StartCoroutine(FadeWorld(state,alphaDuration));
        }
    }
}
