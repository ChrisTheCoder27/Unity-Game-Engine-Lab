using TMPro;
using UnityEngine;

namespace Chapter.Singleton
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] TextMeshProUGUI firewoodText;
        [SerializeField] GameObject confirmationText;
        [SerializeField] TextMeshProUGUI healthText;
        bool canFinishLevel;

        void Awake()
        {
            firewoodText.text = "Firewood collected: 0";
            confirmationText.SetActive(false);
            healthText.text = "Health: 100";
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

        public void UpdateHealthText(int health)
        {
            healthText.text = $"Health: {health}";
        }

        public void QuitGame()
        {
            Debug.Log("Quitting.");
            Application.Quit();
        }
    }
}
