using UnityEngine;

public class S_GlobalVars : MonoBehaviour
{
    // Boolean variables to represent the garments
    public bool Garment1;
    public bool Garment2;
    public bool Garment3;
    public bool Garment4;

    // Reset the variables to false on Start
    void Start()
    {
        ResetGarments();
    }

    // Function to reset all garment variables
    public void ResetGarments()
    {
        Garment1 = false;
        Garment2 = false;
        Garment3 = false;
        Garment4 = false;
        Debug.Log("All garments reset to false.");
    }
}