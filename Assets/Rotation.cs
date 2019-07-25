using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public Vector3 RotationAmountLR;

    public Vector3 RotationAmountUD;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(RotationAmountLR * -1);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(RotationAmountLR);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(RotationAmountUD);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(RotationAmountUD * -1);
        }
    }
}