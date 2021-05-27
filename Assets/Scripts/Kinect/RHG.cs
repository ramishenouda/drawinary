using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;
using System.Runtime.InteropServices;



public class RHG : MonoBehaviour
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;
    private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    private const int MOUSEEVENTF_RIGHTUP = 0x10;

    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    private Body[] bodies;
    private BodySourceManager bodyManager;
    public GameObject BodySrcManager;

    public JointType TrackedJoint;
    private KinectSensor _sensor = null;




    void Start()
    {

        _sensor = KinectSensor.GetDefault();

        if (_sensor != null)
        {
            _sensor.Open();
        }




        if (BodySrcManager == null)
            Debug.Log("Assign BodySrcManager");
        else
        {
            bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
        }
    }

    void Update()
    {
        if (bodyManager == null)
            return;

        bodies = bodyManager.GetData();

        if (bodies == null)
            return;

        foreach (var body in bodies)
        {
            if (body == null)
                continue;

            if (body.IsTracked)
            {

                var pos = body.Joints[JointType.HandRight].Position;
                CameraSpacePoint handRightPosition = pos;
                ColorSpacePoint handRightPoint = _sensor.CoordinateMapper.MapCameraPointToColorSpace(handRightPosition);

                float mapperX = handRightPoint.X;
                float mapperY = handRightPoint.Y;


                if (body.HandRightState == HandState.Closed) {
                    DoMouseClick();
                }
                

                if (body.HandRightState == HandState.Open)
                {
                    int xPos = (int)mapperX , yPos = (int)mapperY;
                    Debug.Log(xPos);
                    Debug.Log(yPos);
                    SetCursorPos(xPos, yPos);
                }

            }
        }


    }
    public static void DoMouseClick()
    {
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
    }
}
