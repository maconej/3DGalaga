using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float forwardSpeed = 25f, latSpeed = 10f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeLatSpeed, activeHoverSpeed;
    private float forwardAccel = 2.5f, latAccel = 2f, hoverAccel = 2f;

    public float rotateSpeed = 80f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        transform.Rotate(-mouseDistance.y * rotateSpeed * Time.deltaTime, mouseDistance.x * rotateSpeed * Time.deltaTime, 0f, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAccel * Time.deltaTime);
        activeLatSpeed = Mathf.Lerp(activeLatSpeed, Input.GetAxisRaw("Horizontal") * latSpeed, latAccel * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAccel *  Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeLatSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

        
    }
}
