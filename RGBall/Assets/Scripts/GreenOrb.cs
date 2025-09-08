using UnityEngine;

public class GreenOrb : Orb
{
    public override void SetColor()
    {
        GetComponent<Renderer>().material.color = new Color32(0, (byte)colorValue, 0, 255);
    }

    public override void ChanagePlayerAspect()
    {
        // Get player
        GameObject player = GameObject.Find("Player");

        // Get player material's RGB values
        int playerColorR = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.r * 255);
        int playerColorG = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.g * 255);
        int playerColorB = Mathf.RoundToInt(player.GetComponent<Renderer>().material.color.b * 255);

        // Add colorValue (green) to player material
        playerColorG += colorValue;
        if (playerColorG > 255) { playerColorG = 255; }

        // Set new player material color
        player.GetComponent<Renderer>().material.color = new Color32((byte)playerColorR, (byte)playerColorG, (byte)playerColorB, 255);

        // Change player's scale
        if (player.GetComponent<PlayerController>().ColorInvertion)
        {
            // Reduce scale when colors are inverted
            float scaleStep = (PlayerController.normalScale - PlayerController.minScale) / 255f;
            player.GetComponent<PlayerController>().ScaleBall(PlayerController.normalScale - scaleStep * playerColorG);
        }
        else
        {
            // Increase scale when colors are inverted
            float scaleStep = (PlayerController.maxScale - PlayerController.normalScale) / 255f;
            player.GetComponent<PlayerController>().ScaleBall(PlayerController.normalScale + scaleStep * playerColorG);
        }
    }
}
