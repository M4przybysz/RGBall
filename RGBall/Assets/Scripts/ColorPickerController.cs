using TMPro;
using UnityEngine;

public class ColorPickerController : MonoBehaviour
{
    public Vector3 colorValue;
    [SerializeField] MonoBehaviour elementToActivate;
    IActivatable activatable;
    GameObject pickPlate;
    GameObject colorValueText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activatable = elementToActivate as IActivatable;

        pickPlate = transform.GetChild(0).gameObject;
        colorValueText = transform.GetChild(1).gameObject;

        colorValueText.GetComponent<TextMeshPro>().text = "R: " + colorValue.x + "\nG: " + colorValue.y + "\nB: " + colorValue.z;
    }

    public void PickColor()
    {
        pickPlate.GetComponent<Renderer>().material.color = new Color32((byte)colorValue.x, (byte)colorValue.y, (byte)colorValue.z, 255);
        colorValueText.SetActive(false);
        activatable.Activate();
    }
}

public interface IActivatable
{
    void Activate();
}