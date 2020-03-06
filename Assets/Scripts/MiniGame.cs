using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGame : MonoBehaviour
{

        int generateNumber(int left, int right)
        {
                return Random.Range(left, right);
        }

        public Button button1, button2, button3, button4, submit;
        public Text firstNumber, secondNumber;
        private int sum;
        public GameObject door;
        private Canvas canvas;
        

        void Start()
        {
                canvas = GetComponent<Canvas>();
                submit.onClick.AddListener(Sumbit);
                button1.onClick.AddListener(() => ChangeCharacter(button1));
                button2.onClick.AddListener(() => ChangeCharacter(button2));
                button3.onClick.AddListener(() => ChangeCharacter(button3));
                button4.onClick.AddListener(() => ChangeCharacter(button4));
                RenderGame();        	
        }

        void ChangeText(Text textObject, string value)
        {
                textObject.text = value;
        }

        public Text GetButtonText(Button button)
        {
                return button.GetComponentInChildren<Text>();
        }

        public void ChangeCharacter(Button button)
        {
                List<string> alphavite = new List<string>(){ "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "V", "E", "L" };
                Text buttonText = GetButtonText(button);
                int nextElementIndex = (alphavite.IndexOf(buttonText.text) + 1) % alphavite.Count;
                ChangeText(buttonText, alphavite[nextElementIndex]);
        }

        void Avel()
        {
                //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                Player.isAvel = true;
        }

        void RenderGame()
        {
                int firstInteger = generateNumber(1000, 8999);
                int secondInteger = generateNumber(1000, 8999 - firstInteger);
                sum = firstInteger + secondInteger;
                ChangeText(firstNumber, firstInteger.ToString());
                ChangeText(secondNumber, secondInteger.ToString());
        }

        public string GetButtonChars()
        {
                string result = "";
                result += GetButtonText(button1).text;
                result += GetButtonText(button2).text;
                result += GetButtonText(button3).text;
                result += GetButtonText(button4).text;
                return result;
        }

       

        public void Sumbit()
        {
                string buttonsText = GetButtonChars();
                if (buttonsText == sum.ToString() == true)
                {
                        door.GetComponent<DoorMovement>().doorIsOpen = true;
                        canvas.enabled = false;
                }
                if (buttonsText == "AVEL")
                {
                        Avel();
                }
        }
}
