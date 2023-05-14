using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleEnemy : MonoBehaviour
{

    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        animator.SetTrigger("pDeath");
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            StartCoroutine(WaitForSceneLoad());

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Enemy Hit");
            

            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;

            animator.SetTrigger("eDeath");


        }
    }
}
