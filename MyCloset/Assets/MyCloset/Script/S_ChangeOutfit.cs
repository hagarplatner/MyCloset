using UnityEngine;

public class S_ChangeOutfit : MonoBehaviour
{
    // Reference to the S_GlobalVars script
    private S_GlobalVars globalVars;

    // GameObjects for the garments
    public GameObject Garment1Object;
    public GameObject Garment2Object;
    public GameObject Garment3Object;
    public GameObject Garment4Object;

    // Track the previous states of the global variables
    private bool previousGarment1State;
    private bool previousGarment2State;
    private bool previousGarment3State;
    private bool previousGarment4State;

    public void SetStartClothes()
    {
        Debug.Log("HAGAR");
        
        // Get the S_GlobalVars component from the parent object
        globalVars = GetComponentInParent<S_GlobalVars>();

        if (globalVars == null)
        {
            Debug.LogError("S_GlobalVars script not found on parent object!");
            return;
        }

        // Initialize previous states and set initial visibility
        previousGarment1State = globalVars.Garment1;
        Debug.Log(previousGarment1State);
        previousGarment2State = globalVars.Garment2;
        Debug.Log(previousGarment2State);
        previousGarment3State = globalVars.Garment3;
        Debug.Log(previousGarment3State);
        previousGarment4State = globalVars.Garment4;
        Debug.Log(previousGarment4State);

        UpdateGarmentVisibility();
    }

    void Update()
    {
        if (globalVars != null)
        {
            //Debug.Log("globalVars != null");
            // Check if any global variable has changed
            if (globalVars.Garment1 != previousGarment1State)
            {
                ToggleGarment1(globalVars.Garment1);
                previousGarment1State = globalVars.Garment1;
                Debug.Log("Var is " + globalVars.Garment1);
            }
            if (globalVars.Garment2 != previousGarment2State)
            {
                ToggleGarment2(globalVars.Garment2);
                previousGarment2State = globalVars.Garment2;
                Debug.Log("Var is " + globalVars.Garment2);
            }
            if (globalVars.Garment3 != previousGarment3State)
            {
                ToggleGarment3(globalVars.Garment3);
                previousGarment3State = globalVars.Garment3;
                Debug.Log("Var is " + globalVars.Garment3);
            }
            if (globalVars.Garment4 != previousGarment4State)
            {
                ToggleGarment4(globalVars.Garment4);
                previousGarment4State = globalVars.Garment4;
                Debug.Log("Var is " + globalVars.Garment4);
            }
        }
        if (globalVars == null)
        {
            //Debug.Log("globalVars == null");
        }
    }

    // Method to update the visibility based on the global variables
    void UpdateGarmentVisibility()
    {
        if (globalVars != null)
        {
            Garment1Object.SetActive(globalVars.Garment1);
            Garment2Object.SetActive(globalVars.Garment2);
            Garment3Object.SetActive(globalVars.Garment3);
            Garment4Object.SetActive(globalVars.Garment4);
        }
    }

    // Methods to toggle specific garments
    public void ToggleGarment1(bool isVisible)
    {
        Garment1Object.SetActive(isVisible);
    }

    public void ToggleGarment2(bool isVisible)
    {
        Garment2Object.SetActive(isVisible);
    }

    public void ToggleGarment3(bool isVisible)
    {
        Garment3Object.SetActive(isVisible);
    }

    public void ToggleGarment4(bool isVisible)
    {
        Garment4Object.SetActive(isVisible);
    }
}
