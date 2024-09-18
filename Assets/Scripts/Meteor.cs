using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Meteor : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnMeteorDestroyed;
    
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

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        } else if (whatIHit.tag == "Laser")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount++;
            OnMeteorDestroyed.Invoke();
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
