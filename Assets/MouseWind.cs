using UnityEngine;

public class MouseWind : MonoBehaviour
{

    [SerializeField]
    private Camera mainCam;

    [SerializeField]
    private int emissionRate = 100;

    [SerializeField]
    private int windForce = 100;

    private ParticleSystem.EmissionModule emmissionController;
    private ParticleSystem.CollisionModule collisionController;

    private ParticleSystem wind;

    private void Awake()
    {
        wind = GetComponent<ParticleSystem>();
        
    }

    private void Start()
    {
        emmissionController = wind.emission;
        collisionController = wind.collision;
        collisionController.colliderForce = windForce;
    }

    void Update()
    {
        MovetoMouse();

        if (Input.GetMouseButton(0))
        {
            emmissionController.rateOverTime = emissionRate;
        }
        else
        {
            emmissionController.rateOverTime = 0;

        }
    }

    void MovetoMouse()
    {
        Vector3 PosToMove = mainCam.ScreenToWorldPoint(Input.mousePosition);
        PosToMove.z = 0;
        transform.position = PosToMove;
    }
}
