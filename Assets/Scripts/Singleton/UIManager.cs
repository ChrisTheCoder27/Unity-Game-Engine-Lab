using TMPro;
using UnityEngine;

namespace Chapter.Singleton
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] TextMeshProUGUI firewoodText;
        [SerializeField] GameObject confirmationText;
        bool canFinishLevel;

        void Awake()
        {
            firewoodText.text = "Firewood collected: 0";
            confirmationText.SetActive(false);
            canFinishLevel = false;
        }

        public bool GetFinishLevel()
        {
            return canFinishLevel;
        }

        public void UpdateFirewoodText(int total)
        {
            firewoodText.text = $"Firewood collected: {total}";
        }

        public void RevealConfirmText()
        {
            confirmationText?.SetActive(true);
            canFinishLevel = true;
        }

        public void QuitGame()
        {
            Debug.Log("Quitting.");
            Application.Quit();
        }
    }
}
