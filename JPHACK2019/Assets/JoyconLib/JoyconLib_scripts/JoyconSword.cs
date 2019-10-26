using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconSword : MonoBehaviour {
    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues (typeof (Joycon.Button)) as Joycon.Button[];

    // joyconが格納されているリスト
    private List<Joycon> m_joycons;
    // joycon
    private Joycon m_joyconL;
    private Joycon m_joyconR;
    // joyconのボタン取得
    private Joycon.Button? m_pressedButtonL;
    private Joycon.Button? m_pressedButtonR;

    private Rigidbody rigidbody;

    private void GetJoyconInput () {

    }

    // Start is called before the first frame update
    void Start () {
        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joyconL = m_joycons.Find (c => c.isLeft);
        m_joyconR = m_joycons.Find (c => !c.isLeft);

        rigidbody = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void FixedUpdate () {
        Vector3 accel = m_joyconL.GetAccel ();
        Vector3 gyro = m_joyconL.GetGyro ();
        Quaternion orientation = m_joyconL.GetVector ();
        Vector3 euler = orientation.eulerAngles;
        orientation = new Quaternion (orientation.y, -orientation.z, -orientation.x, orientation.w);
        Debug.Log ("acc:" + accel + " gyro:" + gyro + " ori:" + euler);
        transform.rotation = orientation;

        
        //rigidbody.AddTorque (gyro);
    }
}