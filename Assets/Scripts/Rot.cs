using UnityEngine;
using System.Collections;

public class Rot : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Rotate(Vector3.one * Time.deltaTime * 100);
	}
}
