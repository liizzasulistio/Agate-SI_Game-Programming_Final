using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedSquare : MonoBehaviour
{
    [SerializeField] private GameObject redSquare;
    [SerializeField] private float timeOnScreen;
    private float timer;
    public UnityAction<RedSquare> OnSquareDestroyed = delegate {};

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeOnScreen)
        {
            OnSquareDestroyed(this);
            redSquare.SetActive(false);
            timer = 0;
        }
    }
}
