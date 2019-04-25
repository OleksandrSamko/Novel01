using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//SceneLoader has reference to loadingScreenPrefab
//Call LoadingAsyncScene(level,<use animation>) to load scene
//SceneLoader find Canvas and there instantiate loadingScreenPrefab to show users predefined screen
//Can be called in any scenes

public class SceneLoader : MonoBehaviour {

    public static SceneLoader Instance;
    [SerializeField]
    private GameObject loadingScreenPrefab;
    private GameObject loadingPanel;
    private Image animationImage;
    private float animationSpeed = 1.0f;	

	private AsyncOperation async;	
    private GameObject canvas;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        if (Instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    #region SceneLoading

    public void LoadingSceneAsync(string levelName, bool animate = true)
	{
        ScenePreload(animate);  
        StartCoroutine(LoadLevel(levelName));   
    }

    public void LoadingSceneAsync(int level, bool animate = true)
    {
        ScenePreload(animate);
        StartCoroutine(LoadLevel(level));	
    }

    public void ScenePreload(bool animate = true)
    {
        ConfigureLoadingPanel();
        ConfigureAnimation(animate);
        loadingPanel.SetActive(true);
    }

    public void ScenePreloadDisable()
    {
        if (loadingPanel != null)
        {
            Destroy(loadingPanel);
        }
    }

    //fullscreen loading background
    void SetPositionLoadingPanel()
    {
        RectTransform rt = loadingPanel.GetComponent<RectTransform>();
    }

    void ConfigureLoadingPanel()
    {
        canvas = FindObjectOfType<Canvas>().gameObject;
        loadingPanel = Instantiate(loadingScreenPrefab, canvas.transform);
        SetPositionLoadingPanel();
    }

    IEnumerator LoadLevel(int level)
	{
		async = SceneManager.LoadSceneAsync(level);

		while (!async.isDone)
			yield return null;
	}

	IEnumerator LoadLevel(string levelName)
	{
		async = SceneManager.LoadSceneAsync(levelName);

		while (!async.isDone)
			yield return null;
	}

    #endregion

    #region Animation

    void ConfigureAnimation(bool animate = true)
    {
        animationImage = loadingPanel.transform.Find("AnimationImage").GetComponent<Image>();
        ChangeAnimationSpeed(animationSpeed);
        animationImage.gameObject.SetActive(animate);
    }
    
    public void ChangeAnimationSpeed(float speed = 1.0f)
    {
		animationImage.GetComponent<Animator>().speed = speed;
	}
	#endregion

}