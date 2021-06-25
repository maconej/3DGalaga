using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float forwardSpeed = 25f, latSpeed = 10f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeLatSpeed, activeHoverSpeed;
    private float forwardAccel = 2.5f, latAccel = 2f, hoverAccel = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAccel * Time.deltaTime);
        activeLatSpeed = Mathf.Lerp(activeLatSpeed, Input.GetAxisRaw("Horizontal") * latSpeed, latAccel * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAccel *  Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeLatSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

        
    }
}
