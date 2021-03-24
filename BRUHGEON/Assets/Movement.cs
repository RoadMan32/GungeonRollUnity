using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float Verti;
    float Horizont;
    public Rigidbody2D Rb;
    public GameObject[] sides;
    public Vector2 Direction;
    public bool DodgeRoll;
    public float DodgeSpeed;
    public float DodgeTime;
    // Start is called before the first frame update
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DodgeRoll)
        {
            Rb.AddForce(Direction * DodgeSpeed);
        }
        Horizont = Input.GetAxisRaw("Horizontal");
        Verti = Input.GetAxisRaw("Vertical");

        if (Horizont > 0 || Horizont < 0 || Verti < 0 || Verti > 0)
        {
            for (int i = 0; i < sides.Length; i++)
            {
                sides[i].GetComponent<Animator>().SetBool("Walking", true);
            }
        }
        else
        {
            for (int i = 0; i < sides.Length; i++)
            {
                sides[i].GetComponent<Animator>().SetBool("Walking", false);
            }
      
        }
        Direction = new Vector2(Horizont, Verti);
        if (Input.GetMouseButtonDown(1) && !IsRolling.IsRollin)
        {
            for (int i = 0; i < sides.Length; i++)
            {
                sides[i].GetComponent<Animator>().SetTrigger("Rollin");

                StartCoroutine(Roll());


            }
        }

    }
    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(Horizont, Verti);
    }
    IEnumerator Roll()
    {
        DodgeRoll = true;
        yield return new WaitForSeconds(DodgeTime);
        DodgeRoll = false;
    }
}
