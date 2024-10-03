using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperBullet : MonoBehaviour
{
    public float damage = 1;
    public GameObject beam;
    public Vector3 endPos;
    public LayerMask LM;
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 200, LM))
        {
            beam.transform.position = Vector3.Lerp(transform.position, hit.point, 0.5f);
            beam.transform.rotation = Quaternion.LookRotation(transform.position - hit.point);
            beam.transform.localScale = new Vector3(beam.transform.localScale.x, beam.transform.localScale.y, Vector3.Distance(transform.position, hit.point));

            if (hit.transform.GetComponent<EnemyHealth>() != null)
            {
                hit.transform.GetComponent<EnemyHealth>().EnemyHurt(damage);
            }
        } else
        {
            beam.transform.position = Vector3.Lerp(transform.position, (transform.position + transform.forward * 100f), 0.5f);
            beam.transform.rotation = Quaternion.LookRotation(transform.position - (transform.position + transform.forward * 100f));
            beam.transform.localScale = new Vector3(beam.transform.localScale.x, beam.transform.localScale.y, Vector3.Distance(transform.position, (transform.position + transform.forward * 100f)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        beam.transform.localScale = Vector3.Lerp(beam.transform.localScale, new Vector3(0,0, beam.transform.localScale.z),5 * Time.deltaTime);
    }
    public void die()
    {
        Destroy(gameObject);
    }
}
