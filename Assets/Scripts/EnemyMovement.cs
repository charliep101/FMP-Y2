using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class EnemyMovement : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed;
    
    Animator animator;

    



    void Start()
    {
        animator = GetComponent<Animator>();
        current = 0;
    }

    void Update()
    {

        if (transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);

        }

        else
        {
            current = (current + 1) % points.Length;
        }



        var lookPos = points[current].position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);

      


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

            animator.SetTrigger("pDeath");
            speed = 0;
            StartCoroutine(WaitForSceneLoad());

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Enemy Hit");
            speed = 0;

            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;

            animator.SetTrigger("eDeath");

            
        }
    }
}

