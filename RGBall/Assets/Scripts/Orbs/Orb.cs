using UnityEngine;

public class Orb : MonoBehaviour
{
    public int colorValue = 0; // Value of one of RGB colours from 0 to 255;
    float minScale = 0.25f;
    float maxScale = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        // Get player
        GameObject player = GameObject.Find("Player");

        // Get player material's RGB values
        int playerColorR = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.r * 255);
        int playerColorG = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.g * 255);
        int playerColorB = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.b * 255);

        playerColorR += colorValue; // Add colorValue (red) to player material
        playerColorG += colorValue; // Add colorValue (green) to player material
        playerColorB += colorValue; // Add colorValue (blue) to player material

        // Check for overflow
        if (playerColorR > 255) { playerColorR = 255; }
        if (playerColorG > 255) { playerColorG = 255; }
        if (playerColorB > 255) { playerColorB = 255; }

        // Set new player material color
        player.GetComponent<Renderer>().material.color = new Color32((byte)playerColorR, (byte)playerColorG, (byte)playerColorB, 255);
    }
}
