using UnityEngine;

// INHERITANCE
public class BlueOrb : Orb
{
    // POLYMORPHISM
    public override void SetColor()
    {
        GetComponent<Renderer>().material.color = new Color32(0, 0, (byte)colorValue, 255);
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

        // Add colorValue (blue) to player material
        playerColorB += colorValue;
        if (playerColorB > 255) { playerColorB = 255; }

        // Set new player material color
        player.GetComponent<Renderer>().material.color = new Color32((byte)playerColorR, (byte)playerColorG, (byte)playerColorB, 255);

        // Update UI
        UI.GetComponent<UIManager>().UpdateRGB(new Vector3(playerColorR, playerColorG, playerColorB));

        // Change player's bounciness
        float extraBounceStep;
        float bouncinessStep;

        if (player.GetComponent<PlayerController>().ColorInvertion)
        {
            // Reduce bounce when colors are inverted
            extraBounceStep = -1 * (PlayerController.normalExtraBounceForce - PlayerController.minExtraBounceForce) / 255f;
            bouncinessStep = -1 * (PlayerController.normalBounciness - PlayerController.minBounciness) / 255f;
        }
        else
        {
            // Increase bounce when colors are inverted
            extraBounceStep = (PlayerController.maxExtraBounceForce - PlayerController.normalExtraBounceForce) / 255f;
            bouncinessStep = (PlayerController.maxBounciness - PlayerController.normalBounciness) / 255f;
        }

        player.GetComponent<PlayerController>().ExtraBounceForce = PlayerController.normalExtraBounceForce + extraBounceStep * playerColorB;
        player.GetComponent<PlayerController>().Bounciness = PlayerController.normalBounciness + bouncinessStep * playerColorB;
    }
}
