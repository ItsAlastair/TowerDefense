using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float h;
    private float v;

    public float moveSpeed = 10;
    public float scrollSpeed = 10;
    public float rotateSpeed = 10;

    float maxX;
    float maxY;

    private void Update()
    {
        if(GameManager.GM.levelSize == 1)
        {
            maxX = maxY = 30;
        }
        if (GameManager.GM.levelSize == 2)
        {
            maxX = maxY = 80;
        }
        if (GameManager.GM.levelSize == 3)
        {
            maxX = maxY = 120;
        }

        //Rotate
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * 10 * rotateSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 10 * rotateSpeed, Space.World);
        }



        //Move
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.Self);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxX, maxX), transform.position.y ,  Mathf.Clamp(transform.position.z, -maxY, maxY));



        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * Time.deltaTime * 100 * scrollSpeed;
        pos.y = Mathf.Clamp(pos.y, 10f, 50f);
        transform.position = pos;
    }
}
