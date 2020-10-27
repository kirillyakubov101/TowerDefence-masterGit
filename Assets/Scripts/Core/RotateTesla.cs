﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTesla : MonoBehaviour
{
	[SerializeField] float RotationSpeed = 52f;
	[SerializeField] Transform target = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		target.RotateAround(transform.position, Vector3.up, RotationSpeed * Time.deltaTime);
	}
}
