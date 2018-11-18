using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : MonoBehaviour {

    private int floor;
    private int room;
    private float weight;
    private float deliverTime;

    // Use this for initialization
    void Start() {
        deliverTime = Time.timeSinceLevelLoad;
    }

    public void SetInformation(int floorNum, int roomNum, float wght, Vector3 dim) {
        floor = floorNum;
        room = roomNum;
        weight = wght;
        gameObject.transform.localScale = dim;
    }

    public int GetFloor() {
        return floor;
    }

    public int GetRoom() {
        return room;
    }

    public float GetWeight() {
        return weight;
    }

    public Vector3 GetDimensions() {
        return gameObject.transform.localScale;
    }

    public float GetSitTime() {

        return Time.timeSinceLevelLoad - deliverTime;
    }

    override
    public string ToString() {
        return "Floor: " + floor + " Room: " + room + " Weight: " + weight  + " Dimensions: " + gameObject.transform.localScale;
    }
}
