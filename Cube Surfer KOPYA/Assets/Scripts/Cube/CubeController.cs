using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
public class CubeController : MonoBehaviour
{
    private  Rigidbody _rg;
    private  PlayerController _playerKontrol;
    private float _timer;
    private GameObject _targatCube;
    private bool _lavÜzerinde;
    private int _obstacleNumber;

    private void Start()
    {
        _rg = GetComponent<Rigidbody>();
        _playerKontrol = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        _playerKontrol.PlayerKüpleri.Add(gameObject);
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("engel"))
        {
            if (_obstacleNumber < 1)
            {
                EngelProtokolü(col.gameObject);
                _obstacleNumber++;
            }
        }
        if(col.gameObject.CompareTag("yeni küp"))
        {
            Destroy(col.gameObject);
            _playerKontrol.AddCube();
            Vibration.Vibrate(40);
        }
        if (col.gameObject.CompareTag("lav"))
        {
            _targatCube = col.gameObject;
            _lavÜzerinde = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("lav"))
        {
            _lavÜzerinde = false;
            _timer = 0;
        }
    }

    void EngelProtokolü(GameObject obje)
    {
        _playerKontrol.PlayerKüpleri.Remove(gameObject);
        _rg.constraints = RigidbodyConstraints.None;
        transform.parent = obje.transform.parent;
        Destroy(gameObject, 4f);
    }
    void LavProtokolü(GameObject obje)
    {
        _playerKontrol.PlayerKüpleri.Remove(gameObject);
        _rg.constraints = RigidbodyConstraints.FreezeRotation;
        transform.parent = null;
        transform.parent = obje.transform;
        Vibration.Vibrate(30);
        Destroy(gameObject);
    }
    private void Update()
    {
        if (_lavÜzerinde)
        {
            _timer += Time.deltaTime;
            if (_timer >= 0.3f)
            {
                LavProtokolü(_targatCube);
                _timer = 0;
            }
        }
    }
}
