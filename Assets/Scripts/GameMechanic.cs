using UnityEngine;
using UnityEngine.UI;

public class GameMechanic : MonoBehaviour
{
        public static bool PlayerWin;

        [SerializeField] private Text textScore;
        [SerializeField] private GameGUI gameGUI;
        [SerializeField] private GameObject panel;
        public static int DestroyedEnemy;
        private Text createdText;

            private void Start()
        {
                PlayerWin = false;
                SetScore();
                createdText = Instantiate(textScore, panel.transform);
                DestroyedEnemy = 0;
        }

        public void SetScore()
        {
            if (createdText != null)
            {
                createdText.text = $"Score: {DestroyedEnemy}";
            }
        }

        private void Update()
        {
            if (DestroyedEnemy == MobsSpawn.AliveTanks)
            {
                PlayerWin = true;
                gameGUI.DisplayEndGame();
            }

            if (PlayerTank.isAlive == false)
            {
                gameGUI.DisplayEndGame();
                PlayerTank.isAlive = true;
            }
            SetScore();
            
        }
}