using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Assets.ZigZag2D.Scripts
{
    public class UnityAD
    {
        private string playStoreId = "3741815";
        private string appStoreId = "3741814";
        private bool isTest = true;

        public void Initialize()
        {
            // true: test, false : service
            Advertisement.Initialize(this.playStoreId, this.isTest);
        }

        public void ShowAd()
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show("video");
            }
        }

        public void ShowRewardAd()
        {
            if (Advertisement.IsReady())
            {
                ShowOptions options = new ShowOptions { resultCallback = ResultedAds };
                Advertisement.Show("rewardedVideo", options);
            }
        }

        public void ResultedAds(ShowResult result)
        {
            switch (result)
            {
                case ShowResult.Failed:
                    Debug.LogError("광고 보기에 실패했습니다.");
                    break;
                case ShowResult.Skipped:
                    Debug.Log("광고를 스킵했습니다.");
                    break;
                case ShowResult.Finished:
                    // 광고 보기 보상 기능 
                    Debug.Log("광고 보기를 완료했습니다.");
                    break;
            }
        }
    }
}
