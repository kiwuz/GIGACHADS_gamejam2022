using UnityEngine;

public class Laser : MonoBehaviour
{
    private int maxBounces = 5;
    public LineRenderer lr;
    [SerializeField] private Transform startPoint;
    [SerializeField] private bool reflectOnlyMirror;
    public bool startLaser;



    private void Start() {
        //lr = GetComponent<LineRenderer>();
        //lr.SetPosition(0, startPoint.position);
        startLaser = false;

    }

    private void Update() {

        if(startLaser){
            lr.enabled = true;
            CastLaser(transform.position, -transform.forward);
        } 

        if(!startLaser) lr.enabled = false;
    }

    private void CastLaser(Vector3 position, Vector3 direction){
        lr.SetPosition(0, startPoint.position);

        for(int i=0; i< maxBounces; i++){
            Ray ray = new Ray(position, direction);
            RaycastHit hit;


            if(Physics.Raycast(ray, out hit, 5000, 1)){
                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                lr.SetPosition(i+1, hit.point);

                if(hit.transform.name != "Mirror" && reflectOnlyMirror)
                {
                    for(int j=(i+1); j<=5;j++){
                        lr.SetPosition(j, hit.point);
                    }
                    break;
                }
                }
            }
    }
   
}