
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScene : MonoBehaviour
{
    private float lenght;
    private float startPos;

    private Transform cam;

    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
<<<<<<< HEAD
        cam = Camera.main.transform;
=======
        //cam = Camera.main.transform.;
>>>>>>> 4e4e0e7736c8ccb4bc73f6159e23d0211421e86d
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = cam.transform.position.x * parallaxEffect;
    }

}
