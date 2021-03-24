using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRolling : MonoBehaviour
{
    public static bool IsRollin;
    // Start is called before the first frame update
    public void roll()
    {
        IsRollin = true;
    }

    // Update is called once per frame
    public void RollEnd()
    {
        IsRollin = false;
        transform.Rotate(0, 0, 0);
    }
}
