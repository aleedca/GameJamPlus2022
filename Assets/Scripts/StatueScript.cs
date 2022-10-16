using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueScript : MonoBehaviour
{
    public GameObject target;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = target.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("fadeout", true);
    }
}
