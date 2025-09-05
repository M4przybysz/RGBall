using UnityEngine;

public class Orb : MonoBehaviour
{
    GameObject player;
    [SerializeField] int colorValue = 0; // Value of one of RGB colours from 0 to 255;
    float minScale = 0.25f;
    float maxScale = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");

        SetSize();
        SetColor();
    }

    void SetSize()
    {
        float orbScale = minScale + (maxScale - minScale) / 255 * colorValue;
        transform.localScale = new Vector3(orbScale, orbScale, orbScale);
    }

    public virtual void SetColor()
    {
        GetComponent<Renderer>().material.color = new Color32((byte)colorValue, (byte)colorValue, (byte)colorValue, 255);
    }

    public virtual void ChanagePlayerAspect()
    {
        int playerColorR = (int)player.GetComponent<Renderer>().material.color.r * 255;
        int playerColorG = (int)player.GetComponent<Renderer>().material.color.g * 255;
        int playerColorB = (int)player.GetComponent<Renderer>().material.color.b * 255;

        playerColorR += colorValue;
        playerColorG += colorValue;
        playerColorB += colorValue;

        if (playerColorR > 255) { playerColorR = 255; }
        if (playerColorG > 255) { playerColorG = 255; }
        if (playerColorB > 255) { playerColorB = 255; }

        player.gameObject.GetComponent<Renderer>().material.color = new Color32((byte)playerColorR, (byte)playerColorG, (byte)playerColorB, 255);
    }
}
