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
    // 剣の基準位置
    private Vector3 swordNeutralPos;
    // 剣を振ったのか
    private bool isSwing　 = false;

    private Vector3 neutralRane;
    private Vector3 upRane;
    private Vector3 downRane;

    [SerializeField] private bool isLeft;

    private float yAxisConf = 5f;

    private void GetJoyconInput () {

    }

    // Start is called before the first frame update
    void Start () {
        // 初期位置を取得
        neutralRane = transform.position;
        swordNeutralPos = neutralRane;

        upRane = new Vector3 (neutralRane.x, neutralRane.y + yAxisConf, neutralRane.z);
        downRane = new Vector3 (neutralRane.x, neutralRane.y - yAxisConf, neutralRane.z);

        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joyconL = m_joycons.Find (c => c.isLeft);
        m_joyconR = m_joycons.Find (c => !c.isLeft);

        rigidbody = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void FixedUpdate () {
        // 傾き取得
        Quaternion orientation = m_joyconL.GetVector ();

        if (!isSwing) {
            SwordRotation ();
            SwordMove (orientation);

            ChangeReane ();
        }
        //RotationTest ();

        // アングルリセット
        if (m_joyconL.GetButtonUp (Joycon.Button.DPAD_DOWN)) {
            m_joyconL.ResetAngle ();
        }

        //rigidbody.AddForce (accel);
        //rigidbody.AddTorque (gyro);

    }

    private void RotationTest () {
        Vector3 gyro = m_joyconL.GetGyro ();
        Vector3 angle = transform.localEulerAngles;

        angle.x += gyro.y;
        angle.y += -gyro.z;
        angle.z += -gyro.x;
        transform.localEulerAngles = angle;

        // if (angle.y >= 60f && angle.y < 180f) {
        //     angle.y = 60f;
        // } else if (angle.y >= 180f && angle.y < 310f) {
        //     angle.y = 310f;
        // }

    }

    // ジョイコンの角度と剣の角度を同期
    private void SwordRotation () {
        Quaternion nowOrientation = m_joyconL.GetVector ();
        // 座標軸を変換
        nowOrientation = new Quaternion (nowOrientation.y, -nowOrientation.z, -nowOrientation.x, nowOrientation.w);

        Vector3 eulor = nowOrientation.eulerAngles;
        Vector3 fixEulor = new Vector3 (eulor.x, eulor.y + yAxisConf, eulor.z);
        if (yAxisConf >= 60) {
            yAxisConf = 0f;
        }
        if (fixEulor.y >= 60f && fixEulor.y < 180f) {
            fixEulor.y = 60f;
        } else if (fixEulor.y >= 180f && fixEulor.y < 310f) {
            fixEulor.y = 310f;
        }

        //Debug.Log ("ori:" + fixEulor);

        Quaternion t = Quaternion.Euler (fixEulor);
        transform.rotation = t;

    }

    // 剣戟を飛ばす
    private void SwordMove (Quaternion nowOrientation) {
        // 加速度取得
        Vector3 accel = m_joyconL.GetAccel ();
        //Vector3 accel = m_joyconL.GetGyro ();

        // 振っていたら振り終わるまで振れない
        if (accel.magnitude >= 3f) {
            //Debug.Log ("accel:" + accel + " dirct:" + accel.magnitude);
            // 座標軸を変換
            accel = new Vector3 (accel.z, accel.x, -accel.y);

            Vector3 slashingPower = -transform.forward * accel.magnitude * 2f;

            rigidbody.velocity = slashingPower;

            isSwing = true;
            Invoke ("ResetPosition", 0.5f);
        }
    }

    // 剣を初期位置に戻す
    private void ResetPosition () {
        rigidbody.isKinematic = true;

        transform.position = swordNeutralPos;

        rigidbody.isKinematic = false;
        isSwing = false;
    }

    private void VectorCalc () {
        // 加速度取得
        Vector3 accel = m_joyconL.GetAccel ();

        accel = m_joyconL.GetAccel ();

        // 加速度取得
        accel = m_joyconL.GetAccel ();
    }

    private void ChangeReane () {
        if (isLeft) {
            if (m_joyconL.GetButton (Joycon.Button.SL)) {
                transform.position = upRane;
                swordNeutralPos = upRane;
            } else if (m_joyconL.GetButton (Joycon.Button.SR)) {
                transform.position = downRane;
                swordNeutralPos = downRane;
            } else {
                transform.position = neutralRane;
                swordNeutralPos = neutralRane;
            }
        } else {   // 右手の時
            if (m_joyconL.GetButton (Joycon.Button.SR)) {
                transform.position = upRane;
                swordNeutralPos = upRane;
            } else if (m_joyconL.GetButton (Joycon.Button.SL)) {
                transform.position = downRane;
                swordNeutralPos = downRane;
            } else {
                transform.position = neutralRane;
                swordNeutralPos = neutralRane;
            }
        }
    }
}