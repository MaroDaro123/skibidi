using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Material EnabledColor;
    [SerializeField] private Material DisabledColor;
    [SerializeField] private MeshRenderer plateRenderer;
    [SerializeField] string CubeTag;
    private Collider ActivationArea;
    private List<GameObject> cubesOnPlate = new();
    private bool pressed = false;

    public static int pressurePlateCount;

    void Start()
    {
        ActivationArea = GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag(CubeTag))
        {
            cubesOnPlate.Add(other.gameObject);
        }
        EnablePressurePlate();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(CubeTag))
        {
            cubesOnPlate.Remove(other.gameObject);
        }
        if (cubesOnPlate.Count == 0) DisablePressurePlate();
    }
    void EnablePressurePlate()
    {
        plateRenderer.material = EnabledColor;
        plateRenderer.gameObject.transform.localPosition = new(0, 0.1f, 0);
        if (!pressed)
        {
            pressed = true;
            pressurePlateCount += 1;
            gamanager.Instance.PressurePlatePressed();
        }
    }
    void DisablePressurePlate()
    {
        plateRenderer.material = DisabledColor;
        plateRenderer.gameObject.transform.localPosition = new(0, 0.4f, 0);
        pressed = false;
        pressurePlateCount -= 1;
    }
}