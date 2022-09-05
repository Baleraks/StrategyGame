using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMove = true;
    public float panSpeed = 30f;
    public float panBorderThic = 10f;
    public float scrollSpeed = 5f;
    public float min = 10f;
    public float max = 80f;
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
            doMove = !doMove;
        if (!doMove)
            return;

        if(Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, min, max);
        transform.position = pos;

    }
}
