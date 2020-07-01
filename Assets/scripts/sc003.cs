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
    public float TimeRewind;
    public Slider slider;

    

    
    List<Vector3> positionList;
    bool IsRewind = false;



    void Start()
    {
  
        positionList = new List<Vector3>();
        slider.maxValue = TimeRewind / Time.fixedDeltaTime;

    }
    private void Awake()
    {
       
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame

    private void FixedUpdate()
    {

        TimeRewind = 5;

   


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
           
            //if (rb.isKinematic == true)
            //{
            //    rb.isKinematic = false;
            //}

        }

        else
        {

            while (positionList.Count >= TimeRewind / Time.fixedDeltaTime)
            {
                positionList.RemoveAt(0);
            }
            positionList.Add(transform.position);
            slider.value = positionList.Count;
            rb.isKinematic = false;

        }
     

    }

    void Update()
    {


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
