using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTrigger : MonoBehaviour {
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
