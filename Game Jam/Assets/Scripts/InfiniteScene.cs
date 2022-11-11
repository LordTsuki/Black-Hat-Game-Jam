using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScene : MonoBehaviour
{
    public float speedScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentScene();
    }

    private void MovimentScene()
    {
        Vector2 displacement = new Vector2(Time.time * speedScene, 0);
        GetComponent<Renderer>().material.mainTextureOffset = displacement;
    }
}
