using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc003 : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    public float speed = 1.0f;
    public float rotationSpeed = 1.0f;
    public KeyCode rewindButton;
    public float TimeRewind =7;
     public Slider slider;

    

    
    List<Vector3> positionList;
    bool IsRewind = false;



    void Start()
    {
        TimeRewind = 7;
        positionList = new List<Vector3>();
      //  slider.maxValue = TimeRewind / 0.02f;
         slider.maxValue = TimeRewind / Time.fixedDeltaTime;
        rb = GetComponent<Rigidbody>();

    }
    //private void Awake()
    //{
       
      
    //}
    // Update is called once per frame

    private void FixedUpdate()
    {
        TimeRewind = 7;

        if (IsRewind)
        {
            
            if (positionList.Count > 0)
            {
                int LastPosition = positionList.Count - 1;
                transform.position = positionList[LastPosition];
                positionList.RemoveAt(LastPosition);
                slider.value = positionList.Count;
                rb.isKinematic = true;

            }
        }

        else
        {

            if (positionList.Count >= TimeRewind / Time.fixedDeltaTime)
            {
                positionList.RemoveAt(0);
            }
            positionList.Add(transform.position);
           slider.value = positionList.Count+1;
          rb.isKinematic = false;

 //  rb.isKinematic = false;

        }
     

    }

    void Update()
    {
        TimeRewind = 7;

        float v1 = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float h1 = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime / 10;

        if (Input.GetKeyDown(KeyCode.F))
        {
            IsRewind = true;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            IsRewind = false;
        }
       
        transform.Translate(new Vector3(h1, 0, v1));
        
        //rb.AddRelativeForce(rotation, 0f, translation);


    }
}
