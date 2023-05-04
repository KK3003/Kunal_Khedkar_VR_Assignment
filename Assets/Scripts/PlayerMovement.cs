using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject pointerPrefab;
    public float moveSpeed = 5.0f;

    private Camera mainCamera;
    private GameObject pointer;
    private RaycastHit hit;
    private bool isMoving;
    private Vector3 targetPosition;

    void Start()
    {
        mainCamera = Camera.main;
        pointer = Instantiate(pointerPrefab);
        pointer.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                pointer.SetActive(true);
                pointer.transform.position = hit.point;
                pointer.transform.up = hit.normal;
                targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                isMoving = true;
            }
        }

        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            pointer.SetActive(false);
        }
    }
}


