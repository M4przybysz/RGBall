using UnityEngine;

public class BlueOrb : Orb
{
    public override void SetColor()
    {
        GetComponent<Renderer>().material.color = new Color32(0, 0, (byte)colorValue, 255);
    }

    public override void ChanagePlayerAspect()
    {
        // Get player
        GameObject player = GameObject.Find("Player");

        // Get player material's RGB values
        int playerColorR = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.r * 255);
        int playerColorG = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.g * 255);
        int playerColorB = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.b * 255);

        // Add colorValue (blue) to player material
        playerColorB += colorValue;
        if (playerColorB > 255) { playerColorB = 255; }

        // Set new player material color
        player.GetComponent<Renderer>().material.color = new Color32((byte)playerColorR, (byte)playerColorG, (byte)playerColorB, 255);

        player.GetComponent<PlayerController>().ExtraBounceForce = 1500f + 3500f / 255f * colorValue;
    }
}
