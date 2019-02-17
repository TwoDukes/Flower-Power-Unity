using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour {

    public int initialBombCount;
    private int bombCount;

    [SerializeField]
    Camera mainCam;

    [SerializeField]
    private GameObject bomb;

    private void Start()
    {
        bombCount = initialBombCount;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 posToSpawn = Input.mousePosition;
            posToSpawn = mainCam.ScreenToWorldPoint(posToSpawn);
            posToSpawn.z = 0;
            Instantiate(bomb, posToSpawn, Quaternion.identity, null);
        }
    }
}
