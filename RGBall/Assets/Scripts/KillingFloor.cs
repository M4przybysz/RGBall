using System.Collections;
using UnityEngine;

public class KillingFloor : MonoBehaviour
{
    GameObject player;
    bool isPlayerOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOn = true;
            player.GetComponent<PlayerController>().Damage(1);
            StartCoroutine(nameof(DamagePlayer));
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOn = false;
        }
    }

    IEnumerator DamagePlayer()
    {
        yield return new WaitForSeconds(1);
        if (isPlayerOn)
        {
            player.GetComponent<PlayerController>().Damage(1);
            StartCoroutine(nameof(DamagePlayer));
        }
    }
}
