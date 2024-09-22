using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Meteor : MonoBehaviour
{
    public AudioClip breakSound;

    public GameObject soundEffect;
    [SerializeField]
    public UnityEvent OnMeteorDestroyed;

    public ParticleSystem explode;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 2f);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D whatIHit)
    {

        
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            whatIHit.gameObject.SetActive(false);
            ExplodeEffect();
            Destroy(this.gameObject);
        } else if (whatIHit.tag == "Laser")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount++;
            OnMeteorDestroyed.Invoke();
            ExplodeEffect();
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }

    public virtual void ExplodeEffect()
    {
        GameManager.soundEffect.PlayOneShot(breakSound);
        var ex = Instantiate(explode, this.transform.position, Quaternion.identity);
        Destroy(ex.gameObject, 2f);
    }
}
