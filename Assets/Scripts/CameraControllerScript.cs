    using System;
    using UnityEngine;
    using System.Collections;
     
    public class CameraControllerScript : MonoBehaviour
    {


        [SerializeField] private Rigidbody2D rb;
        private int zoomOutSpeed;

        private void Update()
        {
            zoomOutSpeed = 10;
            if (rb.velocity.x > zoomOutSpeed || rb.velocity.y > zoomOutSpeed ||
                rb.velocity.x < -zoomOutSpeed || rb.velocity.y < -zoomOutSpeed)
            {
                
            }
        }
        /*private Transform player;
        private Camera mainCamera;
     
        public Vector2 margin = new Vector2(1, 1); // If the player stays inside this margin, the camera won't move.
        public Vector2 smoothing = new Vector2(3, 3); // The bigger the value, the faster is the camera.
     
        public BoxCollider2D cameraBounds;
     
        private Vector3 min, max;
     
        public bool isFollowing;


        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            var position = player.position;
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }

        private void Start()
        {
            var bounds = cameraBounds.bounds;
            min = bounds.min;
            max = bounds.max;
            isFollowing = true;
            mainCamera = GetComponent<Camera>();
     

            mainCamera.backgroundColor = Color.black;
        }

        private void Update()
        {
            var position = transform.position;
            var x = position.x;
            var y = position.y;
     
            if (isFollowing)
            {
                if (Mathf.Abs(x - player.position.x) > margin.x)
                    x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime);
     
                if (Mathf.Abs(y - player.position.y) > margin.y)
                    y = Mathf.Lerp(y, player.position.y, smoothing.y * Time.deltaTime);
            }
     
            // ortographicSize is the haldf of the height of the Camera.
            var cameraHalfWidth = mainCamera.orthographicSize * ((float)Screen.width / Screen.height);
     
            x = Mathf.Clamp(x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
            y = Mathf.Clamp(y, min.y + mainCamera.orthographicSize, max.y - mainCamera.orthographicSize);
     
            transform.position = new Vector3(x, y, transform.position.z);
        }



        public void UpdateBounds()
        {
            var bounds = cameraBounds.bounds;
            min = bounds.min;
            max = bounds.max;
        }*/
    }

