using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ColorPickerController : MonoBehaviour
{
    public Vector3 colorValue;
    [SerializeField] List<MonoBehaviour> elementsToActivate;
    List<IActivatable> activatables;
    GameObject pickPlate;
    GameObject colorValueText;
    BoxCollider boxCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();

        activatables = elementsToActivate.Cast<IActivatable>().ToList();

        pickPlate = transform.GetChild(0).gameObject;
        colorValueText = transform.GetChild(1).gameObject;

        colorValueText.GetComponent<TextMeshPro>().text = "R: " + colorValue.x + "\nG: " + colorValue.y + "\nB: " + colorValue.z;
    }

    public void PickColor()
    {
        boxCollider.enabled = false;
        
        pickPlate.GetComponent<Renderer>().material.color = new Color32((byte)colorValue.x, (byte)colorValue.y, (byte)colorValue.z, 255);
        colorValueText.SetActive(false);

        foreach (IActivatable activatable in activatables)
        {        
            activatable.Activate();
        }
    }
}

public interface IActivatable
{
    void Activate();
}