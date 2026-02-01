using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
public class FlyOpen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void LoadFlyScene()
        {
            Debug.Log("Button Pressed");
            SceneManager.LoadScene("FlyOpen");
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
