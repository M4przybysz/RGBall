using TMPro;
using UnityEngine;

public class ColorfulGateController : MonoBehaviour
{
    [SerializeField] Vector3 colorValue;
    GameObject colorfulWall;
    GameObject colorValueText1, colorValueText2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colorfulWall = transform.GetChild(1).gameObject;
        colorValueText1 = transform.GetChild(2).gameObject;
        colorValueText2 = transform.GetChild(3).gameObject;

        // Set gate color and text value
        colorfulWall.GetComponent<Renderer>().material.color = new Color32((byte)colorValue.x, (byte)colorValue.y, (byte)colorValue.z, 200);
        colorValueText1.GetComponent<TextMeshPro>().text = "R: " + colorValue.x + " | G: " + colorValue.y + " | B: " + colorValue.z;
        colorValueText2.GetComponent<TextMeshPro>().text = "R: " + colorValue.x + " | G: " + colorValue.y + " | B: " + colorValue.z;
    }

    public void checkPlayerColor(Vector3 color)
    {
        // Open or close the gate depending on the player's color
        if (colorValue.x == color.x && colorValue.y == color.y && colorValue.z == color.z)
        {
            colorfulWall.GetComponent<BoxCollider>().isTrigger = true;
        }
        else
        {
            colorfulWall.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
