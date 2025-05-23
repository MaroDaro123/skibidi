using UnityEngine;

public class gamanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [HideInInspector]public static gamanager Instance;
    public GameObject wall;
    public int currentplates => PressurePlate.pressurePlateCount;
    [SerializeField] private int requiredPressurePlates = 3;
    void Start()
    {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void PressurePlatePressed()
    {
        if (PressurePlate.pressurePlateCount >= requiredPressurePlates) wall.SetActive(false);
        
        else wall.SetActive(true);
    }
}
