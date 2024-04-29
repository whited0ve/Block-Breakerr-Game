using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class Paddle : MonoBehaviour
    {
        // Configuration parameters
        [SerializeField] float minX = 1f;
        [SerializeField] float maxX = 15f;
        [SerializeField] float screenWidthInUnits = 16f;

        // Cached references
        GameSession theGameSession;
        Ball theBall;

        // Initialization
        void Start()
        {
            // Find references to GameSession and Ball
            theGameSession = FindObjectOfType<GameSession>();
            if (theGameSession == null)
            {
                Debug.LogWarning("GameSession not found! Paddle functionality will be limited.");
            }

            theBall = FindObjectOfType<Ball>();
            if (theBall == null)
            {
                Debug.LogWarning("Ball not found! Paddle functionality will be limited.");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (theGameSession == null || theBall == null)
            {
                return; // Exit the Update method if references are not found
            }

            // Calculate paddle position
            Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
            paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
            transform.position = paddlePos;
        }

        private float GetXPos()
        {
            // Check if GameSession is in AutoPlay mode
            if (theGameSession != null && theGameSession.IsAutoPlayEnabled())
            {
                // Return ball's x position if AutoPlay is enabled
                return theBall.transform.position.x;
            }
            else
            {
                // Return mouse position if AutoPlay is disabled
                return Input.mousePosition.x / Screen.width * screenWidthInUnits;
            }
        }
    }
}

