using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CablePlacement : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    public GameObject middleObjectPrefab;
    public void SpawnObject()
    {
        Vector3 middlePosition = (object1.position + object2.position) / 2f;
        GameObject middleObject = Instantiate(middleObjectPrefab, middlePosition, Quaternion.identity);
        middleObject.transform.parent = transform;  // Optional: Set the new object as a child of some other GameObject or null
    }
}
