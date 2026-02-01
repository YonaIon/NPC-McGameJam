using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Introduction : MonoBehaviour
{
        //need to control the blinkers
        public GameObject Blurred;
        public GameObject BlinkIntroTop;
        public GameObject BlinkIntroBottom;


        //run once at start
        void Start()
        {
            StartCoroutine(EventStart());
        }

        IEnumerator EventStart()
        {
                yield return new WaitForSeconds(2);
                Blurred.SetActive(true);
                BlinkIntroTop.SetActive(true);
                BlinkIntroBottom.SetActive(true);
        }

        //run constantly
        void Update()
        {
            
        }
    
}