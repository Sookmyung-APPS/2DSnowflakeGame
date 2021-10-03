using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poop : MonoBehaviour
{
    public AudioClip clip;
    [SerializeField]
    private Animator animator;
    private Rigidbody2D rigidbody;
    //public static SoundManager instance;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.SFXPlay("poop", clip);
        if (collision.gameObject.tag == "Ground")
        {
            GameManager.Instance.Score();
            animator.SetTrigger("poop");
            
        }

        if(collision.gameObject.tag == "Player")
        {
            
            GameManager.Instance.GameOver();
            animator.SetTrigger("poop");
        }
        //SoundManager.instance.SFXPlay("poop", clip);
    }
}
