using UnityEngine;
using Photon.Pun;

public class SelfDestroyer : MonoBehaviour {

    public GameObject startGate;
    public GameObject speedrunTimer;
    public float timer = 0f;
    public float destroyTimer = 3f;
    public string particle;
    public bool spawnsParticle, startsTimer;

    public void Update()
    {

        timer += Time.deltaTime;
        if (timer >= destroyTimer)
        {

            DestroyObject();


        }
        else if (timer >= destroyTimer && startsTimer)
        {

            DestroyObject();
            speedrunTimer.SetActive(true);
        }

    }

    public void DestroyObject() {
        if (!spawnsParticle) {
           
            Destroy(gameObject);
        
        } else {

            Destroy(gameObject);
            Instantiate(Resources.Load(particle), transform.position, Quaternion.identity);

        }
    }

}
