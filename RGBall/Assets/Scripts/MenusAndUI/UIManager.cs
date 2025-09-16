using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    TextMeshProUGUI colorInvertionText;
    TextMeshProUGUI colorRText;
    TextMeshProUGUI colorGText;
    TextMeshProUGUI colorBText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colorInvertionText = GameObject.Find("ColorInvertion").GetComponent<TextMeshProUGUI>();
        colorRText = GameObject.Find("ColorR").GetComponent<TextMeshProUGUI>();
        colorGText = GameObject.Find("ColorG").GetComponent<TextMeshProUGUI>();
        colorBText = GameObject.Find("ColorB").GetComponent<TextMeshProUGUI>();

        // Set starting UI values
        UpdateRGB(new Vector3(0, 0, 0));
        UpdateInvertion(false);
    }

    public void UpdateRGB(Vector3 color)
    {
        // Set new RGB UI colors
        colorRText.color = new Color32((byte)color.x, 0, 0, 255);
        colorGText.color = new Color32(0, (byte)color.y, 0, 255);
        colorBText.color = new Color32(0, 0, (byte)color.z, 255);

        // Set new RGB UI text
        colorRText.text = "R: " + color.x;
        colorGText.text = "G: " + color.y;
        colorBText.text = "B: " + color.z;
    }

    public void UpdateInvertion(bool invertion)
    {
        if (invertion)
        {
            colorInvertionText.color = Color.white;
            colorInvertionText.text = "(-)";
        }
        else
        {
            colorInvertionText.color = Color.black;
            colorInvertionText.text = "(+)";
        }
    }
}
