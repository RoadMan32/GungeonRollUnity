
using UnityEngine;

public class GoToGun : MonoBehaviour
{
    public Transform Gun;

    // Update is called once per frame
    void Update()
    {
        transform.position = Gun.position;
    }
}
