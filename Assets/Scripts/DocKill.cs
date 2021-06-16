using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocKill : MonoBehaviour
{
    private AudioSource killSound;
    public bool alreadyPlayed = false;
    [SerializeField]
    private AudioClip clip;
    Animator anim;
    private float timer;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        killSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {  
        bool isDead = anim.GetBool("isDead");
        if(isDead)
        { timer += Time.deltaTime ;
            if(!alreadyPlayed)
            {if(timer>=0.4f)
                {
                    killSound.PlayOneShot(clip);
                    alreadyPlayed = true;
                }
                
            }
            
            
        }
    }
}
