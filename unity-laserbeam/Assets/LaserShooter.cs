using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    LaserBeam laserBeam;

    public Material material;



    void Update () {
        Destroy(GameObject.Find("laserObjects"));

        LaserBeam beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);//+
    }
}