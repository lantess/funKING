using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject border;
    public GameObject _prefab;
    public GameObject ammoBar;
    public static float BPM = 125.0f;
    public float bitsPerArrow = 4.0f;
    public Sprite[] arrowSprites;
    public float Timing { get => BPM / 60.0f / bitsPerArrow; }
    private float deltaTime = 0.0f;
    private Queue<GameObject> arrows_right,
                                arrows_left;
    private KeyCode[] keys;

    private int minS = 10,
                maxS = 20;
    private float[] bpa = { 2.0f, 4.0f, 2.0f, 4.0f, 2.0f, 4.0f , 2.0f, 4.0f , 2.0f, 4.0f , 6.0f};
    private float bpaDelta = 0.0f;

    private Shake shake;

    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        arrows_right = new Queue<GameObject>();
        arrows_left = new Queue<GameObject>();
        keys = new KeyCode[] { KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow };

        bitsPerArrow = bpa[Random.Range(0, bpa.Length)];
        bpaDelta += Random.Range(minS, maxS);
    }

    // Update is called once per frame
    void Update()
    {
        createNewArrow();
        removeMissed();
        listenKeys();
        updateBPA();
    }

    private void createNewArrow()
    {
        if (deltaTime < Timing)
            deltaTime += Time.deltaTime;
        else
        {
            deltaTime = 0.0f;
            int r = Random.Range(0, 4);
            _prefab.GetComponent<SpriteRenderer>().sprite = arrowSprites[r];
            arrows_right.Enqueue(Instantiate(_prefab, new Vector3(8.0f, 6.0f, 0.0f), Quaternion.identity));
            arrows_left.Enqueue(Instantiate(_prefab, new Vector3(-8.0f, 6.0f, 0.0f), Quaternion.identity));
        }
    }

    private void removeMissed()
    {
        if (arrows_right.Count > 0)
        {
            if (arrows_right.Peek().transform.position.y < border.transform.position.y - border.transform.localScale.y/4)
            {
                GameObject.Destroy(arrows_right.Dequeue());
                GameObject.Destroy(arrows_left.Dequeue());
            }
        }
    }

    private void listenKeys()
    {
        for(int i = 0; i <keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]))
            {
                if(arrows_right.Count > 0)
                {
                    if (arrows_right.Peek().transform.position.y < arrows_right.Peek().transform.localScale.y) //pls work
                    {
                        GameObject arr = arrows_right.Dequeue();
                        if (compare(arr, i))
                        {
                            float prec = Mathf.Abs(border.transform.position.y - arr.transform.position.y);
                            if (prec < 1.0f)
                            {
                                PointCounter.Add((int)(20 * (1.0f - prec)));
                                while (PointCounter.HasAmmoToAdd())
                                    ammoBar.GetComponent<AmmoBarController>().Add();
                                PointCounter.isCorrect = true;
                            }
                            else
                            {
                                PointCounter.isCorrect = false;
                                shake.CamShake();
                            }
                        }
                        else
                        {
                            PointCounter.isCorrect = false;
                            shake.CamShake();
                        }
                        GameObject.Destroy(arr);
                        GameObject.Destroy(arrows_left.Dequeue());
                        PointCounter.isHit = true;
                    }
                    else
                    {
                        PointCounter.isHit = false;
                    }
                }
            }
        }
    }

    private bool compare(GameObject arr, int key)
    {
        return arr.GetComponent<SpriteRenderer>().sprite == arrowSprites[key];
    }

    private void updateBPA()
    {
        if (bpaDelta > 0.0)
            bpaDelta -= Time.deltaTime;
        else
        {
            bitsPerArrow = bpa[Random.Range(0, bpa.Length)];
            bpaDelta += Random.Range(minS, maxS);
        }
    }
}
