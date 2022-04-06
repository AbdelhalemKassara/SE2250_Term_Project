using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        LaunchProjectile(projectile, new Vector3(20, 0, -10), new Vector3(20, 0, 1));
    }

    // Update is called once per frame
    void Update() { }

    public static GameObject LaunchProjectile(
        GameObject prefab,
        Vector3 startPosition,
        Vector3 endPosition,
        float speed = 1
    )
    {
        Vector3 direction = (endPosition - startPosition);
        direction.Normalize();
        GameObject _projectile = (GameObject)Instantiate(
            prefab,
            startPosition,
            prefab.transform.rotation
        );
        Vector3 velocity = direction * speed;
        Rigidbody _rigidBody = _projectile.GetComponent<Rigidbody>();
        _rigidBody.velocity = velocity;

        if (CharacterSelection.isPlayerReady())
        {
            _projectile.transform.rotation = CharacterSelection.getPlayer().transform.rotation;
        }

        return _projectile;

        // _projectile


    }
}
