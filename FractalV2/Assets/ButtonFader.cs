using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFader : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    Image image;

    public int min = 100;
    public int max = 200;
    public int increment = 5;

    private int direction = 1;
    public int alpha = 0;

    private bool isSprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
        if (spriteRenderer == null )
        {
            isSprite = false;
        } else
        {
            isSprite = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        alpha = alpha + (increment * direction);
        if(alpha < min)
        {
            alpha = min;
            direction = 1;
        }
        else if(alpha > max)
        {
            alpha = max;
            direction = -1;
        }
        // Color color = new Color(1f, 1f, 1f, alpha/255f);

        //Color color = new Color(1f,1f,1f,0.5f);
        //spriteRenderer.color = color;
        SetColor(alpha);
    }

    private void SetColor(float alpha)
    {
        if (isSprite)
        {
            spriteRenderer.color = new UnityEngine.Color(1f, 1f, 1f, alpha / 255f);
        }
        else
        {
            image.color = new UnityEngine.Color(1f, 1f, 1f, alpha / 255f);
        }
    }
}
