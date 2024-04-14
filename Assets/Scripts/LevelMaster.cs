using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour {

   // Variables referencing two edge colliders
   public EdgeCollider2D leftWall;
   public EdgeCollider2D rightWall;

   // Use this for initialization
   void Start () {

      Application.targetFrameRate = 30;
      // Get the width and height of the camera (in pixels)
      float screenW = Camera.main.pixelWidth;
      float screenH = Camera.main.pixelHeight;
      
      // Create an array consisting of two Vector2 objects
      Vector2[] edgePoints = new Vector2[2];
      
      // Convert screen coordinates point (0,0) to world coordinates
      Vector3 leftBottom  = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));      
      // Convert screen coordinates point (0,H) to world coordinates
      Vector3 leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, screenH, 0f));      
      
      // Set the two points in the array to screen left bottom
      // and screen left top points            
      edgePoints[0] = leftBottom;
      edgePoints[1] = leftTop;
      
      // Position the left wall edge collider
      // at the left edge of the camera
      leftWall.points = edgePoints;
      
      // Allocate a new array consisting of two Vector2 objects
      edgePoints = new Vector2[2];

      // Convert screen coordinates point (W,0) to world coordinates
      Vector3 rightBottom = Camera.main.ScreenToWorldPoint(new Vector3(screenW, 0f, 0f));      
      // Convert screen coordinates point (W,H) to world coordinates
      Vector3 rightTop = Camera.main.ScreenToWorldPoint(new Vector3(screenW, screenH, 0f));      
      
      // Set the two points in the array to screen right bottom
      // and screen right top points            
      edgePoints[0] = rightBottom;
      edgePoints[1] = rightTop;
      
      // Position the left wall edge collider
      // at the left edge of the camera
      rightWall.points = edgePoints;
   }

   void OnGUI() {
      GUI.color = Color.white;
      GUI.skin.label.alignment = TextAnchor.UpperLeft;
      GUI.skin.label.fontSize = 40;
      GUI.skin.label.fontStyle = FontStyle.Bold;
      GUI.Label(new Rect(20,20,500,100), "Score: " + GameMaster.playerScore);

      GUI.color = Color.red;
      GUI.skin.label.alignment = TextAnchor.UpperRight;
      GUI.skin.label.fontSize = 40;
      GUI.skin.label.fontStyle = FontStyle.Bold;
      GUI.Label(new Rect(Screen.width - 320,20,300,100), "Health: " + GameMaster.playerHealth);
   }
}