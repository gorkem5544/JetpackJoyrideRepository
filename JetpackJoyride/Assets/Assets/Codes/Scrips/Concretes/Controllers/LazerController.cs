using Concretes.Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LazerStateEnum
{
    Starting, Prepare, Launch
}
public class LazerController : LifeCycleController
{
    LazerStateEnum _lazerStateEnum = LazerStateEnum.Starting;

    [SerializeField] GameObject _top, _down, _center;
    [SerializeField] Transform _topTarget, _downTarget;

    float tirmer = 0;
    Collider2D _collider2D;

    public override void KillObject()
    {
        LazerPool.Instance.Set(this);
    }

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _center.gameObject.SetActive(false);
        _collider2D.enabled = false;


    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        switch (_lazerStateEnum)
        {
            case LazerStateEnum.Starting:

                //Vector2 extendNegative = new Vector2(-_center.GetComponent<Collider2D>().bounds.extents.x, _top.transform.position.y);
                _top.transform.position = Vector3.MoveTowards(_top.transform.position, _topTarget.position, 0.5f);

                //Vector2 extendPositive = new Vector2(_center.GetComponent<Collider2D>().bounds.extents.x, _down.transform.position.y);
                _down.transform.position = Vector3.MoveTowards(_down.transform.position, _downTarget.position, 0.5f);



                if (Vector2.Distance(_top.transform.position, _topTarget.position) < 0.5f && Vector2.Distance(_down.transform.position, _downTarget.position) < 0.5f)
                {
                    Debug.Log("Lazelerin Ortaya çıkması");

                    _lazerStateEnum = LazerStateEnum.Prepare;
                }



                break;
            case LazerStateEnum.Prepare:


                tirmer += Time.deltaTime;
                if (tirmer > 1.5f)
                {
                    _center.gameObject.SetActive(true);
                    _lazerStateEnum = LazerStateEnum.Launch;
                }


                Debug.Log("Hazırlanma");
                break;
            case LazerStateEnum.Launch:
                _collider2D.enabled = true;
                break;

        }
    }
}
