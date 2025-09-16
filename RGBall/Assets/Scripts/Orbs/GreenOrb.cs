using UnityEngine;

// INHERITANCE
public class GreenOrb : Orb
{
    // POLYMORPHISM
    public override void SetColor()
    {
        GetComponent<Renderer>().material.color = new Color32(0, (byte)colorValue, 0, 255);
    }

    // POLYMORPHISM
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

        // Update UI
        UI.GetComponent<UIManager>().UpdateRGB(new Vector3(playerColorR, playerColorG, playerColorB));

        // Change player's scale
        float scaleStep;

        if (player.GetComponent<PlayerController>().ColorInvertion)
        {
            scaleStep = -1 * (PlayerController.normalScale - PlayerController.minScale) / 255f; // Reduce scale when colors are inverted
        }
        else
        {
            scaleStep = (PlayerController.maxScale - PlayerController.normalScale) / 255f; // Increase scale when colors are inverted
        }

        player.GetComponent<PlayerController>().ScaleBall(PlayerController.normalScale + scaleStep * playerColorG);
    }
}
