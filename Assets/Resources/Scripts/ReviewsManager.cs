using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Play.Review;

public class ReviewsManager : MonoBehaviour
{

    private ReviewManager reviewManager;
    private PlayReviewInfo playReviewInfo;
    private void Start()
    {
        var reviewManager = new ReviewManager();

        // start preloading the review prompt in the background
        var playReviewInfoAsyncOperation = reviewManager.RequestReviewFlow();

        // define a callback after the preloading is done
        playReviewInfoAsyncOperation.Completed += playReviewInfoAsync =>
        {
            if (playReviewInfoAsync.Error == ReviewErrorCode.NoError)
            {
                // display the review prompt
                var playReviewInfo = playReviewInfoAsync.GetResult();
                reviewManager.LaunchReviewFlow(playReviewInfo);
                Debug.Log("Erfolg");
            }
            else
            {
                Debug.Log("Fehler");
                // handle error when loading review prompt
            }
        };
    }


    public void showReview()
    {
        // StartCoroutine(RequestReviews());
    }

    // IEnumerator RequestReviews()
    // {
    //     _reviewManager = new ReviewManager();

    //     var requestFlowOperation = _reviewManager.RequestReviewFlow();
    //     yield return requestFlowOperation;
    //     if (requestFlowOperation.Error != ReviewErrorCode.NoError)
    //     {
    //         // Log error. For example, using requestFlowOperation.Error.ToString().
    //         yield break;
    //     }
    //     _playReviewInfo = requestFlowOperation.GetResult();

    //     var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
    //     yield return launchFlowOperation;
    //     _playReviewInfo = null; // Reset the object
    //     if (launchFlowOperation.Error != ReviewErrorCode.NoError)
    //     {
    //         // Log error. For example, using requestFlowOperation.Error.ToString().
    //         yield break;
    //     }
    // }
}
