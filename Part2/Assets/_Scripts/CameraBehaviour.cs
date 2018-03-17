﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {


    //Camera will have different modes depending on what is happening
    public static CameraMode cameraMode = CameraMode.FollowPlayer; 


    public BoardManager BM;
    public Transform CameraDefaultPos;
    public float TiltedDownRotationX;   
    public float FollowPlayerXOffset;
    public float FollowPlayerYOffset;

    Vector3 TiltedDownRotation;
    Player currentPlayer;

    void Awake()
    {
        TiltedDownRotation = new Vector3(TiltedDownRotationX, 90, 0);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (!TurnManager.GameProperlyLoaded)
        {
            return;
        }
        switch (cameraMode)
        {
            case CameraMode.FollowPlayer:
                currentPlayer = BM.getCurrentPlayer();
                if (currentPlayer == null)
                {
                    Debug.LogError("Couldnt get a valid player, for camera to lookat");
                    return;
                }
                this.transform.position = new Vector3(currentPlayer.transform.position.x + FollowPlayerXOffset, currentPlayer.transform.position.y + FollowPlayerYOffset, currentPlayer.transform.position.z );
                this.transform.rotation = Quaternion.Euler(TiltedDownRotation);
                //rotation shouldnt change here/ this.transform.rotation = currentPlayer.transform.Find("CameraParkingLot").rotation;
                // this.transform.LookAt(currentPlayer.transform);
                break;
            case CameraMode.MapViewMode:
                this.transform.position = CameraDefaultPos.position;
                this.transform.rotation = CameraDefaultPos.rotation;
                break;
            case CameraMode.FollowStar:
                break;
            case CameraMode.ExploreMap:
                break;
            default:
                break;
        }
	}
}
