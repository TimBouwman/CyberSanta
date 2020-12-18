using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class present : MonoBehaviour
{
    [SerializeField] private GameObject goodParticles;
    [SerializeField] private GameObject badParticles;
    [SerializeField] private int goodHouseLayerNumber;
    [SerializeField] private int badHouseLayerNumber;

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.layer);
        if (collision.gameObject.layer == goodHouseLayerNumber)
        {
            Instantiate(goodParticles, collision.transform);
        }
        if (collision.gameObject.layer == badHouseLayerNumber)
        {
            Instantiate(badParticles, collision.transform);
        }
        Destroy(gameObject);
    }
}
