using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using IllusionPlugin;
using UnityEngine;

namespace ThirdPersonCamControlPlugin
{
    public class Plugin : IPlugin
    {
        public float yaw = 0.0f;
        public float pitch = 0.0f;
        public int currentLevelId = 0;

        public string Name
        {
            get { return "Third Person Camera Controller Plugin"; }
        }
        public string Version
        {
            get { return "0.1"; }
        }

        public void OnApplicationQuit()
        {
        }

        public void OnApplicationStart()
        {
        }

        public void OnFixedUpdate()
        {
        }

        public void OnLevelWasInitialized(int level)
        {
            currentLevelId = level;
        }

        public void OnLevelWasLoaded(int level)
        {
        }

        public void OnUpdate()
        {
            if (currentLevelId == 1)
            {
                GameObject cam = GameObject.Find("camera spinner");

                if(cam)
                {

                    float sensitivityX = 50f;
                    float sensitivityY = 50f;
                    float moveSensitivity = 10f;

                    if (Input.GetKey(KeyCode.LeftShift))
                        moveSensitivity = 50f;
                    if (Input.GetKey(KeyCode.LeftControl))
                        moveSensitivity = 2f;

                    if (Input.GetMouseButton(0))
                        cam.transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y") * -sensitivityX * Time.deltaTime, Input.GetAxis("Mouse X") * sensitivityY * Time.deltaTime, 0);

                    if (Input.GetAxis("Mouse ScrollWheel") > 0)
                    {
                        cam.transform.position += cam.transform.forward * 50f * Time.deltaTime;
                    }

                    if (Input.GetAxis("Mouse ScrollWheel") < 0)
                    {
                        cam.transform.position -= cam.transform.forward * 50f * Time.deltaTime;
                    }

                    if (Input.GetKey(KeyCode.W))
                    {
                        cam.transform.position += cam.transform.forward * moveSensitivity * Time.deltaTime;
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        cam.transform.position -= cam.transform.forward * moveSensitivity * Time.deltaTime;
                    }

                    if (Input.GetKey(KeyCode.A))
                    {
                        cam.transform.position -= cam.transform.right * moveSensitivity * Time.deltaTime;
                    }

                    if (Input.GetKey(KeyCode.D))
                    {
                        cam.transform.position += cam.transform.right * moveSensitivity * Time.deltaTime;
                    }

                    if (Input.GetKey(KeyCode.Q))
                    {
                        cam.transform.position += cam.transform.up * moveSensitivity * Time.deltaTime;
                    }

                    if (Input.GetKey(KeyCode.E))
                    {
                        cam.transform.position -= cam.transform.up * moveSensitivity * Time.deltaTime;
                    }

                    MoveOverTime m = cam.GetComponent<MoveOverTime>();
                    SmoothLookatScript s = cam.GetComponent<SmoothLookatScript>();

                    if(m)
                        UnityEngine.Object.Destroy(m);
                    if(s)
                        UnityEngine.Object.Destroy(s);
                }
            }
        }
    }
}
