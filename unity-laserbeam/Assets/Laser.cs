using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    Vector3 position;
    Vector3 direction;
    Material material;

    LineRenderer laser;
    public GameObject laserObjects;
    List<Vector3> liserIndices = new List<Vector3>(); 


    // Start is called before the first frame update
    public LaserBeam(Vector3 position, Vector3 direction, Material material) {
        this.laser = new LineRenderer();
        this.laserObjects = new GameObject();
        this.laserObjects.name = "laserObjects";

        this.position = position;
        this.direction = direction;
        this.material = material;

        this.laser = this.laserObjects.AddComponent(typeof(LineRenderer)) as LineRenderer;

        this.laser.material = material;
        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.startColor = Color.green;
        this.laser.endColor = Color.green;

        CastRay(position, direction, laser);
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer line) {
        liserIndices.Add(pos);

        Ray ray= new Ray(pos, dir);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 30, 1)) {
            CheckHit(hit, dir, line);
        } else {
            liserIndices.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }

    void UpdateLaser() {
        int count = 0;
        laser.positionCount = liserIndices.Count;

        foreach (Vector3 idx in liserIndices) {
            laser.SetPosition(count, idx);
            count++;
        }
    }

    void CheckHit (RaycastHit hit, Vector3 direction, LineRenderer line) {
        if (hit.collider.gameObject.tag == "Mirror") {
            Vector3 pos = hit.point;
            Vector3 dir = Vector3.Reflect(direction, hit.normal);

            CastRay(pos, dir, line);
        } else {
            liserIndices.Add(hit.point);
            UpdateLaser();  
        }
    }
}
