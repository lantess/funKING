using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public int MaxHitPoints = 5;
    public GameObject canvas;
    private int hitPoints;
    

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = MaxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Drone")
        {
            hitPoints--;
            canvas.GetComponent<HitPointsController>().Remove();
        }
        if (hitPoints == 0)
        {
            //TODO: end game
            Time.timeScale = 0.0f;
            Debug.Log("Przegrałeś!");
        }
    }
}
