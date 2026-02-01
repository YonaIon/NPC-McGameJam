using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
        //need to control the blinkers
        public GameObject Blurred;
        public GameObject BlinkIntroTop;
        public GameObject BlinkIntroBottom;
        public GameObject Script;
        public GameObject Space;


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
                yield return new WaitForSeconds(7);
                Script.SetActive(true);
                yield return new WaitForSeconds(4);
                Space.SetActive(true);
        }

        //run constantly
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                {
                SceneManager.LoadScene("JournalChoice");
                }
        }
    
}