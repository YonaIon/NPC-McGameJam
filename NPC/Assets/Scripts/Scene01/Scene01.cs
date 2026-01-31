using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Scene01 : MonoBehaviour
{
        //need to control the blinkers
        public GameObject BlinkTop;
        public GameObject BlinkBottom;
        public GameObject Blackscreen;


        //run once at start
        void Start()
        {
            StartCoroutine(EventStart());
        }

        IEnumerator EventStart()
        {
                yield return new WaitForSeconds(2);
                BlinkTop.SetActive(false);
                BlinkBottom.SetActive(false);
                Blackscreen.SetActive(true);

        }

        //run constantly
        void Update()
        {
            
        }
    
}
