using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleManager : MonoBehaviour
{
    public Text type1Text;  // Reference to the Text object for Type 1 collectibles
    public Text type2Text;  // Reference to the Text object for Type 2 collectibles
    public GameObject door;
    public int typeOneTotal = 0;
    public int typeTwoTotal = 0;

    private int type1Count = 0;
    private int type2Count = 0;

    void Start()
    {
        // Initialize the UI with initial values
        UpdateUI();
    }

    // Method to increment Type 1 collectible count
    public void IncrementType1Count()
    {
        type1Count++;
        typeOneTotal = type1Count;
        UpdateUI();  // Update the UI whenever count changes
        CheckForDoorActivation();
    }

    // Method to increment Type 2 collectible count
    public void IncrementType2Count()
    {
        type2Count++;
        typeTwoTotal = type2Count;
        UpdateUI();  // Update the UI whenever count changes
        CheckForDoorActivation();
    }

    // Method to update the UI with current counts
    private void UpdateUI()
    {
        type1Text.text = "" + type1Count;
        type2Text.text = "" + type2Count;
    }

    private void CheckForDoorActivation()
    {
        Debug.Log("door activation called");
        if(typeOneTotal == 2 && typeTwoTotal == 2)
        {
            door.SetActive(true);
        }
    }
}
