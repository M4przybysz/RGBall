using UnityEngine;

public class RedOrb : Orb
{
    public override void SetColor()
    {
        GetComponent<Renderer>().material.color = new Color32((byte)colorValue, 0, 0, 255);
    }

    public override void ChanagePlayerAspect()
    {
        // Get player
        GameObject player = GameObject.Find("Player");

        // Get player material's RGB values
        int playerColorR = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.r * 255);
        int playerColorG = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.g * 255);
        int playerColorB = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.b * 255);

        // Add colorValue (red) to player material 
        playerColorR += colorValue;
        if (playerColorR > 255) { playerColorR = 255; }

        // Set new player material color
        player.GetComponent<Renderer>().material.color = new Color32((byte)playerColorR, (byte)playerColorG, (byte)playerColorB, 255);

        // Change player's speed force and max speed
        player.GetComponent<PlayerController>().RollingSpeedForce += 90f / 255f * colorValue;
        player.GetComponent<PlayerController>().MaxRollingSpeed += 240f / 255f * colorValue;
    }
}
