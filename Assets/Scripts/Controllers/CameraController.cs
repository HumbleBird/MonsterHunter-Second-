using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

    [SerializeField]
    Transform _player = null;

    [SerializeField] float m_Speed;
    [SerializeField] float m_MaxRayDist = 1;
    [SerializeField] float m_Zoom = 3f;
    Vector2 m_Input;

    void Start()
    {
        GameObject go = Managers.Object.Find(1);
        _player = go.transform;
    }

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            if (Physics.Raycast(_player.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.position).magnitude * 0.8f;
                transform.position = _player.position + _delta.normalized * dist;
            }
            else
            {
                transform.position = _player.position + _delta;
                transform.LookAt(_player);
            }
        }

        Rotate();
    }

    public void SetQuarterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }

    void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            m_Input.x = Input.GetAxis("Mouse X");
            m_Input.y = Input.GetAxis("Mouse Y");

            if (m_Input.magnitude != 0)
            {
                Quaternion q = _player.rotation;
                q.eulerAngles = new Vector3(q.eulerAngles.x + m_Input.y * m_Speed, q.eulerAngles.y + m_Input.x * m_Speed, q.eulerAngles.z);
                _player.rotation = q;

            }
        }
    }

    void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Transform cam = Camera.main.transform;
            if (CheckRay(cam, scroll))
            {
                Vector3 targetDist = cam.transform.position - _player.transform.position;
                targetDist = Vector3.Normalize(targetDist);
                Camera.main.transform.position -= (targetDist * scroll * m_Zoom);
            }
        }

        Camera.main.transform.LookAt(_player.transform);
    }

    bool CheckRay(Transform cam, float scroll)
    {
        if (Physics.Raycast(cam.position, transform.forward, out RaycastHit m_Hit, m_MaxRayDist))
        {
            Debug.Log("hit point : " + m_Hit.point + ", distance : " + m_Hit.distance + ", name : " + m_Hit.collider.name);
            Debug.DrawRay(cam.position, transform.forward * m_Hit.distance, Color.red);
            cam.position += new Vector3(0, 0, m_Hit.point.z);
            return false;
        }

        return true;
    }
}
