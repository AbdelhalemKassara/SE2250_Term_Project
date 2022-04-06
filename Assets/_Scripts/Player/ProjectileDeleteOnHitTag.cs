using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDeleteOnHitTag : MonoBehaviour
{
    public string tag;
    private bool _hit = false;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit object");
        if (_hit)
            return;

        if (other.CompareTag(tag))
        {
            if (tag == "Player")
            {
                _hit = true;
                Debug.Log("Hit player");
                PlayerStats.stats.DamagePlayer(2);
            }
        }
    }
}
