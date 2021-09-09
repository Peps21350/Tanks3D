using System;
using System.Collections;
using UnityEngine;

public class GameMechanic : MonoBehaviour
{
        [SerializeField] private GameGUI gameGUI;
        public float currentTime = 0;
        public static bool PlayerWin = false;
        

        public IEnumerator Timer()
        {
                while (true)
                {
                        currentTime++;
                        
                        yield return new WaitForSeconds(1);
                }
                // ReSharper disable once IteratorNeverReturns
        }

        private void Start()
        {
                StartCoroutine(Timer());
        }
}