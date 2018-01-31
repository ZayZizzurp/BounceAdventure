using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private Vector3 startingPosition;
    private Vector3 offset;
    private Vector3 releasePosition;
    public Rigidbody2D rb;
    public float magnitudeY;
    public float magnitudeX;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}

    /// <summary>
    /// This is a Unity defined function that is called whenever the mouse is clicked
    /// </summary>
    void OnMouseDown()
    {
        startingPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                                                            Input.mousePosition.y, 
                                                                                            startingPosition.z));
        rb.velocity = new Vector2(0, 0);
    }

    /// <summary>
    /// This is a Unity defined function that is called whenever we click and drag the mouse
    /// </summary>
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, startingPosition.z);
          
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

      

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUp()
    {
        releasePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, startingPosition.z);

        float magnitudeX = startingPosition.x - releasePosition.x;
        float magnitudeY = startingPosition.y - releasePosition.y;

        rb.AddForce(new Vector2(magnitudeX, magnitudeY));
    }

}