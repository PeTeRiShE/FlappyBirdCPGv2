using UnityEngine;
using System.Collections;
using System.IO;

public class TwitterShareController : MonoBehaviour
{
    private string ShareMessage;
	public void ClickShareButton()
    {
		ShareMessage = "CPG TEST SCORE RESULT: " + ScoreController.GetInstance.Score;
		StartCoroutine(TakeScreenshotAndShare());
    }

	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "CPGtestImage.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		
		Destroy(ss);

		new NativeShare().AddFile(filePath)
			.SetSubject("CPGTEST").SetText(ShareMessage).SetUrl("https://Facebook.pl")
			.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			.Share();

		
	}


}