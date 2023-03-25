using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class star : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem particleSystem;
    public ProgressBar progressBar;

    void Start()
    {
        particleSystem.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            particleSystem.Play();
            animator.SetTrigger("star");
            Destroy(gameObject, 10f);

            progressBar.AddProgress();

        }
    }
}