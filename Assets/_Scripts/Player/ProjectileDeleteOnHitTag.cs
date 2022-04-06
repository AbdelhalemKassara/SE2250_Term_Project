using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDeleteOnHitTag : MonoBehaviour
{
    public string tag;
    private bool _hit = false;

    private
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter(Collider other)
    {
        if (_hit)
            return;

        if (other.CompareTag(tag))
        {
            if (tag == "Enemy")
            {
                _hit = true;
                Debug.Log("Hit Enemy");
                Combat combat = other.GetComponent<Combat>();
                if (!combat)
                    return;
                combat.damageEnemy(5);
            }
        }
    }
}
