using UnityEngine;
using UnityEngine.InputSystem;
public class Plyer : MonoBehaviour
{
    Vector3 mof;
    public float speed = 5f;
    public float rotateSpeed = 25f;
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void OnMove(InputValue input)
    {
        Vector2 vektor = input.Get<Vector2>();
        mof = new Vector3(vektor.x, 0, vektor.y);
    }


    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * mof.z * Time.deltaTime * speed,Space.Self) ;
        transform.Rotate(Vector3.up * mof.x * Time.deltaTime * rotateSpeed);
    }
    
}
