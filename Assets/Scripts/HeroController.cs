using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public int MaxHitPoints = 5;
    public GameObject canvas;
    private int hitPoints;

    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hitPoints = MaxHitPoints;
        //animator.SetInteger("Character", PlayerPrefs.GetInt("SelectedCharacter"));
        animator.SetInteger("Character", 0);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Up", Input.GetKeyDown(KeyCode.UpArrow));
        animator.SetBool("Down", Input.GetKeyDown(KeyCode.DownArrow));
        animator.SetBool("Left", Input.GetKeyDown(KeyCode.LeftArrow));
        animator.SetBool("Right", Input.GetKeyDown(KeyCode.RightArrow));
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
