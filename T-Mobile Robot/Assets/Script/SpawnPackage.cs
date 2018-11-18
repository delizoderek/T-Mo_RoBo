using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPackage : MonoBehaviour {

    public GameObject newBox;

    private Vector3 origin;
    private float spawnWait;
    private float startTime;

    private int   maxBoxes;
    private int count;
    private Queue<GameObject> boxes;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        origin = gameObject.transform.position;
        spawnWait = 1.0f;
        maxBoxes = 10;
        boxes = new Queue<GameObject>();
	}
	
    
	// Update is called once per frame
	void Update () {
        Debug.Log(boxes.Count);
        if (Time.time - startTime >= spawnWait) {
            if (boxes.Count < maxBoxes) {
                Vector3 objPos = new Vector3(origin.x, origin.y + (1 * boxes.Count), origin.z);
                Mail mailBox = newBox.GetComponent<Mail>();
                mailBox = RandomMail(mailBox);
                boxes.Enqueue(newBox);
                Debug.Log(boxes.Count);
                Instantiate(newBox, objPos, Quaternion.identity);
            }
            startTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            GameObject youGotMail = boxes.Dequeue();
            Mail box = youGotMail.GetComponent<Mail>();
            Debug.Log(box.ToString());

        }
	}
    

    public GameObject GetMail() {
        return boxes.Dequeue();
    }

    private Mail RandomMail(Mail noInfo) {
        Vector3 dim = new Vector3(Random.Range(0.3f, 1f), Random.Range(0.3f, 1f), Random.Range(0.3f, 1f));
        float weight = Random.Range(0.2f,150);
        int room = Random.Range(1, 20);
        int floor = Random.Range(1, 3);
        noInfo.SetInformation(floor,room,weight,dim);
        return noInfo;
    }
}
