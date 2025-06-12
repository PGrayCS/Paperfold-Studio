using UnityEngine;

[ExecuteAlways]
public class ParallaxBackground : MonoBehaviour
{
    [Header("Background Layers (far to near)")]
    public Transform[] layers;
    [Header("Parallax Settings")]
    public float smoothing = 1f;

    private float[] parallaxScales;
    private Transform cam;
    private Vector3 previousCamPos;

    void Awake()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position;
    }

    void Start()
    {
        parallaxScales = new float[layers.Length];
        for (int i = 0; i < layers.Length; i++)
        {
            // Use z-position to determine parallax intensity
            parallaxScales[i] = layers[i].position.z * -1;
        }
    }

    void Update()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            float parallaxX = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            float targetX = layers[i].position.x + parallaxX;
            Vector3 targetPos = new Vector3(targetX, layers[i].position.y, layers[i].position.z);
            layers[i].position = Vector3.Lerp(layers[i].position, targetPos, smoothing * Time.deltaTime);
        }
        previousCamPos = cam.position;
    }
}
