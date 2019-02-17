using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {

    public float secondsTillDestruction;

	void Awake () {
        StartCoroutine(DestroyAfterSec());
	}
	
    IEnumerator DestroyAfterSec()
    {
        yield return new WaitForSeconds(secondsTillDestruction);
        Destroy(gameObject);
    }
}
