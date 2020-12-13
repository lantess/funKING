using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public int MaxHitPoints = 5;
    public GameObject canvas;
    private int hitPoints;

    private Animator animator;
    private Shake shake;


    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        animator = GetComponent<Animator>();
        hitPoints = MaxHitPoints;
        animator.SetInteger("Character", PlayerPrefs.GetInt("SelectedCharacter"));
        // animator.SetInteger("Character", 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        animator.SetBool("Up", Input.GetKeyDown(KeyCode.UpArrow) && PointCounter.isHit && PointCounter.isCorrect);
        animator.SetBool("Down", Input.GetKeyDown(KeyCode.DownArrow) && PointCounter.isHit && PointCounter.isCorrect);
        animator.SetBool("Left", Input.GetKeyDown(KeyCode.LeftArrow) && PointCounter.isHit && PointCounter.isCorrect);
        animator.SetBool("Right", Input.GetKeyDown(KeyCode.RightArrow) && PointCounter.isHit && PointCounter.isCorrect);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Drone")
        {
            shake.CamShake();
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
