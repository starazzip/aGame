using UnityEngine;
using System.Collections;

public class MouseClickMove : MonoBehaviour
{

    [SerializeField] private GameObject model;
    [SerializeField] private float speed = 1;
    private bool moveState = false;
    private Vector3 target = new Vector3();


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.gameObject.tag == "floor")
            {
                moveState = true;
                target = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
        float step = speed * Time.deltaTime;
        if (moveState)
        {
            if (Vector3.Distance(model.transform.position, target) < 0.01f)
            {
                moveState = false;
            }
            model.transform.position = Vector3.MoveTowards(model.transform.position, target, step);
        }
    }
}