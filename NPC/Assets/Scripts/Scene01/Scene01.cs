using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Scene01 : MonoBehaviour
{
        //need to control the blinkers
        public GameObject BlinkTop;
        public GameObject BlinkBottom;
        public GameObject BlackScreen;

        //run once at start
        void Start()
        {
            StartCoroutine(EventStart());
        }

        IEnumerator EventStart()
        {
                yield return new WaitForSeconds(2);
                BlinkTop.SetActive(true);
                BlinkBottom.SetActive(true);
                BlackScreen.SetActive(false);
        }

        //run constantly
        void Update()
        {
            
        }
    
}
