using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
public class Scene01: MonoBehaviour
{
        //need to control the blinkers
        public GameObject BlinkTop;
        public GameObject BlinkBottom;
        public GameObject WakeUpButton;
        public GameObject Title;

        //run once at start
        void Start()
        {
            StartCoroutine(EventStart());
        }

        public void LoadNextScene()
        {
            Debug.Log("Button Pressed");
            SceneManager.LoadScene("Introduction");
        }

        IEnumerator EventStart()
        {
                yield return new WaitForSeconds(2);
                BlinkTop.SetActive(true);
                BlinkBottom.SetActive(true);
                WakeUpButton.SetActive(true);
                Title.SetActive(true);
        }

        //run constantly
        void Update()
        {
            
        }
    
}
