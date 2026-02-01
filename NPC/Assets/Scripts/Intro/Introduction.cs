using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Introduction : MonoBehaviour
{
        //need to control the blinkers
        public GameObject Blurred;

        //run once at start
        void Start()
        {
            StartCoroutine(EventStart());
        }

        IEnumerator EventStart()
        {
                yield return new WaitForSeconds(2);
                Blurred.SetActive(true);
        }

        //run constantly
        void Update()
        {
            
        }
    
}