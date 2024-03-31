using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author[Judith Lopez]
 * Date[03/31/2024
 * camera movement for the player
 */

public class CameraScript : MonoBehaviour
{
    Vector2 MouseLook;
    Vector2 SmoothVect;
    public float sensitivity = 5f;
    public float smoothing = 2f;
    GameObject PlayerChar;

    // Start is called before the first frame update
    void Start()
    {
        PlayerChar = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        SmoothVect.x = Mathf.Lerp(SmoothVect.x, md.x, 1f / smoothing);
        SmoothVect.y = Mathf.Lerp(SmoothVect.y, md.y, 1f / smoothing);
        MouseLook += SmoothVect;
        transform.localRotation = Quaternion.AngleAxis(-MouseLook.y, Vector3.right);
        PlayerChar.transform.localRotation = Quaternion.AngleAxis(MouseLook.x, PlayerChar.transform.up);
    }
}