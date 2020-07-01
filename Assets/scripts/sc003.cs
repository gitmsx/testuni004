using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc003 : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    public float speed = 1.0f;
    public float rotationSpeed = 1.0f;



    public float TimeRewind;

    public KeyCode rewindButton;

    List<Vector3> positionList;
    bool IsRewind;
    void Start()
    {
        positionList = new List<Vector3>();

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame

    private void FixedUpdate()
    {

        TimeRewind = 7;
        while (positionList.Count >= TimeRewind * (1 / 0.02 ))
        {
            positionList.RemoveAt(0);
        }

        if (IsRewind)
        {
            int LastPosition = positionList.Count - 1;

            if (LastPosition+1 >0) 
            { 
            transform.position = positionList[LastPosition];
                positionList.RemoveAt(LastPosition);

            }
        }

        else
        {
            positionList.Add(transform.position);
            
        }

    }

    void Update()
    {


        float v1 = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float h1 = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime /10;

        if (Input.GetKeyDown(KeyCode.F))
        {
            IsRewind = true;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            IsRewind = false;
        }

        transform.Translate(new Vector3( h1, 0, v1));

        //rb.AddRelativeForce(rotation, 0f, translation);


    }
}
