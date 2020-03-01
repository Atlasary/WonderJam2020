using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float posMin, posMax;
    public bool isScrollVertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isScrollVertical)
        {
            if (Input.mousePosition.y > 0.8f * Screen.height && transform.position.y < posMax)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 7f * (0.5f - (Screen.height - Mathf.Min(Input.mousePosition.y, Screen.height)) / Screen.height));
            }
            else if (Input.mousePosition.y < 0.2f * Screen.height && transform.position.y > posMin)
            {
                transform.Translate(Vector3.down * Time.deltaTime * 7f * (0.5f - (Screen.height - Mathf.Min(Screen.height - Input.mousePosition.y, Screen.height)) / Screen.height));
            }
        }
        else
        {
            if (Input.mousePosition.x > 0.8f * Screen.width && transform.position.x < posMax)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 12f * (0.5f - (Screen.width - Mathf.Min(Input.mousePosition.x, Screen.width)) / Screen.width));
            }
            else if (Input.mousePosition.x < 0.2f * Screen.width && transform.position.x > posMin)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 12f * (0.5f - (Screen.width - Mathf.Min(Screen.width - Input.mousePosition.x, Screen.width)) / Screen.width));
            }
        }
        
    }
}
