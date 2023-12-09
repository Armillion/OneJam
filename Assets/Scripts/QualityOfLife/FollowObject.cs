using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    protected Transform target;
    //offset is taken from object position at start
    protected Vector3 offset;

	private void Start()
	{
        offset = transform.position;
	}

	// Update is called once per frame
	void Update()
    {
        transform.position = target.position + offset;
    }
}
