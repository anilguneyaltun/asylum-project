using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pstpstexit : MonoBehaviour
{public GameObject textTarget2;
    public float targetTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    // Update is called once per frame
    void Update()
    {
        targetTime += Time.deltaTime;

        if (targetTime >= 2.3f)
        {
            timerEnded();

        }
    }

    void timerEnded()
    {
        textTarget2.SetActive(false);
        gameObject.GetComponent<Pstpstexit>().enabled = false;
    }
}
