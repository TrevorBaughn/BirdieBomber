using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//comments section on following video helped a decent bit... though I ended up doing most of this myself
//due to the use case of keeping the camera still
//https://www.youtube.com/watch?v=zit45k6CUMk

public class Parallax : MonoBehaviour

{
    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffect;

    private float length;
    private float startPos;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }



    // Update is called once per frame
    void Update()
    {
        //push bg left
        float desiredXPos = transform.position.x - parallaxEffect * Time.deltaTime;

        //move
        transform.position = new Vector2(desiredXPos, transform.position.y);

        //teleport back
        if (startPos - (length * 2) >= transform.position.x)
        {
            transform.position = new Vector2(startPos, transform.position.y);
        }

    }

}