using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject healthbar;
    //List<GameObject> enemies;

    health playerhealth_Script;

    // Start is called before the first frame update
    void Start()
    {
        playerhealth_Script = healthbar.GetComponent<health>();

        //foreach (Transform child in transform)
          //  enemies.Add(child.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == player)
        {
            playerhealth_Script.takeDamage(100);
            
        }
    }
}
