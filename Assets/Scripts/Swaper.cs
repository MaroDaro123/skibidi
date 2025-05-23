using UnityEngine;
using System.Collections.Generic;
using Unity.Cinemachine;
public class Swaper : MonoBehaviour
{
    public Transform character;
    public List<Transform> possibleCharacters;
    public int which;
    public GameObject camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }
        Swap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (which == 0)
            {
                which = possibleCharacters.Count - 1;
            }
            else
            {
                which -= 1;
            }
            Swap();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (which == possibleCharacters.Count - 1)
            {
                which = 0;
            }
            else
            {
                which += 1;
            }
            Swap();
        }
        
    }

    public void Swap()
    {
       
        character = possibleCharacters[which];
        camera.GetComponent<CinemachineCamera>().Follow = character;
        character.GetComponent<Plyer>().enabled = true;
        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<Plyer>().enabled = false;
            }
        }
    }
}
