using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    [SerializeField] private float minZ = 10f;
    [SerializeField] private float maxZ = 50f; 
    [SerializeField] private float zoomFactor = 1.5f; 
    [SerializeField] private float smoothing = 0.1f; 

    public bool isClamped = true;

    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 middle = (player1.transform.position + player2.transform.position) * 0.5f;
        float distance = Vector3.Distance(player1.transform.position, player2.transform.position);

        float halfFOV = cam.fieldOfView * 0.5f * Mathf.Deg2Rad;
        float screenAspect = cam.aspect;
        float distanceToFit = distance / (2f * Mathf.Tan(halfFOV)) / screenAspect;

        float targetZ = Mathf.Max(minZ, distanceToFit);
        targetZ = Mathf.Clamp(targetZ, minZ, maxZ);

        if (transform.position.z == minZ || transform.position.z == maxZ)
        {
            isClamped = true;
        }
        else
        {
            isClamped = false;
        }

        Vector3 targetPosition = new Vector3(middle.x, middle.y, -targetZ);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing);
    }
}