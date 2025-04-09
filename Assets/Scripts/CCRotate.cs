using UnityEngine;

public class CCRotate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("RotateObject", 0.1f);
    }

    void RotateObject()
    {
        transform.Rotate(0, 0, 1);
    }
}
