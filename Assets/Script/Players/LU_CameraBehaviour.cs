using UnityEngine;

public class LU_CameraBehaviour : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    [SerializeField] private float minZ = 10f;
    [SerializeField] private float maxZ = 50f; 
    [SerializeField] private float zoomFactor = 1.5f; 
    [SerializeField] private float smoothing = 0.1f; 

    public bool isClamped = true;

    private Vector3 velocity = Vector3.zero;
    public static Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        CharacterController controller1 = player1.GetComponent<CharacterController>();
        CharacterController controller2 = player2.GetComponent<CharacterController>();
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

        if (transform.position.z == maxZ)
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

    #region Bounds
    public static float Left
    {
        get
        {
            if (cam)
                return cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;

            if (Camera.main)
                return Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;

            return 0.0f;
        }
    }

    public static float Right
    {
        get
        {
            if (cam)
                return cam.ViewportToWorldPoint(new Vector3(1.0f, 0f, 0f)).x;

            if (Camera.main)
                return Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0f, 0f)).x;

            return 0.0f;
        }
    }
    #endregion

    public static void ConstrainCamera(Camera camera, Bounds bounds)
    {
        float left = cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        float right = cam.ViewportToWorldPoint(new Vector3(1.0f, 0f, 0f)).x;

        if (right > bounds.max.x)
        {
            float rightDiff = bounds.max.x - right;
            cam.transform.position += new Vector3(rightDiff, 0, 0);
        }
        else if (left < bounds.min.x)
        {
            float leftDiff = bounds.min.x - left;
            cam.transform.position += new Vector3(leftDiff, 0, 0);
        }
    }
}