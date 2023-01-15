using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LevelManager2 : MonoBehaviour
    {
        public string nextGridName;
        private string currentGridName;
        
        public List<GameObject> grids;
        
        public Animator fadeAnimator;
        private static readonly int FadeOut = Animator.StringToHash("FadeOut");

        private void Awake()
        {
            //dumb
            currentGridName = transform.parent.transform.parent.transform.parent.name;
            Debug.Log("asdf" + currentGridName);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            var gridToLoad = grids.FirstOrDefault(_ => _.name == nextGridName);
            var currentGrid = grids.FirstOrDefault(_ => _.name == currentGridName);

            
            if (currentGrid != null && gridToLoad != null) 
                currentGrid.SetActive(false);
            
            if (currentGrid != null && gridToLoad != null) 
                gridToLoad.SetActive(true);
        }
        
        public void LoadScene()
        {
            CrossSceneVariables.startedFromMenu = true;
            StartCoroutine(LoadLevel());
        }

        private IEnumerator LoadLevel()
        {
            fadeAnimator.SetTrigger(FadeOut);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("BaseArena");
        }
    }
}